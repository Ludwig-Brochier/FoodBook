using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using BLLC.Services;

namespace ClientDesktop
{
    public partial class GestionPlatForm : Form
    {
        private readonly IRestaurationService _restaurationService;
        private Plat plat = new Plat();
        private List<PlatIngredient> ingredientsPlat = new List<PlatIngredient>();
        private BindingSource bsIngredients = new BindingSource();
        private bool isAjout = true; //Booléen de controle si ajout ou modification

        /// <summary>
        /// Formulaire pour la gestion d'un plat
        /// </summary>
        public GestionPlatForm()
        {
            _restaurationService = new RestaurationService();
            InitializeComponent();

            //Initialisation du ComboBox pour le type du plat
            cbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbType.FormattingEnabled = true;
            cbType.DataSource = new List<String>() { "Entrée", "Plat", "Dessert" };

            //Valeur par défaut pour la quantité d'un ingrédient
            txtQuantite.Text = "1";
        }

        /// <summary>
        /// Méthode d'appel pour envoyer un plat à gérer
        /// </summary>
        /// <param name="plat1">Le plat à gérer</param>
        public void Initialise(Plat plat1)
        {
            GetListeIngredientAsync();
            
            //Si ajout d'un nouveau plat
            if (plat1 == null)
            {
                //Propriétés visuelles si ajout d'un nouveau plat
                lbTitre.Text = "Nouveau plat";
                btnPlat.Text = "Ajouter";

                //Sélectionne une case vide du ComboBox de type de plat
                cbType.SelectedIndex = -1;
            }

            //Si modification d'un plat éxistant
            else
            {
                plat = plat1;

                isAjout = false;
                //Propriétés visuelles si modification d'un plat éxistant
                lbTitre.Text = "Modification du plat";
                btnPlat.Text = "Modifier";

                //Récupère les infos du plat à gérer
                txtIntitule.Text = plat.Intitule;
                cbType.SelectedItem = plat.TypePlat;
                txtPrix.Text = plat.Prix.ToString();
                ingredientsPlat = plat.PlatIngredients;                
            }

            ChargementListeIngredientsPlat();
        }

        private async void btnPlat_Click(object sender, EventArgs e)
        {
            if (isAjout == true)
            {
                //Condition si tout les champs sont renseignés
                if (txtIntitule.Text != string.Empty && cbType.SelectedIndex != -1 && txtPrix.Text != string.Empty)
                {
                    //Consomme l'API et ajoute un nouveau plat
                    Plat newPlat = await _restaurationService.InsertPlatAsync(new Plat(0, txtIntitule.Text, cbType.SelectedItem.ToString(), 
                                                                                        float.Parse(txtPrix.Text), ingredientsPlat));

                    //Si la requête a fonctionnée
                    if (newPlat.IdPlat != null)
                    {
                        //Ouvre une fenêtre popup pour confirmer l'ajout
                        DialogResult result = MessageBox.Show("Le plat à bien était ajouté.", "Confirmation", MessageBoxButtons.OK);
                        if (result == DialogResult.OK || result == DialogResult.Cancel)
                        {
                            //Fermeture du formulaire
                            this.Close();
                        }
                    }

                    else
                    {
                        //Ouvre une fenêtre popup pour signaler l'éxistence du plat
                        MessageBox.Show("Le plat éxiste déjà !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                //Condition si tout les champs sont renseignés
                if (txtIntitule.Text != string.Empty && txtPrix.Text != string.Empty)
                {
                    //Consomme l'API et modifie le plat
                    Plat newPlat = await _restaurationService.UpdatePlatAsync(new Plat(plat.IdPlat, txtIntitule.Text, cbType.SelectedItem.ToString(),
                                                                                        float.Parse(txtPrix.Text), ingredientsPlat));

                    //Si la requête a fonctionnée
                    if (newPlat.IdPlat != null)
                    {
                        //Ouvre une fenêtre popup pour confirmer la modification
                        DialogResult result = MessageBox.Show("Le plat à bien était modifié.", "Confirmation", MessageBoxButtons.OK);
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

                else
                {
                    //Ouvre une fenêtre popup pour la non saisie des champs
                    MessageBox.Show("Veuillez renseigner tous les champs !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        /// <summary>
        /// Ajoute un ingrédient et sa quantité à la liste des ingrédients du plat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (bsIngredients.Current != null)
            {
                Ingredient selected = bsIngredients.Current as Ingredient;
                ingredientsPlat.Add(new PlatIngredient(selected, int.Parse(txtQuantite.Text)));

                ChargementListeIngredientsPlat();
            }            
        }

        /// <summary>
        /// Supprime un ingrédient et sa quantité de la liste des ingrédients du plat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoins_Click(object sender, EventArgs e)
        {
            if (dgvIngredientsPlat.SelectedRows.Count == 1)
            {
                ingredientsPlat.Remove(dgvIngredientsPlat.SelectedRows[0].DataBoundItem as PlatIngredient);

                ChargementListeIngredientsPlat();
            }
        }

        /// <summary>
        /// Méthode pour récupérer la liste des ingrédients
        /// </summary>
        private async void GetListeIngredientAsync()
        {
            //Consomme l'API pour liste ingrédients
            RequetePagination requete = new RequetePagination(1, 2147483646); //Requête pagination avec valeur max de int
            Task<ReponsePagination<Ingredient>> reponseTask = _restaurationService.GetAllIngredientsAsync(requete);
            ReponsePagination<Ingredient> reponse = await reponseTask;

            bsIngredients.DataSource = reponse.Donnees;

            //Affichage de la liste
            dgvIngredients.DataSource = bsIngredients;
            dgvIngredients.Columns[0].Visible = false;
            dgvIngredients.Columns[2].Visible = false;
        }

        /// <summary>
        /// Méthode pour recharger la liste des ingrédients du plat
        /// </summary>
        private void ChargementListeIngredientsPlat()
        {
            dgvIngredientsPlat.DataSource = ingredientsPlat;
        }
    }
}
