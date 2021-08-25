using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLLC.Services
{
    public class CommandeService : ICommandeService
    {

        private readonly HttpClient _httpClient;
        public CommandeService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/");
        }

        public Task<ReponsePeriodique<PlatIngredient>> GetCommandeIngredientsAsync(RequetePeriodique requetePeriodique)
        {
            throw new NotImplementedException();
        }
    }
}
