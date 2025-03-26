
using Estoque.Interfaces;
using Estoque.Models;
using Estoque.Repositories;
using Estoque.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SecureIdentity.Password;

namespace Estoque.Controllers {

    [ApiController]
    [Route("v1/employee")]
    public class EmployeeController : ControllerBase {

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository) {
            _employeeRepository = employeeRepository;
        }

        [HttpPost("")]
        public async Task<IActionResult> PostEmployees([FromBody] CreateEmployeeViewModel employeeModel) {

            var employee = new Employee() {
                Name = employeeModel.Name,
                Email = employeeModel.Email,
                PasswordHash = PasswordHasher.Hash(employeeModel.PasswordHash),
                DepartmentId = employeeModel.DepartmentId,
                CompanySiteId = employeeModel.CompanySiteId   
            };

            await _employeeRepository.InsertEmployee(employee);

            if(!(await _employeeRepository.SaveChanges())) {
                return BadRequest(new ResponseViewModel<Employee>("Erro no banco! Não foi possivel salvar"));
            }


            return Created($"v1/employee/{employee.Id}", new ResponseViewModel<Employee>(employee));
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees() {

            var employees = await _employeeRepository.GetEmployees();

            return Ok(new ResponseViewModel<IEnumerable<Employee>>(employees));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int id) {

            var employee = await _employeeRepository.GetOneEmployee(id);

            if(employee == null) {
                return NotFound(new ResponseViewModel<Employee>($"Usuario Id = {id} não encontrado"));
            }

            return Ok(new ResponseViewModel<Employee>(employee));  
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutEmployee([FromRoute] int id, [FromBody] UpdateEmployeeViewModel employeeModel) {

            var employee = await _employeeRepository.GetOneEmployee(id);

            if(employee == null) {
                return NotFound(new ResponseViewModel<Employee>($"Usuario Id = {id} não encontrado"));
            }

            employee.Name = employeeModel.Name;
            employee.DepartmentId = employeeModel.DepartmentId;
            employee.CompanySiteId = employeeModel.CompanySitId;

            _employeeRepository.UpdateEmployee(employee);

            if (!(await _employeeRepository.SaveChanges())) {
                return BadRequest(new ResponseViewModel<Employee>("Erro no banco! Não foi possivel salvar"));
            }

            return Ok(new ResponseViewModel<string>($"Usuario Id = {employee.Id} atualizado com sucesso!", null));

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id) {

            var employee = await _employeeRepository.GetOneEmployee(id);

            if(employee == null) {
                return NotFound(new ResponseViewModel<Employee>($"Usuario Id = {id} não encontrado"));
            }

            _employeeRepository.DeleteEmployee(employee);

            if (!(await _employeeRepository.SaveChanges())) {
                return BadRequest(new ResponseViewModel<Employee>("Erro no banco! Não foi possivel salvar"));
            }

            return Ok(new ResponseViewModel<string>($"Usuario Id = {employee.Id} atualizado com sucesso!", null));
        }
    }
}
