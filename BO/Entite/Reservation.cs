using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BO.Entite
{
    /// <summary>
    /// Représente les Réservations d'un client
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
        [MaxLength(64, ErrorMessage = "Le nom doit être inférieur à 64 caractères")]
        public String Nom { get; set; }

        /// <summary>
        /// Prénom du client passant la réservation
        /// </summary>
        [MaxLength(64, ErrorMessage = "Le prénom doit être inférieur à 64 caractères")]
        public String Prenom { get; set; }

        /// <summary>
        /// Numéro de téléphone du client passant la réservation
        /// </summary>
        [MaxLength(32, ErrorMessage = "Le numéro de téléphone doit être inférieur à 32 caractères")]
        public String NumTel { get; set; }

        /// <summary>
        /// Date de la prise de réservation par le client
        /// </summary>
        public DateTime DtePriseResa { get; }

        /// <summary>
        /// Nombre de personnes inclus dans la réservation
        /// </summary>
        [Range(1, 9, ErrorMessage = "Le nombre de participants doit être compris entre 1 et 9")]
        public int NbPersonne { get; set; }

        /// <summary>
        /// Le Menu réservé
        /// </summary>
        public Menu Menu { get; set; }

        /// <summary>
        /// La Formule du menu réservé
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
        /// <param name="nbPersonne">Nombre de personnes inclus dans la réservation</param>
        /// <param name="menu">Le menu réservé</param>
        /// <param name="formule">La formule du menu</param>
        public Reservation(int? idReservation, String nom, String prenom, String numTel, int nbPersonne, Menu menu, Formule formule)
        {
            IdReservation = idReservation;
            Nom = nom;
            Prenom = prenom;
            NumTel = numTel;
            NbPersonne = nbPersonne;
            Menu = menu;
            Formule = formule;
        }


        public bool Equals(Reservation autre)
        {
            return autre != null &&
                IdReservation == autre.IdReservation &&
                Nom.ToLower() == autre.Nom.ToLower() &&
                Prenom.ToLower() == autre.Prenom.ToLower() &&
                NumTel == autre.NumTel &&
                DtePriseResa == autre.DtePriseResa &&
                NbPersonne == autre.NbPersonne &&
                Menu.IdMenu == autre.Menu.IdMenu &&
                Formule.IdFormule == autre.Formule.IdFormule;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Reservation);
        }

        public override int GetHashCode()
        {
            int hashCode = 842853851;
            hashCode = hashCode * -1521134295 + IdReservation.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nom);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Prenom);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NumTel);
            hashCode = hashCode * -1521134295 + DtePriseResa.GetHashCode();
            hashCode = hashCode * -1521134295 + NbPersonne.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Menu>.Default.GetHashCode(Menu);
            hashCode = hashCode * -1521134295 + EqualityComparer<Formule>.Default.GetHashCode(Formule);
            return hashCode;
        }
    }
}
