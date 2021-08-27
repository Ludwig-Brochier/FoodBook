
namespace ClientDesktop.UserControls
{
    partial class PlatsPage
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
            this.tlpFiltres = new System.Windows.Forms.TableLayoutPanel();
            this.lbFiltre = new System.Windows.Forms.Label();
            this.cbFiltre = new System.Windows.Forms.ComboBox();
            this.plFiltre = new System.Windows.Forms.Panel();
            this.cbIngredient = new System.Windows.Forms.ListBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.tlpNbPlats = new System.Windows.Forms.TableLayoutPanel();
            this.lbNbPlats = new System.Windows.Forms.Label();
            this.txtNbPlats = new System.Windows.Forms.TextBox();
            this.btnActualiser = new System.Windows.Forms.Button();
            this.dgvPlats = new System.Windows.Forms.DataGridView();
            this.tlpPagination = new System.Windows.Forms.TableLayoutPanel();
            this.lbPagination = new System.Windows.Forms.Label();
            this.txtPagination = new System.Windows.Forms.TextBox();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.tlpBoutons = new System.Windows.Forms.TableLayoutPanel();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnPrecedent = new System.Windows.Forms.Button();
            this.btnSuivant = new System.Windows.Forms.Button();
            this.plMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpFiltres.SuspendLayout();
            this.plFiltre.SuspendLayout();
            this.tlpNbPlats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlats)).BeginInit();
            this.tlpPagination.SuspendLayout();
            this.tlpBoutons.SuspendLayout();
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
            this.plMain.TabIndex = 0;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lbTitre, 0, 0);
            this.tlpMain.Controls.Add(this.tlpFiltres, 0, 1);
            this.tlpMain.Controls.Add(this.tlpNbPlats, 0, 2);
            this.tlpMain.Controls.Add(this.dgvPlats, 0, 3);
            this.tlpMain.Controls.Add(this.tlpPagination, 0, 4);
            this.tlpMain.Controls.Add(this.tlpBoutons, 0, 5);
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
            this.lbTitre.Location = new System.Drawing.Point(0, 0);
            this.lbTitre.Margin = new System.Windows.Forms.Padding(0);
            this.lbTitre.Name = "lbTitre";
            this.lbTitre.Size = new System.Drawing.Size(734, 50);
            this.lbTitre.TabIndex = 0;
            this.lbTitre.Text = "Gestion des plats";
            this.lbTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpFiltres
            // 
            this.tlpFiltres.ColumnCount = 3;
            this.tlpFiltres.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tlpFiltres.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tlpFiltres.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFiltres.Controls.Add(this.lbFiltre, 0, 0);
            this.tlpFiltres.Controls.Add(this.cbFiltre, 1, 0);
            this.tlpFiltres.Controls.Add(this.plFiltre, 2, 0);
            this.tlpFiltres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFiltres.Location = new System.Drawing.Point(0, 50);
            this.tlpFiltres.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFiltres.Name = "tlpFiltres";
            this.tlpFiltres.RowCount = 1;
            this.tlpFiltres.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFiltres.Size = new System.Drawing.Size(734, 50);
            this.tlpFiltres.TabIndex = 1;
            // 
            // lbFiltre
            // 
            this.lbFiltre.AutoSize = true;
            this.lbFiltre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFiltre.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbFiltre.Location = new System.Drawing.Point(0, 0);
            this.lbFiltre.Margin = new System.Windows.Forms.Padding(0);
            this.lbFiltre.Name = "lbFiltre";
            this.lbFiltre.Size = new System.Drawing.Size(190, 50);
            this.lbFiltre.TabIndex = 0;
            this.lbFiltre.Text = "Filtre de recherche :";
            this.lbFiltre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbFiltre
            // 
            this.cbFiltre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbFiltre.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbFiltre.FormattingEnabled = true;
            this.cbFiltre.Location = new System.Drawing.Point(190, 10);
            this.cbFiltre.Margin = new System.Windows.Forms.Padding(0, 10, 15, 0);
            this.cbFiltre.Name = "cbFiltre";
            this.cbFiltre.Size = new System.Drawing.Size(235, 31);
            this.cbFiltre.TabIndex = 1;
            // 
            // plFiltre
            // 
            this.plFiltre.Controls.Add(this.cbIngredient);
            this.plFiltre.Controls.Add(this.cbType);
            this.plFiltre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plFiltre.Location = new System.Drawing.Point(450, 8);
            this.plFiltre.Margin = new System.Windows.Forms.Padding(10, 8, 25, 8);
            this.plFiltre.Name = "plFiltre";
            this.plFiltre.Size = new System.Drawing.Size(259, 34);
            this.plFiltre.TabIndex = 2;
            // 
            // cbIngredient
            // 
            this.cbIngredient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbIngredient.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbIngredient.FormattingEnabled = true;
            this.cbIngredient.ItemHeight = 23;
            this.cbIngredient.Location = new System.Drawing.Point(0, 0);
            this.cbIngredient.Margin = new System.Windows.Forms.Padding(0);
            this.cbIngredient.Name = "cbIngredient";
            this.cbIngredient.ScrollAlwaysVisible = true;
            this.cbIngredient.Size = new System.Drawing.Size(259, 34);
            this.cbIngredient.Sorted = true;
            this.cbIngredient.TabIndex = 1;
            this.cbIngredient.Visible = false;
            // 
            // cbType
            // 
            this.cbType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbType.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(0, 0);
            this.cbType.Margin = new System.Windows.Forms.Padding(0);
            this.cbType.MaxDropDownItems = 3;
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(259, 31);
            this.cbType.TabIndex = 0;
            this.cbType.Visible = false;
            // 
            // tlpNbPlats
            // 
            this.tlpNbPlats.ColumnCount = 4;
            this.tlpNbPlats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpNbPlats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpNbPlats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNbPlats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpNbPlats.Controls.Add(this.lbNbPlats, 0, 0);
            this.tlpNbPlats.Controls.Add(this.txtNbPlats, 1, 0);
            this.tlpNbPlats.Controls.Add(this.btnActualiser, 3, 0);
            this.tlpNbPlats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpNbPlats.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tlpNbPlats.Location = new System.Drawing.Point(0, 100);
            this.tlpNbPlats.Margin = new System.Windows.Forms.Padding(0);
            this.tlpNbPlats.Name = "tlpNbPlats";
            this.tlpNbPlats.RowCount = 1;
            this.tlpNbPlats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNbPlats.Size = new System.Drawing.Size(734, 50);
            this.tlpNbPlats.TabIndex = 2;
            // 
            // lbNbPlats
            // 
            this.lbNbPlats.AutoSize = true;
            this.lbNbPlats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNbPlats.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbNbPlats.Location = new System.Drawing.Point(0, 0);
            this.lbNbPlats.Margin = new System.Windows.Forms.Padding(0);
            this.lbNbPlats.Name = "lbNbPlats";
            this.lbNbPlats.Size = new System.Drawing.Size(180, 50);
            this.lbNbPlats.TabIndex = 0;
            this.lbNbPlats.Text = "Nombre de plats :";
            this.lbNbPlats.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNbPlats
            // 
            this.txtNbPlats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNbPlats.Enabled = false;
            this.txtNbPlats.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNbPlats.Location = new System.Drawing.Point(180, 10);
            this.txtNbPlats.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.txtNbPlats.Name = "txtNbPlats";
            this.txtNbPlats.Size = new System.Drawing.Size(50, 31);
            this.txtNbPlats.TabIndex = 1;
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
            // dgvPlats
            // 
            this.dgvPlats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlats.Location = new System.Drawing.Point(25, 155);
            this.dgvPlats.Margin = new System.Windows.Forms.Padding(25, 5, 25, 5);
            this.dgvPlats.Name = "dgvPlats";
            this.dgvPlats.RowTemplate.Height = 25;
            this.dgvPlats.Size = new System.Drawing.Size(684, 326);
            this.dgvPlats.TabIndex = 3;
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
            this.tlpPagination.TabIndex = 5;
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
            this.txtPage.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPage.Location = new System.Drawing.Point(609, 10);
            this.txtPage.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(40, 31);
            this.txtPage.TabIndex = 3;
            this.txtPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tlpBoutons
            // 
            this.tlpBoutons.ColumnCount = 7;
            this.tlpBoutons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpBoutons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpBoutons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpBoutons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpBoutons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpBoutons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpBoutons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpBoutons.Controls.Add(this.btnAjouter, 1, 0);
            this.tlpBoutons.Controls.Add(this.btnModifier, 3, 0);
            this.tlpBoutons.Controls.Add(this.btnSupprimer, 5, 0);
            this.tlpBoutons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBoutons.Location = new System.Drawing.Point(0, 536);
            this.tlpBoutons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBoutons.Name = "tlpBoutons";
            this.tlpBoutons.RowCount = 1;
            this.tlpBoutons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBoutons.Size = new System.Drawing.Size(734, 75);
            this.tlpBoutons.TabIndex = 6;
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.White;
            this.btnAjouter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAjouter.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAjouter.Location = new System.Drawing.Point(40, 15);
            this.btnAjouter.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(188, 45);
            this.btnAjouter.TabIndex = 0;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.White;
            this.btnModifier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnModifier.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnModifier.Location = new System.Drawing.Point(273, 15);
            this.btnModifier.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(188, 45);
            this.btnModifier.TabIndex = 1;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.White;
            this.btnSupprimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSupprimer.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSupprimer.Location = new System.Drawing.Point(506, 15);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(188, 45);
            this.btnSupprimer.TabIndex = 2;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
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
            this.btnPrecedent.TabIndex = 4;
            this.btnPrecedent.Text = "<";
            this.btnPrecedent.UseVisualStyleBackColor = false;
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
            this.btnSuivant.TabIndex = 5;
            this.btnSuivant.Text = ">";
            this.btnSuivant.UseVisualStyleBackColor = false;
            // 
            // PlatsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plMain);
            this.Name = "PlatsPage";
            this.Size = new System.Drawing.Size(734, 611);
            this.plMain.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpFiltres.ResumeLayout(false);
            this.tlpFiltres.PerformLayout();
            this.plFiltre.ResumeLayout(false);
            this.tlpNbPlats.ResumeLayout(false);
            this.tlpNbPlats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlats)).EndInit();
            this.tlpPagination.ResumeLayout(false);
            this.tlpPagination.PerformLayout();
            this.tlpBoutons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plMain;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lbTitre;
        private System.Windows.Forms.TableLayoutPanel tlpFiltres;
        private System.Windows.Forms.Label lbFiltre;
        private System.Windows.Forms.ComboBox cbFiltre;
        private System.Windows.Forms.Panel plFiltre;
        private System.Windows.Forms.ListBox cbIngredient;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.TableLayoutPanel tlpNbPlats;
        private System.Windows.Forms.Label lbNbPlats;
        private System.Windows.Forms.TextBox txtNbPlats;
        private System.Windows.Forms.DataGridView dgvPlats;
        private System.Windows.Forms.TableLayoutPanel tlpPagination;
        private System.Windows.Forms.Label lbPagination;
        private System.Windows.Forms.TextBox txtPagination;
        private System.Windows.Forms.TextBox txtPage;
        private System.Windows.Forms.TableLayoutPanel tlpBoutons;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnActualiser;
        private System.Windows.Forms.Button btnPrecedent;
        private System.Windows.Forms.Button btnSuivant;
    }
}
