using System.ComponentModel;

namespace POS_RESTO.Forms;

partial class OrderStatusForm
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
        this.Text = "Changer le statut de la commande";
        this.Size = new Size(400, 250);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        
        var panel = new Panel();
        panel.Dock = DockStyle.Fill;
        panel.Padding = new Padding(20);
        
        // Titre
        var lblTitle = new Label();
        lblTitle.Text = "MODIFIER LE STATUT";
        lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(0, 123, 255);
        lblTitle.Dock = DockStyle.Top;
        lblTitle.Height = 40;
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        
        // Info commande
        lblOrderInfo = new Label();
        lblOrderInfo.Font = new Font("Segoe UI", 10);
        lblOrderInfo.Location = new Point(0, 50);
        lblOrderInfo.Size = new Size(340, 40);
        
        // Statut
        var lblStatus = new Label();
        lblStatus.Text = "Nouveau statut:*";
        lblStatus.Font = new Font("Segoe UI", 10);
        lblStatus.Location = new Point(0, 100);
        lblStatus.Size = new Size(120, 25);
        
        cmbStatus = new ComboBox();
        cmbStatus.Items.AddRange(new object[] { "en cours", "terminee", "annulee" });
        cmbStatus.Font = new Font("Segoe UI", 10);
        cmbStatus.Location = new Point(130, 100);
        cmbStatus.Size = new Size(150, 25);
        
        // Boutons
        var panelButtons = new Panel();
        panelButtons.Dock = DockStyle.Bottom;
        panelButtons.Height = 60;
        panelButtons.Padding = new Padding(20, 10, 20, 10);
        
        btnSave = new Button();
        btnSave.Text = "Enregistrer";
        btnSave.BackColor = Color.FromArgb(0, 123, 255);
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
        panel.Controls.Add(lblOrderInfo);
        panel.Controls.Add(lblStatus);
        panel.Controls.Add(cmbStatus);
        
        this.Controls.Add(panel);
        this.Controls.Add(panelButtons);
    }

    #endregion
}