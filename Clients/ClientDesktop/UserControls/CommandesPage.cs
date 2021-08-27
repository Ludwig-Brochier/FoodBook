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
        private int? nbIngredient;


        public CommandesPage()
        {
            _commandeService = new CommandeService();
            InitializeComponent();

            txtPagination.Text = pagination.ToString();
            txtPage.Text = pageActuel.ToString();
            btnPrecedent.Enabled = false;
        }

        private async void ChargementListe()
        {
            DateTime debut = dtpDebut.Value.Date;
            DateTime fin = dtpFin.Value.Date;

            RequetePeriodique requete = new RequetePeriodique(new DateTime(2021,08,30), new DateTime(2021,09,03), pageActuel, txtPagination.Text == "50" ? pagination : int.Parse(txtPagination.Text));

            Task<ReponsePeriodique<PlatIngredient>> reponseTask = _commandeService.GetCommandeIngredientsAsync(requete);
            ReponsePeriodique<PlatIngredient> reponse = await reponseTask;
            maxPage = reponse.TotalPages.GetValueOrDefault();
            nbIngredient = reponse.TotalEnregistrements;
            txtNbIngredients.Text = nbIngredient.ToString();
            bindingSource.DataSource = reponse.Donnees;

            dgvIngredients.DataSource = bindingSource;
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            RechargerPage();
        }

        private void RechargerPage()
        {
            txtPage.Text = pageActuel.ToString();
            ChargementListe();

            btnPrecedent.Enabled = pageActuel > 1 ? true : false;
            btnSuivant.Enabled = pageActuel == maxPage ? false : true;
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
