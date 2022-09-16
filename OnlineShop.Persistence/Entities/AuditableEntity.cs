using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShop.Persistence.Entities
{
    public abstract class AuditableEntity
    {
        public string UserIn { get; set; }
        public DateTime? DateIn { get; set; }
        public string UserUp { get; set; }
        public DateTime? DateUp { get; set; }
        public bool IsActive { get; set; }
    }

    public class AuditableEntityConf<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : AuditableEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasIndex(p => p.IsActive);

            builder.HasQueryFilter(p => p.IsActive);
        }
    }
}