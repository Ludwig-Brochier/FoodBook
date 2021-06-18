using BO.Entite;

namespace DAL.Repertoire
{
    /// <summary>
    /// Interface implémentée par le répertoire réservation
    /// </summary>
    public interface IReservationRepertoire : IRepertoireCRUD<Reservation>, IRepertoirePeriodique<Reservation>
    {
    }
}
