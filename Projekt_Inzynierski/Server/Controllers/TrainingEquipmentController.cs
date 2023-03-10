using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.Core.Services.Interfaces;
using Projekt_Inzynierski.DataAccess.Queries;

namespace Projekt_Inzynierski.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Employee")]
    public class TrainingEquipmentController : ControllerBase
    {
        private readonly ITrainingEquipmentService _trainingEquipmentService;

        public TrainingEquipmentController(ITrainingEquipmentService trainingEquipmentService)
        {
            _trainingEquipmentService = trainingEquipmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrainingEquipments([FromQuery] SearchQuery query)
        {
            return Ok(await _trainingEquipmentService.GetAllTrainingEquipmentsAsync(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainingEquipmentById(int id)
        {
            return Ok(await _trainingEquipmentService.GetTrainingEquipmentByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrainingEquipment(TrainingEquipmentDto trainingEquipmentDto)
        {
            await _trainingEquipmentService.CreateTrainingEquipmentAsync(trainingEquipmentDto);
            return Ok("Sprzęt dodany pomyślnie");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainingEquipment(int id, TrainingEquipmentDto trainingEquipmentDto)
        {
            await _trainingEquipmentService.UpdateTrainingEquipmentAsync(trainingEquipmentDto, id);
            return Ok("Sprzęt zaktualizowany pomyślnie");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingEquipment(int id)
        {
            await _trainingEquipmentService.DeleteTrainingEquipmentAsync(id);
            return Ok("Sprzęt usunięty pomyślnie");
        }
    }
}
