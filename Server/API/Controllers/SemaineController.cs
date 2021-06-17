using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BO.Entite;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class SemaineController : ControllerBase
    {
        private readonly IManagementService _managementService;
        public SemaineController(IManagementService managementService)
        {
            _managementService = managementService;
        }        

        /// <summary>
        /// Permet de récupérer une semaine précise via son ID
        /// </summary>
        /// <param name="idSemaine">L'identifiant de la semaine</param>
        /// <returns>La semaine demandée</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSemaineAsync([FromRoute] int idSemaine)
        {
            // Méthode pour récupérer une semaine
            Semaine semaine = await _managementService.GetSemaineAsync(idSemaine);

            if (semaine != null)
            {
                // Résultat Ok + semaine
                return Ok(semaine);
            }

            else
            {
                // Semaine introuvable
                return NotFound();
            }
        }

        /// <summary>
        /// Permet d'ajouter une semaine
        /// </summary>
        /// <param name="semaine">La semaine à ajouter</param>
        /// <returns>La nouvelle semaine</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InsertSemaineAsync([FromBody] Semaine semaine)
        {
            // Méthode pour ajouter une semaine
            Semaine newSemaine = await _managementService.InsertSemaineAsync(semaine);

            if (newSemaine != null)
            {
                // Semaine créée, donc retourne la nouvelle semaine en appelant la méthodeGet
                return CreatedAtAction(nameof(GetSemaineAsync), new { id = semaine.IdSemaine }, newSemaine);
            }

            else
            {
                // La requête n'est pas conforme
                return BadRequest();
            }
        }

        /// <summary>
        /// Permet de mettre à jour une semaine via son ID
        /// </summary>
        /// <param name="idSemaine">L'identifiant de la semaine</param>
        /// <param name="semaine">La nouvelle semaine</param>
        /// <returns>La semaine modifiée</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSemaineAsync([FromRoute] int idSemaine, [FromBody] Semaine semaine)
        {
            if (semaine == null || idSemaine != semaine.IdSemaine)
            {
                // La requête n'est pas conforme
                return BadRequest();
            }

            else
            {
                // Méthode pour mettre à jour une semaine
                Semaine updateSemaine = await _managementService.UpdateSemaineAsync(semaine);

                if (updateSemaine != null)
                {
                    // Résultat Ok + la semaine modifiée
                    return Ok(updateSemaine);
                }

                else
                {
                    // Semaine introuvable
                    return NotFound();
                }
            }
        }

        /// <summary>
        /// Permet de supprimer une semaine précise via son ID
        /// </summary>
        /// <param name="idSemaine">L'identifiant de la semaine</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSemaineAsync([FromRoute]int idSemaine)
        {
            // Méthode pour supprimer une semaine
            if (await _managementService.DeleteSemaineAsync(idSemaine))
            {
                // La semaine est bien supprimée
                return NoContent();
            }

            else
            {
                // Semaine introuvable
                return NotFound();
            }
        }
    }
}
