using System;

namespace BO.Entite
{
    /// <summary>
    /// Représente la Réservation d'un client
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// Identifiant de la réservation
        /// </summary>
        public int? IdReservation { get; set; }

        /// <summary>
        /// Nom du client passant la réservation
        /// </summary>
        public String Nom { get; set; }

        /// <summary>
        /// Prénom du client passant la réservation
        /// </summary>
        public String Prenom { get; set; }

        /// <summary>
        /// Numéro de téléphone du client passant la réservation
        /// </summary>
        public String NumTel { get; set; }

        /// <summary>
        /// Date et heure de la réservation
        /// </summary>
        public DateTime DteResa { get; set; }

        /// <summary>
        /// Date de la prise de réservation par le client
        /// Valeur par défaut: SYSDATE
        /// </summary>
        public DateTime DtePriseResa { get; set; }

        /// <summary>
        /// Nombre de personnes inclus dans la réservation
        /// </summary>
        public int NbPersonne { get; set; }

        /// <summary>
        /// Objet Menu réservé
        /// </summary>
        public Menu Menu { get; set; }

        /// <summary>
        /// Objet Formule du menu réservé
        /// </summary>
        public Formule Formule { get; set; }


        /// <summary>
        /// Constructeur de base de l'objet Reservation
        /// </summary>
        public Reservation() { }

        /// <summary>
        /// Constructeur complet de l'objet Reservation
        /// </summary>
        /// <param name="idReservation">Identifiant de la réservation</param>
        /// <param name="nom">Nom du client</param>
        /// <param name="prenom">Prénom du client</param>
        /// <param name="numTel">Numéro de téléphone du client</param>
        /// <param name="dteResa">Date et heure de la réservation</param>
        /// <param name="dtePriseResa">Date de la prise de la réservation</param>
        /// <param name="nbPersonne">Nombre de personnes inclus dans la réservation</param>
        /// <param name="menu">Le menu réservé</param>
        /// <param name="formule">La formule du menu</param>
        public Reservation(int? idReservation, String nom, String prenom, String numTel, DateTime dteResa, DateTime dtePriseResa, int nbPersonne, Menu menu, Formule formule)
        {
            IdReservation = idReservation;
            Nom = nom;
            Prenom = prenom;
            NumTel = numTel;
            DteResa = dteResa;
            DtePriseResa = dtePriseResa;
            NbPersonne = nbPersonne;
            Menu = menu;
            Formule = formule;
        }


        public bool Equals(Reservation autre)
        {
            return autre != null &&
                IdReservation == autre.IdReservation &&
                Nom == autre.Nom &&
                Prenom == autre.Prenom &&
                NumTel == autre.NumTel &&
                DteResa == autre.DteResa &&
                DtePriseResa == autre.DtePriseResa &&
                NbPersonne == autre.NbPersonne &&
                Menu == autre.Menu &&
                Formule == autre.Formule;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj as Reservation);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(IdReservation);
            hash.Add(Nom);
            hash.Add(Prenom);
            hash.Add(NumTel);
            hash.Add(DteResa);
            hash.Add(DtePriseResa);
            hash.Add(NbPersonne);
            hash.Add(Menu);
            hash.Add(Formule);
            return hash.ToHashCode();
        }
    }
}
