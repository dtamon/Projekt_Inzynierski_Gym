using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.Core.Services.Interfaces;

namespace Projekt_Inzynierski.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpecializationService _specializationService;

        public SpecializationController(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSpecializations()
        {
            return Ok(await _specializationService.GetAllSpecializationsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecializationById(int id)
        {
            return Ok(await _specializationService.GetSpecializationByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialization(SpecializationDto specializationDto)
        {
            await _specializationService.CreateSpecializationAsync(specializationDto);
            return Ok("Specjalizacja dodana pomyślnie");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSpecialization(int id, SpecializationDto specializationDto)
        {
            await _specializationService.UpdateSpecializationAsync(specializationDto, id);
            return Ok("Specjalizacja zaktualizowana pomyślnie");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialization(int id)
        {
            await _specializationService.DeleteSpecializationAsync(id);
            return Ok("Specjalizacja usunięta pomyślnie");
        }
    }
}
