using Estoque.Models;
using System.ComponentModel.DataAnnotations;

namespace Estoque.ViewModels {
    public class CreateEmployeeViewModel {

        [Required(ErrorMessage = "Nome é necessario!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é necessario!")]
        [EmailAddress(ErrorMessage = "Email invalido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password é necessario!")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Departamento é necessario!")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Company Site é necessario!")]
        public int CompanySiteId { get; set; }
    }
}
