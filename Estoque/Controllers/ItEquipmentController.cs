using Estoque.Dtos;
using Estoque.Interfaces;
using Estoque.Models;
using Estoque.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Controllers {

    [ApiController]
    [Route("v1/itequipment")]
    public class ItEquipmentController : ControllerBase {

        private readonly IItEquipmentRepository _ItEquipmentRepository;

        public ItEquipmentController(IItEquipmentRepository _itEquipmentRepository) {
            _ItEquipmentRepository = _itEquipmentRepository;
        }

        [HttpPost("")]
        public async Task<IActionResult> PostItEquipment([FromBody] CreateItEquipmentDto equipmentModel) {

            try {

                var equipment = new ItEquipment() {
                    AssaAbloyTag = equipmentModel.AssaAbloyTag,
                    Description = equipmentModel.Description,
                    TypeEquipment = equipmentModel.TypeEquipment
                };

                await _ItEquipmentRepository.InsertEquipment(equipment);

                if (!(await _ItEquipmentRepository.SaveChanges())) {
                    return BadRequest(new ResponseViewModel<ItEquipment>("Erro no banco! Não foi possivel salvar"));
                }

                return Created($"v1/itequipment/{equipment.Id}", new ResponseViewModel<string>($"Equipamento Id = {equipment.Id} criado com sucesso!", null));

            } catch {

                return StatusCode(500, "Erro no servidor! Tente novamente mais tarde");
            }  
        }

        [HttpGet("")]
        public async Task<IActionResult> GetItEquipments() {

            try {

                var itEquipments = await _ItEquipmentRepository.GetEquipments();

                List<ReadEditorItEquipmentsDto> itEquipmentsDtoList = new List<ReadEditorItEquipmentsDto>();

                foreach (ItEquipment equipment in itEquipments) {

                    itEquipmentsDtoList.Add(new ReadEditorItEquipmentsDto() {
                        AssaAbloyTag = equipment.AssaAbloyTag,
                        Description = equipment.Description,
                        EmployeeEmail = equipment.Employee?.Email ?? "Livre",
                        Id = equipment.Id,
                        TypeEquipment = equipment.TypeEquipment.ToString()
                    });
                }

                return Ok(new ResponseViewModel<IEnumerable<ReadEditorItEquipmentsDto>>(itEquipmentsDtoList));

            } catch {

                return StatusCode(500, "Erro no servidor! Tente novamente mais tarde");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetItEquipmentById([FromRoute] int id) {

            try {

                var itEquipment = await _ItEquipmentRepository.GetOneEquipment(id);

                if (itEquipment == null) {
                    return NotFound(new ResponseViewModel<ReadEditorItEquipmentsDto>($"Equipamento Id = {id} não encontrado"));
                }

                var equipment = new ReadEditorItEquipmentsDto() {
                    AssaAbloyTag = itEquipment.AssaAbloyTag,
                    Description = itEquipment.Description,
                    EmployeeEmail = itEquipment.Employee?.Email ?? "Livre",
                    Id = itEquipment.Id,
                    TypeEquipment = itEquipment.TypeEquipment.ToString()
                };

                return Ok(new ResponseViewModel<ReadEditorItEquipmentsDto>(equipment));

            } catch {

                return StatusCode(500, "Erro no servidor! Tente novamente mais tarde");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutItEquipment(
            [FromRoute] int id, 
            [FromBody] UpdateItEquipmentDto itEquipmentDto, 
            [FromServices] IEmployeeRepository employeeRepository) {

            try {

                var equipment = await _ItEquipmentRepository.GetOneEquipment(id);

                if (equipment == null) {
                    return NotFound(new ResponseViewModel<UpdateItEquipmentDto>($"Equipamento Id = {id} não encontrado"));
                }

                if (await employeeRepository.GetOneEmployee(itEquipmentDto.EmployeeId) == null) {
                    return NotFound(new ResponseViewModel<UpdateItEquipmentDto>($"Usuario Id = {itEquipmentDto.EmployeeId} não encontrado para vincular o equipamento"));
                }

                equipment.EmployeeId = itEquipmentDto.EmployeeId;
                equipment.Description = itEquipmentDto.Description;

                _ItEquipmentRepository.UpdateEquipment(equipment);

                if (!(await _ItEquipmentRepository.SaveChanges())) {
                    return BadRequest(new ResponseViewModel<UpdateItEquipmentDto>("Erro no banco! Não foi possivel salvar"));
                }

                return Ok(new ResponseViewModel<string>($"Equipamento Id = {equipment.Id} atualizado com sucesso!", null));

            } catch {

                return StatusCode(500, "Erro no servidor! Tente novamente mais tarde");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteItEquipment([FromRoute] int id) {

            try {

                var itEquipment = await _ItEquipmentRepository.GetOneEquipment(id);

                if (itEquipment == null) {
                    return NotFound(new ResponseViewModel<ItEquipment>($"Equipamento Id = {id} não encontrado"));
                }

                _ItEquipmentRepository.DeleteEquipment(itEquipment);

                if (!(await _ItEquipmentRepository.SaveChanges())) {
                    return BadRequest(new ResponseViewModel<ItEquipment>("Erro no banco! Não foi possivel salvar"));
                }

                return Ok(new ResponseViewModel<string>($"Equipamento Id = {itEquipment.Id} removido com sucesso!", null));
            
            } catch {

                return StatusCode(500, "Erro no servidor! Tente novamente mais tarde");
            }
        }
    }
}

