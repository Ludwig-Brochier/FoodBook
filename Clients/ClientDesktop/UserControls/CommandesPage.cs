using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLC.Services;
using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;

namespace ClientDesktop.UserControls
{
    public partial class CommandesPage : UserControl
    {
        private readonly ICommandeService _commandeService;
        private BindingSource bindingSource = new BindingSource();
        private int pageActuel = 1;
        private int pagination = 50;
        private int maxPage;

        /// <summary>
        /// User control pour la visualisation des commandes
        /// </summary>
        public CommandesPage()
        {
            _commandeService = new CommandeService();
            InitializeComponent();

            //Affichage et désactivation au lancement
            txtPagination.Text = pagination.ToString();
            txtPage.Text = pageActuel.ToString();
            btnPrecedent.Enabled = false;
            btnSuivant.Enabled = false;
        }

        /// <summary>
        /// Méthode pour charger la liste des commandes
        /// </summary>
        private async void ChargementListe()
        {
            //Période précise
            DateTime debut = dtpDebut.Value.Date;
            DateTime fin = dtpFin.Value.Date;

            RequetePeriodique requete = new RequetePeriodique(debut, fin, pageActuel, txtPagination.Text == "50" ? pagination : int.Parse(txtPagination.Text));

            //Consomme l'API pour liste des commandes
            Task<ReponsePeriodique<PlatIngredient>> reponseTask = _commandeService.GetCommandeIngredientsAsync(requete);
            ReponsePeriodique<PlatIngredient> reponse = await reponseTask;

            if (reponse != null)
            {
                maxPage = reponse.TotalPages.GetValueOrDefault();
                txtNbIngredients.Text = reponse.TotalEnregistrements.ToString();

                //Affichage de la liste
                bindingSource.DataSource = reponse.Donnees;
                dgvIngredients.DataSource = bindingSource;
                dgvIngredients.Columns[0].HeaderText = "Ingrédient";
                dgvIngredients.Columns[1].HeaderText = "Quantité";

                //Condition si bouton page suivante est actif ou non
                btnSuivant.Enabled = pageActuel < maxPage ? true : false;
            }

            else
            {
                //Message d'erreur
                dgvIngredients.DataSource = null;
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
    }
}
