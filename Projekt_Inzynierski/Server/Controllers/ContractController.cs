using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.Core.Services.Interfaces;
using Projekt_Inzynierski.DataAccess.Queries;

namespace Projekt_Inzynierski.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> GetAllContracts([FromQuery] SearchQuery query)
        {
            return Ok(await _contractService.GetAllContractsAsync(query));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetContractById(int id)
        {
            return Ok(await _contractService.GetContractByIdAsync(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateContract(ContractDto contractDto)
        {
            await _contractService.CreateContractAsync(contractDto);
            return Ok("Kontrakt dodany pomyślnie");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateContract(int id, ContractDto contractDto)
        {
            await _contractService.UpdateContractAsync(contractDto, id);
            return Ok("Kontrakt zaktualizowany pomyślnie");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteContract(int id)
        {
            await _contractService.DeleteContractAsync(id);
            return Ok("Kontrakt usunięty pomyślnie");
        }
    }
}
