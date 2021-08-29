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
using BO.Entite;
using ClientDesktop;

namespace ClientDesktop.UserControls
{
    public partial class MenusPage : UserControl
    {
        private readonly IRestaurationService _restaurationService;
        private BindingSource bindingSource = new BindingSource();
        private int nbMenus = 0;
        private int pageActuel = 1;
        private int pagination = 10;
        private int maxPage;


        public MenusPage()
        {
            _restaurationService = new RestaurationService();

            InitializeComponent();

            txtPagination.Text = pagination.ToString();
            txtPage.Text = pageActuel.ToString();
            txtNbMenus.Text = nbMenus.ToString();
            btnPrecedent.Enabled = false;
            btnSuivant.Enabled = false;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
        }

        private async void ChargementListe()
        {
            DateTime debut = dtpDebut.Value.Date;
            DateTime fin = dtpFin.Value.Date;

            RequetePeriodique requete = new RequetePeriodique(debut, fin, pageActuel, txtPagination.Text == "10" ? pagination : int.Parse(txtPagination.Text));

            Task<ReponsePeriodique<Menu>> reponseTask = _restaurationService.GetAllMenusAsync(requete);
            ReponsePeriodique<Menu> reponse = await reponseTask;

            if (reponse != null)
            {
                maxPage = reponse.TotalPages.GetValueOrDefault();
                nbMenus = reponse.TotalEnregistrements.GetValueOrDefault();
                txtNbMenus.Text = nbMenus.ToString();

                bindingSource.DataSource = reponse.Donnees;
                dgvMenus.DataSource = bindingSource;

                dgvMenus.Columns[0].Visible = false;
                dgvMenus.Columns[2].ReadOnly = true;

                btnSuivant.Enabled = pageActuel < maxPage ? true : false;
                btnModifier.Enabled = nbMenus > 0 ? true : false;
                btnSupprimer.Enabled = nbMenus > 0 ? true : false;
            }

            else
            {
                dgvMenus.DataSource = null;
                MessageBox.Show("Veuillez saisir une date de fin supérieure à la date de début.", "Attention !", buttons: MessageBoxButtons.OK);
            }
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            pageActuel = 1;
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

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            GestionMenuForm gestionMenu = new GestionMenuForm();
            gestionMenu.Initialise(null);
            gestionMenu.ShowDialog();

            RechargerPage();
        }                

        private async void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvMenus.SelectedRows.Count == 1)
            {
                int selected = (int)((Menu)dgvMenus.SelectedRows[0].DataBoundItem).IdMenu;
                Menu menu = await _restaurationService.GetMenuAsync(selected);
                GestionMenuForm gestionMenu = new GestionMenuForm();
                gestionMenu.Initialise(menu);
                gestionMenu.ShowDialog();

                RechargerPage();
            }            
        }

        private async void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvMenus.SelectedRows.Count == 1)
            {
                int selected = (int)((Menu)dgvMenus.SelectedRows[0].DataBoundItem).IdMenu;

                DialogResult result = MessageBox.Show("Voulez-vous vraiment supprimer ce menu ?",
                                                        "Attention",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question,
                                                        MessageBoxDefaultButton.Button2) ;

                if (result == DialogResult.Yes)
                {
                    bool isdelete = await _restaurationService.DeleteMenuAsync(selected);
                    string message = "";
                    string titre = "";

                    if (isdelete == true)
                    {
                        message = "Le menu à bien était supprimer.";
                        titre = "Confirmation";

                        RechargerPage();
                    }

                    else
                    {
                        message = "Une ou plusieurs réservations sont actives pour ce menu. Suppression impossible !";
                        titre = "Erreur";
                    }

                    MessageBox.Show(message, titre);
                }
            }
        }
    }
}
