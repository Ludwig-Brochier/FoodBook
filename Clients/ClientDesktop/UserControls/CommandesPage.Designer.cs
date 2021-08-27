
namespace ClientDesktop.UserControls
{
    partial class CommandesPage
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
            this.plMain = new System.Windows.Forms.Panel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lbTitre = new System.Windows.Forms.Label();
            this.tlpPeriode = new System.Windows.Forms.TableLayoutPanel();
            this.lbSemaine1 = new System.Windows.Forms.Label();
            this.lbSemaine2 = new System.Windows.Forms.Label();
            this.dtpDebut = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.tlpNbIngredients = new System.Windows.Forms.TableLayoutPanel();
            this.lbNbIngredients = new System.Windows.Forms.Label();
            this.txtNbIngredients = new System.Windows.Forms.TextBox();
            this.btnActualiser = new System.Windows.Forms.Button();
            this.dgvIngredients = new System.Windows.Forms.DataGridView();
            this.tlpPagination = new System.Windows.Forms.TableLayoutPanel();
            this.lbPagination = new System.Windows.Forms.Label();
            this.txtPagination = new System.Windows.Forms.TextBox();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.btnPrecedent = new System.Windows.Forms.Button();
            this.btnSuivant = new System.Windows.Forms.Button();
            this.plMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpPeriode.SuspendLayout();
            this.tlpNbIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).BeginInit();
            this.tlpPagination.SuspendLayout();
            this.SuspendLayout();
            // 
            // plMain
            // 
            this.plMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.plMain.Controls.Add(this.tlpMain);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 0);
            this.plMain.Margin = new System.Windows.Forms.Padding(0);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(734, 611);
            this.plMain.TabIndex = 1;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lbTitre, 0, 0);
            this.tlpMain.Controls.Add(this.tlpPeriode, 0, 1);
            this.tlpMain.Controls.Add(this.tlpNbIngredients, 0, 2);
            this.tlpMain.Controls.Add(this.dgvIngredients, 0, 3);
            this.tlpMain.Controls.Add(this.tlpPagination, 0, 4);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 6;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlpMain.Size = new System.Drawing.Size(734, 611);
            this.tlpMain.TabIndex = 0;
            // 
            // lbTitre
            // 
            this.lbTitre.AutoSize = true;
            this.lbTitre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitre.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbTitre.Location = new System.Drawing.Point(3, 0);
            this.lbTitre.Name = "lbTitre";
            this.lbTitre.Size = new System.Drawing.Size(728, 50);
            this.lbTitre.TabIndex = 0;
            this.lbTitre.Text = "Commandes des ingrédients";
            this.lbTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpPeriode
            // 
            this.tlpPeriode.ColumnCount = 4;
            this.tlpPeriode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpPeriode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47F));
            this.tlpPeriode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpPeriode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53F));
            this.tlpPeriode.Controls.Add(this.lbSemaine1, 0, 0);
            this.tlpPeriode.Controls.Add(this.lbSemaine2, 2, 0);
            this.tlpPeriode.Controls.Add(this.dtpDebut, 1, 0);
            this.tlpPeriode.Controls.Add(this.dtpFin, 3, 0);
            this.tlpPeriode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPeriode.Location = new System.Drawing.Point(0, 50);
            this.tlpPeriode.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPeriode.Name = "tlpPeriode";
            this.tlpPeriode.RowCount = 1;
            this.tlpPeriode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPeriode.Size = new System.Drawing.Size(734, 50);
            this.tlpPeriode.TabIndex = 1;
            // 
            // lbSemaine1
            // 
            this.lbSemaine1.AutoSize = true;
            this.lbSemaine1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSemaine1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbSemaine1.Location = new System.Drawing.Point(3, 0);
            this.lbSemaine1.Name = "lbSemaine1";
            this.lbSemaine1.Size = new System.Drawing.Size(134, 50);
            this.lbSemaine1.TabIndex = 0;
            this.lbSemaine1.Text = "Semaine du ";
            this.lbSemaine1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbSemaine2
            // 
            this.lbSemaine2.AutoSize = true;
            this.lbSemaine2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSemaine2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbSemaine2.Location = new System.Drawing.Point(401, 0);
            this.lbSemaine2.Name = "lbSemaine2";
            this.lbSemaine2.Size = new System.Drawing.Size(39, 50);
            this.lbSemaine2.TabIndex = 1;
            this.lbSemaine2.Text = "au";
            this.lbSemaine2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDebut
            // 
            this.dtpDebut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDebut.Location = new System.Drawing.Point(143, 15);
            this.dtpDebut.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.dtpDebut.Name = "dtpDebut";
            this.dtpDebut.Size = new System.Drawing.Size(252, 23);
            this.dtpDebut.TabIndex = 2;
            // 
            // dtpFin
            // 
            this.dtpFin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFin.Location = new System.Drawing.Point(446, 15);
            this.dtpFin.Margin = new System.Windows.Forms.Padding(3, 15, 25, 3);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(263, 23);
            this.dtpFin.TabIndex = 3;
            // 
            // tlpNbIngredients
            // 
            this.tlpNbIngredients.ColumnCount = 4;
            this.tlpNbIngredients.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tlpNbIngredients.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpNbIngredients.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNbIngredients.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpNbIngredients.Controls.Add(this.lbNbIngredients, 0, 0);
            this.tlpNbIngredients.Controls.Add(this.txtNbIngredients, 1, 0);
            this.tlpNbIngredients.Controls.Add(this.btnActualiser, 3, 0);
            this.tlpNbIngredients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpNbIngredients.Location = new System.Drawing.Point(0, 100);
            this.tlpNbIngredients.Margin = new System.Windows.Forms.Padding(0);
            this.tlpNbIngredients.Name = "tlpNbIngredients";
            this.tlpNbIngredients.RowCount = 1;
            this.tlpNbIngredients.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNbIngredients.Size = new System.Drawing.Size(734, 50);
            this.tlpNbIngredients.TabIndex = 2;
            // 
            // lbNbIngredients
            // 
            this.lbNbIngredients.AutoSize = true;
            this.lbNbIngredients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNbIngredients.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbNbIngredients.Location = new System.Drawing.Point(3, 0);
            this.lbNbIngredients.Name = "lbNbIngredients";
            this.lbNbIngredients.Size = new System.Drawing.Size(219, 50);
            this.lbNbIngredients.TabIndex = 0;
            this.lbNbIngredients.Text = "Nombre d\'ingrédients :";
            this.lbNbIngredients.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNbIngredients
            // 
            this.txtNbIngredients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNbIngredients.Enabled = false;
            this.txtNbIngredients.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNbIngredients.Location = new System.Drawing.Point(225, 10);
            this.txtNbIngredients.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.txtNbIngredients.Name = "txtNbIngredients";
            this.txtNbIngredients.Size = new System.Drawing.Size(50, 31);
            this.txtNbIngredients.TabIndex = 1;
            this.txtNbIngredients.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnActualiser
            // 
            this.btnActualiser.BackColor = System.Drawing.Color.White;
            this.btnActualiser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnActualiser.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnActualiser.Location = new System.Drawing.Point(534, 5);
            this.btnActualiser.Margin = new System.Windows.Forms.Padding(0, 5, 25, 5);
            this.btnActualiser.Name = "btnActualiser";
            this.btnActualiser.Size = new System.Drawing.Size(175, 40);
            this.btnActualiser.TabIndex = 2;
            this.btnActualiser.Text = "Actualiser";
            this.btnActualiser.UseVisualStyleBackColor = false;
            this.btnActualiser.Click += new System.EventHandler(this.btnActualiser_Click);
            // 
            // dgvIngredients
            // 
            this.dgvIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIngredients.Location = new System.Drawing.Point(25, 155);
            this.dgvIngredients.Margin = new System.Windows.Forms.Padding(25, 5, 25, 5);
            this.dgvIngredients.Name = "dgvIngredients";
            this.dgvIngredients.RowTemplate.Height = 25;
            this.dgvIngredients.Size = new System.Drawing.Size(684, 326);
            this.dgvIngredients.TabIndex = 3;
            // 
            // tlpPagination
            // 
            this.tlpPagination.ColumnCount = 7;
            this.tlpPagination.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tlpPagination.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpPagination.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPagination.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpPagination.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpPagination.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpPagination.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPagination.Controls.Add(this.lbPagination, 0, 0);
            this.tlpPagination.Controls.Add(this.txtPagination, 1, 0);
            this.tlpPagination.Controls.Add(this.txtPage, 4, 0);
            this.tlpPagination.Controls.Add(this.btnPrecedent, 3, 0);
            this.tlpPagination.Controls.Add(this.btnSuivant, 5, 0);
            this.tlpPagination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPagination.Location = new System.Drawing.Point(0, 486);
            this.tlpPagination.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPagination.Name = "tlpPagination";
            this.tlpPagination.RowCount = 1;
            this.tlpPagination.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPagination.Size = new System.Drawing.Size(734, 50);
            this.tlpPagination.TabIndex = 4;
            // 
            // lbPagination
            // 
            this.lbPagination.AutoSize = true;
            this.lbPagination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPagination.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbPagination.Location = new System.Drawing.Point(0, 0);
            this.lbPagination.Margin = new System.Windows.Forms.Padding(0);
            this.lbPagination.Name = "lbPagination";
            this.lbPagination.Size = new System.Drawing.Size(125, 50);
            this.lbPagination.TabIndex = 0;
            this.lbPagination.Text = "Pagination :";
            this.lbPagination.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPagination
            // 
            this.txtPagination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPagination.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPagination.Location = new System.Drawing.Point(125, 10);
            this.txtPagination.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.txtPagination.Name = "txtPagination";
            this.txtPagination.Size = new System.Drawing.Size(50, 31);
            this.txtPagination.TabIndex = 1;
            this.txtPagination.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPage
            // 
            this.txtPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPage.Enabled = false;
            this.txtPage.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPage.Location = new System.Drawing.Point(609, 10);
            this.txtPage.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(40, 31);
            this.txtPage.TabIndex = 3;
            this.txtPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPrecedent
            // 
            this.btnPrecedent.BackColor = System.Drawing.Color.White;
            this.btnPrecedent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrecedent.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPrecedent.Location = new System.Drawing.Point(564, 8);
            this.btnPrecedent.Margin = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.btnPrecedent.Name = "btnPrecedent";
            this.btnPrecedent.Size = new System.Drawing.Size(30, 34);
            this.btnPrecedent.TabIndex = 5;
            this.btnPrecedent.Text = "<";
            this.btnPrecedent.UseVisualStyleBackColor = false;
            this.btnPrecedent.Click += new System.EventHandler(this.btnPrecedent_Click);
            // 
            // btnSuivant
            // 
            this.btnSuivant.BackColor = System.Drawing.Color.White;
            this.btnSuivant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSuivant.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSuivant.Location = new System.Drawing.Point(664, 8);
            this.btnSuivant.Margin = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.btnSuivant.Name = "btnSuivant";
            this.btnSuivant.Size = new System.Drawing.Size(30, 34);
            this.btnSuivant.TabIndex = 6;
            this.btnSuivant.Text = ">";
            this.btnSuivant.UseVisualStyleBackColor = false;
            this.btnSuivant.Click += new System.EventHandler(this.btnSuivant_Click);
            // 
            // CommandesPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plMain);
            this.Name = "CommandesPage";
            this.Size = new System.Drawing.Size(734, 611);
            this.plMain.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpPeriode.ResumeLayout(false);
            this.tlpPeriode.PerformLayout();
            this.tlpNbIngredients.ResumeLayout(false);
            this.tlpNbIngredients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).EndInit();
            this.tlpPagination.ResumeLayout(false);
            this.tlpPagination.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plMain;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lbTitre;
        private System.Windows.Forms.TableLayoutPanel tlpPeriode;
        private System.Windows.Forms.Label lbSemaine1;
        private System.Windows.Forms.Label lbSemaine2;
        private System.Windows.Forms.DateTimePicker dtpDebut;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.TableLayoutPanel tlpNbIngredients;
        private System.Windows.Forms.Label lbNbIngredients;
        private System.Windows.Forms.TextBox txtNbIngredients;
        private System.Windows.Forms.DataGridView dgvIngredients;
        private System.Windows.Forms.TableLayoutPanel tlpPagination;
        private System.Windows.Forms.Label lbPagination;
        private System.Windows.Forms.TextBox txtPagination;
        private System.Windows.Forms.TextBox txtPage;
        private System.Windows.Forms.Button btnActualiser;
        private System.Windows.Forms.Button btnPrecedent;
        private System.Windows.Forms.Button btnSuivant;
    }
}
