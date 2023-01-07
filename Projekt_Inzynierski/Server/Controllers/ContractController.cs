﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.Core.Services.Interfaces;

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
        public async Task<IActionResult> GetAllContracts()
        {
            return Ok(await _contractService.GetAllContractsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContractById(int id)
        {
            return Ok(await _contractService.GetContractByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateContract(ContractDto contractDto)
        {
            await _contractService.CreateContractAsync(contractDto);
            return Ok("Kontrakt dodany pomyślnie");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContract(int id, ContractDto contractDto)
        {
            await _contractService.UpdateContractAsync(contractDto, id);
            return Ok("Kontrakt zaktualizowany pomyślnie");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContract(int id)
        {
            await _contractService.DeleteContractAsync(id);
            return Ok("Kontrakt usunięty pomyślnie");
        }
    }
}
