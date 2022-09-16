using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Persistence.Entities.Master;
using OnlineShop.Persistence.Entities.Transaction;

namespace OnlineShop.Persistence.Entities.History
{
    public class CheckoutShipment : UniqueEntity
    {
        public string IdCheckout { get; set; }
        public string IdShipment { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public virtual Checkout Checkout { get; set; }
        public virtual Shipment Shipment { get; set; }
    }

    public class CheckoutShipmentConf : UniqueEntityConf<CheckoutShipment>
    {
        public override void Configure(EntityTypeBuilder<CheckoutShipment> builder)
        {
            builder.ToTable("Hs" + nameof(CheckoutShipment));

            builder.HasOne(x => x.Shipment)
                .WithMany(x => x.CheckoutShipments)
                .HasForeignKey(fk => fk.IdShipment);
            
            base.Configure(builder);
        }
    }
}