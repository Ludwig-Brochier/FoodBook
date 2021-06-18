using BO.Entite;

namespace DAL.Repertoire
{
    /// <summary>
    /// Interface implémentée par le répertoire Plat
    /// </summary>
    public interface IPlatRepertoire : IRepertoireCRUD<Plat>, IRepertoirePaginable<Plat>
    {
    }
}
