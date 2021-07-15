using System;
using System.Collections.Generic;

namespace BO.Entite
{
    /// <summary>
    /// Représente les Menus
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Identifiant du menu
        /// </summary>
        public int? IdMenu { get; set; }

        /// <summary>
        /// Date du menu
        /// </summary>
        public DateTime DteMenu { get; set; }

        /// <summary>
        /// Indique si le menu est prévu pour le midi ou le soir
        /// 1 = Midi, 0 = Soir
        /// </summary>
        public bool ServiceMidi { get; set; }

        /// <summary>
        /// Dade butoire de réservation du menu
        /// </summary>
        public DateTime DteButoire => GetDteButoir(DteMenu);

        /// <summary>
        /// Liste des plats constituant le menu
        /// </summary>
        public List<Plat> Plats { get; set; }


        /// <summary>
        /// Constructeur de base de l'objet Menu
        /// </summary>
        public Menu() { }

        /// <summary>
        /// Constructeur complet de l'obet Menu
        /// </summary>
        /// <param name="idMenu">Identifiant du menu</param>
        /// <param name="dteMenu">Date du menu</param>
        /// <param bool name="serviceMidi">Si menu du midi = 1 ou du soir = 0</param>
        /// <param name="plats">Liste des plats constituant le menu</param>
        public Menu(int? idMenu, DateTime dteMenu, bool serviceMidi, List<Plat> plats)
        {
            IdMenu = idMenu;
            DteMenu = dteMenu;
            ServiceMidi = serviceMidi;
            Plats = plats;
        }


        public bool Equals(Menu autre)
        {
            return autre != null &&
                IdMenu == autre.IdMenu;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Menu);
        }

        public override int GetHashCode()
        {
            int hashCode = -1761736086;
            hashCode = hashCode * -1521134295 + IdMenu.GetHashCode();
            hashCode = hashCode * -1521134295 + DteMenu.GetHashCode();
            hashCode = hashCode * -1521134295 + ServiceMidi.GetHashCode();
            hashCode = hashCode * -1521134295 + DteButoire.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Plat>>.Default.GetHashCode(Plats);
            return hashCode;
        }

        /// <summary>
        /// Méthode pour calculer la date butoire de réservation du menu en fonction de sa date
        /// </summary>
        /// <param name="dteMenu">Date du menu</param>
        /// <returns>Date butoire de réservation du menu</returns>
        private DateTime GetDteButoir(DateTime dteMenu)
        {
            // 0 = Dimanche, 3 = Mercredi, 6 = Samedi
            int jour = (int)dteMenu.DayOfWeek;

            switch (jour)
            {
                case 1:
                    return dteMenu.AddDays(-3);

                case 2:
                    return dteMenu.AddDays(-4);

                case 3:
                    return dteMenu.AddDays(-5);

                case 4:
                    return dteMenu.AddDays(-6);               

                default:
                    return dteMenu.AddDays(-7);
            }
        }
    }
}
