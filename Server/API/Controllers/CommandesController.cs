using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;
using BO.DTO.Requetes;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class CommandesController : ControllerBase
    {
        private readonly ICommandeService _commandeService;

        public CommandesController(ICommandeService commandeService)
        {
            _commandeService = commandeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommendeIngredientsAsync([FromQuery]RequetePeriodique requetePeriodique)
        {
            return Ok(await _commandeService.GetCommandeIngredientsAsync(requetePeriodique));
        }
    }
}
