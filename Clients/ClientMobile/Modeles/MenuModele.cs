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
        private static MenuModele _instance;
        private static readonly object Verrou = new object();
        private DateTime debutSemaine;
        private DateTime finSemaine;
        public List<Menu> menus;

        public static MenuModele Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Verrou)
                    {
                        if (_instance == null)
                        {
                            _instance = new MenuModele();
                        }
                    }
                }

                return _instance;
            }
        }

        private MenuModele()
        {
            SemaineMenu();
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
            RequetePeriodique requete = new RequetePeriodique(debutSemaine, finSemaine, 1, 10);
            ReponsePeriodique<Menu> reponse = await _restaurationService.GetAllMenusAsync(requete);
            return reponse.Donnees;
        }

        public async Task<List<Plat>> GetPlatsMenuAsync(int idMenu)
        {
            Menu menu = await _restaurationService.GetMenuAsync(idMenu);
            return menu.Plats;
        }

        public void SemaineMenu()
        {
            DateTime dateDepart = GetDateDepart();
            int daysUntilMonday = ((int)DayOfWeek.Monday - (int)dateDepart.DayOfWeek + 7) % 7;
            if (daysUntilMonday == 0)
            {
                daysUntilMonday = 7;
            }

            debutSemaine = dateDepart.AddDays(daysUntilMonday);
            finSemaine = debutSemaine.AddDays(4);
        }

        public DateTime GetDateDepart()
        {
            DateTime today = DateTime.Today;
            switch ((int)today.DayOfWeek)
            {
                case 6:
                    return today.AddDays(2);
                case 0:
                    return today.AddDays(1);
                default:
                    return today;
            }
        }
    }
}
