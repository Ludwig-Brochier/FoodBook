using System;

namespace DAL.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Démarre une transaction SQL
        /// </summary>
        void DebutTransaction();

        /// <summary>
        /// Permet de sauvegarder les changements via un commit SQL
        /// </summary>
        void Commit();

        /// <summary>
        /// Permet de revenir à un état précédent la transaction via un rollback SQL
        /// </summary>
        void Rollback();

        /// <summary>
        /// Permet de récupérer un répertoire précis
        /// </summary>
        /// <typeparam name="T">Répertoire</typeparam>
        /// <returns>Le répertoire demandé</returns>
        T GetRepertoire<T>();
    }
}
