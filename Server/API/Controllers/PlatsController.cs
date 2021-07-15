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
    [Route("api/[controller]/")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class PlatsController : ControllerBase 
    {
        // Appel du service restauration via Injecteur de dépendance
        private readonly IRestaurationService _restaurationService;
        public PlatsController(IRestaurationService restaurationService)
        {
            _restaurationService = restaurationService;
        }

        /// <summary>
        /// Permet de récupérer tous les plats selon une pagination précise
        /// </summary>
        /// <param name="requetePagination">La pagination demandée</param>
        /// <returns>Les plats mis en page</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllPlatsAsync([FromQuery]RequeteFiltresPlats requeteFiltresPlats)
        {
            if ((requeteFiltresPlats.Populaire == true && requeteFiltresPlats.Type != null) || 
                (requeteFiltresPlats.Populaire == true && requeteFiltresPlats.IdIngredient != 0) ||
                (requeteFiltresPlats.Type != null && requeteFiltresPlats.IdIngredient != 0))
            {
                return BadRequest();
            }

            else
            {
                if (requeteFiltresPlats.Populaire == true)
                {
                    return Ok(await _restaurationService.GetAllPlatsPopulaireAsync(requeteFiltresPlats));
                }

                else
                {
                    // Méthode pour récupérer tous les plats
                    return Ok(await _restaurationService.GetAllPlatsAsync(requeteFiltresPlats));
                }
            }            
        }

        /// <summary>
        /// Permet de récupérer un plat précise via son ID
        /// </summary>
        /// <param name="idPlat">L'identifiant du plat</param>
        /// <returns>Le plat demandé</returns>
        [ActionName("Get")]
        [HttpGet("{idPlat}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPlatAsync([FromRoute]int idPlat)
        {
            // Méthode pour récupérer un plat
            Plat plat = await _restaurationService.GetPlatAsync(idPlat);

            if (plat != null)
            {
                // Résultat Ok + plat
                return Ok(plat);
            }

            else
            {
                // Plat introuvable
                return NotFound();
            }
        }

        
        /// <summary>
        /// Permet d'ajouter un plat
        /// </summary>
        /// <param name="plat">Le plat à ajouter</param>
        /// <returns>Le nouveau plat</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InsertPlatAsync([FromBody]Plat plat)
        {            
            // Méthode pour ajouter un plat
            Plat newPlat = await _restaurationService.InsertPlatAsync(plat);

            if (newPlat != null)
            {
                // Plat créé, donc retourne le nouveau plat en appelant la méthode Get
                return CreatedAtAction(HttpMethods.Get.ToString(), new { newPlat.IdPlat }, newPlat);
            }

            else
            {
                // La requête n'est pas conforme
                return BadRequest();
            }                      
        }

        /// <summary>
        /// Permet de mettre à jour un plat précis via son ID
        /// </summary>
        /// <param name="idPlat">L'identifiant du plat</param>
        /// <param name="plat">Le nouveau plat</param>
        /// <returns>Le plat modifié</returns>
        [HttpPut("{idPlat}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePlatAsync([FromRoute]int idPlat, [FromBody]Plat plat)
        {
            if (plat == null || idPlat != plat.IdPlat)
            {
                return BadRequest();
            }

            else
            {
                // Méthode pour mettre à jour un plat
                Plat updatePlat = await _restaurationService.UpdatePlatAsync(plat);

                if (updatePlat != null)
                {
                    // Résultat Ok + plat modifié
                    return Ok(updatePlat);
                }

                else
                {
                    // Plat introuvable
                    return NotFound();
                }
            }
        }

        /// <summary>
        /// Permet de supprimer un plat précis via son ID
        /// </summary>
        /// <param name="idPlat">L'identifiant du plat</param>
        /// <returns></returns>
        [HttpDelete("{idPlat}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePlatAsync([FromRoute]int idPlat)
        {
            // Méthode pour supprimer un plat
            if (await _restaurationService.DeletePlatAsync(idPlat))
            {
                // Le plat est bien supprimé
                return NoContent();
            }

            else
            {
                // Plat introuvable
                return NotFound();
            }
        }
    }
}
