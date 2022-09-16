using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace OnlineShop.Persistence.Migrator
{
    /// <summary>
    /// This class is created for support migrations using dotnet cli. dotnet ef migrations [args] [options]
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public abstract class DesignTimeDbContextFactory<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        /// <summary>
        /// Can be change due to requirement.
        /// </summary>
        private const string _connectionStringName = "DbConnection";
        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

        public TContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            basePath = Path.GetFullPath(Path.Combine(basePath, "OnlineShop", "OnlineShop.Client"));

            return Create(basePath: basePath, environmentName: "Development");
        }

        private TContext Create(string basePath, string environmentName)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
            var connectionString = configuration.GetConnectionString(_connectionStringName);

            return Create(connectionString);
        }

        private TContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException($"Connection string '{_connectionStringName}' is null or empty.", nameof(connectionString));

            var optionsBuilder = new DbContextOptionsBuilder<TContext>()
                .UseSqlite(connectionString);

            return CreateNewInstance(optionsBuilder.Options);
        }
    }
}
