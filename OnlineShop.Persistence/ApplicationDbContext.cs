using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Persistence.Entities;
using OnlineShop.Persistence.Entities.History;
using OnlineShop.Persistence.Entities.Master;
using OnlineShop.Persistence.Entities.Transaction;

namespace OnlineShop.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {
            
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.UserIn ??= Guid.Empty.ToString();
                        entry.Entity.DateIn ??= DateTime.UtcNow;
                        entry.Entity.IsActive = true;
                        break;
                    
                    case EntityState.Modified:
                        entry.Entity.UserUp ??= Guid.Empty.ToString();
                        entry.Entity.DateUp ??= DateTime.UtcNow;
                        entry.Entity.IsActive = true;
                        break;

                    case EntityState.Deleted:
                        entry.Entity.UserUp ??= Guid.Empty.ToString();
                        entry.Entity.DateUp ??= DateTime.UtcNow;
                        entry.Entity.IsActive = false;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public virtual DbSet<CheckoutPayment> CheckoutPayment { get; set; }
        public virtual DbSet<CheckoutProduct> CheckoutProduct { get; set; }
        public virtual DbSet<CheckoutShipment> CheckoutShipment { get; set; }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<Shipment> Shipment { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAddress> UserAddress { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }

        public virtual DbSet<Basket> Basket { get; set; }
        public virtual DbSet<Checkout> Checkout { get; set; }
    }
}