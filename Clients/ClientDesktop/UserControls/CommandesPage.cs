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

namespace ClientDesktop.UserControls
{
    public partial class CommandesPage : UserControl
    {
        private readonly ICommandeService _commandeService;
        private BindingSource bindingSource = new BindingSource();
        private int pageActuel = 1;
        private int pagination = 50;
        private int maxPage;


        public CommandesPage()
        {
            _commandeService = new CommandeService();
            InitializeComponent();

            txtPagination.Text = pagination.ToString();
            txtPage.Text = pageActuel.ToString();
            btnPrecedent.Enabled = false;
            btnSuivant.Enabled = false;
        }

        private async void ChargementListe()
        {
            DateTime debut = dtpDebut.Value.Date;
            DateTime fin = dtpFin.Value.Date;

            RequetePeriodique requete = new RequetePeriodique(new DateTime(2021, 09, 13), new DateTime(2021, 09, 17), pageActuel, txtPagination.Text == "50" ? pagination : int.Parse(txtPagination.Text));

            Task<ReponsePeriodique<PlatIngredient>> reponseTask = _commandeService.GetCommandeIngredientsAsync(requete);
            ReponsePeriodique<PlatIngredient> reponse = await reponseTask;
            maxPage = reponse.TotalPages.GetValueOrDefault();
            txtNbIngredients.Text = reponse.TotalEnregistrements.ToString();

            bindingSource.DataSource = reponse.Donnees;
            dgvIngredients.DataSource = bindingSource;

            btnSuivant.Enabled = pageActuel < maxPage ? true : false;
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
    }
}
