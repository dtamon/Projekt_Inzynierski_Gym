using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.Core.Services.Interfaces;

namespace Projekt_Inzynierski.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            return Ok(await _clientService.GetAllClientsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            return Ok(await _clientService.GetClientByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientDto clientDto)
        {
            await _clientService.CreateClientAsync(clientDto);
            return Ok("Klient dodany pomyślnie");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, ClientDto clientDto)
        {
            await _clientService.UpdateClientAsync(clientDto, id);
            return Ok("Klient zaktualizowany pomyślnie");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _clientService.DeleteClientAsync(id);
            return Ok("Klient usunięty pomyślnie");
        }
    }
}
