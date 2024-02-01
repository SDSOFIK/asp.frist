using fristclass.webapp.Models;
using Microsoft.EntityFrameworkCore;

namespace fristclass.webapp.modelConfiguration
{
    public class studentConfiguration : IEntityTypeConfiguration<student>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<student> builder)
        {
           builder.ToTable(nameof(student));
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Address).HasMaxLength(128).IsRequired();
            builder.Property(t => t.Email).HasMaxLength(50).IsRequired();
            builder.Property(t => t.Phone).HasMaxLength(15).IsRequired();
        }
    }
}
