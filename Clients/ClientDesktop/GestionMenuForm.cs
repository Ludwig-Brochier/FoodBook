using System;
using System.Collections.Generic;
using System.Linq;
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
        private bool isAjout = true; //Booléen de controle si ajout ou modification

        /// <summary>
        /// Formulaire pour la gestion de menu
        /// </summary>
        public GestionMenuForm()
        {
            _restaurationService = new RestaurationService();
            InitializeComponent();

            //Initialisation du ComboBox pour le type de service
            cbService.DataSource = new List<String>() {"Midi", "Soir"};
            cbService.DropDownStyle = ComboBoxStyle.DropDownList;

            //Initialisation des listes de plat selon type
            GetEntreesAsync();
            GetPlatsAsync();
            GetDessertsAsync();
        }

        /// <summary>
        /// Méthode d'appel pour envoyer un menu à gérer
        /// </summary>
        /// <param name="menu1">Le menu à gérer</param>
        public void Initialise(Menu menu1)
        {        
            //Si ajout d'un nouveau menu
            if (menu1 == null)
            {
                //Propriétés visuelles si ajout d'un nouveau menu
                lbTitre.Text = "Nouveau menu";
                btnMenu.Text = "Ajouter";
            }

            //Si modification d'un menu éxistant
            else
            {
                menu = menu1;

                isAjout = false;
                //Propriétés visuelles si modification d'un menu éxistant
                lbTitre.Text = "Modification du menu";
                btnMenu.Text = "Modifier";

                //Récupère la date du menu à gérer dans un DateTimePicker
                dtpDate.Value = menu.DteMenu;
                if (menu.ServiceMidi == false)
                {
                    cbService.SelectedIndex = 1;
                }

                //Liaison de la liste des plats du menu à gérer
                plats = menu.Plats;                
            }
        }

        private async void btnMenu_Click(object sender, EventArgs e)
        {
            if (isAjout == true)
            {
                //Condition si tout les champs sont renseignés
                if (cbEntree.SelectedIndex != -1 && cbPlat.SelectedIndex != -1 && cbDessert.SelectedIndex != -1)
                {
                    //Consomme l'API et ajoute un nouveau menu
                    Menu newMenu = await _restaurationService.InsertMenuAsync(new Menu(0, dtpDate.Value, cbService.Text == "Midi" ? true : false, 
                                                                                new List<Plat>() { cbEntree.SelectedItem as Plat, 
                                                                                cbPlat.SelectedItem as Plat, 
                                                                                cbDessert.SelectedItem as Plat }));

                    //Si la requête a fonctionnée
                    if (newMenu.IdMenu != null)
                    {
                        //Ouvre une fenêtre popup pour confirmer l'ajout
                        DialogResult result = MessageBox.Show("Le menu à bien était ajouté.", "Confirmation", MessageBoxButtons.OK);
                        if (result == DialogResult.OK || result == DialogResult.Cancel)
                        {
                            //Fermeture du formulaire
                            this.Close();
                        }
                    }

                    else
                    {
                        //Ouvre une fenêtre popup pour signaler l'éxistence du menu
                        MessageBox.Show("Le menu éxiste déjà !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }

                else
                {
                    //Ouvre une fenêtre popup pour la non saisie des champs
                    MessageBox.Show("Veuillez renseigner tous les champs !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            else
            {
                //Consomme l'API et modifie le menu
                Menu newMenu = await _restaurationService.UpdateMenuAsync(new Menu(menu.IdMenu, dtpDate.Value, cbService.Text == "Midi" ? true : false,
                                                                            new List<Plat>() { cbEntree.SelectedItem as Plat,
                                                                            cbPlat.SelectedItem as Plat,
                                                                            cbDessert.SelectedItem as Plat }));

                //Si la requête a fonctionnée
                if (newMenu.IdMenu != null)
                {
                    //Ouvre une fenêtre popup pour confirmer la modification
                    DialogResult result = MessageBox.Show("Le menu à bien était modifié.", "Confirmation", MessageBoxButtons.OK);
                    if (result == DialogResult.OK || result == DialogResult.Cancel)
                    {
                        //Fermeture du formulaire
                        this.Close();
                    }
                }

                else
                {
                    //Ouvre une fenêtre popup pour signaler une erreur
                    MessageBox.Show("Une erreur est survenue.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Méthode pour récupérer la liste des plats de type entrée
        /// </summary>
        private async void GetEntreesAsync()
        {
            //Consomme l'API pour liste des plats de type entrée
            RequeteFiltresPlats requete = new RequeteFiltresPlats(false, "entree", 0, 1, 2147483646);
            Task<ReponsePagination<Plat>> reponseTask = _restaurationService.GetAllPlatsAsync(requete);
            ReponsePagination<Plat> reponse = await reponseTask;

            //Initialisation du ComboBox pour le type entrée
            cbEntree.DataSource = reponse.Donnees;            
            cbEntree.DropDownStyle = ComboBoxStyle.DropDownList;            
            cbEntree.FormattingEnabled = true;
            
            if (isAjout == true)
            {
                //Ajout d'un nouveau menu
                cbEntree.SelectedIndex = -1; //Sélectionne une case vide
            }
            else
            {
                //Modification d'un menu
                cbEntree.SelectedItem = plats.FirstOrDefault(p => p.TypePlat == "Entrée"); //Sélectionne l'entrée du menu
            }
            cbEntree.DisplayMember = "Intitule";
        }

        /// <summary>
        /// Méthode pour récupérer la liste des plats de type plat
        /// </summary>
        private async void GetPlatsAsync()
        {
            //Consomme l'API pour liste des plats de type plat
            RequeteFiltresPlats requete = new RequeteFiltresPlats(false, "plat", 0, 1, 2147483646);
            Task<ReponsePagination<Plat>> reponseTask = _restaurationService.GetAllPlatsAsync(requete);
            ReponsePagination<Plat> reponse = await reponseTask;

            //Initialisation du ComboBox pour le type plat
            cbPlat.DataSource = reponse.Donnees;            
            cbPlat.DropDownStyle = ComboBoxStyle.DropDownList;            
            cbPlat.FormattingEnabled = true;
            if (isAjout == true)
            {
                //Ajout d'un nouveau menu
                cbPlat.SelectedIndex = -1; //Sélectionne une case vide
            }
            else
            {
                //Modification d'un menu
                cbPlat.SelectedItem = plats.FirstOrDefault(p => p.TypePlat == "Plat"); //Sélectionne le plat du menu
            }
            cbPlat.DisplayMember = "Intitule";
        }

        /// <summary>
        /// Méthode pour récupérer la liste des plats de type dessert
        /// </summary>
        private async void GetDessertsAsync()
        {
            //Consomme l'API pour liste des plats de type dessert
            RequeteFiltresPlats requete = new RequeteFiltresPlats(false, "dessert", 0, 1, 2147483646);
            Task<ReponsePagination<Plat>> reponseTask = _restaurationService.GetAllPlatsAsync(requete);
            ReponsePagination<Plat> reponse = await reponseTask;

            //Initialisation du ComboBox pour le type dessert
            cbDessert.DataSource = reponse.Donnees;
            cbDessert.DropDownStyle = ComboBoxStyle.DropDownList;            
            cbDessert.FormattingEnabled = true;
            if (isAjout == true)
            {
                //Ajout d'un nouveau menu
                cbDessert.SelectedIndex = -1; //Sélectionne une case vide
            }
            else
            {
                //Modification d'un menu
                cbDessert.SelectedItem = plats.FirstOrDefault(p => p.TypePlat == "Dessert"); //Sélectionne le dessert du menu
            }
            cbDessert.DisplayMember = "Intitule";
        }
    }
}
