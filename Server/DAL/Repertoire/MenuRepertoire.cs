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

        public async Task<ReponsePeriodique<Menu>> GetAllPeriodeAsync(RequetePeriodique requetePeriodique)
        {
            throw new NotImplementedException();
        }

        public async Task<Menu> GetAsync(int id)
        {
            var requete = @"SELECT * FROM Menu WHERE IdMenu = @ID";

            Menu menu = await _session.Connection.QueryFirstOrDefaultAsync<Menu>(requete, param: new { ID = id }, _session.Transaction);

            if (menu != null)
            {
                var requetePlat = @"SELECT * FROM MenuPlat JOIN Plat ON MenuPlat.IdPlat = Plat.IdPlat WHERE IdMenu = @ID";

                List<Plat> plats = (List<Plat>) await _session.Connection.QueryAsync<Plat>(requetePlat, param: new { ID = id }, _session.Transaction);

                menu.Plats = plats;
            }

            return menu;
        }

        public async Task<Menu> InsertAsync(Menu entite)
        {
            throw new NotImplementedException();
        }

        public async Task<Menu> UpdateAsync(Menu entite)
        {
            throw new NotImplementedException();
        }
    }
}
