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
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllTrainers([FromQuery] SearchQuery query)
        {
            return Ok(await _trainerService.GetAllTrainersAsync(query));
        }

        [HttpGet("others")]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> GetOtherTrainers()
        {
            return Ok(await _trainerService.GetOtherTrainersAsync());
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetTrainerById(int id)
        {
            return Ok(await _trainerService.GetTrainerByIdAsync(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateTrainer(TrainerAccountDto trainerDto)
        {
            await _trainerService.CreateTrainerAsync(trainerDto);
            return Ok("Trener dodany pomyślnie");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateTrainer(int id, TrainerViewDto trainerDto)
        {
            await _trainerService.UpdateTrainerAsync(trainerDto, id);
            return Ok("Trener zaktualizowany pomyślnie");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            await _trainerService.DeleteTrainerAsync(id);
            return Ok("Trener usunięty pomyślnie");
        }
    }
}
