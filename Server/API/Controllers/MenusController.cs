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
        /// Permet de récupérer les menus sur une période précise, le tout mis en page
        /// </summary>
        /// <param name="requetePeriodique">La période demandée, dont mise en page</param>
        /// <returns>Les menus de la période mis en page</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllMenusAsync([FromQuery] RequetePeriodique requetePeriodique)
        {
            // Méthode pour récupérer les menus d'une période
            return Ok(await _restaurationService.GetAllMenusAsync(requetePeriodique));
        }

        /// <summary>
        /// Permet de récupérer un menu précis via son ID
        /// </summary>
        /// <param name="idMenu">L'identifiant du menu</param>
        /// <returns>Le menu demandé</returns>
        [ActionName("Get")]
        [HttpGet("{idMenu}")]
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

        /// <summary>
        /// Permet d'ajouter un menu
        /// </summary>
        /// <param name="menu">Le menu à ajouter</param>
        /// <returns>Le nouveau menu</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InsertMenuAsync([FromBody]Menu menu)
        {
            // Méthode pour ajouter un menu
            Menu newMenu = await _restaurationService.InsertMenuAsync(menu);

            if (newMenu != null)
            {
                // Menu créé, donc retourne le nouveau menu en appelant la méthode Get
                return CreatedAtAction(HttpMethods.Get.ToString(), new { newMenu.IdMenu }, newMenu);
            }

            else
            {
                // La requête n'est pas conforme
                return BadRequest();
            }
        }

        /// <summary>
        /// Permet de mettre à jour un menu précis via son ID
        /// </summary>
        /// <param name="idMenu">L'identifiant du menu</param>
        /// <param name="menu">Le nouveau menu</param>
        /// <returns>Le menu modifié</returns>
        [HttpPut("{idMenu}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMenuAsync([FromRoute]int idMenu, [FromBody]Menu menu)
        {
            if (menu == null || idMenu != menu.IdMenu)
            {
                // La requête n'est pas conforme
                return BadRequest();
            }

            else
            {
                // Méthode pour mettre à jour un menu
                Menu updateMenu = await _restaurationService.UpdateMenuAsync(menu);

                if (updateMenu != null)
                {
                    // Résultat Ok + menu modifié
                    return Ok(updateMenu);
                }

                else
                {
                    // Menu introuvable
                    return NotFound();
                }
            }
        }

        /// <summary>
        /// Permet de supprimer un menu précis via son ID
        /// </summary>
        /// <param name="idMenu">L'identifiant du menu</param>
        /// <returns></returns>
        [HttpDelete("{idMenu}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMenuAsync([FromRoute]int idMenu)
        {
            // Méthode pour supprimer un menu
            if (await _restaurationService.DeleteMenuAsync(idMenu))
            {
                // Le menu est bien supprimé
                return NoContent();
            }

            else
            {
                // Menu introuvable
                return NotFound();
            }
        }
    }
}
