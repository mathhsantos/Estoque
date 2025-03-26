using Estoque.Models.Enums;

namespace Estoque.Models {
    public class Department {
        public int Id { get; set; }
        public EDepartment Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
