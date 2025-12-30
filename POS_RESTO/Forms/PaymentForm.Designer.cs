using System.ComponentModel;

namespace POS_RESTO.Forms;

partial class PaymentForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        this.Size = new Size(400, 350);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        
        var panel = new Panel();
        panel.Dock = DockStyle.Fill;
        panel.Padding = new Padding(20);
        
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
        
        // Montant commande
        lblOrderTotal = new Label();
        lblOrderTotal.Text = "Montant commande: -- HTG";
        lblOrderTotal.Font = new Font("Segoe UI", 10);
        lblOrderTotal.Location = new Point(0, 95);
        lblOrderTotal.Size = new Size(300, 25);
        
        // Montant à payer
        var lblAmount = new Label();
        lblAmount.Text = "Montant paye:*";
        lblAmount.Font = new Font("Segoe UI", 10);
        lblAmount.Location = new Point(0, 130);
        lblAmount.Size = new Size(120, 25);
        
        numAmount = new NumericUpDown();
        numAmount.DecimalPlaces = 2;
        numAmount.Minimum = 0;
        numAmount.Maximum = 10000000;
        numAmount.Font = new Font("Segoe UI", 10);
        numAmount.Location = new Point(130, 130);
        numAmount.Size = new Size(150, 25);
        
        // Mode de paiement
        var lblPaymentMode = new Label();
        lblPaymentMode.Text = "Mode paiement:*";
        lblPaymentMode.Font = new Font("Segoe UI", 10);
        lblPaymentMode.Location = new Point(0, 170);
        lblPaymentMode.Size = new Size(120, 25);
        
        cmbPaymentMode = new ComboBox();
        cmbPaymentMode.Items.AddRange(new object[] { "cash", "card", "cheque" });
        cmbPaymentMode.SelectedIndex = 0;
        cmbPaymentMode.Font = new Font("Segoe UI", 10);
        cmbPaymentMode.Location = new Point(130, 170);
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
        panel.Controls.Add(lblOrderTotal);
        panel.Controls.Add(lblAmount);
        panel.Controls.Add(numAmount);
        panel.Controls.Add(lblPaymentMode);
        panel.Controls.Add(cmbPaymentMode);
        
        this.Controls.Add(panel);
        this.Controls.Add(panelButtons);
    }
        

    #endregion
    
    
    private NumericUpDown numOrderId;
    private NumericUpDown numAmount;
    private ComboBox cmbPaymentMode;
    private Button btnSave;
    private Button btnCancel;
    private Label lblOrderTotal;
}