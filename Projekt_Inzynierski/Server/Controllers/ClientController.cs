using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.Core.Services.Interfaces;
using Projekt_Inzynierski.DataAccess.Queries;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace Projekt_Inzynierski.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Employee")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients([FromQuery] SearchQuery query)
        {
            return Ok(await _clientService.GetAllClientsAsync(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            return Ok(await _clientService.GetClientByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientAccountDto clientDto)
        {
            var data = await _clientService.CreateClientAsync(clientDto);
            var document = new PdfDocument();

            string htmlContent = "<h1>WNIOSEK/UMOWA O CZŁONKOSTWO</h1><p></p>";
            htmlContent += "<h3>Klient</h3>";
            htmlContent += $"<p>Imię: {data.Client.FirstName}</p>";
            htmlContent += $"<p>Nazwisko: {data.Client.LastName}</p>";
            htmlContent += $"<p>Pesel: {data.Client.Pesel}</p>";
            htmlContent += $"<p>Numer telefonu: {data.Client.PhoneNr}</p>";
            htmlContent += $"<p>Email: {data.Client.Email}</p><p></p>";
            htmlContent += "<h3>Warunki umowy członkowskiej</h3>";
            htmlContent += $"<p>Okres obowiązywania umowy: {data.Client.ContractStart.ToShortDateString()}-{data.Client.ContractEnd.ToShortDateString()}</p>";
            htmlContent += $"<p>Ilośc miesięcy obowiązywania umowy: {data.Contract.Months}</p>";
            htmlContent += $"<p>Miesięczny abonament: {data.Contract.MonthlyCost} zł</p>";


            PdfGenerator.AddPdfPages(document, htmlContent, PageSize.A4);
            byte[]? response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                document.Save(ms);
                response = ms.ToArray();
            }

            string fileName = $"Umowa_{data.Client.FirstName}_{data.Client.LastName}.pdf";

            return File(response, "application/pdf", fileName);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, ClientViewDto clientDto)
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




//using (MemoryStream ms = new MemoryStream())
//{
//    Document document = new Document(PageSize.A4, 25, 25, 30, 30);
//    PdfWriter writer = PdfWriter.GetInstance(document, ms);
//    document.Open();
//    List<Paragraph> paragraphs = new List<Paragraph>
//    {
//        new Paragraph($"WNIOSEK/UMOWA O CZŁONKOSTWO", new Font(Font.FontFamily.HELVETICA, 20)),
//        new Paragraph($"", new Font(Font.FontFamily.HELVETICA, 10)),
//        new Paragraph($"Klient", new Font(Font.FontFamily.HELVETICA, 15)),
//        new Paragraph($"Imię: {data.Client.FirstName}", new Font(Font.FontFamily.HELVETICA, 10)),
//        new Paragraph($"Nazwisko: {data.Client.LastName}", new Font(Font.FontFamily.HELVETICA, 10)),
//        new Paragraph($"Pesel: {data.Client.Pesel}", new Font(Font.FontFamily.HELVETICA, 10)),
//        new Paragraph($"Numer Telefonu: {data.Client.PhoneNr}", new Font(Font.FontFamily.HELVETICA, 10)),
//        new Paragraph($"Email: {data.Client.Email}", new Font(Font.FontFamily.HELVETICA, 10)),
//        new Paragraph($"", new Font(Font.FontFamily.HELVETICA, 10)),
//        new Paragraph($"Warunki umowy członkowskiej", new Font(Font.FontFamily.HELVETICA, 15)),
//        new Paragraph($"okres obowiązywania umowy: {data.Client.ContractStart.ToShortDateString()}-{data.Client.ContractEnd.ToShortDateString()}", new Font(Font.FontFamily.HELVETICA, 10)),
//        new Paragraph($"czas trwania umowy: {data.Contract.Months} miesięcy", new Font(Font.FontFamily.HELVETICA, 10)),
//        new Paragraph($"miesięczny abonament: {data.Contract.MonthlyCost}PLN", new Font(Font.FontFamily.HELVETICA, 10))
//    };

//    foreach (var paragraph in paragraphs)
//    {
//        paragraph.Alignment = Element.ALIGN_LEFT;
//        document.Add(paragraph);
//    }
//    document.Close();
//    writer.Close();
//    var constant = ms.ToArray();
//    var file = File(constant, "application/vnd", $"Umowa_{data.Client.FirstName}_{data.Client.LastName}.pdf");

//    return file;
//}