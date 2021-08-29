using ClientDesktop.UserControls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClientDesktop
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Formulaire par défaut
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            ChargementAccueil();
        }

        /// <summary>
        /// Méthode pour afficher la page d'accueil
        /// </summary>
        private void ChargementAccueil()
        {
            tlpPage.Controls.Clear(); //Supprime le dernier User control chargé
            //Ouvre le User control d'accueil
            AccueilPage accueilPage = new AccueilPage(); 
            tlpPage.Controls.Add(accueilPage); 

            GestionCouleursBtn();
        }

        private void btnLogoAccueil_Click(object sender, EventArgs e)
        {
            ChargementAccueil();
        }

        private void btnMenus_Click(object sender, EventArgs e)
        {
            tlpPage.Controls.Clear(); //Supprime le dernier User control chargé
            //Ouvre le User control des menus
            MenusPage menusPage = new MenusPage();
            tlpPage.Controls.Add(menusPage);

            //Applique une couleur pour signaler le menu de navigation sélectionné
            GestionCouleursBtn();
            btnMenus.BackColor = Color.FromArgb(255, 224, 192);

        }

        private void btnPlats_Click(object sender, EventArgs e)
        {
            tlpPage.Controls.Clear(); //Supprime le dernier User control chargé
            //Ouvre le User control des plats
            PlatsPage platsPage = new PlatsPage();
            tlpPage.Controls.Add(platsPage);

            //Applique une couleur pour signaler le menu de navigation sélectionné
            GestionCouleursBtn();
            btnPlats.BackColor = Color.FromArgb(255, 224, 192);
        }

        private void btnCommandes_Click(object sender, EventArgs e)
        {
            tlpPage.Controls.Clear(); //Supprime le dernier User control chargé
            //Ouvre le User control des commandes
            CommandesPage commandesPage = new CommandesPage();
            tlpPage.Controls.Add(commandesPage);

            //Applique une couleur pour signaler le menu de navigation sélectionné
            GestionCouleursBtn();
            btnCommandes.BackColor = Color.FromArgb(255, 224, 192); 
        }

        /// <summary>
        /// Méthode pour gérer réinitialiser la couleur des boutons du menu de navigation
        /// </summary>
        private void GestionCouleursBtn()
        {
            btnMenus.BackColor = Color.White;
            btnPlats.BackColor = Color.White;
            btnCommandes.BackColor = Color.White;
        }
    }
}
