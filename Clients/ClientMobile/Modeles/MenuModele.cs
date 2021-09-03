using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.Entite;
using BLLC.Services;
using BO.DTO.Requetes;
using BO.DTO.Reponses;

namespace ClientMobile.Modeles
{
    public class MenuModele : ModeleBase
    {
        private readonly IRestaurationService _restaurationService = new RestaurationService();
        private static MenuModele Instance;
        private static readonly object Verrou = new object();

        public List<Menu> menus;
        
        private bool isLoaded = false; //

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
        }

        public async Task SetListMenu()
        {
            menus = await GetMenusServicesAsync();

            for (int i = 0; i < menus.Count; i++)
            {
                Menu menu = menus[i];
                menus[i].Plats = await GetPlatsMenuAsync((int)menu.IdMenu);
            }
        }

        public async Task<List<Menu>> GetMenusServicesAsync()
        {
            RequetePeriodique requete = new RequetePeriodique(new DateTime(2021, 08, 30), new DateTime(2021, 09, 03), 1, 10);
            ReponsePeriodique<Menu> reponse = await _restaurationService.GetAllMenusAsync(requete);
            return reponse.Donnees;
        }

        public async Task<List<Plat>> GetPlatsMenuAsync(int idMenu)
        {
            Menu menu = await _restaurationService.GetMenuAsync(idMenu);
            return menu.Plats;
        }
    }
}
