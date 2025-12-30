namespace POS_RESTO.Views
{
    partial class OrdersUserControl
    {
        private System.ComponentModel.IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
        
        
        private DataGridView dgvOrders;
        private Button btnNewOrder;
        private Button btnRefresh;
        private ComboBox cmbFilterStatus;
        private Label lblStatus;
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        
        private void InitializeComponent()
        {
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbFilterStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)this.dgvOrders).BeginInit();
            this.SuspendLayout();
            
            // 
            // OrdersUserControl
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            
            // Titre
            var lblTitle = new System.Windows.Forms.Label();
            lblTitle.Text = "GESTION DES COMMANDES";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 20, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Height = 50;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            
            // Panel d'outils
            var panelTools = new System.Windows.Forms.Panel();
            panelTools.Dock = System.Windows.Forms.DockStyle.Top;
            panelTools.Height = 50;
            panelTools.BackColor = System.Drawing.Color.White;
            
            // Bouton nouvelle commande
            this.btnNewOrder.Text = "Nouvelle Commande";
            this.btnNewOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnNewOrder.ForeColor = System.Drawing.Color.White;
            this.btnNewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewOrder.FlatAppearance.BorderSize = 0;
            this.btnNewOrder.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnNewOrder.Size = new System.Drawing.Size(180, 35);
            this.btnNewOrder.Location = new System.Drawing.Point(0, 10);
            this.btnNewOrder.Click += BtnNewOrder_Click;
            
            // Bouton rafraichir
            this.btnRefresh.Text = "Rafraichir";
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10);
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.Location = new System.Drawing.Point(190, 10);
            this.btnRefresh.Click += BtnRefresh_Click;
            
            // Filtre par statut
            var lblFilter = new System.Windows.Forms.Label();
            lblFilter.Text = "Statut:";
            lblFilter.Font = new System.Drawing.Font("Segoe UI", 10);
            lblFilter.Location = new System.Drawing.Point(300, 15);
            lblFilter.Size = new System.Drawing.Size(50, 25);
            
            this.cmbFilterStatus.Items.AddRange(new object[] { 
                "Tous", 
                "En cours", 
                "Prête", 
                "Servie", 
                "Annulée" 
            });
            this.cmbFilterStatus.SelectedIndex = 0;
            this.cmbFilterStatus.Font = new System.Drawing.Font("Segoe UI", 10);
            this.cmbFilterStatus.Size = new System.Drawing.Size(150, 25);
            this.cmbFilterStatus.Location = new System.Drawing.Point(350, 12);
            this.cmbFilterStatus.SelectedIndexChanged += CmbFilterStatus_SelectedIndexChanged;
            
            panelTools.Controls.Add(this.btnNewOrder);
            panelTools.Controls.Add(this.btnRefresh);
            panelTools.Controls.Add(lblFilter);
            panelTools.Controls.Add(this.cmbFilterStatus);
            
            // DataGridView pour les commandes
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AllowUserToOrderColumns = false;
            
            // Événements du DataGridView
            this.dgvOrders.CellFormatting += DgvOrders_CellFormatting;
            this.dgvOrders.CellDoubleClick += DgvOrders_CellDoubleClick;
            
            // Status label
            this.lblStatus.Text = "Chargement...";
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9);
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Height = 25;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            
            // Ajouter les contrôles
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(panelTools);
            this.Controls.Add(lblTitle);
            
            ((System.ComponentModel.ISupportInitialize)this.dgvOrders).EndInit();
            this.ResumeLayout(false);
        }
    }
}