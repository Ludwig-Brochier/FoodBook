using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using DAL.UOW;
using System.Collections.Generic;
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
            string requete = @"DELETE FROM Menu WHERE IdMenu = @ID";
            
            return await _session.Connection.ExecuteAsync(requete, param: new { ID = id }, _session.Transaction) > 0;
        }

        public async Task<ReponsePeriodique<Menu>> GetAllPeriodeAsync(RequetePeriodique requetePeriodique)
        {
            string requete = @"SELECT * FROM Menu 
                                WHERE DteMenu BETWEEN @debut AND @fin 
                                ORDER BY DteMenu, ServiceMidi Desc OFFSET @taillePage * (@page - 1) rows 
                                FETCH NEXT @taillePage rows only";
            string requeteNbMenu = @"SELECT COUNT(*) FROM Menu WHERE DteMenu BETWEEN @debut AND @fin";

            List<Menu> menus = await _session.Connection.QueryAsync<Menu>(requete, requetePeriodique, _session.Transaction) as List<Menu>;
            int nbMenu = await _session.Connection.ExecuteScalarAsync<int>(requeteNbMenu, requetePeriodique, _session.Transaction);

            return new ReponsePeriodique<Menu>(requetePeriodique.Debut, requetePeriodique.Fin, requetePeriodique.Page, requetePeriodique.TaillePage, nbMenu, menus);
        }

        public async Task<Menu> GetAsync(int id)
        {
            string requete = @"SELECT * FROM Menu WHERE IdMenu = @ID";

            Menu menu = await _session.Connection.QueryFirstOrDefaultAsync<Menu>(requete, param: new { ID = id }, _session.Transaction);

            if (menu != null)
            {
                string requetePlat = @"SELECT * FROM MenuPlat inner JOIN Plat ON MenuPlat.IdPlat = Plat.IdPlat WHERE IdMenu = @ID";

                List<Plat> plats = await _session.Connection.QueryAsync<Plat>(requetePlat, param: new { ID = id }, _session.Transaction) as List<Plat>;

                menu.Plats = plats;
            }

            return menu;
        }

        public async Task<Menu> InsertAsync(Menu entite)
        {
            string requete = @"INSERT INTO Menu(DteMenu, ServiceMidi, DteButoire) OUTPUT INSERTED.IdMenu VALUES(@dteMenu, @serviceMidi, @dteButoire)";
            int idMenu = await _session.Connection.QuerySingleAsync<int>(requete, entite, _session.Transaction);

            List<Plat> plats = entite.Plats;

            string requeteMenuPlats = @"INSERT INTO MenuPlat(IdMenu, IdPlat) VALUES(@idMenu, @idPlat)";

            foreach (var plat in plats)
            {
                await _session.Connection.QueryAsync(requeteMenuPlats, param: new { idMenu, plat.IdPlat }, _session.Transaction);
            }

            return await GetAsync(idMenu);
        }

        public async Task<Menu> UpdateAsync(Menu entite)
        {
            string requete = @"UPDATE Menu SET DteMenu = @dteMenu, ServiceMidi = @serviceMidi, DteButoire = @dteButoire WHERE IdMenu = @idMenu";

            if (entite.Plats != null)
            {
                string requeteDelete = @"DELETE FROM MenuPlat WHERE IdMenu = @idMenu";
                string requeteInsert = @"INSERT INTO MenuPlat(IdMenu, IdPlat) VALUES(@idMenu, @idPlat)";

                await _session.Connection.ExecuteAsync(requeteDelete, entite, _session.Transaction);

                List<Plat> plats = entite.Plats;

                foreach (var plat in plats)
                {
                    await _session.Connection.QueryAsync(requeteInsert, param: new { entite.IdMenu, plat.IdPlat }, _session.Transaction);
                }
            }

            if (await _session.Connection.ExecuteAsync(requete, entite, _session.Transaction) > 0)
            {
                return await GetAsync((int)entite.IdMenu);
            }

            else
            {
                return null;
            }
        }
    }
}
