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
    class SemaineRepertoire : ISemaineRepertoire
    {
        private readonly IDbSession _session;
        public SemaineRepertoire(IDbSession session)
        {
            _session = session;
        }


        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }        

        public Task<Semaine> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Semaine> InsertAsync(Semaine entite)
        {
            throw new NotImplementedException();
        }

        public Task<Semaine> UpdateAsync(Semaine entite)
        {
            throw new NotImplementedException();
        }
    }
}
