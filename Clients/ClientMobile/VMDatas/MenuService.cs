using BO.Entite;
using System;
using System.Collections.Generic;

namespace ClientMobile.VMDatas
{
    /// <summary>
    /// Données utiles pour la gestion des menus
    /// Réécriture propre à l'application mobile de l'entité Menu
    /// </summary>
    public struct MenuService
    {
        public int id;
        public DateTime dteMenu;
        public string midiSoir;
        public string entree;
        public string plat;
        public string dessert;
        
        /// <summary>
        /// Méthode pour transformer un Menu en MenuService
        /// </summary>
        /// <param name="menu">Le menu à transformer</param>
        /// <returns>Le MenuService</returns>
        public static MenuService FromMenu(Menu menu)
        {
            var newMenu = new MenuService();
            newMenu.id = (int)menu.IdMenu;
            newMenu.dteMenu = menu.DteMenu;
            newMenu.midiSoir = menu.ServiceMidi ? "Midi" : "Soir"; //Transformation du bool en string
            List<Plat> plats = menu.Plats;
            //Gestion des plats du menu
            foreach (Plat plat in plats) //Retourne uniquement l'intitulé du plat correspondant
            {
                if (plat.TypePlat == "Entrée")
                {
                    newMenu.entree = plat.Intitule;
                }

                else if (plat.TypePlat == "Plat")
                {
                    newMenu.plat = plat.Intitule;
                }

                else
                {
                    newMenu.dessert = plat.Intitule;
                }
            }
            return newMenu;
        }
    }

}
