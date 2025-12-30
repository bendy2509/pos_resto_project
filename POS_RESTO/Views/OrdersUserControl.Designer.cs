using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace POS_RESTO.Views
{
    partial class OrdersUserControl
    {
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
            dgvOrders = new System.Windows.Forms.DataGridView();
            btnNewOrder = new System.Windows.Forms.Button();
            btnRefresh = new System.Windows.Forms.Button();
            btnUpdateStatus = new System.Windows.Forms.Button();
            btnViewDetails = new System.Windows.Forms.Button();
            btnExport = new System.Windows.Forms.Button();
            btnClearFilters = new System.Windows.Forms.Button();
            cmbFilterStatus = new System.Windows.Forms.ComboBox();
            lblStatus = new System.Windows.Forms.Label();
            lblTitle = new System.Windows.Forms.Label();
            panelTools = new System.Windows.Forms.Panel();
            lblFilterStatus = new System.Windows.Forms.Label();
            lblFilterDate = new System.Windows.Forms.Label();
            dateFilterPicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            panelTools.SuspendLayout();
            SuspendLayout();
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.BackgroundColor = System.Drawing.Color.White;
            dgvOrders.Location = new System.Drawing.Point(0, 120);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new System.Drawing.Size(1100, 400);
            dgvOrders.TabIndex = 0;
            dgvOrders.CellDoubleClick += DgvOrders_CellDoubleClick;
            dgvOrders.CellFormatting += DgvOrders_CellFormatting;
            dgvOrders.SelectionChanged += DgvOrders_SelectionChanged;
            // 
            // btnNewOrder
            // 
            btnNewOrder.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
            btnNewOrder.FlatAppearance.BorderSize = 0;
            btnNewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNewOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnNewOrder.ForeColor = System.Drawing.Color.White;
            btnNewOrder.Location = new System.Drawing.Point(14, 10);
            btnNewOrder.Name = "btnNewOrder";
            btnNewOrder.Size = new System.Drawing.Size(166, 35);
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
            btnRefresh.Text = "Rafraîchir";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // btnUpdateStatus
            // 
            btnUpdateStatus.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)193)), ((int)((byte)7)));
            btnUpdateStatus.Enabled = false;
            btnUpdateStatus.FlatAppearance.BorderSize = 0;
            btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnUpdateStatus.ForeColor = System.Drawing.Color.Black;
            btnUpdateStatus.Location = new System.Drawing.Point(325, 8);
            btnUpdateStatus.Name = "btnUpdateStatus";
            btnUpdateStatus.Size = new System.Drawing.Size(120, 35);
            btnUpdateStatus.TabIndex = 2;
            btnUpdateStatus.Text = "Changer statut";
            btnUpdateStatus.UseVisualStyleBackColor = false;
            btnUpdateStatus.Click += BtnUpdateStatus_Click;
            // 
            // btnViewDetails
            // 
            btnViewDetails.BackColor = System.Drawing.Color.FromArgb(((int)((byte)111)), ((int)((byte)66)), ((int)((byte)193)));
            btnViewDetails.Enabled = false;
            btnViewDetails.FlatAppearance.BorderSize = 0;
            btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnViewDetails.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnViewDetails.ForeColor = System.Drawing.Color.White;
            btnViewDetails.Location = new System.Drawing.Point(451, 8);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new System.Drawing.Size(120, 35);
            btnViewDetails.TabIndex = 3;
            btnViewDetails.Text = "Voir détails";
            btnViewDetails.UseVisualStyleBackColor = false;
            btnViewDetails.Click += BtnViewDetails_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = System.Drawing.Color.FromArgb(((int)((byte)23)), ((int)((byte)162)), ((int)((byte)184)));
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnExport.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnExport.ForeColor = System.Drawing.Color.White;
            btnExport.Location = new System.Drawing.Point(958, 3);
            btnExport.Name = "btnExport";
            btnExport.Size = new System.Drawing.Size(100, 35);
            btnExport.TabIndex = 4;
            btnExport.Text = "Exporter";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += BtnExport_Click;
            // 
            // btnClearFilters
            // 
            btnClearFilters.BackColor = System.Drawing.Color.FromArgb(((int)((byte)52)), ((int)((byte)58)), ((int)((byte)64)));
            btnClearFilters.FlatAppearance.BorderSize = 0;
            btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClearFilters.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnClearFilters.ForeColor = System.Drawing.Color.White;
            btnClearFilters.Location = new System.Drawing.Point(949, 39);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new System.Drawing.Size(120, 25);
            btnClearFilters.TabIndex = 9;
            btnClearFilters.Text = "Effacer filtres";
            btnClearFilters.UseVisualStyleBackColor = false;
            btnClearFilters.Click += BtnClearFilters_Click;
            // 
            // cmbFilterStatus
            // 
            cmbFilterStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbFilterStatus.Items.AddRange(new object[] { "Tous", "en cours", "terminee", "annulee" });
            cmbFilterStatus.Location = new System.Drawing.Point(633, 13);
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new System.Drawing.Size(120, 25);
            cmbFilterStatus.TabIndex = 6;
            cmbFilterStatus.SelectedIndexChanged += CmbFilterStatus_SelectedIndexChanged;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblStatus.ForeColor = System.Drawing.Color.Gray;
            lblStatus.Location = new System.Drawing.Point(0, 570);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new System.Windows.Forms.Padding(10, 0, 10, 5);
            lblStatus.Size = new System.Drawing.Size(2950, 30);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Chargement...";
            lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
            lblTitle.Location = new System.Drawing.Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(1400, 50);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "GESTION DES COMMANDES";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelTools
            // 
            panelTools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            panelTools.BackColor = System.Drawing.Color.White;
            panelTools.Controls.Add(btnNewOrder);
            panelTools.Controls.Add(btnRefresh);
            panelTools.Controls.Add(btnUpdateStatus);
            panelTools.Controls.Add(btnViewDetails);
            panelTools.Controls.Add(btnExport);
            panelTools.Controls.Add(lblFilterStatus);
            panelTools.Controls.Add(cmbFilterStatus);
            panelTools.Controls.Add(lblFilterDate);
            panelTools.Controls.Add(dateFilterPicker);
            panelTools.Controls.Add(btnClearFilters);
            panelTools.Location = new System.Drawing.Point(0, 50);
            panelTools.Name = "panelTools";
            panelTools.Padding = new System.Windows.Forms.Padding(5, 5, 10, 5);
            panelTools.Size = new System.Drawing.Size(1100, 70);
            panelTools.TabIndex = 2;
            // 
            // lblFilterStatus
            // 
            lblFilterStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblFilterStatus.Location = new System.Drawing.Point(577, 13);
            lblFilterStatus.Name = "lblFilterStatus";
            lblFilterStatus.Size = new System.Drawing.Size(50, 25);
            lblFilterStatus.TabIndex = 5;
            lblFilterStatus.Text = "Statut:";
            lblFilterStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFilterDate
            // 
            lblFilterDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblFilterDate.Location = new System.Drawing.Point(759, 13);
            lblFilterDate.Name = "lblFilterDate";
            lblFilterDate.Size = new System.Drawing.Size(40, 25);
            lblFilterDate.TabIndex = 7;
            lblFilterDate.Text = "Date:";
            // 
            // dateFilterPicker
            // 
            dateFilterPicker.Checked = false;
            dateFilterPicker.Font = new System.Drawing.Font("Segoe UI", 10F);
            dateFilterPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dateFilterPicker.Location = new System.Drawing.Point(823, 13);
            dateFilterPicker.Name = "dateFilterPicker";
            dateFilterPicker.Size = new System.Drawing.Size(120, 25);
            dateFilterPicker.TabIndex = 8;
            dateFilterPicker.ValueChanged += DateFilterPicker_ValueChanged;
            // 
            // OrdersUserControl
            // 
            BackColor = System.Drawing.Color.White;
            Controls.Add(lblStatus);
            Controls.Add(panelTools);
            Controls.Add(lblTitle);
            Controls.Add(dgvOrders);
            Size = new System.Drawing.Size(1400, 600);
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            panelTools.ResumeLayout(false);
            ResumeLayout(false);
        }
        
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button btnNewOrder;
        private Button btnRefresh;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelTools;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.DateTimePicker dateFilterPicker;
        private System.Windows.Forms.Label lblFilterDate;
    }
}