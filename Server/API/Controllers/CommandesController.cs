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

        /// <summary>
        /// Permet de récupérer la liste des ingrédients à commander, en plus de sa quantité
        /// La liste dépend d'une période (début et fin)
        /// Mise en page possible des résultats
        /// </summary>
        /// <param name="requetePeriodique">Les dates de début et fin, plus la pagination</param>
        /// <returns>La liste paginée des ingrédients selon la période</returns>
        [HttpGet]
        public async Task<IActionResult> GetCommendeIngredientsAsync([FromQuery]RequetePeriodique requetePeriodique)
        {
            return Ok(await _commandeService.GetCommandeIngredientsAsync(requetePeriodique));
        }
    }
}
