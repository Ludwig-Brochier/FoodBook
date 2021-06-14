using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    class PlatRepertoire : IPlatRepertoire
    {
        private readonly IDbSession _session;
        public PlatRepertoire(IDbSession session)
        {
            _session = session;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ReponsePagination<Plat>> GetAllAsync(RequetePagination requetePagination)
        {
            throw new NotImplementedException();
        }

        public async Task<Plat> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Plat> InsertAsync(Plat entite)
        {
            throw new NotImplementedException();
        }

        public async Task<Plat> UpdateAsync(Plat entite)
        {
            throw new NotImplementedException();
        }
    }
}
