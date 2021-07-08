using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using DAL.UOW;
using DAL.Repertoire;
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


        public async Task<bool> DeleteReservationAsync(int idReservation)
        {
            _bdd.DebutTransaction();
            IReservationRepertoire reservationRepertoire = _bdd.GetRepertoire<IReservationRepertoire>();
            bool delete = await reservationRepertoire.DeleteAsync(idReservation);
            if (delete)
            {
                _bdd.Commit();
                return true;
            }
            else
            {
                _bdd.Rollback();
                return false;
            }
        }

        public async Task<ReponsePeriodique<Reservation>> GetAllReservationsAsync(RequetePeriodique requetePeriodique)
        {
            IReservationRepertoire reservationRepertoire = _bdd.GetRepertoire<IReservationRepertoire>();
            return await reservationRepertoire.GetAllPeriodeAsync(requetePeriodique);
        }

        public async Task<Reservation> GetReservationAsync(int idReservation)
        {
            IReservationRepertoire reservationRepertoire = _bdd.GetRepertoire<IReservationRepertoire>();
            return await reservationRepertoire.GetAsync(idReservation);
        }

        public async Task<Reservation> InsertReservationAsync(Reservation reservation)
        {
            _bdd.DebutTransaction();
            IReservationRepertoire reservationRepertoire = _bdd.GetRepertoire<IReservationRepertoire>();
            Reservation newReservation = await reservationRepertoire.InsertAsync(reservation);
            _bdd.Commit();
            return newReservation;
        }

        public async Task<Reservation> UpdateReservation(Reservation reservation)
        {
            _bdd.DebutTransaction();
            IReservationRepertoire reservationRepertoire = _bdd.GetRepertoire<IReservationRepertoire>();
            Reservation newReservation = await reservationRepertoire.UpdateAsync(reservation);
            _bdd.Commit();
            return newReservation;
        }
    }
}
