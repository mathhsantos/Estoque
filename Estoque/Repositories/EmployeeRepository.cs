using Estoque.Data;
using Estoque.Interfaces;
using Estoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Repositories {
    public class EmployeeRepository : IEmployeeRepository {

        private readonly EstoqueDbContext _db;

        public EmployeeRepository(EstoqueDbContext db) {
            _db = db;
        }

        public async Task InsertEmployee(Employee employee) {

            await _db.Employees.AddAsync(employee);
        }

        public async Task<IEnumerable<Employee>> GetEmployees() {

            var EmployeeList = await _db.Employees
                .AsNoTracking()
                .Include(x => x.Department)
                .Include(x => x.CompanySite)
                .ToListAsync();

            return EmployeeList;
        }

        public async Task<Employee> GetOneEmployee(int id) {

            var employee = await _db.Employees
                .Include(x => x.Department)
                .Include(x => x.CompanySite)
                .Include(x => x.Equipments)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null) {
                return null;
            }

            return employee;
        }

        public void UpdateEmployee(Employee employee) {

            _db.Employees.Update(employee);
        }

        public void DeleteEmployee(Employee employee) {

            _db.Employees.Remove(employee);
        }

        public async Task<bool> SaveChanges() {

            return await _db.SaveChangesAsync() > 0;
        }
    }
}
