using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BO.Entite;
using BLLC.Services;
using BO.DTO.Requetes;
using BO.DTO.Reponses;

namespace ClientMobile.Modeles
{
    /// <summary>
    /// Modele de l'entité Menu
    /// </summary>
    public class MenuModele : ModeleBase
    {
        private readonly IRestaurationService _restaurationService = new RestaurationService(); 
        private static MenuModele _instance;
        private static readonly object Verrou = new object();
        private DateTime debutSemaine;
        private DateTime finSemaine;
        public List<Menu> menus;

        /// <summary>
        /// Singleton du model de Menu
        /// </summary>
        public static MenuModele Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Verrou) //Thread safe
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
            SemaineMenu(); //La semaine du service à afficher
        }

        /// <summary>
        /// Initialise les menus du service
        /// </summary>
        /// <returns></returns>
        public async Task SetListMenu()
        {
            menus = await GetMenusServicesAsync();

            for (int i = 0; i < menus.Count; i++)
            {
                Menu menu = menus[i];
                menus[i].Plats = await GetPlatsMenuAsync((int)menu.IdMenu); //Ajoute les plats du menu
            }
        }

        /// <summary>
        /// Récupère les menus
        /// Consomme l'API via la BLLC
        /// </summary>
        /// <returns>Liste de menu</returns>
        public async Task<List<Menu>> GetMenusServicesAsync()
        {
            RequetePeriodique requete = new RequetePeriodique(debutSemaine, finSemaine, 1, 10);
            ReponsePeriodique<Menu> reponse = await _restaurationService.GetAllMenusAsync(requete);
            return reponse.Donnees;
        }

        /// <summary>
        /// Récupère les plats du menu
        /// Consomme l'API via la BLLC
        /// </summary>
        /// <param name="idMenu">Identifiant du menu</param>
        /// <returns>Liste des plats du menu</returns>
        public async Task<List<Plat>> GetPlatsMenuAsync(int idMenu)
        {
            Menu menu = await _restaurationService.GetMenuAsync(idMenu);
            return menu.Plats;
        }

        /// <summary>
        /// Détermine la semaine du service
        /// </summary>
        public void SemaineMenu()
        {
            DateTime dateDepart = GetDateDepart(); //Départ de la semaine
            int daysUntilMonday = ((int)DayOfWeek.Monday - (int)dateDepart.DayOfWeek + 7) % 7; //Nombre de jour avant le Lundi suivant
            if (daysUntilMonday == 0)
            {
                daysUntilMonday = 7;
            }

            debutSemaine = dateDepart.AddDays(daysUntilMonday); //Récupère la date du Lundi suivant
            finSemaine = debutSemaine.AddDays(4); //Semaine de 5 jours
        }

        /// <summary>
        /// Détermine la date de départ de la semaine du service
        /// </summary>
        /// <returns></returns>
        public DateTime GetDateDepart()
        {
            DateTime today = DateTime.Today;
            switch ((int)today.DayOfWeek)
            {
                case 6: //Si Samedi
                    return today.AddDays(2); //Saute 2 jours
                case 0: //Si Dimanche
                    return today.AddDays(1); //Saute 1 jour
                default:
                    return today;
            }
        }
    }
}
