using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace POS_RESTO.Forms;

partial class PaymentForm
{
    private DataGridView dgvPayments;
    private Label lblAmountPaid;
    private Label lblRemaining;
    
    private void InitializeComponent()
    {
        this.Size = new Size(500, 600);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        
        var panel = new Panel();
        panel.Dock = DockStyle.Fill;
        panel.Padding = new Padding(20);
        panel.AutoScroll = true;
        
        // Titre
        var lblTitle = new Label();
        lblTitle.Text = "NOUVEAU PAIEMENT";
        lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(0, 123, 255);
        lblTitle.Dock = DockStyle.Top;
        lblTitle.Height = 40;
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        
        // ID Commande
        var lblOrderId = new Label();
        lblOrderId.Text = "ID Commande:*";
        lblOrderId.Font = new Font("Segoe UI", 10);
        lblOrderId.Location = new Point(0, 60);
        lblOrderId.Size = new Size(120, 25);
        
        numOrderId = new NumericUpDown();
        numOrderId.Minimum = 1;
        numOrderId.Maximum = 100000;
        numOrderId.Font = new Font("Segoe UI", 10);
        numOrderId.Location = new Point(130, 60);
        numOrderId.Size = new Size(150, 25);
        numOrderId.ValueChanged += NumOrderId_ValueChanged;
        
        // Détails de la commande
        lblOrderDetails = new Label();
        lblOrderDetails.Text = "";
        lblOrderDetails.Font = new Font("Segoe UI", 9);
        lblOrderDetails.ForeColor = Color.Gray;
        lblOrderDetails.Location = new Point(0, 90);
        lblOrderDetails.Size = new Size(400, 25);
        
        // Total commande
        lblOrderTotal = new Label();
        lblOrderTotal.Text = "Total commande: -- HTG";
        lblOrderTotal.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        lblOrderTotal.Location = new Point(0, 120);
        lblOrderTotal.Size = new Size(400, 25);
        
        // Montant déjà payé
        lblAmountPaid = new Label();
        lblAmountPaid.Text = "Déjà payé: -- HTG";
        lblAmountPaid.Font = new Font("Segoe UI", 10);
        lblAmountPaid.Location = new Point(0, 145);
        lblAmountPaid.Size = new Size(400, 25);
        
        // Montant restant
        lblRemaining = new Label();
        lblRemaining.Text = "Reste à payer: -- HTG";
        lblRemaining.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        lblRemaining.Location = new Point(0, 170);
        lblRemaining.Size = new Size(400, 25);
        
        // Séparateur
        var separator = new Label();
        separator.BorderStyle = BorderStyle.Fixed3D;
        separator.Location = new Point(0, 200);
        separator.Size = new Size(400, 2);
        
        // Historique des paiements
        var lblHistoryTitle = new Label();
        lblHistoryTitle.Text = "Historique des paiements:";
        lblHistoryTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        lblHistoryTitle.Location = new Point(0, 210);
        lblHistoryTitle.Size = new Size(200, 25);
        
        dgvPayments = new DataGridView();
        dgvPayments.Location = new Point(0, 240);
        dgvPayments.Size = new Size(400, 150);
        dgvPayments.ReadOnly = true;
        dgvPayments.RowHeadersVisible = false;
        dgvPayments.AllowUserToAddRows = false;
        dgvPayments.AllowUserToDeleteRows = false;
        dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        
        // Séparateur 2
        var separator2 = new Label();
        separator2.BorderStyle = BorderStyle.Fixed3D;
        separator2.Location = new Point(0, 400);
        separator2.Size = new Size(400, 2);
        
        // Montant à payer
        var lblAmount = new Label();
        lblAmount.Text = "Montant à payer:*";
        lblAmount.Font = new Font("Segoe UI", 10);
        lblAmount.Location = new Point(0, 410);
        lblAmount.Size = new Size(120, 25);
        
        numAmount = new NumericUpDown();
        numAmount.DecimalPlaces = 2;
        numAmount.Minimum = 0;
        numAmount.Maximum = 10000000;
        numAmount.Font = new Font("Segoe UI", 10);
        numAmount.Location = new Point(130, 410);
        numAmount.Size = new Size(150, 25);
        
        // Mode de paiement
        var lblPaymentMode = new Label();
        lblPaymentMode.Text = "Mode paiement:*";
        lblPaymentMode.Font = new Font("Segoe UI", 10);
        lblPaymentMode.Location = new Point(0, 445);
        lblPaymentMode.Size = new Size(120, 25);
        
        cmbPaymentMode = new ComboBox();
        cmbPaymentMode.Items.AddRange(new object[] { "cash", "card", "cheque" });
        cmbPaymentMode.SelectedIndex = 0;
        cmbPaymentMode.Font = new Font("Segoe UI", 10);
        cmbPaymentMode.Location = new Point(130, 445);
        cmbPaymentMode.Size = new Size(150, 25);
        
        // Boutons
        var panelButtons = new Panel();
        panelButtons.Dock = DockStyle.Bottom;
        panelButtons.Height = 60;
        panelButtons.Padding = new Padding(20, 10, 20, 10);
        
        btnSave = new Button();
        btnSave.Text = "Enregistrer";
        btnSave.BackColor = Color.FromArgb(40, 167, 69);
        btnSave.ForeColor = Color.White;
        btnSave.FlatStyle = FlatStyle.Flat;
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        btnSave.Size = new Size(120, 35);
        btnSave.Location = new Point(100, 10);
        btnSave.Click += BtnSave_Click;
        
        btnCancel = new Button();
        btnCancel.Text = "Annuler";
        btnCancel.BackColor = Color.FromArgb(108, 117, 125);
        btnCancel.ForeColor = Color.White;
        btnCancel.FlatStyle = FlatStyle.Flat;
        btnCancel.FlatAppearance.BorderSize = 0;
        btnCancel.Font = new Font("Segoe UI", 10);
        btnCancel.Size = new Size(120, 35);
        btnCancel.Location = new Point(230, 10);
        btnCancel.Click += BtnCancel_Click;
        
        panelButtons.Controls.Add(btnSave);
        panelButtons.Controls.Add(btnCancel);
        
        panel.Controls.Add(lblTitle);
        panel.Controls.Add(lblOrderId);
        panel.Controls.Add(numOrderId);
        panel.Controls.Add(lblOrderDetails);
        panel.Controls.Add(lblOrderTotal);
        panel.Controls.Add(lblAmountPaid);
        panel.Controls.Add(lblRemaining);
        panel.Controls.Add(separator);
        panel.Controls.Add(lblHistoryTitle);
        panel.Controls.Add(dgvPayments);
        panel.Controls.Add(separator2);
        panel.Controls.Add(lblAmount);
        panel.Controls.Add(numAmount);
        panel.Controls.Add(lblPaymentMode);
        panel.Controls.Add(cmbPaymentMode);
        
        this.Controls.Add(panel);
        this.Controls.Add(panelButtons);
    }
    
    // Déclaration des contrôles
    private NumericUpDown numOrderId;
    private Label lblOrderDetails;
    private Label lblOrderTotal;
    private NumericUpDown numAmount;
    private ComboBox cmbPaymentMode;
    private Button btnSave;
    private Button btnCancel;
}