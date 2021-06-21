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
    public class IngredientsController : ControllerBase
    {
        private readonly IRestaurationService _restaurationService;
        public IngredientsController(IRestaurationService restaurationService)
        {
            _restaurationService = restaurationService;
        }

        /// <summary>
        /// Permet de récupérer tous les ingrédients selon une pagination précise
        /// </summary>
        /// <param name="requetePagination">La pagination demandée</param>
        /// <returns>Les ingrédients mis en page</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllIngredientsAsync([FromQuery]RequetePagination requetePagination)
        {
            // Méthode pour récupérer tous les ingrédients
            return Ok(await _restaurationService.GetAllIngredientsAsync(requetePagination));
        }

        /// <summary>
        /// Permet de récupérer un ingrédient précis via son ID
        /// </summary>
        /// <param name="idIngredient">L'identifiant de l'ingrédient</param>
        /// <returns>L'ingrédient demandé</returns>
        [HttpGet("{idIngredient}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetIngredientAsync([FromRoute]int idIngredient)
        {
            // Méthode pour récupérer un ingrédient
            Ingredient ingredient = await _restaurationService.GetIngredientAsync(idIngredient);

            if (ingredient != null)
            {
                // Résultat Ok + ingrédient
                return Ok(ingredient);
            }

            else
            {
                // Ingrédient introuvable
                return NotFound();
            }
        }
    }
}
