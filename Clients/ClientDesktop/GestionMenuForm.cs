using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using BLLC.Services;

namespace ClientDesktop
{
    public partial class GestionMenuForm : Form
    {
        private readonly IRestaurationService _restaurationService;
        private List<Plat> plats = new List<Plat>();

        public GestionMenuForm()
        {
            _restaurationService = new RestaurationService();
            InitializeComponent();

            cbService.DataSource = new List<String>() {"Midi", "Soir"};
            cbService.DropDownStyle = ComboBoxStyle.DropDownList;

            GetEntrees();
            GetPlats();
            GetDesserts();
        }

        public void Initialise(Menu menu)
        {        
            if (menu == null)
            {
                lbTitre.Text = "Nouveau menu";
                btnMenu.Text = "Ajouter";

                cbEntree.SelectedIndex = -1;
                cbPlat.SelectedIndex = -1;
                cbDessert.SelectedIndex = -1;
            }

            else
            {
                lbTitre.Text = "Modification du menu";
                btnMenu.Text = "Modifier";

                dtpDate.Value = menu.DteMenu;
                if (menu.ServiceMidi == false)
                {
                    cbService.SelectedIndex = 1;
                }

                plats = menu.Plats;
                cbEntree.SelectedItem = plats.FirstOrDefault(p => p.TypePlat == "Entrée").Intitule;
                cbPlat.SelectedItem = plats.FirstOrDefault(p => p.TypePlat == "Plat").Intitule;
                cbDessert.SelectedItem = plats.FirstOrDefault(p => p.TypePlat == "Dessert").Intitule;
            }
        }

        private async void GetEntrees()
        {
            RequeteFiltresPlats requete = new RequeteFiltresPlats(false, "entree", 0, 1, 2147483646);
            Task<ReponsePagination<Plat>> reponseTask = _restaurationService.GetAllPlatsAsync(requete);
            ReponsePagination<Plat> reponse = await reponseTask;

            cbEntree.DataSource = reponse.Donnees;            
            cbEntree.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEntree.DisplayMember = "Intitule";
            cbEntree.FormattingEnabled = true;            
        }

        private async void GetPlats()
        {
            RequeteFiltresPlats requete = new RequeteFiltresPlats(false, "plat", 0, 1, 2147483646);
            Task<ReponsePagination<Plat>> reponseTask = _restaurationService.GetAllPlatsAsync(requete);
            ReponsePagination<Plat> reponse = await reponseTask;

            cbPlat.DataSource = reponse.Donnees;            
            cbPlat.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPlat.DisplayMember = "Intitule";
            cbPlat.FormattingEnabled = true;            
        }

        private async void GetDesserts()
        {
            RequeteFiltresPlats requete = new RequeteFiltresPlats(false, "dessert", 0, 1, 2147483646);
            Task<ReponsePagination<Plat>> reponseTask = _restaurationService.GetAllPlatsAsync(requete);
            ReponsePagination<Plat> reponse = await reponseTask;

            cbDessert.DataSource = reponse.Donnees;
            cbDessert.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDessert.DisplayMember = "Intitule";
            cbDessert.FormattingEnabled = true;
        }
    }
}
