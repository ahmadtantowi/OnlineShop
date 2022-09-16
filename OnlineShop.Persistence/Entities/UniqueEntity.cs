using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShop.Persistence.Entities
{
    public abstract class UniqueEntity : AuditableEntity
    {
        public string Id { get; set; }
    }

    public class UniqueEntityConf<TEntity> : AuditableEntityConf<TEntity>
        where TEntity : UniqueEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasMaxLength(36)
                .ValueGeneratedNever();

            base.Configure(builder);
        }
    }
}