using Estoque.Models;

namespace Estoque.Dtos {
    public class ReadOneEmployeeDto {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string Department { get; set; }
        public string CompanySite { get; set; }
        public List<ReadListItEquipmentDto> Equipments { get; set; } = new List<ReadListItEquipmentDto>();
    }
}

