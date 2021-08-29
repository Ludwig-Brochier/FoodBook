
namespace ClientDesktop
{
    partial class GestionPlatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionPlatForm));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lbTitre = new System.Windows.Forms.Label();
            this.btnPlat = new System.Windows.Forms.Button();
            this.tlpData = new System.Windows.Forms.TableLayoutPanel();
            this.tlpIntitule = new System.Windows.Forms.TableLayoutPanel();
            this.lbIntitule = new System.Windows.Forms.Label();
            this.txtIntitule = new System.Windows.Forms.TextBox();
            this.tlpData2 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpType = new System.Windows.Forms.TableLayoutPanel();
            this.lbType = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.tlpPrix = new System.Windows.Forms.TableLayoutPanel();
            this.lbPrix = new System.Windows.Forms.Label();
            this.txtPrix = new System.Windows.Forms.TextBox();
            this.tlpGestionIngredients = new System.Windows.Forms.TableLayoutPanel();
            this.tlpIngredientsPlats = new System.Windows.Forms.TableLayoutPanel();
            this.lbIngredientsPlat = new System.Windows.Forms.Label();
            this.dgvIngredientsPlat = new System.Windows.Forms.DataGridView();
            this.tlpListeIngredients = new System.Windows.Forms.TableLayoutPanel();
            this.lbIngredients = new System.Windows.Forms.Label();
            this.dgvIngredients = new System.Windows.Forms.DataGridView();
            this.tlpGestionIngredients2 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpQuantite = new System.Windows.Forms.TableLayoutPanel();
            this.lbQuantite = new System.Windows.Forms.Label();
            this.txtQuantite = new System.Windows.Forms.TextBox();
            this.tlpBouton = new System.Windows.Forms.TableLayoutPanel();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnMoins = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.tlpData.SuspendLayout();
            this.tlpIntitule.SuspendLayout();
            this.tlpData2.SuspendLayout();
            this.tlpType.SuspendLayout();
            this.tlpPrix.SuspendLayout();
            this.tlpGestionIngredients.SuspendLayout();
            this.tlpIngredientsPlats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientsPlat)).BeginInit();
            this.tlpListeIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).BeginInit();
            this.tlpGestionIngredients2.SuspendLayout();
            this.tlpQuantite.SuspendLayout();
            this.tlpBouton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lbTitre, 0, 0);
            this.tlpMain.Controls.Add(this.btnPlat, 0, 2);
            this.tlpMain.Controls.Add(this.tlpData, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.Size = new System.Drawing.Size(584, 561);
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
            this.lbTitre.Size = new System.Drawing.Size(584, 40);
            this.lbTitre.TabIndex = 1;
            this.lbTitre.Text = "Titre";
            this.lbTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPlat
            // 
            this.btnPlat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnPlat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlat.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPlat.Location = new System.Drawing.Point(190, 516);
            this.btnPlat.Margin = new System.Windows.Forms.Padding(190, 5, 190, 5);
            this.btnPlat.Name = "btnPlat";
            this.btnPlat.Size = new System.Drawing.Size(204, 40);
            this.btnPlat.TabIndex = 2;
            this.btnPlat.Text = "bouton";
            this.btnPlat.UseVisualStyleBackColor = false;
            this.btnPlat.Click += new System.EventHandler(this.btnPlat_Click);
            // 
            // tlpData
            // 
            this.tlpData.ColumnCount = 1;
            this.tlpData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpData.Controls.Add(this.tlpIntitule, 0, 0);
            this.tlpData.Controls.Add(this.tlpData2, 0, 1);
            this.tlpData.Controls.Add(this.tlpGestionIngredients, 0, 2);
            this.tlpData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpData.Location = new System.Drawing.Point(25, 40);
            this.tlpData.Margin = new System.Windows.Forms.Padding(25, 0, 25, 0);
            this.tlpData.Name = "tlpData";
            this.tlpData.RowCount = 3;
            this.tlpData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlpData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlpData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpData.Size = new System.Drawing.Size(534, 471);
            this.tlpData.TabIndex = 3;
            // 
            // tlpIntitule
            // 
            this.tlpIntitule.ColumnCount = 1;
            this.tlpIntitule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpIntitule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpIntitule.Controls.Add(this.lbIntitule, 0, 0);
            this.tlpIntitule.Controls.Add(this.txtIntitule, 0, 1);
            this.tlpIntitule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpIntitule.Location = new System.Drawing.Point(0, 0);
            this.tlpIntitule.Margin = new System.Windows.Forms.Padding(0);
            this.tlpIntitule.Name = "tlpIntitule";
            this.tlpIntitule.RowCount = 2;
            this.tlpIntitule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpIntitule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpIntitule.Size = new System.Drawing.Size(534, 75);
            this.tlpIntitule.TabIndex = 0;
            // 
            // lbIntitule
            // 
            this.lbIntitule.AutoSize = true;
            this.lbIntitule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbIntitule.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbIntitule.Location = new System.Drawing.Point(3, 0);
            this.lbIntitule.Name = "lbIntitule";
            this.lbIntitule.Size = new System.Drawing.Size(528, 37);
            this.lbIntitule.TabIndex = 0;
            this.lbIntitule.Text = "Intitule :";
            this.lbIntitule.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtIntitule
            // 
            this.txtIntitule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtIntitule.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtIntitule.Location = new System.Drawing.Point(3, 40);
            this.txtIntitule.Name = "txtIntitule";
            this.txtIntitule.Size = new System.Drawing.Size(528, 31);
            this.txtIntitule.TabIndex = 1;
            // 
            // tlpData2
            // 
            this.tlpData2.ColumnCount = 2;
            this.tlpData2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpData2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpData2.Controls.Add(this.tlpType, 0, 0);
            this.tlpData2.Controls.Add(this.tlpPrix, 1, 0);
            this.tlpData2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpData2.Location = new System.Drawing.Point(0, 75);
            this.tlpData2.Margin = new System.Windows.Forms.Padding(0);
            this.tlpData2.Name = "tlpData2";
            this.tlpData2.RowCount = 1;
            this.tlpData2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpData2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpData2.Size = new System.Drawing.Size(534, 75);
            this.tlpData2.TabIndex = 1;
            // 
            // tlpType
            // 
            this.tlpType.ColumnCount = 1;
            this.tlpType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpType.Controls.Add(this.lbType, 0, 0);
            this.tlpType.Controls.Add(this.cbType, 0, 1);
            this.tlpType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpType.Location = new System.Drawing.Point(0, 0);
            this.tlpType.Margin = new System.Windows.Forms.Padding(0);
            this.tlpType.Name = "tlpType";
            this.tlpType.RowCount = 2;
            this.tlpType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpType.Size = new System.Drawing.Size(267, 75);
            this.tlpType.TabIndex = 0;
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbType.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbType.Location = new System.Drawing.Point(3, 0);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(261, 37);
            this.lbType.TabIndex = 0;
            this.lbType.Text = "Type :";
            this.lbType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cbType
            // 
            this.cbType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbType.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(3, 40);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(261, 31);
            this.cbType.TabIndex = 1;
            // 
            // tlpPrix
            // 
            this.tlpPrix.ColumnCount = 1;
            this.tlpPrix.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrix.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrix.Controls.Add(this.lbPrix, 0, 0);
            this.tlpPrix.Controls.Add(this.txtPrix, 0, 1);
            this.tlpPrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrix.Location = new System.Drawing.Point(287, 0);
            this.tlpPrix.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tlpPrix.Name = "tlpPrix";
            this.tlpPrix.RowCount = 2;
            this.tlpPrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrix.Size = new System.Drawing.Size(247, 75);
            this.tlpPrix.TabIndex = 1;
            // 
            // lbPrix
            // 
            this.lbPrix.AutoSize = true;
            this.lbPrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPrix.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbPrix.Location = new System.Drawing.Point(3, 0);
            this.lbPrix.Name = "lbPrix";
            this.lbPrix.Size = new System.Drawing.Size(241, 37);
            this.lbPrix.TabIndex = 0;
            this.lbPrix.Text = "Prix :";
            this.lbPrix.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtPrix
            // 
            this.txtPrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrix.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPrix.Location = new System.Drawing.Point(3, 40);
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.Size = new System.Drawing.Size(241, 31);
            this.txtPrix.TabIndex = 1;
            // 
            // tlpGestionIngredients
            // 
            this.tlpGestionIngredients.ColumnCount = 3;
            this.tlpGestionIngredients.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGestionIngredients.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tlpGestionIngredients.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGestionIngredients.Controls.Add(this.tlpIngredientsPlats, 0, 0);
            this.tlpGestionIngredients.Controls.Add(this.tlpListeIngredients, 2, 0);
            this.tlpGestionIngredients.Controls.Add(this.tlpGestionIngredients2, 1, 0);
            this.tlpGestionIngredients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGestionIngredients.Location = new System.Drawing.Point(0, 150);
            this.tlpGestionIngredients.Margin = new System.Windows.Forms.Padding(0, 0, 0, 25);
            this.tlpGestionIngredients.Name = "tlpGestionIngredients";
            this.tlpGestionIngredients.RowCount = 1;
            this.tlpGestionIngredients.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGestionIngredients.Size = new System.Drawing.Size(534, 296);
            this.tlpGestionIngredients.TabIndex = 2;
            // 
            // tlpIngredientsPlats
            // 
            this.tlpIngredientsPlats.ColumnCount = 1;
            this.tlpIngredientsPlats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpIngredientsPlats.Controls.Add(this.lbIngredientsPlat, 0, 0);
            this.tlpIngredientsPlats.Controls.Add(this.dgvIngredientsPlat, 0, 1);
            this.tlpIngredientsPlats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpIngredientsPlats.Location = new System.Drawing.Point(0, 0);
            this.tlpIngredientsPlats.Margin = new System.Windows.Forms.Padding(0);
            this.tlpIngredientsPlats.Name = "tlpIngredientsPlats";
            this.tlpIngredientsPlats.RowCount = 2;
            this.tlpIngredientsPlats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tlpIngredientsPlats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83F));
            this.tlpIngredientsPlats.Size = new System.Drawing.Size(204, 296);
            this.tlpIngredientsPlats.TabIndex = 0;
            // 
            // lbIngredientsPlat
            // 
            this.lbIngredientsPlat.AutoSize = true;
            this.lbIngredientsPlat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbIngredientsPlat.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbIngredientsPlat.Location = new System.Drawing.Point(3, 0);
            this.lbIngredientsPlat.Name = "lbIngredientsPlat";
            this.lbIngredientsPlat.Size = new System.Drawing.Size(198, 50);
            this.lbIngredientsPlat.TabIndex = 0;
            this.lbIngredientsPlat.Text = "Ingrédients du plat :";
            this.lbIngredientsPlat.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dgvIngredientsPlat
            // 
            this.dgvIngredientsPlat.AllowUserToAddRows = false;
            this.dgvIngredientsPlat.AllowUserToDeleteRows = false;
            this.dgvIngredientsPlat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIngredientsPlat.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIngredientsPlat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIngredientsPlat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredientsPlat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIngredientsPlat.EnableHeadersVisualStyles = false;
            this.dgvIngredientsPlat.Location = new System.Drawing.Point(0, 50);
            this.dgvIngredientsPlat.Margin = new System.Windows.Forms.Padding(0);
            this.dgvIngredientsPlat.MultiSelect = false;
            this.dgvIngredientsPlat.Name = "dgvIngredientsPlat";
            this.dgvIngredientsPlat.RowHeadersVisible = false;
            this.dgvIngredientsPlat.RowTemplate.Height = 25;
            this.dgvIngredientsPlat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngredientsPlat.Size = new System.Drawing.Size(204, 246);
            this.dgvIngredientsPlat.TabIndex = 1;
            // 
            // tlpListeIngredients
            // 
            this.tlpListeIngredients.ColumnCount = 1;
            this.tlpListeIngredients.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpListeIngredients.Controls.Add(this.lbIngredients, 0, 0);
            this.tlpListeIngredients.Controls.Add(this.dgvIngredients, 0, 1);
            this.tlpListeIngredients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpListeIngredients.Location = new System.Drawing.Point(329, 0);
            this.tlpListeIngredients.Margin = new System.Windows.Forms.Padding(0);
            this.tlpListeIngredients.Name = "tlpListeIngredients";
            this.tlpListeIngredients.RowCount = 2;
            this.tlpListeIngredients.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tlpListeIngredients.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83F));
            this.tlpListeIngredients.Size = new System.Drawing.Size(205, 296);
            this.tlpListeIngredients.TabIndex = 1;
            // 
            // lbIngredients
            // 
            this.lbIngredients.AutoSize = true;
            this.lbIngredients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbIngredients.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbIngredients.Location = new System.Drawing.Point(3, 0);
            this.lbIngredients.Name = "lbIngredients";
            this.lbIngredients.Size = new System.Drawing.Size(199, 50);
            this.lbIngredients.TabIndex = 0;
            this.lbIngredients.Text = "Ingrédients :";
            this.lbIngredients.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dgvIngredients
            // 
            this.dgvIngredients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIngredients.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIngredients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredients.ColumnHeadersVisible = false;
            this.dgvIngredients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIngredients.EnableHeadersVisualStyles = false;
            this.dgvIngredients.Location = new System.Drawing.Point(0, 50);
            this.dgvIngredients.Margin = new System.Windows.Forms.Padding(0);
            this.dgvIngredients.MultiSelect = false;
            this.dgvIngredients.Name = "dgvIngredients";
            this.dgvIngredients.RowHeadersVisible = false;
            this.dgvIngredients.RowTemplate.Height = 25;
            this.dgvIngredients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngredients.Size = new System.Drawing.Size(205, 246);
            this.dgvIngredients.TabIndex = 1;
            // 
            // tlpGestionIngredients2
            // 
            this.tlpGestionIngredients2.ColumnCount = 1;
            this.tlpGestionIngredients2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGestionIngredients2.Controls.Add(this.tlpQuantite, 0, 0);
            this.tlpGestionIngredients2.Controls.Add(this.tlpBouton, 0, 1);
            this.tlpGestionIngredients2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGestionIngredients2.Location = new System.Drawing.Point(204, 0);
            this.tlpGestionIngredients2.Margin = new System.Windows.Forms.Padding(0);
            this.tlpGestionIngredients2.Name = "tlpGestionIngredients2";
            this.tlpGestionIngredients2.RowCount = 3;
            this.tlpGestionIngredients2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tlpGestionIngredients2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tlpGestionIngredients2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tlpGestionIngredients2.Size = new System.Drawing.Size(125, 296);
            this.tlpGestionIngredients2.TabIndex = 2;
            // 
            // tlpQuantite
            // 
            this.tlpQuantite.ColumnCount = 1;
            this.tlpQuantite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQuantite.Controls.Add(this.lbQuantite, 0, 0);
            this.tlpQuantite.Controls.Add(this.txtQuantite, 0, 1);
            this.tlpQuantite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQuantite.Location = new System.Drawing.Point(0, 0);
            this.tlpQuantite.Margin = new System.Windows.Forms.Padding(0);
            this.tlpQuantite.Name = "tlpQuantite";
            this.tlpQuantite.RowCount = 2;
            this.tlpQuantite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpQuantite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpQuantite.Size = new System.Drawing.Size(125, 100);
            this.tlpQuantite.TabIndex = 0;
            // 
            // lbQuantite
            // 
            this.lbQuantite.AutoSize = true;
            this.lbQuantite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbQuantite.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbQuantite.Location = new System.Drawing.Point(3, 0);
            this.lbQuantite.Name = "lbQuantite";
            this.lbQuantite.Size = new System.Drawing.Size(119, 50);
            this.lbQuantite.TabIndex = 0;
            this.lbQuantite.Text = "Quantite :";
            this.lbQuantite.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtQuantite
            // 
            this.txtQuantite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuantite.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtQuantite.Location = new System.Drawing.Point(30, 53);
            this.txtQuantite.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.txtQuantite.Name = "txtQuantite";
            this.txtQuantite.Size = new System.Drawing.Size(65, 31);
            this.txtQuantite.TabIndex = 1;
            this.txtQuantite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tlpBouton
            // 
            this.tlpBouton.ColumnCount = 1;
            this.tlpBouton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBouton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBouton.Controls.Add(this.btnPlus, 0, 0);
            this.tlpBouton.Controls.Add(this.btnMoins, 0, 1);
            this.tlpBouton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBouton.Location = new System.Drawing.Point(0, 100);
            this.tlpBouton.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBouton.Name = "tlpBouton";
            this.tlpBouton.RowCount = 2;
            this.tlpBouton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBouton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBouton.Size = new System.Drawing.Size(125, 94);
            this.tlpBouton.TabIndex = 1;
            // 
            // btnPlus
            // 
            this.btnPlus.BackColor = System.Drawing.Color.White;
            this.btnPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlus.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPlus.Location = new System.Drawing.Point(40, 5);
            this.btnPlus.Margin = new System.Windows.Forms.Padding(40, 5, 40, 5);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(45, 37);
            this.btnPlus.TabIndex = 0;
            this.btnPlus.Text = "<-";
            this.btnPlus.UseVisualStyleBackColor = false;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnMoins
            // 
            this.btnMoins.BackColor = System.Drawing.Color.White;
            this.btnMoins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoins.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMoins.Location = new System.Drawing.Point(40, 52);
            this.btnMoins.Margin = new System.Windows.Forms.Padding(40, 5, 40, 5);
            this.btnMoins.Name = "btnMoins";
            this.btnMoins.Size = new System.Drawing.Size(45, 37);
            this.btnMoins.TabIndex = 1;
            this.btnMoins.Text = "->";
            this.btnMoins.UseVisualStyleBackColor = false;
            this.btnMoins.Click += new System.EventHandler(this.btnMoins_Click);
            // 
            // GestionPlatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GestionPlatForm";
            this.Text = "FoodBook";
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpData.ResumeLayout(false);
            this.tlpIntitule.ResumeLayout(false);
            this.tlpIntitule.PerformLayout();
            this.tlpData2.ResumeLayout(false);
            this.tlpType.ResumeLayout(false);
            this.tlpType.PerformLayout();
            this.tlpPrix.ResumeLayout(false);
            this.tlpPrix.PerformLayout();
            this.tlpGestionIngredients.ResumeLayout(false);
            this.tlpIngredientsPlats.ResumeLayout(false);
            this.tlpIngredientsPlats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientsPlat)).EndInit();
            this.tlpListeIngredients.ResumeLayout(false);
            this.tlpListeIngredients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).EndInit();
            this.tlpGestionIngredients2.ResumeLayout(false);
            this.tlpQuantite.ResumeLayout(false);
            this.tlpQuantite.PerformLayout();
            this.tlpBouton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lbTitre;
        private System.Windows.Forms.Button btnPlat;
        private System.Windows.Forms.TableLayoutPanel tlpData;
        private System.Windows.Forms.TableLayoutPanel tlpIntitule;
        private System.Windows.Forms.TableLayoutPanel tlpData2;
        private System.Windows.Forms.TableLayoutPanel tlpType;
        private System.Windows.Forms.TableLayoutPanel tlpPrix;
        private System.Windows.Forms.TableLayoutPanel tlpGestionIngredients;
        private System.Windows.Forms.TableLayoutPanel tlpIngredientsPlats;
        private System.Windows.Forms.TableLayoutPanel tlpListeIngredients;
        private System.Windows.Forms.Label lbIntitule;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Label lbPrix;
        private System.Windows.Forms.Label lbIngredientsPlat;
        private System.Windows.Forms.Label lbIngredients;
        private System.Windows.Forms.TableLayoutPanel tlpGestionIngredients2;
        private System.Windows.Forms.TableLayoutPanel tlpQuantite;
        private System.Windows.Forms.Label lbQuantite;
        private System.Windows.Forms.TextBox txtIntitule;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.TextBox txtPrix;
        private System.Windows.Forms.TextBox txtQuantite;
        private System.Windows.Forms.TableLayoutPanel tlpBouton;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnMoins;
        private System.Windows.Forms.DataGridView dgvIngredientsPlat;
        private System.Windows.Forms.DataGridView dgvIngredients;
    }
}