
namespace ClientDesktop
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.ltpMenu = new System.Windows.Forms.TableLayoutPanel();
            this.flpBoutonsNavig = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMenus = new System.Windows.Forms.Button();
            this.btnPlats = new System.Windows.Forms.Button();
            this.btnCommandes = new System.Windows.Forms.Button();
            this.btnLogoAccueil = new System.Windows.Forms.Button();
            this.tlpPage = new System.Windows.Forms.TableLayoutPanel();
            this.tlpMain.SuspendLayout();
            this.ltpMenu.SuspendLayout();
            this.flpBoutonsNavig.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.ltpMenu, 0, 0);
            this.tlpMain.Controls.Add(this.tlpPage, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(984, 611);
            this.tlpMain.TabIndex = 0;
            // 
            // ltpMenu
            // 
            this.ltpMenu.ColumnCount = 1;
            this.ltpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ltpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ltpMenu.Controls.Add(this.flpBoutonsNavig, 0, 1);
            this.ltpMenu.Controls.Add(this.btnLogoAccueil, 0, 0);
            this.ltpMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ltpMenu.Location = new System.Drawing.Point(3, 3);
            this.ltpMenu.Name = "ltpMenu";
            this.ltpMenu.RowCount = 2;
            this.ltpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ltpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ltpMenu.Size = new System.Drawing.Size(244, 605);
            this.ltpMenu.TabIndex = 0;
            // 
            // flpBoutonsNavig
            // 
            this.flpBoutonsNavig.Controls.Add(this.btnMenus);
            this.flpBoutonsNavig.Controls.Add(this.btnPlats);
            this.flpBoutonsNavig.Controls.Add(this.btnCommandes);
            this.flpBoutonsNavig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBoutonsNavig.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpBoutonsNavig.Location = new System.Drawing.Point(3, 305);
            this.flpBoutonsNavig.Name = "flpBoutonsNavig";
            this.flpBoutonsNavig.Size = new System.Drawing.Size(238, 297);
            this.flpBoutonsNavig.TabIndex = 0;
            // 
            // btnMenus
            // 
            this.btnMenus.BackColor = System.Drawing.Color.White;
            this.btnMenus.FlatAppearance.BorderSize = 5;
            this.btnMenus.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMenus.Location = new System.Drawing.Point(45, 25);
            this.btnMenus.Margin = new System.Windows.Forms.Padding(45, 25, 3, 3);
            this.btnMenus.Name = "btnMenus";
            this.btnMenus.Size = new System.Drawing.Size(150, 50);
            this.btnMenus.TabIndex = 1;
            this.btnMenus.Text = "Menus";
            this.btnMenus.UseVisualStyleBackColor = false;
            this.btnMenus.Click += new System.EventHandler(this.btnMenus_Click);
            // 
            // btnPlats
            // 
            this.btnPlats.BackColor = System.Drawing.Color.White;
            this.btnPlats.FlatAppearance.BorderSize = 5;
            this.btnPlats.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPlats.Location = new System.Drawing.Point(45, 103);
            this.btnPlats.Margin = new System.Windows.Forms.Padding(45, 25, 3, 3);
            this.btnPlats.Name = "btnPlats";
            this.btnPlats.Size = new System.Drawing.Size(150, 50);
            this.btnPlats.TabIndex = 2;
            this.btnPlats.Text = "Plats";
            this.btnPlats.UseVisualStyleBackColor = false;
            this.btnPlats.Click += new System.EventHandler(this.btnPlats_Click);
            // 
            // btnCommandes
            // 
            this.btnCommandes.BackColor = System.Drawing.Color.White;
            this.btnCommandes.FlatAppearance.BorderSize = 5;
            this.btnCommandes.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCommandes.Location = new System.Drawing.Point(45, 181);
            this.btnCommandes.Margin = new System.Windows.Forms.Padding(45, 25, 3, 3);
            this.btnCommandes.Name = "btnCommandes";
            this.btnCommandes.Size = new System.Drawing.Size(150, 50);
            this.btnCommandes.TabIndex = 3;
            this.btnCommandes.Text = "Commandes";
            this.btnCommandes.UseVisualStyleBackColor = false;
            this.btnCommandes.Click += new System.EventHandler(this.btnCommandes_Click);
            // 
            // btnLogoAccueil
            // 
            this.btnLogoAccueil.BackColor = System.Drawing.Color.Transparent;
            this.btnLogoAccueil.BackgroundImage = global::ClientDesktop.Properties.Resources.Logo100px;
            this.btnLogoAccueil.FlatAppearance.BorderSize = 0;
            this.btnLogoAccueil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogoAccueil.Location = new System.Drawing.Point(50, 25);
            this.btnLogoAccueil.Margin = new System.Windows.Forms.Padding(50, 25, 3, 3);
            this.btnLogoAccueil.Name = "btnLogoAccueil";
            this.btnLogoAccueil.Size = new System.Drawing.Size(153, 155);
            this.btnLogoAccueil.TabIndex = 4;
            this.btnLogoAccueil.UseVisualStyleBackColor = false;
            this.btnLogoAccueil.Click += new System.EventHandler(this.btnLogoAccueil_Click);
            // 
            // tlpPage
            // 
            this.tlpPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tlpPage.ColumnCount = 1;
            this.tlpPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPage.Location = new System.Drawing.Point(250, 0);
            this.tlpPage.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPage.Name = "tlpPage";
            this.tlpPage.RowCount = 1;
            this.tlpPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPage.Size = new System.Drawing.Size(734, 611);
            this.tlpPage.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Accueil";
            this.tlpMain.ResumeLayout(false);
            this.ltpMenu.ResumeLayout(false);
            this.flpBoutonsNavig.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel ltpMenu;
        private System.Windows.Forms.FlowLayoutPanel flpBoutonsNavig;
        private System.Windows.Forms.Button btnMenus;
        private System.Windows.Forms.Button btnPlats;
        private System.Windows.Forms.Button btnCommandes;
        private System.Windows.Forms.Button btnLogoAccueil;
        private System.Windows.Forms.TableLayoutPanel tlpPage;
    }
}

