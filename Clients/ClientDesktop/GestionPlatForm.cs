using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        private bool isAjout = true;

        public GestionPlatForm()
        {
            _restaurationService = new RestaurationService();
            InitializeComponent();
        }

        public void Initialise(Plat plat1)
        {
            if (plat1 == null)
            {
                lbTitre.Text = "Nouveau plat";
                btnPlat.Text = "Ajouter";
            }

            else
            {
                plat = plat1;

                isAjout = false;
                lbTitre.Text = "Modification du plat";
                btnPlat.Text = "Modifier";
            }
        }
    }
}
