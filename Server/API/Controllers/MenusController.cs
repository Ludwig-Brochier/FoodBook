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
        /// Permet de récupérer tous les menus d'une semaine précise selon une pagination précise
        /// </summary>
        /// <param name="requetePagination">La pagination demandée</param>
        /// <param name="semaine">La semaine demandée</param>
        /// <returns>Les menus de la semaine mis en page</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllMenusSemaineAsync([FromQuery]RequetePagination requetePagination, [FromBody]Semaine semaine)
        {
            if (semaine == null)
            {
                return BadRequest();
            }

            else
            {
                var reponse = await _restaurationService.GetAllMenusAsync(requetePagination, (int)semaine.IdSemaine);

                if (reponse != null)
                {
                    return Ok(reponse);
                }

                else
                {
                    return NotFound();
                }
            }
        }

        /// <summary>
        /// Permet de récupérer un menu précis via son ID
        /// </summary>
        /// <param name="idMenu">L'identifiant du menu</param>
        /// <returns>Le menu demandé</returns>
        [HttpGet("{id}")]
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
                return CreatedAtAction(nameof(GetMenuAsync), new { id = newMenu.IdMenu }, newMenu);
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
        [HttpPut("{id}")]
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
        [HttpDelete]
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
