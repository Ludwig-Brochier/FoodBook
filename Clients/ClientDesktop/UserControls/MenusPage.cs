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
    public partial class MenusPage : UserControl
    {
        private readonly IRestaurationService _restaurationService;
        private BindingSource bindingSource = new BindingSource();
        private int pageActuel = 1;
        private int pagination = 50;
        private int maxPage;


        public MenusPage()
        {
            _restaurationService = new RestaurationService();
            InitializeComponent();
        }

        private async void ChargementListe()
        {
            DateTime debut = dtpDebut.Value.Date;
            DateTime fin = dtpFin.Value.Date;

            RequetePeriodique requete = new RequetePeriodique(new DateTime(2021, 08, 30), new DateTime(2021, 09, 03));

            Task<ReponsePeriodique<Menu>> reponseTask = _restaurationService.GetAllMenusAsync(requete);
            ReponsePeriodique<Menu> reponse = await reponseTask;
            maxPage = reponse.TotalPages.GetValueOrDefault();
            bindingSource.DataSource = reponse.Donnees;

            dgvMenus.DataSource = bindingSource;
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            ChargementListe();
        }
    }
}
