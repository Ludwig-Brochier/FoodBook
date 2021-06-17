using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repertoire
{
    class ReservationRepertoire : IReservationRepertoire
    {
        private readonly IDbSession _session;
        public ReservationRepertoire(IDbSession session)
        {
            _session = session;
        }


        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ReponsePagination<Reservation>> GetAllPrecisAsync(RequetePagination requetePagination, int id)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> InsertAsync(Reservation entite)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> UpdateAsync(Reservation entite)
        {
            throw new NotImplementedException();
        }
    }
}
