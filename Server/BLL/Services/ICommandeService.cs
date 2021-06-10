using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.DTO.Reponses;
using BO.Entite;

namespace BLL.Services
{
    public interface ICommandeService
    {
        Task<ReponsePagination<Ingredient>> CommandeIngredientsAsync(int idSemaine);
    }
}
