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
    public class ReservationService : IReservationService
    {
        private readonly HttpClient _httpClient;
        public ReservationService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/");
        }

        public Task<bool> DeleteReservationAsync(int idReservation)
        {
            throw new NotImplementedException();
        }

        public Task<ReponsePeriodique<Reservation>> GetAllReservationsAsync(RequetePeriodique requetePeriodique)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> GetReservationAsync(int idReservation)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> InsertReservationAsync(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> UpdateReservationAsync(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
