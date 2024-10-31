using EagleTask.Models.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EagleTask.Data.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(p => p.Id)
                .HasName("PK_ProductKey");

            builder
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(p => p.BrandId)
                .IsRequired();

            builder
                .Property(p => p.CategoryId)
                .IsRequired();

            builder
                .Property(p => p.Description)
                .HasMaxLength(200);

            builder
                .Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            builder
                .HasMany(p => p.Orders)
                .WithMany(p => p.Products)
                .UsingEntity<ProductsOrders>(
                    j => j.HasOne(po => po.Order)
                         .WithMany(o => o.ProductsOrders)
                         .HasForeignKey(po => po.OrderId)
                         .HasConstraintName("FK_ProductOrder_Order"),
                    j => j.HasOne(po => po.Product)
                         .WithMany(p => p.ProductsOrders)
                         .HasForeignKey(po => po.ProductId)
                         .HasConstraintName("FK_ProductOrder_Product"),
                    j =>
                    {
                        j
                        .Property(po => po.AddedOn)
                        .HasDefaultValueSql("GETDATE()");

                        j
                        .HasKey(po => new { po.ProductId, po.OrderId });
                    }
                );

            builder
                .HasOne(p => p.Brand)
                .WithMany()
                .HasForeignKey(p => p.BrandId)
                .HasConstraintName("FK_ProductBrand");

            builder
                .HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .HasConstraintName("FK_ProductCategory");
        }
    }
}
