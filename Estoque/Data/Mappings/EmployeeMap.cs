using Estoque.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estoque.Data.Mappings {
    public class EmployeeMap : IEntityTypeConfiguration<Employee> {
        public void Configure(EntityTypeBuilder<Employee> builder) {

            builder.ToTable("Employee");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseMySqlIdentityColumn()
                .IsRequired();


            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.DepartmentId)
                .HasColumnName("DepartmentId")
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(x => x.CompanySiteId)
                .HasColumnName("CompanySiteId")
                .HasColumnType("INT")
                .IsRequired();

            builder
               .HasIndex(x => x.Email, "IX_Email")
               .IsUnique();

            builder.HasOne(x => x.Department)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.DepartmentId)
                .HasConstraintName("FK_DepartmentId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CompanySite)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.CompanySiteId)
                .HasConstraintName("FK_CompanySiteId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
