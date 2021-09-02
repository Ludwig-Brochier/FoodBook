using BO.Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMobile.VMDatas
{
    public struct MenuService
    {
        public int id;
        public DateTime dteMenu;
        public string midiSoir;
        public string entree;
        public string plat;
        public string dessert;
        
        public static MenuService FromMenu(Menu menu)
        {
            var newMenu = new MenuService();
            newMenu.id = (int)menu.IdMenu;
            newMenu.dteMenu = menu.DteMenu;
            newMenu.midiSoir = menu.ServiceMidi ? "Midi" : "Soir";
            List<Plat> plats = menu.Plats;
            foreach (Plat plat in plats)
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
