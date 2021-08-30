using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLC.Services;
using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;

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

        /// <summary>
        /// User control pour la gestion des menus
        /// </summary>
        public MenusPage()
        {
            _restaurationService = new RestaurationService();
            InitializeComponent();

            //Affichage et désactivation au lancement
            txtPagination.Text = pagination.ToString();
            txtPage.Text = pageActuel.ToString();
            txtNbMenus.Text = nbMenus.ToString();
            btnPrecedent.Enabled = false;
            btnSuivant.Enabled = false;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
        }

        /// <summary>
        /// Méthode pour charger la liste des menus
        /// </summary>
        private async void ChargementListe()
        {
            //Période précise
            DateTime debut = dtpDebut.Value.Date;
            DateTime fin = dtpFin.Value.Date;

            RequetePeriodique requete = new RequetePeriodique(debut, fin, pageActuel, txtPagination.Text == "10" ? pagination : int.Parse(txtPagination.Text));

            //Consomme l'API pour liste des menus
            Task<ReponsePeriodique<Menu>> reponseTask = _restaurationService.GetAllMenusAsync(requete);
            ReponsePeriodique<Menu> reponse = await reponseTask;

            if (reponse != null)
            {
                //Affichage des infos
                maxPage = reponse.TotalPages.GetValueOrDefault();
                nbMenus = reponse.TotalEnregistrements.GetValueOrDefault();
                txtNbMenus.Text = nbMenus.ToString();

                //Affichage de la liste
                bindingSource.DataSource = reponse.Donnees;
                dgvMenus.DataSource = bindingSource;
                dgvMenus.Columns[0].Visible = false;
                dgvMenus.Columns[1].HeaderText = "Date du menu";
                dgvMenus.Columns[1].DefaultCellStyle.Format = "D";
                dgvMenus.Columns[2].ReadOnly = true;
                dgvMenus.Columns[2].HeaderText = "Service de midi";
                dgvMenus.Columns[3].HeaderText = "Date butoire";
                dgvMenus.Columns[3].DefaultCellStyle.Format = "D";

                //Condition si boutons actifs ou non
                btnSuivant.Enabled = pageActuel < maxPage ? true : false;
                btnModifier.Enabled = nbMenus > 0 ? true : false;
                btnSupprimer.Enabled = nbMenus > 0 ? true : false;
            }

            else
            {
                //Message d'erreur
                dgvMenus.DataSource = null;
                MessageBox.Show("Veuillez saisir une date de fin supérieure à la date de début.", "Attention !", buttons: MessageBoxButtons.OK);
            }
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            //Valeur par défaut
            pageActuel = 1;
            RechargerPage();
        }

        /// <summary>
        /// Méthode pour recharger le formulaire
        /// </summary>
        private void RechargerPage()
        {
            ChargementListe();

            //Conditions d'affichage et d'activation des boutons
            txtPage.Text = pageActuel.ToString();
            btnPrecedent.Enabled = pageActuel > 1 ? true : false;
            btnSuivant.Enabled = pageActuel < maxPage ? true : false;
        }

        /// <summary>
        /// Méthode page suivante en rapport avec la pagination
        /// </summary>
        private void PageSuivante()
        {
            if (pageActuel < maxPage)
            {
                pageActuel++;
                RechargerPage();
            }
        }

        /// <summary>
        /// Méthode page précèdente en rapport avec la pagination
        /// </summary>
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
            //Ouvre un formulaire pour la gestion d'un menu
            GestionMenuForm gestionMenu = new GestionMenuForm();
            gestionMenu.Initialise(null);
            gestionMenu.ShowDialog();

            RechargerPage();
        }                

        private async void btnModifier_Click(object sender, EventArgs e)
        {
            //Si un menu de la liste est sélectionné.
            if (dgvMenus.SelectedRows.Count == 1)
            {                
                int selected = (int)((Menu)dgvMenus.SelectedRows[0].DataBoundItem).IdMenu; //Récupère l'identifiant du menu sélectionné
                Menu menu = await _restaurationService.GetMenuAsync(selected); //Consomme l'API pour récupérer le menu sélectionné
                //Ouvre un formulaire pour la gestion d'un menu
                GestionMenuForm gestionMenu = new GestionMenuForm();
                gestionMenu.Initialise(menu);
                gestionMenu.ShowDialog();

                RechargerPage();
            }            
        }

        private async void btnSupprimer_Click(object sender, EventArgs e)
        {
            //Si un menu de la liste est sélectionné
            if (dgvMenus.SelectedRows.Count == 1)
            {
                int selected = (int)((Menu)dgvMenus.SelectedRows[0].DataBoundItem).IdMenu; //Récupère l'identifiant du menu sélectionné

                //Ouvre une fenêtre popup pour valider la suppréssion
                DialogResult result = MessageBox.Show("Voulez-vous vraiment supprimer ce menu ?",
                                                        "Attention",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question,
                                                        MessageBoxDefaultButton.Button2) ;

                //Si utilisateur valide la popup
                if (result == DialogResult.Yes)
                {
                    bool isdelete = await _restaurationService.DeleteMenuAsync(selected); //Consomme l'API pour supprimer le menu
                    string message = "";
                    string titre = "";

                    //Si la requête a fonctionnée
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

                    //Ouvre une fenêtre popup pour confirmer ou non la suppression
                    MessageBox.Show(message, titre);
                }
            }
        }
    }
}
