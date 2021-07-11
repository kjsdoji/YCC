using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using YCC.Data.Entities;

namespace YCC.Data.Configurations
{
    public class ProductReviewConfiguration : IEntityTypeConfiguration<ProductReview>
    {
        public void Configure(EntityTypeBuilder<ProductReview> builder)
        {
            builder.ToTable("ProductReviews");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Comments).HasMaxLength(500);
            builder.Property(x => x.PublishedDate);
            builder.HasOne(x => x.Products).WithMany(x => x.ProductReviews).HasForeignKey(x => x.ProductId);
        }
    }
}
