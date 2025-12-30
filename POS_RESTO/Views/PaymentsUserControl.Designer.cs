using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace POS_RESTO.Views
{
    partial class PaymentsUserControl
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvPayments;
        private Button btnNewPayment;
        private Button btnRefresh;
        private Button btnToday;
        private Button btnThisWeek;
        private Button btnThisMonth;
        private Button btnExport;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Label lblTitle;
        private Panel panelTools;
        private Label lblFrom;
        private Label lblTo;
        private Label lblStatus;
        private Panel panelStatistics;
        private Label lblTotalAmount;
        private Label lblCashAmount;
        private Label lblCardAmount;
        private Label lblChequeAmount;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            dgvPayments = new DataGridView();
            btnNewPayment = new Button();
            btnRefresh = new Button();
            btnToday = new Button();
            btnThisWeek = new Button();
            btnThisMonth = new Button();
            btnExport = new Button();
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            lblTitle = new Label();
            panelTools = new Panel();
            lblFrom = new Label();
            lblTo = new Label();
            lblStatus = new Label();
            panelStatistics = new Panel();
            lblTotalAmount = new Label();
            lblCashAmount = new Label();
            lblCardAmount = new Label();
            lblChequeAmount = new Label();
            
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            panelTools.SuspendLayout();
            panelStatistics.SuspendLayout();
            this.SuspendLayout();
            
            // lblTitle
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Text = "GESTION DES PAIEMENTS";
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
            
            // Filtres dates
            lblFrom.Text = "Du:";
            lblFrom.Font = new Font("Segoe UI", 10);
            lblFrom.Location = new Point(0, 17);
            lblFrom.Size = new Size(30, 25);
            
            dtpFrom.Font = new Font("Segoe UI", 10);
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Size = new Size(120, 25);
            dtpFrom.Location = new Point(35, 14);
            dtpFrom.Value = DateTime.Today.AddDays(-7);
            dtpFrom.ValueChanged += DateFilter_Changed;
            
            lblTo.Text = "Au:";
            lblTo.Font = new Font("Segoe UI", 10);
            lblTo.Location = new Point(165, 17);
            lblTo.Size = new Size(25, 25);
            
            dtpTo.Font = new Font("Segoe UI", 10);
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Size = new Size(120, 25);
            dtpTo.Location = new Point(195, 14);
            dtpTo.Value = DateTime.Today;
            dtpTo.ValueChanged += DateFilter_Changed;
            
            // Boutons de période rapide
            btnToday.Text = "Aujourd'hui";
            btnToday.BackColor = Color.FromArgb(23, 162, 184);
            btnToday.ForeColor = Color.White;
            btnToday.FlatStyle = FlatStyle.Flat;
            btnToday.FlatAppearance.BorderSize = 0;
            btnToday.Font = new Font("Segoe UI", 9);
            btnToday.Size = new Size(100, 25);
            btnToday.Location = new Point(330, 14);
            btnToday.Click += BtnToday_Click;
            
            btnThisWeek.Text = "Cette semaine";
            btnThisWeek.BackColor = Color.FromArgb(111, 66, 193);
            btnThisWeek.ForeColor = Color.White;
            btnThisWeek.FlatStyle = FlatStyle.Flat;
            btnThisWeek.FlatAppearance.BorderSize = 0;
            btnThisWeek.Font = new Font("Segoe UI", 9);
            btnThisWeek.Size = new Size(100, 25);
            btnThisWeek.Location = new Point(440, 14);
            btnThisWeek.Click += BtnThisWeek_Click;
            
            btnThisMonth.Text = "Ce mois";
            btnThisMonth.BackColor = Color.FromArgb(253, 126, 20);
            btnThisMonth.ForeColor = Color.White;
            btnThisMonth.FlatStyle = FlatStyle.Flat;
            btnThisMonth.FlatAppearance.BorderSize = 0;
            btnThisMonth.Font = new Font("Segoe UI", 9);
            btnThisMonth.Size = new Size(100, 25);
            btnThisMonth.Location = new Point(550, 14);
            btnThisMonth.Click += BtnThisMonth_Click;
            
            // Boutons d'action
            btnNewPayment.Text = "Nouveau Paiement";
            btnNewPayment.BackColor = Color.FromArgb(40, 167, 69);
            btnNewPayment.ForeColor = Color.White;
            btnNewPayment.FlatStyle = FlatStyle.Flat;
            btnNewPayment.FlatAppearance.BorderSize = 0;
            btnNewPayment.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnNewPayment.Size = new Size(160, 35);
            btnNewPayment.Location = new Point(660, 10);
            btnNewPayment.Click += BtnNewPayment_Click;
            
            btnRefresh.Text = "Rafraîchir";
            btnRefresh.BackColor = Color.FromArgb(108, 117, 125);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Font = new Font("Segoe UI", 10);
            btnRefresh.Size = new Size(100, 35);
            btnRefresh.Location = new Point(830, 10);
            btnRefresh.Click += BtnRefresh_Click;
            
            btnExport.Text = "Exporter";
            btnExport.BackColor = Color.FromArgb(23, 162, 184);
            btnExport.ForeColor = Color.White;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.Font = new Font("Segoe UI", 10);
            btnExport.Size = new Size(100, 35);
            btnExport.Location = new Point(940, 10);
            btnExport.Click += BtnExport_Click;
            
            panelTools.Controls.Add(lblFrom);
            panelTools.Controls.Add(dtpFrom);
            panelTools.Controls.Add(lblTo);
            panelTools.Controls.Add(dtpTo);
            panelTools.Controls.Add(btnToday);
            panelTools.Controls.Add(btnThisWeek);
            panelTools.Controls.Add(btnThisMonth);
            panelTools.Controls.Add(btnNewPayment);
            panelTools.Controls.Add(btnRefresh);
            panelTools.Controls.Add(btnExport);
            
            // panelStatistics
            panelStatistics.Dock = DockStyle.Top;
            panelStatistics.Height = 40;
            panelStatistics.BackColor = Color.FromArgb(248, 249, 250);
            panelStatistics.Padding = new Padding(20, 5, 20, 5);
            
            lblTotalAmount.Text = "Total: 0 HTG";
            lblTotalAmount.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.FromArgb(40, 167, 69);
            lblTotalAmount.Location = new Point(0, 10);
            lblTotalAmount.Size = new Size(150, 25);
            
            lblCashAmount.Text = "Espèces: 0 HTG";
            lblCashAmount.Font = new Font("Segoe UI", 9);
            lblCashAmount.ForeColor = Color.FromArgb(108, 117, 125);
            lblCashAmount.Location = new Point(160, 10);
            lblCashAmount.Size = new Size(120, 25);
            
            lblCardAmount.Text = "Carte: 0 HTG";
            lblCardAmount.Font = new Font("Segoe UI", 9);
            lblCardAmount.ForeColor = Color.FromArgb(108, 117, 125);
            lblCardAmount.Location = new Point(290, 10);
            lblCardAmount.Size = new Size(120, 25);
            
            lblChequeAmount.Text = "Chèque: 0 HTG";
            lblChequeAmount.Font = new Font("Segoe UI", 9);
            lblChequeAmount.ForeColor = Color.FromArgb(108, 117, 125);
            lblChequeAmount.Location = new Point(420, 10);
            lblChequeAmount.Size = new Size(120, 25);
            
            panelStatistics.Controls.Add(lblTotalAmount);
            panelStatistics.Controls.Add(lblCashAmount);
            panelStatistics.Controls.Add(lblCardAmount);
            panelStatistics.Controls.Add(lblChequeAmount);
            
            // dgvPayments
            dgvPayments.Dock = DockStyle.Fill;
            dgvPayments.BackgroundColor = Color.White;
            dgvPayments.ReadOnly = true;
            dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayments.RowHeadersVisible = false;
            dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayments.AllowUserToAddRows = false;
            dgvPayments.AllowUserToDeleteRows = false;
            dgvPayments.CellDoubleClick += DgvPayments_CellDoubleClick;
            
            // lblStatus
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Text = "Chargement...";
            lblStatus.Font = new Font("Segoe UI", 9);
            lblStatus.ForeColor = Color.Gray;
            lblStatus.Height = 30;
            lblStatus.Padding = new Padding(20, 0, 20, 5);
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            
            // PaymentsUserControl
            this.BackColor = Color.White;
            this.Controls.Add(dgvPayments);
            this.Controls.Add(lblStatus);
            this.Controls.Add(panelStatistics);
            this.Controls.Add(panelTools);
            this.Controls.Add(lblTitle);
            this.Size = new Size(1200, 600);
            
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            panelTools.ResumeLayout(false);
            panelStatistics.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}