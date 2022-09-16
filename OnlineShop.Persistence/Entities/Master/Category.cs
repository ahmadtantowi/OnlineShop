using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShop.Persistence.Entities.Master
{
    public class Category : UniqueEntity
    {
        public string Name { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }

    public class CategoryConf : UniqueEntityConf<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Ms" + nameof(Category));
            
            builder.Property(p => p.Name)
                .HasMaxLength(25)
                .IsRequired();

            base.Configure(builder);
        }
    }
}