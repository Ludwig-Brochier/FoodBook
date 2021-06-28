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


        public async Task<bool> DeleteAsync(int id)
        {
            var requete = @"DELETE FROM Menu WHERE IdMenu = @ID";
            var requeteExist = @"SELECT COUNT(*) FROM MenuPlat WHERE IdMenu = @ID";

            if (await _session.Connection.ExecuteScalarAsync<int>(requeteExist, param: new { ID = id }, _session.Transaction) > 0)
            {
                var requeteMenuPlat = @"DELETE FROM MenuPlat WHERE IdMenu = @ID";

                await _session.Connection.ExecuteAsync(requeteMenuPlat, param: new { ID =id }, _session.Transaction);
            }

            return await _session.Connection.ExecuteAsync(requete, param: new { ID = id }, _session.Transaction) > 0;
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
