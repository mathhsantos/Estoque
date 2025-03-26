using Estoque.Models;
using System.ComponentModel.DataAnnotations;

namespace Estoque.Dtos {
    public class CreateEmployeeDto {

        [Required(ErrorMessage = "Nome é necessario!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é necessario!")]
        [EmailAddress(ErrorMessage = "Email invalido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password é necessario!")]
        [MinLength(6, ErrorMessage ="A senha deve ter no minimo 6 caracteres")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Departamento é necessario!")]
        [Range(1, 11, ErrorMessage = "Escolha o ID do departamento de 1 a 11")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Company Site é necessario!")]
        [Range(1, 3, ErrorMessage = "Escolha o ID da CompanySite de 1 a 3")]
        public int CompanySiteId { get; set; }
    }
}
