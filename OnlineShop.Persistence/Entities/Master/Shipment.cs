using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Persistence.Entities.History;

namespace OnlineShop.Persistence.Entities.Master
{
    public class Shipment : UniqueEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<CheckoutShipment> CheckoutShipments { get; set; }
    }

    public class ShipmentConf : UniqueEntityConf<Shipment>
    {
        public override void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.ToTable("Ms" + nameof(Shipment));

            base.Configure(builder);
        }
    }
}