using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Persistence.Entities.Transaction;

namespace OnlineShop.Persistence.Entities.Master
{
    public class User : UniqueEntity
    {
        public string IdUserProfile { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual ICollection<Checkout> Checkouts { get; set; }
    }

    public class UserConf : UniqueEntityConf<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Ms" + nameof(User));

            builder.HasIndex(p => p.Username)
                .IsUnique();
            
            builder.Property(p => p.Username)
                .HasMaxLength(32)
                .IsRequired();
            
            builder.Property(p => p.Fullname)
                .HasMaxLength(100);

            builder.HasOne(x => x.UserProfile)
                .WithOne(x => x.User)
                .HasForeignKey<UserProfile>(fk => fk.IdUser);
            
            base.Configure(builder);
        }
    }
}