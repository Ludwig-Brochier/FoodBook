using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.Entite;

namespace ClientMobile.Modeles
{
    public class MenuModele : ModeleBase
    {
        private static MenuModele Instance;
        private static readonly object Verrou = new object();

        public List<Menu> menus;

        public static MenuModele GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    lock (Verrou)
                    {
                        if (Instance == null)
                        {
                            Instance = new MenuModele();
                        }
                    }
                }

                return Instance;
            }
        }

        private MenuModele()
        {
            List<Menu> donnees = new List<Menu>()
            {
                new Menu()
                {
                    IdMenu = 1,
                    DteMenu = new DateTime(2021, 08, 30),
                    ServiceMidi = true,
                    Plats = new List<Plat>()
                    {
                        new Plat(1, "Entrée 1", "Entrée", 10, null),
                        new Plat(2, "Plat 1", "Plat", 10, null),
                        new Plat(3, "Dessert 1", "Dessert", 10, null)
                    }
                },

                new Menu()
                {
                    IdMenu = 2,
                    DteMenu = new DateTime(2021, 08, 30),
                    ServiceMidi = false,
                    Plats = new List<Plat>()
                    {
                        new Plat(4, "Entrée 2", "Entrée", 10, null),
                        new Plat(5, "Plat 2", "Plat", 10, null),
                        new Plat(6, "Dessert 2", "Dessert", 10, null)
                    }
                },

                new Menu()
                {
                    IdMenu = 3,
                    DteMenu = new DateTime(2021, 08, 31),
                    ServiceMidi = true,
                    Plats = new List<Plat>()
                    {
                        new Plat(7, "Entrée 3", "Entrée", 10, null),
                        new Plat(8, "Plat 3", "Plat", 10, null),
                        new Plat(9, "Dessert 3", "Dessert", 10, null)
                    }
                },

                new Menu()
                {
                    IdMenu = 4,
                    DteMenu = new DateTime(2021, 08, 31),
                    ServiceMidi = false,
                    Plats = new List<Plat>()
                    {
                        new Plat(10, "Entrée 4", "Entrée", 10, null),
                        new Plat(11, "Plat 4", "Plat", 10, null),
                        new Plat(12, "Dessert 4", "Dessert", 10, null)
                    }
                },

                new Menu()
                {
                    IdMenu = 5,
                    DteMenu = new DateTime(2021, 09, 01),
                    ServiceMidi = true,
                    Plats = new List<Plat>()
                    {
                        new Plat(13, "Entrée 5", "Entrée", 10, null),
                        new Plat(14, "Plat 5", "Plat", 10, null),
                        new Plat(15, "Dessert 5", "Dessert", 10, null)
                    }
                },

                new Menu()
                {
                    IdMenu = 6,
                    DteMenu = new DateTime(2021, 09, 01),
                    ServiceMidi = false,
                    Plats = new List<Plat>()
                    {
                        new Plat(16, "Entrée 6", "Entrée", 10, null),
                        new Plat(17, "Plat 6", "Plat", 10, null),
                        new Plat(18, "Dessert 6", "Dessert", 10, null)
                    }
                },

                new Menu()
                {
                    IdMenu = 7,
                    DteMenu = new DateTime(2021, 09, 02),
                    ServiceMidi = true,
                    Plats = new List<Plat>()
                    {
                        new Plat(19, "Entrée 7", "Entrée", 10, null),
                        new Plat(20, "Plat 7", "Plat", 10, null),
                        new Plat(21, "Dessert 7", "Dessert", 10, null)
                    }
                },

                new Menu()
                {
                    IdMenu = 8,
                    DteMenu = new DateTime(2021, 09, 02),
                    ServiceMidi = false,
                    Plats = new List<Plat>()
                    {
                        new Plat(22, "Entrée 8", "Entrée", 10, null),
                        new Plat(23, "Plat 8", "Plat", 10, null),
                        new Plat(24, "Dessert 8", "Dessert", 10, null)
                    }
                }
            };

            menus = new List<Menu>(donnees);
        }
    }
}
