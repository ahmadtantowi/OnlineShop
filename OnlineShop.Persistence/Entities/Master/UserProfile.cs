using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Persistence.Enum;

namespace OnlineShop.Persistence.Entities.Master
{
    public class UserProfile : UniqueEntity
    {
        public string IdUser { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gender? Gender { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<UserAddress> UserAddresses { get; set; }
    }

    public class UserProfileConf : UniqueEntityConf<UserProfile>
    {
        public override void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("Ms" + nameof(UserProfile));
            
            builder.Property(p => p.Email)
                .HasMaxLength(100);
            
            builder.Property(p => p.Phone)
                .HasMaxLength(16);

            builder.Property(p => p.Gender)
                .HasConversion<string>();

            builder.HasOne(x => x.User)
                .WithOne(x => x.UserProfile)
                .HasForeignKey<User>(fk => fk.IdUserProfile);

            base.Configure(builder);
        }
    }
}