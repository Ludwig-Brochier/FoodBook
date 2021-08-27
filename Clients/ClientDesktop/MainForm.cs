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
        }

        private void btnPlats_Click(object sender, EventArgs e)
        {
            tlpPage.Controls.Clear();
            PlatsPage platsPage = new PlatsPage();
            tlpPage.Controls.Add(platsPage);
        }

        private void btnCommandes_Click(object sender, EventArgs e)
        {
            tlpPage.Controls.Clear();
            CommandesPage commandesPage = new CommandesPage();
            tlpPage.Controls.Add(commandesPage);
        }
    }
}
