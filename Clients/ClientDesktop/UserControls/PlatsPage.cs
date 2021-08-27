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
    public partial class PlatsPage : UserControl
    {
        private readonly IRestaurationService _restaurationService;
        private BindingSource bindingSource = new BindingSource();
        private int pageActuel = 1;
        private int pagination = 50;
        private int maxPage;


        public PlatsPage()
        {
            _restaurationService = new RestaurationService();
            InitializeComponent();
        }

        private async void ChargementListe()
        {
            RequeteFiltresPlats requete = new RequeteFiltresPlats();
            Task<ReponsePagination<Plat>> reponseTask = _restaurationService.GetAllPlatsAsync(requete);
            ReponsePagination<Plat> reponse = await reponseTask;
            maxPage = reponse.TotalPages.GetValueOrDefault();
            bindingSource.DataSource = reponse.Donnees;

            dgvPlats.DataSource = bindingSource;
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            ChargementListe();
        }
    }
}
