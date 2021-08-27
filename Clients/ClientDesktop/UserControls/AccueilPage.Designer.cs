
namespace ClientDesktop.UserControls
{
    partial class AccueilPage
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccueilPage));
            this.tlpPage = new System.Windows.Forms.TableLayoutPanel();
            this.lbAccueil = new System.Windows.Forms.Label();
            this.tlpPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPage
            // 
            this.tlpPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tlpPage.ColumnCount = 1;
            this.tlpPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPage.Controls.Add(this.lbAccueil, 0, 0);
            this.tlpPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPage.Location = new System.Drawing.Point(0, 0);
            this.tlpPage.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPage.Name = "tlpPage";
            this.tlpPage.RowCount = 1;
            this.tlpPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPage.Size = new System.Drawing.Size(734, 611);
            this.tlpPage.TabIndex = 2;
            // 
            // lbAccueil
            // 
            this.lbAccueil.AutoSize = true;
            this.lbAccueil.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbAccueil.Location = new System.Drawing.Point(50, 125);
            this.lbAccueil.Margin = new System.Windows.Forms.Padding(50, 125, 50, 0);
            this.lbAccueil.Name = "lbAccueil";
            this.lbAccueil.Size = new System.Drawing.Size(615, 140);
            this.lbAccueil.TabIndex = 0;
            this.lbAccueil.Text = resources.GetString("lbAccueil.Text");
            // 
            // AccueilPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpPage);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AccueilPage";
            this.Size = new System.Drawing.Size(734, 611);
            this.tlpPage.ResumeLayout(false);
            this.tlpPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPage;
        private System.Windows.Forms.Label lbAccueil;
    }
}
