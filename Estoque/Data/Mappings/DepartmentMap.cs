using Estoque.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estoque.Data.Mappings {
    public class DepartmentMap : IEntityTypeConfiguration<Department> {
        public void Configure(EntityTypeBuilder<Department> builder) {

            builder.ToTable("Department");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseMySqlIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasConversion<string>()
                .HasColumnName("Name")
                .HasMaxLength(20);
        }
    }
}
