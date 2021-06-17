using BO.Entite;
using DAL.UOW;
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


        public Task<bool> DeleteSemaineAsync(int idSemaine)
        {
            throw new NotImplementedException();
        }

        public Task<Semaine> GetSemaineAsync(int idSemaine)
        {
            throw new NotImplementedException();
        }

        public Task<Semaine> InsertSemaineAsync(Semaine semaine)
        {
            throw new NotImplementedException();
        }

        public Task<Semaine> UpdateSemaineAsync(Semaine semaine)
        {
            throw new NotImplementedException();
        }
    }
}
