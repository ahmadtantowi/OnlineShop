using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Persistence.Entities.Master;
using OnlineShop.Persistence.Entities.Transaction;

namespace OnlineShop.Persistence.Entities.History
{
    public class CheckoutProduct : UniqueEntity
    {
        public string IdCheckout { get; set; }
        public string IdProduct { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public virtual Checkout Checkout { get; set; }
        public virtual Product Product { get; set; }
    }

    public class CheckoutProductConf : UniqueEntityConf<CheckoutProduct>
    {
        public override void Configure(EntityTypeBuilder<CheckoutProduct> builder)
        {
            builder.ToTable("Hs" + nameof(CheckoutProductConf));
            
            builder.HasOne(x => x.Checkout)
                .WithMany(x => x.CheckoutProducts)
                .HasForeignKey(fk => fk.IdCheckout);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.CheckoutProducts)
                .HasForeignKey(fk => fk.IdProduct);
            
            base.Configure(builder);
        }
    }
}