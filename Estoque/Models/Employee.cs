
namespace Estoque.Models {
    public class Employee {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int CompanySiteId { get; set; }
        public CompanySite CompanySite { get; set; }
        public List<ItEquipment> Equipments { get; set; } = new List<ItEquipment>();
    }
}
