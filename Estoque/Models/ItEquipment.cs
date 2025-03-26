using Estoque.Models.Enums;

namespace Estoque.Models {
    public class ItEquipment {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public string Description { get; set; }
        public string? AssaAbloyTag { get; set; }
        public ETypeItEquipment TypeEquipment { get; set; }
    }
}
