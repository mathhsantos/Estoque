using Estoque.Models;
using System.ComponentModel.DataAnnotations;

namespace Estoque.Dtos {
    public class UpdateEmployeeDto {

        [Required(ErrorMessage = "Nome é necessario!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Departamento é necessario")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Company Site é necessario!")]
        public int CompanySitId { get; set; }

    }
}
