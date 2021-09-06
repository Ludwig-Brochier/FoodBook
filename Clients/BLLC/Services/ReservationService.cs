using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json;

namespace BLLC.Services
{
    public class ReservationService : IReservationService
    {
        private readonly HttpClient _httpClient;
        public ReservationService()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/");
        }

        public async Task<bool> DeleteReservationAsync(int idReservation)
        {
            var reponse = await _httpClient.DeleteAsync($"reservations/{idReservation}");

            if (reponse.IsSuccessStatusCode)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public async Task<ReponsePeriodique<Reservation>> GetAllReservationsAsync(RequetePeriodique requetePeriodique)
        {
            if (requetePeriodique.Debut <= requetePeriodique.Fin)
            {
                return await _httpClient.GetFromJsonAsync<ReponsePeriodique<Reservation>>
                ($"reservations?debut={requetePeriodique.Debut:yyyy-MM-dd}" +
                $"&fin={requetePeriodique.Fin:yyyy-MM-dd}" +
                $"&page={requetePeriodique.Page}" +
                $"&taillepage={requetePeriodique.TaillePage}");
            }

            else
            {
                return null;
            }
        }

        public async Task<Reservation> GetReservationAsync(int idReservation)
        {
            return await _httpClient.GetFromJsonAsync<Reservation>($"reservations/{idReservation}");
        }

        public async Task<Reservation> InsertReservationAsync(Reservation reservation)
        {
            var reponse = await _httpClient.PostAsJsonAsync("reservations", reservation);
            using (var stream = await reponse.Content.ReadAsStreamAsync())
            {
                Reservation newReservation = await JsonSerializer.DeserializeAsync<Reservation>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return newReservation;
            }
        }

        public async Task<Reservation> UpdateReservationAsync(Reservation reservation)
        {
            var reponse = await _httpClient.PutAsJsonAsync("reservations/" + reservation.IdReservation, reservation);
            using (var stream = await reponse.Content.ReadAsStreamAsync())
            {
                Reservation newReservation = await JsonSerializer.DeserializeAsync<Reservation>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return newReservation;
            }
        }
    }
}
