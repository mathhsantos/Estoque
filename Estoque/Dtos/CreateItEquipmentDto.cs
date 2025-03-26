using Estoque.Models.Enums;
using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;

namespace Estoque.Dtos {
    public class CreateItEquipmentDto {

        [Required(ErrorMessage = "Description é obrigatório!")]
        public string? Description { get; set; }
        public string? AssaAbloyTag { get; set; }

        [Required(ErrorMessage = "Description é obrigatório!")]
        [Range(1, 4, ErrorMessage = "Escolha o Id de 1 até 4")]
        public ETypeItEquipment TypeEquipment { get; set; }
    }
}
