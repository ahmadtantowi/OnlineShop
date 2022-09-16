using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Persistence.Entities.Master;
using OnlineShop.Persistence.Entities.Transaction;

namespace OnlineShop.Persistence.Entities.History
{
    public class CheckoutPayment : UniqueEntity
    {
        public string IdCheckout { get; set; }
        public string IdPayment { get; set; }
        public string Provider { get; set; }
        public string Number { get; set; }

        public virtual Checkout Checkout { get; set; }
        public virtual Payment Payment { get; set; }
    }

    public class CheckoutPaymentConf : UniqueEntityConf<CheckoutPayment>
    {
        public override void Configure(EntityTypeBuilder<CheckoutPayment> builder)
        {
            builder.ToTable("Hs" + nameof(CheckoutPayment));

            builder.HasOne(x => x.Payment)
                .WithMany(x => x.CheckoutPayments)
                .HasForeignKey(fk => fk.IdPayment);
                
            base.Configure(builder);
        }
    }
}