using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLC.Services;
using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.DTO.Modeles;
using BO.Entite;

namespace ClientDesktop.UserControls
{
    public partial class PlatsPage : UserControl
    {
        private readonly IRestaurationService _restaurationService;
        private BindingSource bindingSource = new BindingSource();
        private int nbPlats = 0;
        private int pageActuel = 1;
        private int pagination = 10;
        private int maxPage;

        private bool populaire;
        private string type;
        private int idIngredient;

        private List<Ingredient> ingredients = new();


        public PlatsPage()
        {
            _restaurationService = new RestaurationService();
            InitializeComponent();

            txtPagination.Text = pagination.ToString();
            txtPage.Text = pageActuel.ToString();
            txtNbPlats.Text = nbPlats.ToString();
            btnPrecedent.Enabled = false;
            btnSuivant.Enabled = false;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
                        
            cbFiltre.DataSource = new List<String>() {"", "Populaire", "Type de plat", "Ingrédient"};
            cbFiltre.DropDownStyle = ComboBoxStyle.DropDownList;

            cbType.Visible = false;
            cbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbType.DataSource = new List<String>() { "Entrée", "Plat", "Dessert" };

            cbIngredient.Visible = false;
            cbIngredient.DropDownStyle = ComboBoxStyle.DropDownList;
            ListeIngredient();
        }

        private async void ChargementListe()
        {
            RequeteFiltresPlats requete = new RequeteFiltresPlats(populaire, type, idIngredient, pageActuel, txtPagination.Text == "10" ? pagination : int.Parse(txtPagination.Text));

            if (populaire == true)
            {
                Task<ReponsePagination<PlatPopulaire>> reponseTask = _restaurationService.GetAllPlatsPopulaireAsync(requete);
                ReponsePagination<PlatPopulaire> reponse = await reponseTask;
                maxPage = reponse.TotalPages.GetValueOrDefault();
                nbPlats = reponse.TotalEnregistrements.GetValueOrDefault();
                txtNbPlats.Text = nbPlats.ToString();

                bindingSource.DataSource = reponse.Donnees;
                dgvPlats.DataSource = bindingSource;
            }

            else
            {
                Task<ReponsePagination<Plat>> reponseTask = _restaurationService.GetAllPlatsAsync(requete);
                ReponsePagination<Plat> reponse = await reponseTask;
                maxPage = reponse.TotalPages.GetValueOrDefault();
                nbPlats = reponse.TotalEnregistrements.GetValueOrDefault();
                txtNbPlats.Text = nbPlats.ToString();

                bindingSource.DataSource = reponse.Donnees;
                dgvPlats.DataSource = bindingSource;

                dgvPlats.Columns[0].Visible = false;
                dgvPlats.Columns[1].Width = 400;
            }        

            btnSuivant.Enabled = pageActuel < maxPage ? true : false;
            btnModifier.Enabled = nbPlats > 0 ? true : false;
            btnModifier.Enabled = cbFiltre.SelectedIndex == 0 ? true : false;
            btnSupprimer.Enabled = nbPlats > 0 ? true : false;
            btnSupprimer.Enabled = cbFiltre.SelectedIndex == 0 ? true : false;
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            pageActuel = 1;
            populaire = false;
            type = string.Empty;
            idIngredient = 0;

            GestionFiltre();
            RechargerPage();
        }

        private void RechargerPage()
        {
            ChargementListe();

            txtPage.Text = pageActuel.ToString();
            btnPrecedent.Enabled = pageActuel > 1 ? true : false;
            btnSuivant.Enabled = pageActuel < maxPage ? true : false;
        }

        private void PageSuivante()
        {
            if (pageActuel < maxPage)
            {
                pageActuel++;
                RechargerPage();
            }
        }

        private void PagePrecedente()
        {
            if (pageActuel > 1)
            {
                pageActuel--;
                RechargerPage();
            }
        }

        private void btnPrecedent_Click(object sender, EventArgs e)
        {
            PagePrecedente();
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            PageSuivante();
        }

        private void GestionFiltre()
        {
            if (cbFiltre.SelectedIndex == 1)
            {
                populaire = true;
            }

            else if (cbFiltre.SelectedIndex == 2)
            {
                type = cbType.Text switch
                {
                    "Entrée" => "entree",
                    "Plat" => "plat",
                    _ => "dessert",
                };
            }

            else if (cbFiltre.SelectedIndex == 3)
            {
                Ingredient selected = cbIngredient.SelectedItem as Ingredient;
                idIngredient = selected.IdIngredient.GetValueOrDefault();
            }
        }

        private async void ListeIngredient()
        {
            RequetePagination requete = new RequetePagination(1, 2147483646);
            Task<ReponsePagination<Ingredient>> reponseTask = _restaurationService.GetAllIngredientsAsync(requete);
            ReponsePagination<Ingredient> reponse = await reponseTask;
            ingredients = reponse.Donnees;

            cbIngredient.DataSource = ingredients;
            cbIngredient.DisplayMember = "Intitule";
        }

        private void cbFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbType.Visible = false;
            cbIngredient.Visible = false;

            if (cbFiltre.Text == "Type de plat")
            {
                cbType.Visible = true;
            }

            else if (cbFiltre.Text == "Ingrédient")
            {
                cbIngredient.Visible = true;
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            GestionPlatForm gestionPlat = new GestionPlatForm();
            gestionPlat.Initialise(null);
            gestionPlat.ShowDialog();

            RechargerPage();
        }

        private async void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvPlats.SelectedRows.Count == 1)
            {
                int selected = (int)((Plat)dgvPlats.SelectedRows[0].DataBoundItem).IdPlat;
                Plat plat = await _restaurationService.GetPlatAsync(selected);
                GestionPlatForm gestionPlat = new GestionPlatForm();
                gestionPlat.Initialise(plat);
                gestionPlat.ShowDialog();

                RechargerPage();
            }
        }

        private async void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvPlats.SelectedRows.Count == 1)
            {
                int selected = (int)((Plat)dgvPlats.SelectedRows[0].DataBoundItem).IdPlat;

                DialogResult result = MessageBox.Show("Voulez-vous vraiment supprimer ce plat ?",
                                                        "Attention",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question,
                                                        MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    bool isdelete = await _restaurationService.DeletePlatAsync(selected);
                    string message = "";
                    string titre = "";

                    if (isdelete == true)
                    {
                        message = "Le plat à bien était supprimer.";
                        titre = "Confirmation";

                        RechargerPage();
                    }

                    else
                    {
                        message = "Un ou plusieurs menus sont constitués de ce plat. Suppression impossible !";
                        titre = "Erreur";
                    }

                    MessageBox.Show(message, titre);
                }
            }
        }
    }
}
