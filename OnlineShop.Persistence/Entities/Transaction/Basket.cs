using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Persistence.Entities.Master;

namespace OnlineShop.Persistence.Entities.Transaction
{
    public class Basket : UniqueEntity
    {
        public string IdProduct { get; set; }
        public string IdUser { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }

    public class BasketConf : UniqueEntityConf<Basket>
    {
        public override void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.ToTable("Tr" + nameof(Basket));
            
            builder.Property(p => p.Quantity)
                .IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Baskets)
                .HasForeignKey(fk => fk.IdProduct);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Baskets)
                .HasForeignKey(fk => fk.IdUser);

            base.Configure(builder);
        }
    }
}