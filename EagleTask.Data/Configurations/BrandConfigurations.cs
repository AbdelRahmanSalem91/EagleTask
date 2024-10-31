
using EagleTask.Models.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EagleTask.Data.Configurations
{
    public class BrandConfigurations : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder
                .HasKey(c => c.Id)
                .HasName("PK_BrandKey");

            builder
                .Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
