using Microsoft.Extensions.DependencyInjection;
using System;

namespace DAL.UOW
{
    sealed class UnitOfWork : IUnitOfWork
    {
        private readonly IDbSession _session;
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(IDbSession session, IServiceProvider serviceProvider)
        {
            _session = session;
            _serviceProvider = serviceProvider;
        }

        public void Commit()
        {
            _session.Transaction.Commit();
            Dispose();
        }

        public void DebutTransaction()
        {
            _session.Transaction = _session.Connection.BeginTransaction();
        }

        public void Dispose()
        {
            _session.Transaction?.Dispose();
        }

        public T GetRepertoire<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }

        public void Rollback()
        {
            _session.Transaction.Rollback();
            Dispose();
        }
    }
}
