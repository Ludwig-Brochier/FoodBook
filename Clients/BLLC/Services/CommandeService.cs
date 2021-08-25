using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BLLC.Extensions;

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

        public async Task<ReponsePeriodique<PlatIngredient>> GetCommandeIngredientsAsync(RequetePeriodique requetePeriodique)
        {
            return await _httpClient.GetFromJsonAsync<ReponsePeriodique<PlatIngredient>>($"commandes{requetePeriodique.ToUriQuery()}");
        }
    }
}
