using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using DAL.UOW;
using System;
using System.Threading.Tasks;

namespace BLL.Services
{
    class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _bdd;
        public ReservationService(IUnitOfWork unitOfWork)
        {
            _bdd = unitOfWork;
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

        public Task<Reservation> UpdateReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
