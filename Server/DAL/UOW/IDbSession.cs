using System.Data;

namespace DAL.UOW
{
    public interface IDbSession
    {
        /// <summary>
        /// Permet de lancer une connection à une base de données SQL
        /// </summary>
        IDbConnection Connection { get; }

        /// <summary>
        /// Permet de démarrer une nouvelle transaction SQL
        /// </summary>
        IDbTransaction Transaction { get; set; }
    }
}
