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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            dgvOrders = new DataGridView();
            btnNewOrder = new Button();
            btnRefresh = new Button();
            btnUpdateStatus = new Button();
            btnViewDetails = new Button();
            btnExport = new Button();
            btnClearFilters = new Button();
            cmbFilterStatus = new ComboBox();
            lblStatus = new Label();
            lblTitle = new Label();
            panelTools = new Panel();
            lblFilterStatus = new Label();
            dateFilterPicker = new DateTimePicker();
            lblFilterDate = new Label();
            
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            panelTools.SuspendLayout();
            this.SuspendLayout();
            
            // lblTitle
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Text = "GESTION DES COMMANDES";
            lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 123, 255);
            lblTitle.Height = 50;
            lblTitle.Padding = new Padding(20, 20, 20, 0);
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            
            // panelTools
            panelTools.Dock = DockStyle.Top;
            panelTools.Height = 70;
            panelTools.BackColor = Color.White;
            panelTools.Padding = new Padding(20, 10, 20, 10);
            
            // btnNewOrder
            btnNewOrder.Text = "Nouvelle Commande";
            btnNewOrder.BackColor = Color.FromArgb(0, 123, 255);
            btnNewOrder.ForeColor = Color.White;
            btnNewOrder.FlatStyle = FlatStyle.Flat;
            btnNewOrder.FlatAppearance.BorderSize = 0;
            btnNewOrder.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnNewOrder.Size = new Size(180, 35);
            btnNewOrder.Location = new Point(0, 10);
            btnNewOrder.Click += BtnNewOrder_Click;
            
            // btnRefresh
            btnRefresh.Text = "Rafraîchir";
            btnRefresh.BackColor = Color.FromArgb(108, 117, 125);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Font = new Font("Segoe UI", 10);
            btnRefresh.Size = new Size(100, 35);
            btnRefresh.Location = new Point(190, 10);
            btnRefresh.Click += BtnRefresh_Click;
            
            // btnUpdateStatus
            btnUpdateStatus.Text = "Changer statut";
            btnUpdateStatus.BackColor = Color.FromArgb(255, 193, 7);
            btnUpdateStatus.ForeColor = Color.Black;
            btnUpdateStatus.FlatStyle = FlatStyle.Flat;
            btnUpdateStatus.FlatAppearance.BorderSize = 0;
            btnUpdateStatus.Font = new Font("Segoe UI", 10);
            btnUpdateStatus.Size = new Size(120, 35);
            btnUpdateStatus.Location = new Point(400, 10);
            btnUpdateStatus.Enabled = false;
            btnUpdateStatus.Click += BtnUpdateStatus_Click;
            
            // btnViewDetails
            btnViewDetails.Text = "Voir détails";
            btnViewDetails.BackColor = Color.FromArgb(111, 66, 193);
            btnViewDetails.ForeColor = Color.White;
            btnViewDetails.FlatStyle = FlatStyle.Flat;
            btnViewDetails.FlatAppearance.BorderSize = 0;
            btnViewDetails.Font = new Font("Segoe UI", 10);
            btnViewDetails.Size = new Size(120, 35);
            btnViewDetails.Location = new Point(530, 10);
            btnViewDetails.Enabled = false;
            btnViewDetails.Click += BtnViewDetails_Click;
            
            // btnExport
            btnExport.Text = "Exporter";
            btnExport.BackColor = Color.FromArgb(23, 162, 184);
            btnExport.ForeColor = Color.White;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.Font = new Font("Segoe UI", 10);
            btnExport.Size = new Size(100, 35);
            btnExport.Location = new Point(800, 10);
            btnExport.Click += BtnExport_Click;
            
            // Filtres
            lblFilterStatus.Text = "Statut:";
            lblFilterStatus.Font = new Font("Segoe UI", 10);
            lblFilterStatus.Location = new Point(660, 17);
            lblFilterStatus.Size = new Size(50, 25);
            
            cmbFilterStatus.Items.AddRange(new object[] { 
                "Tous", 
                "en cours", 
                "terminee", 
                "annulee" 
            });
            cmbFilterStatus.SelectedIndex = 0;
            cmbFilterStatus.Font = new Font("Segoe UI", 10);
            cmbFilterStatus.Size = new Size(120, 25);
            cmbFilterStatus.Location = new Point(710, 14);
            cmbFilterStatus.SelectedIndexChanged += CmbFilterStatus_SelectedIndexChanged;
            
            lblFilterDate.Text = "Date:";
            lblFilterDate.Font = new Font("Segoe UI", 10);
            lblFilterDate.Location = new Point(840, 17);
            lblFilterDate.Size = new Size(40, 25);
            
            dateFilterPicker.Font = new Font("Segoe UI", 10);
            dateFilterPicker.Format = DateTimePickerFormat.Short;
            dateFilterPicker.Size = new Size(120, 25);
            dateFilterPicker.Location = new Point(880, 14);
            dateFilterPicker.Checked = false;
            dateFilterPicker.ValueChanged += DateFilterPicker_ValueChanged;
            
            // btnClearFilters
            btnClearFilters.Text = "Effacer filtres";
            btnClearFilters.BackColor = Color.FromArgb(52, 58, 64);
            btnClearFilters.ForeColor = Color.White;
            btnClearFilters.FlatStyle = FlatStyle.Flat;
            btnClearFilters.FlatAppearance.BorderSize = 0;
            btnClearFilters.Font = new Font("Segoe UI", 10);
            btnClearFilters.Size = new Size(120, 25);
            btnClearFilters.Location = new Point(1010, 14);
            btnClearFilters.Click += BtnClearFilters_Click;
            
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
            
            // dgvOrders
            dgvOrders.Dock = DockStyle.Fill;
            dgvOrders.BackgroundColor = Color.White;
            dgvOrders.ReadOnly = true;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.AllowUserToOrderColumns = false;
            dgvOrders.CellFormatting += DgvOrders_CellFormatting;
            dgvOrders.CellDoubleClick += DgvOrders_CellDoubleClick;
            dgvOrders.SelectionChanged += DgvOrders_SelectionChanged;
            
            // lblStatus
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Text = "Chargement...";
            lblStatus.Font = new Font("Segoe UI", 9);
            lblStatus.ForeColor = Color.Gray;
            lblStatus.Height = 30;
            lblStatus.Padding = new Padding(20, 0, 20, 5);
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            
            // OrdersUserControl
            this.BackColor = Color.White;
            this.Controls.Add(dgvOrders);
            this.Controls.Add(lblStatus);
            this.Controls.Add(panelTools);
            this.Controls.Add(lblTitle);
            this.Size = new Size(1200, 600);
            
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            panelTools.ResumeLayout(false);
            panelTools.PerformLayout();
            this.ResumeLayout(false);
        }
        
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvOrders;
        private Button btnNewOrder;
        private Button btnRefresh;
        private Button btnUpdateStatus;
        private Button btnViewDetails;
        private Button btnExport;
        private Button btnClearFilters;
        private ComboBox cmbFilterStatus;
        private Label lblStatus;
        private Label lblTitle;
        private Panel panelTools;
        private Label lblFilterStatus;
        private DateTimePicker dateFilterPicker;
        private Label lblFilterDate;
    }
}