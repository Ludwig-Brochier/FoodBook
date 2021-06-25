using BO.Entite;
using DAL.UOW;
using DAL.Repertoire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class ManagementService : IManagementService
    {
        private readonly IUnitOfWork _bdd;
        public ManagementService(IUnitOfWork unitOfWork)
        {
            _bdd = unitOfWork;
        }


        public async Task<bool> DeleteSemaineAsync(int idSemaine)
        {
            _bdd.DebutTransaction();
            ISemaineRepertoire semaineRepertoire = _bdd.GetRepertoire<ISemaineRepertoire>();
            bool delete = await semaineRepertoire.DeleteAsync(idSemaine);

            if (delete)
            {
                _bdd.Commit();
                return true;
            }

            else
            {
                return false;
            }
        }

        public async Task<Semaine> GetSemaineAsync(int idSemaine)
        {
            ISemaineRepertoire semaineRepertoire = _bdd.GetRepertoire<ISemaineRepertoire>();
            return await semaineRepertoire.GetAsync(idSemaine);
        }

        public async Task<Semaine> InsertSemaineAsync(Semaine semaine)
        {
            _bdd.DebutTransaction();
            ISemaineRepertoire semaineRepertoire = _bdd.GetRepertoire<ISemaineRepertoire>();
            Semaine newSemaine = await semaineRepertoire.InsertAsync(semaine);
            _bdd.Commit();
            return newSemaine;
        }

        public async Task<Semaine> UpdateSemaineAsync(Semaine semaine)
        {
            _bdd.DebutTransaction();
            ISemaineRepertoire semaineRepertoire = _bdd.GetRepertoire<ISemaineRepertoire>();
            Semaine newSemaine = await semaineRepertoire.UpdateAsync(semaine);
            _bdd.Commit();
            return newSemaine;
        }
    }
}
