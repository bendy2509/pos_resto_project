using System.ComponentModel;

namespace POS_RESTO.Forms;

partial class OrderDetailsForm
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
        this.Text = "Détails de la commande";
        this.Size = new Size(600, 400);
        this.StartPosition = FormStartPosition.CenterScreen;
        
        var panel = new Panel();
        panel.Dock = DockStyle.Fill;
        panel.Padding = new Padding(20);
        
        // Titre
        var lblTitle = new Label();
        lblTitle.Name = "lblTitle";
        lblTitle.Text = "COMMANDE";
        lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(0, 123, 255);
        lblTitle.Dock = DockStyle.Top;
        lblTitle.Height = 40;
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        
        // Info commande
        lblOrderInfo = new Label();
        lblOrderInfo.Name = "lblOrderInfo";
        lblOrderInfo.Font = new Font("Segoe UI", 10);
        lblOrderInfo.Dock = DockStyle.Top;
        lblOrderInfo.Height = 30;
        
        // DataGridView pour les détails
        dgvDetails = new DataGridView();
        dgvDetails.Name = "dgvDetails";
        dgvDetails.Dock = DockStyle.Fill;
        dgvDetails.BackgroundColor = Color.White;
        dgvDetails.ReadOnly = true;
        dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvDetails.RowHeadersVisible = false;
        dgvDetails.AllowUserToAddRows = false;
        
        // Total
        lblTotal = new Label();
        lblTotal.Name = "lblTotal";
        lblTotal.Font = new Font("Segoe UI", 12, FontStyle.Bold);
        lblTotal.Dock = DockStyle.Bottom;
        lblTotal.Height = 40;
        lblTotal.TextAlign = ContentAlignment.MiddleRight;
        lblTotal.Padding = new Padding(0, 0, 20, 0);
        
        // Bouton fermer
        var btnClose = new Button();
        btnClose.Text = "Fermer";
        btnClose.BackColor = Color.FromArgb(108, 117, 125);
        btnClose.ForeColor = Color.White;
        btnClose.FlatStyle = FlatStyle.Flat;
        btnClose.FlatAppearance.BorderSize = 0;
        btnClose.Font = new Font("Segoe UI", 10);
        btnClose.Size = new Size(100, 35);
        btnClose.Location = new Point(460, 310);
        btnClose.Click += BtnClose_Click;
        
        panel.Controls.Add(btnClose);
        panel.Controls.Add(dgvDetails);
        panel.Controls.Add(lblOrderInfo);
        panel.Controls.Add(lblTitle);
        panel.Controls.Add(lblTotal);
        
        this.Controls.Add(panel);
    }

    #endregion
    
    
    private int orderId;
}