using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.Core.Services.Interfaces;

namespace Projekt_Inzynierski.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrainers()
        {
            return Ok(await _trainerService.GetAllTrainersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainerById(int id)
        {
            return Ok(await _trainerService.GetTrainerByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrainer(TrainerAccountDto trainerDto)
        {
            await _trainerService.CreateTrainerAsync(trainerDto);
            return Ok("Trener dodany pomyślnie");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainer(int id, TrainerViewDto trainerDto)
        {
            await _trainerService.UpdateTrainerAsync(trainerDto, id);
            return Ok("Trener zaktualizowany pomyślnie");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            await _trainerService.DeleteTrainerAsync(id);
            return Ok("Trener usunięty pomyślnie");
        }
    }
}
