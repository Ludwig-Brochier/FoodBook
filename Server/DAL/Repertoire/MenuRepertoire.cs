using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DAL.Repertoire
{
    class MenuRepertoire : IMenuRepertoire
    {
        private readonly IDbSession _session;
        public MenuRepertoire(IDbSession session)
        {
            _session = session;
        }


        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ReponsePeriodique<Menu>> GetAllPeriodeAsync(RequetePeriodique requetePeriodique)
        {
            throw new NotImplementedException();
        }

        public Task<Menu> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Menu> InsertAsync(Menu entite)
        {
            throw new NotImplementedException();
        }

        public Task<Menu> UpdateAsync(Menu entite)
        {
            throw new NotImplementedException();
        }
    }
}
