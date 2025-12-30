namespace POS_RESTO.Views
{
    partial class OrdersUserControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvOrders;
        private Button btnNewOrder;
        private Button btnRefresh;
        private ComboBox cmbFilterStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Statut;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Label lblFilter;
        
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dgvOrders = new System.Windows.Forms.DataGridView();
            ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Statut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            btnNewOrder = new System.Windows.Forms.Button();
            btnRefresh = new System.Windows.Forms.Button();
            cmbFilterStatus = new System.Windows.Forms.ComboBox();
            lblStatus = new System.Windows.Forms.Label();
            lblTitle = new System.Windows.Forms.Label();
            panelTools = new System.Windows.Forms.Panel();
            lblFilter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            panelTools.SuspendLayout();
            SuspendLayout();
            // 
            // dgvOrders
            // 
            dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.BackgroundColor = System.Drawing.Color.White;
            dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { ID, Client, Date, Statut, Total });
            dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvOrders.Location = new System.Drawing.Point(20, 120);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new System.Drawing.Size(620, 264);
            dgvOrders.TabIndex = 0;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // Client
            // 
            Client.HeaderText = "Client";
            Client.Name = "Client";
            Client.ReadOnly = true;
            // 
            // Date
            // 
            Date.HeaderText = "Date";
            Date.Name = "Date";
            Date.ReadOnly = true;
            // 
            // Statut
            // 
            Statut.HeaderText = "Statut";
            Statut.Name = "Statut";
            Statut.ReadOnly = true;
            // 
            // Total
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            Total.DefaultCellStyle = dataGridViewCellStyle1;
            Total.HeaderText = "Total HTG";
            Total.Name = "Total";
            Total.ReadOnly = true;
            // 
            // btnNewOrder
            // 
            btnNewOrder.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
            btnNewOrder.FlatAppearance.BorderSize = 0;
            btnNewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNewOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnNewOrder.ForeColor = System.Drawing.Color.White;
            btnNewOrder.Location = new System.Drawing.Point(0, 10);
            btnNewOrder.Name = "btnNewOrder";
            btnNewOrder.Size = new System.Drawing.Size(180, 35);
            btnNewOrder.TabIndex = 0;
            btnNewOrder.Text = "Nouvelle Commande";
            btnNewOrder.UseVisualStyleBackColor = false;
            btnNewOrder.Click += BtnNewOrder_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)((byte)108)), ((int)((byte)117)), ((int)((byte)125)));
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnRefresh.ForeColor = System.Drawing.Color.White;
            btnRefresh.Location = new System.Drawing.Point(190, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(100, 35);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Rafraichir";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // cmbFilterStatus
            // 
            cmbFilterStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbFilterStatus.Items.AddRange(new object[] { "Tous", "En cours", "Prete", "Servie", "Annulee" });
            cmbFilterStatus.Location = new System.Drawing.Point(350, 12);
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new System.Drawing.Size(150, 25);
            cmbFilterStatus.TabIndex = 3;
            cmbFilterStatus.SelectedIndexChanged += CmbFilterStatus_SelectedIndexChanged;
            // 
            // lblStatus
            // 
            lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblStatus.ForeColor = System.Drawing.Color.Gray;
            lblStatus.Location = new System.Drawing.Point(20, 384);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(620, 25);
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
            lblTitle.Size = new System.Drawing.Size(620, 50);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "GESTION DES COMMANDES";
            // 
            // panelTools
            // 
            panelTools.BackColor = System.Drawing.Color.White;
            panelTools.Controls.Add(btnNewOrder);
            panelTools.Controls.Add(btnRefresh);
            panelTools.Controls.Add(lblFilter);
            panelTools.Controls.Add(cmbFilterStatus);
            panelTools.Dock = System.Windows.Forms.DockStyle.Top;
            panelTools.Location = new System.Drawing.Point(20, 70);
            panelTools.Name = "panelTools";
            panelTools.Size = new System.Drawing.Size(620, 50);
            panelTools.TabIndex = 2;
            // 
            // lblFilter
            // 
            lblFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblFilter.Location = new System.Drawing.Point(300, 15);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new System.Drawing.Size(50, 25);
            lblFilter.TabIndex = 2;
            lblFilter.Text = "Statut:";
            // 
            // OrdersUserControl
            // 
            BackColor = System.Drawing.Color.White;
            Controls.Add(dgvOrders);
            Controls.Add(lblStatus);
            Controls.Add(panelTools);
            Controls.Add(lblTitle);
            Padding = new System.Windows.Forms.Padding(20);
            Size = new System.Drawing.Size(660, 429);
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            panelTools.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelTools;
    }
}