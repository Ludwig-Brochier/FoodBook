using ClientDesktop.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientDesktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ChargementAccueil();
        }

        private void ChargementAccueil()
        {
            tlpPage.Controls.Clear();
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
            tlpPage.Controls.Clear();
            MenusPage menusPage = new MenusPage();
            tlpPage.Controls.Add(menusPage);

            GestionCouleursBtn();
            btnMenus.BackColor = Color.FromArgb(255, 224, 192);

        }

        private void btnPlats_Click(object sender, EventArgs e)
        {
            tlpPage.Controls.Clear();
            PlatsPage platsPage = new PlatsPage();
            tlpPage.Controls.Add(platsPage);

            GestionCouleursBtn();
            btnPlats.BackColor = Color.FromArgb(255, 224, 192);
        }

        private void btnCommandes_Click(object sender, EventArgs e)
        {
            tlpPage.Controls.Clear();
            CommandesPage commandesPage = new CommandesPage();
            tlpPage.Controls.Add(commandesPage);

            GestionCouleursBtn();
            btnCommandes.BackColor = Color.FromArgb(255, 224, 192);
        }

        private void GestionCouleursBtn()
        {
            btnMenus.BackColor = Color.White;
            btnPlats.BackColor = Color.White;
            btnCommandes.BackColor = Color.White;
        }
    }
}
