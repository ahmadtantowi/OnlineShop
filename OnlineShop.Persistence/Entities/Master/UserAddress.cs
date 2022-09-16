using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShop.Persistence.Entities.Master
{
    public class UserAddress : UniqueEntity
    {
        public string IdUserProfile { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsFavorit { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }

    public class UserAddressConf : UniqueEntityConf<UserAddress>
    {
        public override void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.ToTable("Ms" + nameof(UserAddress));

            builder.Property(p => p.Name)
                .HasMaxLength(25);

            builder.Property(p => p.Address)
                .HasMaxLength(256);

            builder.HasOne(x => x.UserProfile)
                .WithMany(x => x.UserAddresses)
                .HasForeignKey(fk => fk.IdUserProfile);

            base.Configure(builder);
        }
    }
}