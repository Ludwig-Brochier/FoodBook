using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using DAL.UOW;
using DAL.Repertoire;
using System.Threading.Tasks;

namespace BLL.Services
{
    class CommandeService : ICommandeService
    {
        private readonly IUnitOfWork _bdd;
        public CommandeService(IUnitOfWork unitOfWork)
        {
            _bdd = unitOfWork;
        }

        public async Task<ReponsePeriodique<PlatIngredient>> GetCommandeIngredientsAsync(RequetePeriodique requetePeriodique)
        {
            IIngredientRepertoire ingredientRepertoire = _bdd.GetRepertoire<IIngredientRepertoire>();
            return await ingredientRepertoire.GetCommandeIngredientsAsync(requetePeriodique);
        }
    }
}
