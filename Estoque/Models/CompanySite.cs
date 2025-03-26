using Estoque.Models.Enums;

namespace Estoque.Models {
    public class CompanySite {
        public int Id { get; set; }
        public ENameCompanySite SiteName { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
