using System;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Persistence;

namespace OnlineShop.Persistence.Migrator
{
    public class ApplicationDbContextFactory : DesignTimeDbContextFactory<ApplicationDbContext>
    {
        protected override ApplicationDbContext CreateNewInstance(DbContextOptions<ApplicationDbContext> options)
        {
            return new ApplicationDbContext(options);
        }
    }
}