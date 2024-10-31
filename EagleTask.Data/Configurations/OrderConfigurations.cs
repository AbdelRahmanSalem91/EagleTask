
using EagleTask.Models.Models.Domains;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EagleTask.Data.Configurations
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasKey(o => o.Id)
                .HasName("PK_OrderKey");
            builder
                .Property(o => o.TotalPrice)
                .HasColumnType("decimal(18, 2)");
            builder
                .Property(o => o.Quantity)
                .IsRequired();
            builder
                .HasIndex(o => o.CustomerId)
                .HasDatabaseName("IX_OrdersCustomer_Index");
            builder
                .Property(o => o.OrderDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
