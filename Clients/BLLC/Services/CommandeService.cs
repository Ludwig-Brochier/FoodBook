using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BLLC.Services
{
    public class CommandeService : ICommandeService
    {

        private readonly HttpClient _httpClient;
        public CommandeService()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
            _httpClient = new HttpClient(handler);
            _httpClient.BaseAddress = new Uri("http://user04.2isa.org/api/");
        }

        public async Task<ReponsePeriodique<PlatIngredient>> GetCommandeIngredientsAsync(RequetePeriodique requetePeriodique)
        {
            if (requetePeriodique.Debut <= requetePeriodique.Fin)
            {
                return await _httpClient.GetFromJsonAsync<ReponsePeriodique<PlatIngredient>>
                ($"commandes?debut={requetePeriodique.Debut:yyyy-MM-dd}" +
                $"&fin={requetePeriodique.Fin:yyyy-MM-dd}" +
                $"&page={requetePeriodique.Page}" +
                $"&taillepage={requetePeriodique.TaillePage}");
            }

            else
            {
                return null;
            }            
        }
    }
}
