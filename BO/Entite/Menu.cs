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
        /// Indique si le menu est prévu pour le midi ou le soir
        /// 1 = Midi, 0 = Soir
        /// </summary>
        public bool ServiceMidi { get; set; }

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
        /// <param bool name="serviceMidi">Si menu du midi = 1 ou du soir = 0</param>
        /// <param name="plats">Liste des plats constituant le menu</param>
        public Menu(int? idMenu, bool serviceMidi, List<Plat> plats)
        {
            IdMenu = idMenu;
            ServiceMidi = serviceMidi;
            Plats = plats;
        }


        public bool Equals(Menu autre)
        {
            return autre != null &&
                IdMenu == autre.IdMenu &&
                ServiceMidi == autre.ServiceMidi &&
                Plats == autre.Plats;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj as Menu);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdMenu, ServiceMidi, Plats);
        }
    }
}
