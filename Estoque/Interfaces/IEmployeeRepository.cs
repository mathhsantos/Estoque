using Estoque.Models;

namespace Estoque.Interfaces {
    public interface IEmployeeRepository {

        Task InsertEmployee(Employee employee);
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetOneEmployee(int id);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        Task<bool> SaveChanges();
    }
}
