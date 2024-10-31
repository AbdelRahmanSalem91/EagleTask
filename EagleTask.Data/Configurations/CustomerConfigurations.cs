using EagleTask.Models.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EagleTask.Data.Configurations
{
    public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(c => c.Id)
                .HasName("PK_CustomerKey");
            builder
                .Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11);
        }
    }
}
