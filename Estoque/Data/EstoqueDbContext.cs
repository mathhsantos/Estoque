using Estoque.Data.Mappings;
using Estoque.Models;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data {
    public class EstoqueDbContext : DbContext {

        public DbSet<Employee> Employees { get; set; }
        public DbSet<ItEquipment> ItEquipments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<CompanySite> CompanySites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new EmployeeMap());
            modelBuilder.ApplyConfiguration(new ItEquipmentMap());
            modelBuilder.ApplyConfiguration(new DepartmentMap());
            modelBuilder.ApplyConfiguration(new CompanySiteMap());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql(Environment.GetEnvironmentVariable("StringConnectorMySQL", EnvironmentVariableTarget.User), new MySqlServerVersion(new Version(8,0,36)));
        }
    }
}
