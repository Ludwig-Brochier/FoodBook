using System;
using System.Collections.Generic;
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

        //Gestion des filtres de plat
        private bool populaire;
        private string type;
        private int idIngredient;

        private List<Ingredient> ingredients = new();

        /// <summary>
        /// User control pour la gestion des plats
        /// </summary>
        public PlatsPage()
        {
            _restaurationService = new RestaurationService();
            InitializeComponent();

            //Affichage et désactivation au lancement
            txtPagination.Text = pagination.ToString();
            txtPage.Text = pageActuel.ToString();
            txtNbPlats.Text = nbPlats.ToString();
            btnPrecedent.Enabled = false;
            btnSuivant.Enabled = false;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
                        
            //Initialisation du ComboBox pour les filtres de plat
            cbFiltre.DataSource = new List<String>() {"", "Populaire", "Type de plat", "Ingrédient"};
            cbFiltre.DropDownStyle = ComboBoxStyle.DropDownList;

            //Initialisation du ComboBox pour les types de plat
            cbType.Visible = false; //Invisible par défaut
            cbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbType.DataSource = new List<String>() { "Entrée", "Plat", "Dessert" };

            //Initialisation du ComboBox pour le filtre de plat via les ingrédients
            cbIngredient.Visible = false; //Invisible par défaut
            cbIngredient.DropDownStyle = ComboBoxStyle.DropDownList;
            GetListeIngredientAsync();
        }

        /// <summary>
        /// Méthode pour charger la liste des plats
        /// </summary>
        private async void ChargementListe()
        {
            RequeteFiltresPlats requete = new RequeteFiltresPlats(populaire, type, idIngredient, pageActuel, txtPagination.Text == "10" ? pagination : int.Parse(txtPagination.Text));

            //Si filtre par popularité
            if (populaire == true)
            {
                //Consomme l'API pour liste des plats populaire
                Task<ReponsePagination<PlatPopulaire>> reponseTask = _restaurationService.GetAllPlatsPopulaireAsync(requete);
                ReponsePagination<PlatPopulaire> reponse = await reponseTask;
                maxPage = reponse.TotalPages.GetValueOrDefault();
                nbPlats = reponse.TotalEnregistrements.GetValueOrDefault();
                txtNbPlats.Text = nbPlats.ToString();

                //Affichage de la liste
                bindingSource.DataSource = reponse.Donnees;
                dgvPlats.DataSource = bindingSource;
                dgvPlats.Columns[0].HeaderText = "Intitule";
                dgvPlats.Columns[1].HeaderText = "Nombre de réservations";
            }

            else
            {
                //Consomme l'API pour liste des plats
                Task<ReponsePagination<Plat>> reponseTask = _restaurationService.GetAllPlatsAsync(requete);
                ReponsePagination<Plat> reponse = await reponseTask;
                maxPage = reponse.TotalPages.GetValueOrDefault();
                nbPlats = reponse.TotalEnregistrements.GetValueOrDefault();
                txtNbPlats.Text = nbPlats.ToString();

                //Affichage de la liste
                bindingSource.DataSource = reponse.Donnees;
                dgvPlats.DataSource = bindingSource;
                dgvPlats.Columns[0].Visible = false;
                dgvPlats.Columns[1].Width = 400;
                dgvPlats.Columns[2].HeaderText = "Type de plat";
                dgvPlats.Columns[3].DefaultCellStyle.Format = "c"; //Format monétaire avec le signe €
            }        

            //Condition d'activation des boutons
            btnSuivant.Enabled = pageActuel < maxPage ? true : false;
            btnModifier.Enabled = nbPlats > 0 ? true : false;
            btnModifier.Enabled = cbFiltre.SelectedIndex == 0 ? true : false;
            btnSupprimer.Enabled = nbPlats > 0 ? true : false;
            btnSupprimer.Enabled = cbFiltre.SelectedIndex == 0 ? true : false;
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            //Valeur par défaut
            pageActuel = 1;
            populaire = false;
            type = string.Empty;
            idIngredient = 0;

            GestionFiltre();
            RechargerPage();
        }

        /// <summary>
        /// Méthode pour le formulaire
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

        /// <summary>
        /// Méthode pour gérer les filtres de plat
        /// </summary>
        private void GestionFiltre()
        {
            //Si filtre par popularité
            if (cbFiltre.SelectedIndex == 1)
            {
                populaire = true;
            }

            //Si filtre par type de plat
            else if (cbFiltre.SelectedIndex == 2)
            {
                //Condition de renvoi de type
                type = cbType.Text switch
                {
                    "Entrée" => "entree",
                    "Plat" => "plat",
                    _ => "dessert",
                };
            }

            //Si filtre par ingrédient
            else if (cbFiltre.SelectedIndex == 3)
            {
                Ingredient selected = cbIngredient.SelectedItem as Ingredient; //Ingrédient du ComboBox sélectionné
                idIngredient = selected.IdIngredient.GetValueOrDefault(); //Identifiant de l'ingrédient sélectionné
            }
        }

        /// <summary>
        /// Méthode pour récupérer la liste des ingrédients pour filtre de plat
        /// </summary>
        private async void GetListeIngredientAsync()
        {
            //Consomme l'API pour liste ingrédients
            RequetePagination requete = new RequetePagination(1, 2147483646); //Requête pagination avec valeur max de int
            Task<ReponsePagination<Ingredient>> reponseTask = _restaurationService.GetAllIngredientsAsync(requete);
            ReponsePagination<Ingredient> reponse = await reponseTask;
            ingredients = reponse.Donnees;

            //Liaison de la liste ingrédients avec le ComboBox de filtre
            cbIngredient.DataSource = ingredients;
            cbIngredient.DisplayMember = "Intitule";
        }

        /// <summary>
        /// Evénement pour gestion des filtres de plat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Valeurs par défaut
            cbType.Visible = false;
            cbIngredient.Visible = false;

            //Si filtre par type
            if (cbFiltre.Text == "Type de plat")
            {
                cbType.Visible = true; //Affiche le ComboBox filtre par type
            }

            //Si filtre par ingrédient
            else if (cbFiltre.Text == "Ingrédient")
            {
                cbIngredient.Visible = true; //Affiche le ComboBox filtre par ingrédient
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            //Ouvre un formulaire pour la gestion des plats
            GestionPlatForm gestionPlat = new GestionPlatForm();
            gestionPlat.Initialise(null);
            gestionPlat.ShowDialog();

            RechargerPage();
        }

        private async void btnModifier_Click(object sender, EventArgs e)
        {
            //Si un plat de la liste est sélectionné
            if (dgvPlats.SelectedRows.Count == 1)
            {
                int selected = (int)((Plat)dgvPlats.SelectedRows[0].DataBoundItem).IdPlat; //Récupère l'identifiant du plat sélectionné
                Plat plat = await _restaurationService.GetPlatAsync(selected); //Consomme l'API pour récupérer le plat sélectionné
                //Ouvre un formulaire pour la gestion des plats
                GestionPlatForm gestionPlat = new GestionPlatForm();
                gestionPlat.Initialise(plat);
                gestionPlat.ShowDialog();

                RechargerPage();
            }
        }

        private async void btnSupprimer_Click(object sender, EventArgs e)
        {
            //Si un plat de la liste est sélectionné
            if (dgvPlats.SelectedRows.Count == 1)
            {
                int selected = (int)((Plat)dgvPlats.SelectedRows[0].DataBoundItem).IdPlat; //Récupère l'identifiant du plat sélectionné

                //Ouvre une fenêtre popup pour valider la suppréssion
                DialogResult result = MessageBox.Show("Voulez-vous vraiment supprimer ce plat ?",
                                                        "Attention",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question,
                                                        MessageBoxDefaultButton.Button2);

                //Si utilisateur valide la popup
                if (result == DialogResult.Yes)
                {
                    bool isdelete = await _restaurationService.DeletePlatAsync(selected); //Concomme l'API pour supprimer le plat
                    string message = "";
                    string titre = "";

                    //Si la requête a fonctionnée
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

                    //Ouvre une fenêtre popup pour confirmer ou non la suppression
                    MessageBox.Show(message, titre);
                }
            }
        }
    }
}
