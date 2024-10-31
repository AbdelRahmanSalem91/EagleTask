
using EagleTask.Models.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EagleTask.Data.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(c => c.Id)
                .HasName("PK_CategoryKey");

            builder
                .Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
