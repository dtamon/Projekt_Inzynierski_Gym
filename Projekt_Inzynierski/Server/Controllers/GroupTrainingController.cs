using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.Core.Services.Interfaces;
using Projekt_Inzynierski.Core.Services.Services;
using Projekt_Inzynierski.DataAccess.Queries;

namespace Projekt_Inzynierski.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupTrainingController : ControllerBase
    {
        private readonly IGroupTrainingService _groupTrainingService;

        public GroupTrainingController(IGroupTrainingService groupTrainingService)
        {
            _groupTrainingService = groupTrainingService;
        }

        [HttpGet]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> GetAllGroupTrainings([FromQuery] SearchQuery query)
        {
            return Ok(await _groupTrainingService.GetAllGroupTrainingsAsync(query));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> GetGroupTrainingById(int id)
        {
            return Ok(await _groupTrainingService.GetGroupTrainingByIdAsync(id));
        }

        [HttpPost]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> CreateGroupTraining(GroupTrainingDto groupTrainingDto)
        {
            await _groupTrainingService.CreateGroupTrainingAsync(groupTrainingDto);
            return Ok("Zajęcia grupowe dodane pomyślnie");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> UpdateGroupTraining(int id, GroupTrainingDto groupTrainingDto)
        {
            await _groupTrainingService.UpdateGroupTrainingAsync(groupTrainingDto, id);
            return Ok("Zajęcia grupowe zaktualizowane pomyślnie");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> DeleteGroupTraining(int id)
        {
            await _groupTrainingService.DeleteGroupTrainingAsync(id);
            return Ok("Zajęcia grupowe usunięte pomyślnie");
        }

        [HttpPost("signUp/{id}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> SignUpForTraining(int id)
        {
            await _groupTrainingService.SignUpForTraining(id);
            return Ok("Pomyślnie zapisano na trening");
        }

        [HttpPost("signOut/{id}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> SignOutOfTraining(int id)
        {
            await _groupTrainingService.SignOutOfTraining(id);
            return Ok("Pomyślnie wypisano się z treningu");
        }

        [HttpGet("yourGroupTrainings")]
        [Authorize(Roles = "Client,Trainer")]
        public async Task<IActionResult> GetTrainingByUserId([FromQuery] SearchQuery query)
        {
            return Ok(await _groupTrainingService.GetGroupTrainingsByUserId(query));
        }

        [HttpGet("trainingsNotSignedUp")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> GetTrainingsWhereClientIsAbsent([FromQuery] SearchQuery query)
        {
            return Ok(await _groupTrainingService.GetTrainingsWhereClientIsAbsent(query));
        }
    }
}
