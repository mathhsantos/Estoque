using Estoque.Models.Enums;
using Estoque.Models;

namespace Estoque.Dtos {
    public class ReadEditorItEquipmentsDto {
        public int Id { get; set; }
        public string? EmployeeEmail { get; set; }
        public string Description { get; set; }
        public string? AssaAbloyTag { get; set; }
        public string TypeEquipment { get; set; }
    }
}

