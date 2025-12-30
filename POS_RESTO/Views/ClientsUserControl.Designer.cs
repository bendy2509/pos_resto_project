namespace POS_RESTO.Views
{
    partial class ClientsUserControl
    {
        private System.ComponentModel.IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvClients = new System.Windows.Forms.DataGridView();
            btnAddClient = new System.Windows.Forms.Button();
            btnEditClient = new System.Windows.Forms.Button();
            btnDeleteClient = new System.Windows.Forms.Button();
            txtSearch = new System.Windows.Forms.TextBox();
            lblStatus = new System.Windows.Forms.Label();
            lblTitle = new System.Windows.Forms.Label();
            panelTools = new System.Windows.Forms.Panel();
            lblSearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            panelTools.SuspendLayout();
            SuspendLayout();
            // 
            // dgvClients
            // 
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AllowUserToDeleteRows = false;
            dgvClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.BackgroundColor = System.Drawing.Color.White;
            dgvClients.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvClients.Location = new System.Drawing.Point(20, 120);
            dgvClients.Name = "dgvClients";
            dgvClients.ReadOnly = true;
            dgvClients.RowHeadersVisible = false;
            dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvClients.Size = new System.Drawing.Size(656, 296);
            dgvClients.TabIndex = 0;
            // 
            // btnAddClient
            // 
            btnAddClient.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
            btnAddClient.FlatAppearance.BorderSize = 0;
            btnAddClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddClient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnAddClient.ForeColor = System.Drawing.Color.White;
            btnAddClient.Location = new System.Drawing.Point(300, 10);
            btnAddClient.Name = "btnAddClient";
            btnAddClient.Size = new System.Drawing.Size(140, 35);
            btnAddClient.TabIndex = 2;
            btnAddClient.Text = "Nouveau Client";
            btnAddClient.UseVisualStyleBackColor = false;
            btnAddClient.Click += BtnAddClient_Click;
            // 
            // btnEditClient
            // 
            btnEditClient.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)193)), ((int)((byte)7)));
            btnEditClient.FlatAppearance.BorderSize = 0;
            btnEditClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEditClient.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnEditClient.ForeColor = System.Drawing.Color.Black;
            btnEditClient.Location = new System.Drawing.Point(450, 10);
            btnEditClient.Name = "btnEditClient";
            btnEditClient.Size = new System.Drawing.Size(100, 35);
            btnEditClient.TabIndex = 3;
            btnEditClient.Text = "Modifier";
            btnEditClient.UseVisualStyleBackColor = false;
            btnEditClient.Click += BtnEditClient_Click;
            // 
            // btnDeleteClient
            // 
            btnDeleteClient.BackColor = System.Drawing.Color.FromArgb(((int)((byte)220)), ((int)((byte)53)), ((int)((byte)69)));
            btnDeleteClient.FlatAppearance.BorderSize = 0;
            btnDeleteClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDeleteClient.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnDeleteClient.ForeColor = System.Drawing.Color.White;
            btnDeleteClient.Location = new System.Drawing.Point(560, 10);
            btnDeleteClient.Name = "btnDeleteClient";
            btnDeleteClient.Size = new System.Drawing.Size(93, 35);
            btnDeleteClient.TabIndex = 4;
            btnDeleteClient.Text = "Supprimer";
            btnDeleteClient.UseVisualStyleBackColor = false;
            btnDeleteClient.Click += BtnDeleteClient_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtSearch.Location = new System.Drawing.Point(85, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(200, 25);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // lblStatus
            // 
            lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblStatus.ForeColor = System.Drawing.Color.Gray;
            lblStatus.Location = new System.Drawing.Point(20, 416);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            lblStatus.Size = new System.Drawing.Size(656, 25);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Chargement...";
            lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
            lblTitle.Location = new System.Drawing.Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(656, 50);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "GESTION DES CLIENTS";
            // 
            // panelTools
            // 
            panelTools.BackColor = System.Drawing.Color.White;
            panelTools.Controls.Add(lblSearch);
            panelTools.Controls.Add(txtSearch);
            panelTools.Controls.Add(btnAddClient);
            panelTools.Controls.Add(btnEditClient);
            panelTools.Controls.Add(btnDeleteClient);
            panelTools.Dock = System.Windows.Forms.DockStyle.Top;
            panelTools.Location = new System.Drawing.Point(20, 70);
            panelTools.Name = "panelTools";
            panelTools.Size = new System.Drawing.Size(656, 50);
            panelTools.TabIndex = 2;
            // 
            // lblSearch
            // 
            lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblSearch.Location = new System.Drawing.Point(0, 15);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new System.Drawing.Size(80, 25);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Rechercher:";
            // 
            // ClientsUserControl
            // 
            BackColor = System.Drawing.Color.White;
            Controls.Add(dgvClients);
            Controls.Add(lblStatus);
            Controls.Add(panelTools);
            Controls.Add(lblTitle);
            Padding = new System.Windows.Forms.Padding(20);
            Size = new System.Drawing.Size(696, 461);
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            panelTools.ResumeLayout(false);
            panelTools.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelTools;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Button btnEditClient;
        private System.Windows.Forms.Button btnDeleteClient;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblSearch;
    }
}