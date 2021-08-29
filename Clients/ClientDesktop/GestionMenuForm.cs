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
        private Menu menu = new Menu();
        private List<Plat> plats = new List<Plat>();
        private bool isAjout = true;

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

        public void Initialise(Menu menu1)
        {        
            if (menu1 == null)
            {
                lbTitre.Text = "Nouveau menu";
                btnMenu.Text = "Ajouter";
            }

            else
            {
                menu = menu1;

                isAjout = false;
                lbTitre.Text = "Modification du menu";
                btnMenu.Text = "Modifier";

                dtpDate.Value = menu.DteMenu;
                if (menu.ServiceMidi == false)
                {
                    cbService.SelectedIndex = 1;
                }

                plats = menu.Plats;                
            }
        }

        private async void btnMenu_Click(object sender, EventArgs e)
        {
            if (isAjout == true)
            {
                if (cbEntree.SelectedIndex != -1 && cbPlat.SelectedIndex != -1 && cbDessert.SelectedIndex != -1)
                {
                    Menu newMenu = await _restaurationService.InsertMenuAsync(new Menu(0, dtpDate.Value, cbService.Text == "Midi" ? true : false, 
                                                                                new List<Plat>() { cbEntree.SelectedItem as Plat, 
                                                                                cbPlat.SelectedItem as Plat, 
                                                                                cbDessert.SelectedItem as Plat }));

                    if (newMenu.IdMenu != null)
                    {
                        DialogResult result = MessageBox.Show("Le menu à bien était ajouté.", "Confirmation", MessageBoxButtons.OK);
                        if (result == DialogResult.OK || result == DialogResult.Cancel)
                        {
                            this.Close();
                        }
                    }

                    else
                    {
                        MessageBox.Show("Le menu éxiste déjà !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }

                else
                {
                    MessageBox.Show("Veuillez renseigner tous les champs !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            else if (isAjout == false)
            {
                Menu newMenu = await _restaurationService.UpdateMenuAsync(new Menu(menu.IdMenu, dtpDate.Value, cbService.Text == "Midi" ? true : false,
                                                                            new List<Plat>() { cbEntree.SelectedItem as Plat,
                                                                            cbPlat.SelectedItem as Plat,
                                                                            cbDessert.SelectedItem as Plat }));

                if (newMenu.IdMenu != null)
                {
                    DialogResult result = MessageBox.Show("Le menu à bien était modifié.", "Confirmation", MessageBoxButtons.OK);
                    if (result == DialogResult.OK || result == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                }

                else
                {
                    MessageBox.Show("Une erreur est survenue.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                DialogResult result = MessageBox.Show("Une erreur est survenue.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK || result == DialogResult.Cancel)
                {
                    this.Close();
                }
            }
        }

        private async void GetEntrees()
        {
            RequeteFiltresPlats requete = new RequeteFiltresPlats(false, "entree", 0, 1, 2147483646);
            Task<ReponsePagination<Plat>> reponseTask = _restaurationService.GetAllPlatsAsync(requete);
            ReponsePagination<Plat> reponse = await reponseTask;

            cbEntree.DataSource = reponse.Donnees;            
            cbEntree.DropDownStyle = ComboBoxStyle.DropDownList;            
            cbEntree.FormattingEnabled = true;
            if (isAjout == true)
            {
                cbEntree.SelectedIndex = -1;
            }
            else
            {
                cbEntree.SelectedItem = plats.FirstOrDefault(p => p.TypePlat == "Entrée");
            }
            cbEntree.DisplayMember = "Intitule";
        }

        private async void GetPlats()
        {
            RequeteFiltresPlats requete = new RequeteFiltresPlats(false, "plat", 0, 1, 2147483646);
            Task<ReponsePagination<Plat>> reponseTask = _restaurationService.GetAllPlatsAsync(requete);
            ReponsePagination<Plat> reponse = await reponseTask;

            cbPlat.DataSource = reponse.Donnees;            
            cbPlat.DropDownStyle = ComboBoxStyle.DropDownList;            
            cbPlat.FormattingEnabled = true;
            if (isAjout == true)
            {
                cbPlat.SelectedIndex = -1;
            }
            else
            {
                cbPlat.SelectedItem = plats.FirstOrDefault(p => p.TypePlat == "Plat");
            }
            cbPlat.DisplayMember = "Intitule";
        }

        private async void GetDesserts()
        {
            RequeteFiltresPlats requete = new RequeteFiltresPlats(false, "dessert", 0, 1, 2147483646);
            Task<ReponsePagination<Plat>> reponseTask = _restaurationService.GetAllPlatsAsync(requete);
            ReponsePagination<Plat> reponse = await reponseTask;

            cbDessert.DataSource = reponse.Donnees;
            cbDessert.DropDownStyle = ComboBoxStyle.DropDownList;            
            cbDessert.FormattingEnabled = true;
            if (isAjout == true)
            {
                cbDessert.SelectedIndex = -1;
            }
            else
            {
                cbDessert.SelectedItem = plats.FirstOrDefault(p => p.TypePlat == "Dessert");
            }
            cbDessert.DisplayMember = "Intitule";
        }
    }
}
