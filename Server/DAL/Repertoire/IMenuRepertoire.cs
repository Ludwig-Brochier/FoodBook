using BO.Entite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repertoire
{
    /// <summary>
    /// Interface implémentée par le répertoire Menu
    /// </summary>
    public interface IMenuRepertoire : IRepertoireCRUD<Menu>, IRepertoirePeriodique<Menu>
    {
    }
}
