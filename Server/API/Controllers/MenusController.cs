using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;
using BO.DTO.Requetes;
using Microsoft.AspNetCore.Http;
using BO.Entite;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class MenusController : ControllerBase
    {
        private readonly IRestaurationService _restaurationService;
        public MenusController(IRestaurationService restaurationService)
        {
            _restaurationService = restaurationService;
        }

        /// <summary>
        /// Permet de récupérer tous les menus selon une pagination précise
        /// </summary>
        /// <param name="requetePagination">La pagination demandée</param>
        /// <returns>Les menus mis en page</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllMenusAsync([FromQuery] RequetePagination requetePagination)
        {
            // Méthode pour récupérer tous les menus
            return Ok(await _restaurationService.GetAllMenusAsync(requetePagination));
        }

        /// <summary>
        /// Permet de récupérer un menu précis via son ID
        /// </summary>
        /// <param name="idMenu">L'identifiant du menu</param>
        /// <returns>Le menu demandé</returns>
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMenuAsync([FromRoute]int idMenu)
        {
            // Méthode pour récupérer un menu
            Menu menu = await _restaurationService.GetMenuAsync(idMenu);

            if (menu != null)
            {
                // Résultat Ok + menu
                return Ok(menu);
            }

            else
            {
                // Menu introuvable
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
    }
}
