using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.Core.Services.Interfaces;
using Projekt_Inzynierski.DataAccess.Queries;

namespace Projekt_Inzynierski.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly IVisitService _visitService;

        public VisitController(IVisitService visitService)
        {
            _visitService = visitService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVisits([FromQuery] SearchQuery query)
        {
            return Ok(await _visitService.GetAllVisitsAsync(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVisitById(int id)
        {
            return Ok(await _visitService.GetVisitByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateVisit(VisitDto visitDto)
        {
            await _visitService.CreateVisitAsync(visitDto);
            return Ok("Wizyta dodana pomyślnie");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVisit(int id, VisitDto visitDto)
        {
            await _visitService.UpdateVisitAsync(visitDto, id);
            return Ok("Wizyta zaktualizowana pomyślnie");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisit(int id)
        {
            await _visitService.DeleteVisitAsync(id);
            return Ok("Wizyta usunięta pomyślnie");
        }
    }
}
