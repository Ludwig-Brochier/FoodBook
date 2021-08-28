
namespace ClientDesktop
{
    partial class GestionMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionMenuForm));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lbTitre = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.Button();
            this.tlpdata = new System.Windows.Forms.TableLayoutPanel();
            this.tlpDate = new System.Windows.Forms.TableLayoutPanel();
            this.lbDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.tlpService = new System.Windows.Forms.TableLayoutPanel();
            this.lbService = new System.Windows.Forms.Label();
            this.cbService = new System.Windows.Forms.ComboBox();
            this.tlpEntree = new System.Windows.Forms.TableLayoutPanel();
            this.lbEntree = new System.Windows.Forms.Label();
            this.cbEntree = new System.Windows.Forms.ComboBox();
            this.tlpPlat = new System.Windows.Forms.TableLayoutPanel();
            this.lbPlat = new System.Windows.Forms.Label();
            this.cbPlat = new System.Windows.Forms.ComboBox();
            this.tlpDessert = new System.Windows.Forms.TableLayoutPanel();
            this.lbDessert = new System.Windows.Forms.Label();
            this.cbDessert = new System.Windows.Forms.ComboBox();
            this.tlpMain.SuspendLayout();
            this.tlpdata.SuspendLayout();
            this.tlpDate.SuspendLayout();
            this.tlpService.SuspendLayout();
            this.tlpEntree.SuspendLayout();
            this.tlpPlat.SuspendLayout();
            this.tlpDessert.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lbTitre, 0, 0);
            this.tlpMain.Controls.Add(this.btnMenu, 0, 2);
            this.tlpMain.Controls.Add(this.tlpdata, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.Size = new System.Drawing.Size(384, 561);
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
            this.lbTitre.Size = new System.Drawing.Size(384, 40);
            this.lbTitre.TabIndex = 0;
            this.lbTitre.Text = "Titre";
            this.lbTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenu.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMenu.Location = new System.Drawing.Point(90, 516);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(90, 5, 90, 5);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(204, 40);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Text = "bouton";
            this.btnMenu.UseVisualStyleBackColor = false;
            // 
            // tlpdata
            // 
            this.tlpdata.ColumnCount = 1;
            this.tlpdata.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpdata.Controls.Add(this.tlpDate, 0, 0);
            this.tlpdata.Controls.Add(this.tlpService, 0, 1);
            this.tlpdata.Controls.Add(this.tlpEntree, 0, 2);
            this.tlpdata.Controls.Add(this.tlpPlat, 0, 3);
            this.tlpdata.Controls.Add(this.tlpDessert, 0, 4);
            this.tlpdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpdata.Location = new System.Drawing.Point(25, 40);
            this.tlpdata.Margin = new System.Windows.Forms.Padding(25, 0, 25, 15);
            this.tlpdata.Name = "tlpdata";
            this.tlpdata.RowCount = 5;
            this.tlpdata.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpdata.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpdata.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpdata.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpdata.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpdata.Size = new System.Drawing.Size(334, 456);
            this.tlpdata.TabIndex = 2;
            // 
            // tlpDate
            // 
            this.tlpDate.ColumnCount = 1;
            this.tlpDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDate.Controls.Add(this.lbDate, 0, 0);
            this.tlpDate.Controls.Add(this.dtpDate, 0, 1);
            this.tlpDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDate.Location = new System.Drawing.Point(0, 0);
            this.tlpDate.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDate.Name = "tlpDate";
            this.tlpDate.RowCount = 2;
            this.tlpDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDate.Size = new System.Drawing.Size(334, 91);
            this.tlpDate.TabIndex = 0;
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDate.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbDate.Location = new System.Drawing.Point(0, 0);
            this.lbDate.Margin = new System.Windows.Forms.Padding(0);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(334, 45);
            this.lbDate.TabIndex = 0;
            this.lbDate.Text = "Date :";
            this.lbDate.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dtpDate
            // 
            this.dtpDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDate.Location = new System.Drawing.Point(3, 48);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(328, 23);
            this.dtpDate.TabIndex = 1;
            // 
            // tlpService
            // 
            this.tlpService.ColumnCount = 1;
            this.tlpService.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpService.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpService.Controls.Add(this.lbService, 0, 0);
            this.tlpService.Controls.Add(this.cbService, 0, 1);
            this.tlpService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpService.Location = new System.Drawing.Point(0, 91);
            this.tlpService.Margin = new System.Windows.Forms.Padding(0);
            this.tlpService.Name = "tlpService";
            this.tlpService.RowCount = 2;
            this.tlpService.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpService.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpService.Size = new System.Drawing.Size(334, 91);
            this.tlpService.TabIndex = 1;
            // 
            // lbService
            // 
            this.lbService.AutoSize = true;
            this.lbService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbService.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbService.Location = new System.Drawing.Point(0, 0);
            this.lbService.Margin = new System.Windows.Forms.Padding(0);
            this.lbService.Name = "lbService";
            this.lbService.Size = new System.Drawing.Size(334, 45);
            this.lbService.TabIndex = 0;
            this.lbService.Text = "Service :";
            this.lbService.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cbService
            // 
            this.cbService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbService.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbService.FormattingEnabled = true;
            this.cbService.Location = new System.Drawing.Point(3, 48);
            this.cbService.Name = "cbService";
            this.cbService.Size = new System.Drawing.Size(328, 31);
            this.cbService.TabIndex = 1;
            // 
            // tlpEntree
            // 
            this.tlpEntree.ColumnCount = 1;
            this.tlpEntree.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEntree.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEntree.Controls.Add(this.lbEntree, 0, 0);
            this.tlpEntree.Controls.Add(this.cbEntree, 0, 1);
            this.tlpEntree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEntree.Location = new System.Drawing.Point(0, 182);
            this.tlpEntree.Margin = new System.Windows.Forms.Padding(0);
            this.tlpEntree.Name = "tlpEntree";
            this.tlpEntree.RowCount = 2;
            this.tlpEntree.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEntree.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEntree.Size = new System.Drawing.Size(334, 91);
            this.tlpEntree.TabIndex = 2;
            // 
            // lbEntree
            // 
            this.lbEntree.AutoSize = true;
            this.lbEntree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbEntree.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbEntree.Location = new System.Drawing.Point(0, 0);
            this.lbEntree.Margin = new System.Windows.Forms.Padding(0);
            this.lbEntree.Name = "lbEntree";
            this.lbEntree.Size = new System.Drawing.Size(334, 45);
            this.lbEntree.TabIndex = 0;
            this.lbEntree.Text = "Entrée :";
            this.lbEntree.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cbEntree
            // 
            this.cbEntree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbEntree.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbEntree.FormattingEnabled = true;
            this.cbEntree.Location = new System.Drawing.Point(3, 48);
            this.cbEntree.Name = "cbEntree";
            this.cbEntree.Size = new System.Drawing.Size(328, 31);
            this.cbEntree.TabIndex = 1;
            // 
            // tlpPlat
            // 
            this.tlpPlat.ColumnCount = 1;
            this.tlpPlat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlat.Controls.Add(this.lbPlat, 0, 0);
            this.tlpPlat.Controls.Add(this.cbPlat, 0, 1);
            this.tlpPlat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPlat.Location = new System.Drawing.Point(0, 273);
            this.tlpPlat.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPlat.Name = "tlpPlat";
            this.tlpPlat.RowCount = 2;
            this.tlpPlat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlat.Size = new System.Drawing.Size(334, 91);
            this.tlpPlat.TabIndex = 3;
            // 
            // lbPlat
            // 
            this.lbPlat.AutoSize = true;
            this.lbPlat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPlat.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbPlat.Location = new System.Drawing.Point(0, 0);
            this.lbPlat.Margin = new System.Windows.Forms.Padding(0);
            this.lbPlat.Name = "lbPlat";
            this.lbPlat.Size = new System.Drawing.Size(334, 45);
            this.lbPlat.TabIndex = 0;
            this.lbPlat.Text = "Plat :";
            this.lbPlat.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cbPlat
            // 
            this.cbPlat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbPlat.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPlat.FormattingEnabled = true;
            this.cbPlat.Location = new System.Drawing.Point(3, 48);
            this.cbPlat.Name = "cbPlat";
            this.cbPlat.Size = new System.Drawing.Size(328, 31);
            this.cbPlat.TabIndex = 1;
            // 
            // tlpDessert
            // 
            this.tlpDessert.ColumnCount = 1;
            this.tlpDessert.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDessert.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDessert.Controls.Add(this.lbDessert, 0, 0);
            this.tlpDessert.Controls.Add(this.cbDessert, 0, 1);
            this.tlpDessert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDessert.Location = new System.Drawing.Point(0, 364);
            this.tlpDessert.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDessert.Name = "tlpDessert";
            this.tlpDessert.RowCount = 2;
            this.tlpDessert.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDessert.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDessert.Size = new System.Drawing.Size(334, 92);
            this.tlpDessert.TabIndex = 4;
            // 
            // lbDessert
            // 
            this.lbDessert.AutoSize = true;
            this.lbDessert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDessert.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbDessert.Location = new System.Drawing.Point(0, 0);
            this.lbDessert.Margin = new System.Windows.Forms.Padding(0);
            this.lbDessert.Name = "lbDessert";
            this.lbDessert.Size = new System.Drawing.Size(334, 46);
            this.lbDessert.TabIndex = 0;
            this.lbDessert.Text = "Dessert :";
            this.lbDessert.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cbDessert
            // 
            this.cbDessert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDessert.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbDessert.FormattingEnabled = true;
            this.cbDessert.Location = new System.Drawing.Point(3, 49);
            this.cbDessert.Name = "cbDessert";
            this.cbDessert.Size = new System.Drawing.Size(328, 31);
            this.cbDessert.TabIndex = 1;
            // 
            // GestionMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 561);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GestionMenuForm";
            this.Text = "FoodBook";
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpdata.ResumeLayout(false);
            this.tlpDate.ResumeLayout(false);
            this.tlpDate.PerformLayout();
            this.tlpService.ResumeLayout(false);
            this.tlpService.PerformLayout();
            this.tlpEntree.ResumeLayout(false);
            this.tlpEntree.PerformLayout();
            this.tlpPlat.ResumeLayout(false);
            this.tlpPlat.PerformLayout();
            this.tlpDessert.ResumeLayout(false);
            this.tlpDessert.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lbTitre;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.TableLayoutPanel tlpdata;
        private System.Windows.Forms.TableLayoutPanel tlpDate;
        private System.Windows.Forms.TableLayoutPanel tlpService;
        private System.Windows.Forms.TableLayoutPanel tlpEntree;
        private System.Windows.Forms.TableLayoutPanel tlpPlat;
        private System.Windows.Forms.TableLayoutPanel tlpDessert;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lbService;
        private System.Windows.Forms.Label lbEntree;
        private System.Windows.Forms.Label lbPlat;
        private System.Windows.Forms.Label lbDessert;
        private System.Windows.Forms.ComboBox cbService;
        private System.Windows.Forms.ComboBox cbEntree;
        private System.Windows.Forms.ComboBox cbPlat;
        private System.Windows.Forms.ComboBox cbDessert;
    }
}