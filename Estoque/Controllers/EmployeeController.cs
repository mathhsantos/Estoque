
using Estoque.Dtos;
using Estoque.Interfaces;
using Estoque.Models;
using Estoque.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
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
        public async Task<IActionResult> PostEmployees([FromBody] CreateEmployeeDto employeeModel) {

            try {

                var employee = new Employee() {
                    Name = employeeModel.Name,
                    Email = employeeModel.Email,
                    PasswordHash = PasswordHasher.Hash(employeeModel.PasswordHash),
                    DepartmentId = employeeModel.DepartmentId,
                    CompanySiteId = employeeModel.CompanySiteId
                };

                await _employeeRepository.InsertEmployee(employee);

                if (!(await _employeeRepository.SaveChanges())) {
                    return BadRequest(new ResponseViewModel<Employee>("Erro no banco! Não foi possivel salvar"));
                }


                return Created($"v1/employee/{employee.Id}", new ResponseViewModel<string>($"Usuario Id = {employee.Id} criado com sucesso!", null));
            
            } catch {

                return StatusCode(500, "Erro no servidor! Tente novamente mais tarde");
            } 
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees() {

            try {

                var employees = await _employeeRepository.GetEmployees();

                List<ReadManyEmployeesDto> employeesTdo = new List<ReadManyEmployeesDto>();

                foreach (Employee employee in employees) {

                    employeesTdo.Add(new ReadManyEmployeesDto() {
                        Id = employee.Id,
                        Name = employee.Name,
                        Email = employee.Email,
                        Department = employee.Department.Name.ToString(),
                        CompanySite = employee.CompanySite.SiteName.ToString(),
                    });
                }

                return Ok(new ResponseViewModel<IEnumerable<ReadManyEmployeesDto>>(employeesTdo));
            
            } catch {

                return StatusCode(500, "Erro no servidor! Tente novamente mais tarde");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int id) {

            try {

                var employee = await _employeeRepository.GetOneEmployee(id);

                if (employee == null) {
                    return NotFound(new ResponseViewModel<Employee>($"Usuario Id = {id} não encontrado"));
                }

                List<ReadListItEquipmentDto> equipmentsList = new List<ReadListItEquipmentDto>();

                foreach (ItEquipment equipment in employee.Equipments) {

                    equipmentsList.Add(new ReadListItEquipmentDto() {
                        Id = equipment.Id,
                        AssaAbloyTag = equipment.AssaAbloyTag,
                        Description = equipment.Description,
                        TypeEquipment = equipment.TypeEquipment.ToString()
                    });
                }

                var employeeTdo = new ReadOneEmployeeDto() {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Department = employee.Department.Name.ToString(),
                    CompanySite = employee.CompanySite.SiteName.ToString(),
                    Equipments = equipmentsList
                };

                return Ok(new ResponseViewModel<ReadOneEmployeeDto>(employeeTdo));
            
            } catch {

                return StatusCode(500, "Erro no servidor! Tente novamente mais tarde");
            }

            
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutEmployee([FromRoute] int id, [FromBody] UpdateEmployeeDto employeeModel) {

            try {

                var employee = await _employeeRepository.GetOneEmployee(id);

                if (employee == null) {
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
            
            } catch {

                return StatusCode(500, "Erro no servidor! Tente novamente mais tarde");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id) {


            try {

                var employee = await _employeeRepository.GetOneEmployee(id);

                if (employee == null) {
                    return NotFound(new ResponseViewModel<Employee>($"Usuario Id = {id} não encontrado"));
                }

                _employeeRepository.DeleteEmployee(employee);

                if (!(await _employeeRepository.SaveChanges())) {
                    return BadRequest(new ResponseViewModel<Employee>("Erro no banco! Não foi possivel salvar"));
                }

                return Ok(new ResponseViewModel<string>($"Usuario Id = {employee.Id} removido com sucesso!", null));
            
            } catch {

                return StatusCode(500, "Erro no servidor! Tente novamente mais tarde");
            } 

            
        }
    }
}
