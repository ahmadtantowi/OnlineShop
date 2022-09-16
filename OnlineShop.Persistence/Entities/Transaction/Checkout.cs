using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Persistence.Entities.History;
using OnlineShop.Persistence.Entities.Master;

namespace OnlineShop.Persistence.Entities.Transaction
{
    public class Checkout : UniqueEntity
    {
        public string IdCheckoutPayment { get; set; }
        public string IdCheckoutShipment { get; set; }
        public string IdUser { get; set; }

        public virtual CheckoutPayment CheckoutPayment { get; set; }
        public virtual CheckoutShipment CheckoutShipment { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CheckoutProduct> CheckoutProducts { get; set; }
    }

    public class CheckoutConf : UniqueEntityConf<Checkout>
    {
        public override void Configure(EntityTypeBuilder<Checkout> builder)
        {
            builder.ToTable("Tr" + nameof(Checkout));

            builder.HasOne(x => x.CheckoutPayment)
                .WithOne(x => x.Checkout)
                .HasForeignKey<CheckoutPayment>(fk => fk.IdCheckout);

            builder.HasOne(x => x.CheckoutShipment)
                .WithOne(x => x.Checkout)
                .HasForeignKey<CheckoutShipment>(fk => fk.IdShipment);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Checkouts)
                .HasForeignKey(fk => fk.IdUser);

            base.Configure(builder);
        }
    }
}