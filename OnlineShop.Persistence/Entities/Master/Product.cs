using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Persistence.Entities.History;
using OnlineShop.Persistence.Entities.Transaction;

namespace OnlineShop.Persistence.Entities.Master
{
    public class Product : UniqueEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual ICollection<CheckoutProduct> CheckoutProducts { get; set; }
    }

    public class ProductConf : UniqueEntityConf<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Ms" + nameof(Product));
            
            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(p => p.Description)
                .HasMaxLength(256);

            builder.Property(p => p.Price)
                .IsRequired();
            
            base.Configure(builder);
        }
    }
}