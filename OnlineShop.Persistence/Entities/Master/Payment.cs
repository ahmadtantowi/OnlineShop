using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Persistence.Entities.History;

namespace OnlineShop.Persistence.Entities.Master
{
    public class Payment : UniqueEntity
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public virtual ICollection<CheckoutPayment> CheckoutPayments { get; set; }
    }

    public class PaymentConf : UniqueEntityConf<Payment>
    {
        public override void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Ms" + nameof(Payment));
            
            builder.Property(p => p.Name)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(p => p.Number)
                .HasMaxLength(25)
                .IsRequired();

            base.Configure(builder);
        }
    }
}