using Estoque.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estoque.Data.Mappings {
    public class CompanySiteMap : IEntityTypeConfiguration<CompanySite> {
        public void Configure(EntityTypeBuilder<CompanySite> builder) {

            builder.ToTable("CompanySite");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseMySqlIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.SiteName)
                .IsRequired()
                .HasColumnName("SiteName")
                .HasConversion<string>()
                .HasMaxLength(2);
            
        }
    }
}
