using Estoque.Models.Enums;
using Estoque.Models;
using System.ComponentModel.DataAnnotations;

namespace Estoque.Dtos {
    public class UpdateItEquipmentDto {

        [Required(ErrorMessage = "Necessario incluir um ID de Employee")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Necessario incluir um ID de Employee")]
        public string Description { get; set; }
    }
}
