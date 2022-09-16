using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShop.Persistence.Entities.Master
{
    public class ProductCategory : UniqueEntity
    {
        public string IdProduct { get; set; }
        public string IdCategory { get; set; }

        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }
    }

    public class ProductCategoryConf : UniqueEntityConf<ProductCategory>
    {
        public override void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("Ms" + nameof(ProductCategory));

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductCategories)
                .HasForeignKey(fk => fk.IdProduct);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.ProductCategories)
                .HasForeignKey(fk => fk.IdCategory);

            base.Configure(builder);
        }
    }
}