using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace POS_RESTO.Views
{
    partial class MenusUserControl
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvMenus;
        private System.Windows.Forms.ComboBox cmbFilterCategory;
        private System.Windows.Forms.Button btnAddMenu;
        private System.Windows.Forms.Button btnEditMenu;
        private System.Windows.Forms.Button btnDeleteMenu;
        private Label lblTitle;
        private System.Windows.Forms.Panel panelTools;
        private System.Windows.Forms.TextBox txtSearch;
        private Label lblSearch;
        private Label lblStatus;
        private System.Windows.Forms.Label lblFilter;
        private Timer searchTimer;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            
            if (disposing && searchTimer != null)
            {
                searchTimer.Dispose();
            }
            
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dgvMenus = new System.Windows.Forms.DataGridView();
            btnAddMenu = new System.Windows.Forms.Button();
            btnEditMenu = new System.Windows.Forms.Button();
            btnDeleteMenu = new System.Windows.Forms.Button();
            lblTitle = new System.Windows.Forms.Label();
            panelTools = new System.Windows.Forms.Panel();
            lblFilter = new System.Windows.Forms.Label();
            cmbFilterCategory = new System.Windows.Forms.ComboBox();
            lblSearch = new System.Windows.Forms.Label();
            txtSearch = new System.Windows.Forms.TextBox();
            lblStatus = new System.Windows.Forms.Label();
            searchTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dgvMenus).BeginInit();
            panelTools.SuspendLayout();
            SuspendLayout();
            // 
            // dgvMenus
            // 
            dgvMenus.AllowUserToAddRows = false;
            dgvMenus.AllowUserToDeleteRows = false;
            dgvMenus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvMenus.BackgroundColor = System.Drawing.Color.White;
            dgvMenus.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvMenus.Location = new System.Drawing.Point(20, 130);
            dgvMenus.Name = "dgvMenus";
            dgvMenus.ReadOnly = true;
            dgvMenus.RowHeadersVisible = false;
            dgvMenus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvMenus.Size = new System.Drawing.Size(726, 300);
            dgvMenus.TabIndex = 0;
            dgvMenus.CellDoubleClick += DgvMenus_CellDoubleClick;
            // 
            // btnAddMenu
            // 
            btnAddMenu.BackColor = System.Drawing.Color.FromArgb(((int)((byte)40)), ((int)((byte)167)), ((int)((byte)69)));
            btnAddMenu.FlatAppearance.BorderSize = 0;
            btnAddMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddMenu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnAddMenu.ForeColor = System.Drawing.Color.White;
            btnAddMenu.Location = new System.Drawing.Point(251, 9);
            btnAddMenu.Name = "btnAddMenu";
            btnAddMenu.Size = new System.Drawing.Size(120, 35);
            btnAddMenu.TabIndex = 2;
            btnAddMenu.Text = "Nouveau Menu";
            btnAddMenu.UseVisualStyleBackColor = false;
            btnAddMenu.Click += BtnAddMenu_Click;
            // 
            // btnEditMenu
            // 
            btnEditMenu.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)193)), ((int)((byte)7)));
            btnEditMenu.FlatAppearance.BorderSize = 0;
            btnEditMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEditMenu.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnEditMenu.ForeColor = System.Drawing.Color.Black;
            btnEditMenu.Location = new System.Drawing.Point(377, 8);
            btnEditMenu.Name = "btnEditMenu";
            btnEditMenu.Size = new System.Drawing.Size(100, 35);
            btnEditMenu.TabIndex = 3;
            btnEditMenu.Text = "Modifier";
            btnEditMenu.UseVisualStyleBackColor = false;
            btnEditMenu.Click += BtnEditMenu_Click;
            // 
            // btnDeleteMenu
            // 
            btnDeleteMenu.BackColor = System.Drawing.Color.FromArgb(((int)((byte)220)), ((int)((byte)53)), ((int)((byte)69)));
            btnDeleteMenu.FlatAppearance.BorderSize = 0;
            btnDeleteMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDeleteMenu.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnDeleteMenu.ForeColor = System.Drawing.Color.White;
            btnDeleteMenu.Location = new System.Drawing.Point(494, 9);
            btnDeleteMenu.Name = "btnDeleteMenu";
            btnDeleteMenu.Size = new System.Drawing.Size(100, 35);
            btnDeleteMenu.TabIndex = 4;
            btnDeleteMenu.Text = "Supprimer";
            btnDeleteMenu.UseVisualStyleBackColor = false;
            btnDeleteMenu.Click += BtnDeleteMenu_Click;
            // 
            // lblTitle
            // 
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
            lblTitle.Location = new System.Drawing.Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(726, 50);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "GESTION DES MENUS";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelTools
            // 
            panelTools.BackColor = System.Drawing.Color.White;
            panelTools.Controls.Add(lblFilter);
            panelTools.Controls.Add(cmbFilterCategory);
            panelTools.Controls.Add(lblSearch);
            panelTools.Controls.Add(txtSearch);
            panelTools.Controls.Add(btnAddMenu);
            panelTools.Controls.Add(btnEditMenu);
            panelTools.Controls.Add(btnDeleteMenu);
            panelTools.Dock = System.Windows.Forms.DockStyle.Top;
            panelTools.Location = new System.Drawing.Point(20, 70);
            panelTools.Name = "panelTools";
            panelTools.Size = new System.Drawing.Size(726, 60);
            panelTools.TabIndex = 2;
            // 
            // lblFilter
            // 
            lblFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblFilter.Location = new System.Drawing.Point(615, 43);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new System.Drawing.Size(74, 27);
            lblFilter.TabIndex = 6;
            lblFilter.Text = "Catégorie:";
            // 
            // cmbFilterCategory
            // 
            cmbFilterCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbFilterCategory.Items.AddRange(new object[] { "Toutes catégories", "plats", "boissons", "desserts" });
            cmbFilterCategory.Location = new System.Drawing.Point(600, 15);
            cmbFilterCategory.Name = "cmbFilterCategory";
            cmbFilterCategory.Size = new System.Drawing.Size(115, 25);
            cmbFilterCategory.TabIndex = 5;
            cmbFilterCategory.SelectedIndexChanged += CmbFilterCategory_SelectedIndexChanged;
            // 
            // lblSearch
            // 
            lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblSearch.Location = new System.Drawing.Point(0, 18);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new System.Drawing.Size(80, 25);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Rechercher:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtSearch.Location = new System.Drawing.Point(85, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(160, 25);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // lblStatus
            // 
            lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblStatus.ForeColor = System.Drawing.Color.Gray;
            lblStatus.Location = new System.Drawing.Point(20, 430);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            lblStatus.Size = new System.Drawing.Size(726, 25);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Chargement...";
            lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // searchTimer
            // 
            searchTimer.Interval = 500;
            searchTimer.Tick += SearchTimer_Tick;
            // 
            // MenusUserControl
            // 
            BackColor = System.Drawing.Color.White;
            Controls.Add(dgvMenus);
            Controls.Add(lblStatus);
            Controls.Add(panelTools);
            Controls.Add(lblTitle);
            Padding = new System.Windows.Forms.Padding(20);
            Size = new System.Drawing.Size(766, 475);
            Load += MenusUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMenus).EndInit();
            panelTools.ResumeLayout(false);
            panelTools.PerformLayout();
            ResumeLayout(false);
        }
    }
}