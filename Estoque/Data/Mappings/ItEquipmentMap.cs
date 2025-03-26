using Estoque.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estoque.Data.Mappings {
    public class ItEquipmentMap : IEntityTypeConfiguration<ItEquipment> {
        public void Configure(EntityTypeBuilder<ItEquipment> builder) {

            builder.ToTable("ItEquipment");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseMySqlIdentityColumn();

            builder.Property(x => x.EmployeeId)
                .HasColumnName("EmployeeId")
                .HasColumnType("INT")
                .IsRequired(false);

            builder.Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("VARCHAR")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.AssaAbloyTag)
                .HasColumnName("AssaAbloyTag")
                .HasColumnType("VARCHAR")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.TypeEquipment)
                .HasColumnName("TypeEquipment")
                .HasMaxLength(20)
                .HasConversion<string>();

            builder.HasIndex(x => x.AssaAbloyTag, "IX_Assa_Abloy_Tag")
                .IsUnique();

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.Equipments)
                .HasForeignKey(x => x.EmployeeId)
                .HasConstraintName("FK_EmployeeId")
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
