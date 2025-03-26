using Estoque.Models.Enums;
using Estoque.Models;

namespace Estoque.Dtos {
    public class ReadListItEquipmentstoEmployeeDto {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? AssaAbloyTag { get; set; }
        public string? TypeEquipment { get; set; }
    }
}
