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
    class SemaineRepertoire : ISemaineRepertoire
    {
        private readonly IDbSession _session;
        public SemaineRepertoire(IDbSession session)
        {
            _session = session;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var requete = @"DELETE FROM Semaine WHERE IdSemaine = @ID";

            Semaine semaine = await GetAsync(id);

            if (semaine.Menus.Count > 0)
            {
                var requeteMenus = @"DELETE FROM Menu WHERE IdSemaine = @ID";

                await _session.Connection.ExecuteAsync(requeteMenus, param: new { ID = id }, _session.Transaction);
            }

            return await _session.Connection.ExecuteAsync(requete, param: new { ID = id }, _session.Transaction) > 0;

        }        

        public async Task<Semaine> GetAsync(int id)
        {
            var requete = @"SELECT * FROM Semaine WHERE IdSemaine = @ID";
            var requeteMenu = @"SELECT IdMenu, ServiceMidi FROM Semaine JOIN Menu ON Semaine.IdSemaine = Menu.IdSemaine WHERE Semaine.IdSemaine = @ID";

            Semaine semaine = await _session.Connection.QueryFirstOrDefaultAsync<Semaine>(requete, param: new { ID = id }, _session.Transaction);

            if (semaine != null)
            {
                semaine.Menus = (List<Menu>) await _session.Connection.QueryAsync<Menu>(requeteMenu, param: new { ID = id }, _session.Transaction);
            }

            return semaine;
        }

        public async Task<Semaine> InsertAsync(Semaine entite)
        {
            var requete = @"INSERT INTO Semaine(DteDebut, DteFin, DteButoir) OUTPUT INSERTED.IdSemaine VALUES(@dteDebut, @dteFin, @dteButoir)";

            int idSemaine = await _session.Connection.QuerySingleAsync<int>(requete, entite, _session.Transaction);

            return await GetAsync(idSemaine);
        }

        public async Task<Semaine> UpdateAsync(Semaine entite)
        {
            var requete = @"UPDATE Semaine SET DteDebut = @dteDebut, DteFin = @dteFin, DteButoir = @dteButoir WHERE IdSemaine = @idSemaine";

            if (await _session.Connection.ExecuteAsync(requete, entite, _session.Transaction) > 0)
            {
                return await GetAsync((int)entite.IdSemaine);
            }

            else
            {
                return null;
            }
        }
    }
}
