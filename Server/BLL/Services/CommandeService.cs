using BO.DTO.Reponses;
using BO.Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class CommandeService : ICommandeService
    {
        public Task<ReponsePagination<Ingredient>> CommandeIngredientsAsync(int idSemaine)
        {
            throw new NotImplementedException();
        }
    }
}
