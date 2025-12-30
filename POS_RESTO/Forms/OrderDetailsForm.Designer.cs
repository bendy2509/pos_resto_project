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
        panel = new System.Windows.Forms.Panel();
        btnClose = new System.Windows.Forms.Button();
        dgvDetails = new System.Windows.Forms.DataGridView();
        lblOrderInfo = new System.Windows.Forms.Label();
        lblTitle = new System.Windows.Forms.Label();
        lblTotal = new System.Windows.Forms.Label();
        panel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
        SuspendLayout();
        // 
        // panel
        // 
        panel.Controls.Add(btnClose);
        panel.Controls.Add(dgvDetails);
        panel.Controls.Add(lblOrderInfo);
        panel.Controls.Add(lblTitle);
        panel.Controls.Add(lblTotal);
        panel.Dock = System.Windows.Forms.DockStyle.Fill;
        panel.Location = new System.Drawing.Point(0, 0);
        panel.Name = "panel";
        panel.Padding = new System.Windows.Forms.Padding(20);
        panel.Size = new System.Drawing.Size(584, 361);
        panel.TabIndex = 0;
        // 
        // btnClose
        // 
        btnClose.BackColor = System.Drawing.Color.FromArgb(((int)((byte)108)), ((int)((byte)117)), ((int)((byte)125)));
        btnClose.FlatAppearance.BorderSize = 0;
        btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
        btnClose.ForeColor = System.Drawing.Color.White;
        btnClose.Location = new System.Drawing.Point(460, 310);
        btnClose.Name = "btnClose";
        btnClose.Size = new System.Drawing.Size(100, 35);
        btnClose.TabIndex = 0;
        btnClose.Text = "Fermer";
        btnClose.UseVisualStyleBackColor = false;
        btnClose.Click += BtnClose_Click;
        // 
        // dgvDetails
        // 
        dgvDetails.AllowUserToAddRows = false;
        dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        dgvDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvDetails.BackgroundColor = System.Drawing.Color.White;
        dgvDetails.Location = new System.Drawing.Point(12, 101);
        dgvDetails.Name = "dgvDetails";
        dgvDetails.ReadOnly = true;
        dgvDetails.RowHeadersVisible = false;
        dgvDetails.Size = new System.Drawing.Size(549, 203);
        dgvDetails.TabIndex = 1;
        // 
        // lblOrderInfo
        // 
        lblOrderInfo.Dock = System.Windows.Forms.DockStyle.Top;
        lblOrderInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
        lblOrderInfo.Location = new System.Drawing.Point(20, 60);
        lblOrderInfo.Name = "lblOrderInfo";
        lblOrderInfo.Size = new System.Drawing.Size(544, 30);
        lblOrderInfo.TabIndex = 2;
        // 
        // lblTitle
        // 
        lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        lblTitle.Location = new System.Drawing.Point(20, 20);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new System.Drawing.Size(544, 40);
        lblTitle.TabIndex = 3;
        lblTitle.Text = "COMMANDE";
        lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblTotal
        // 
        lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        lblTotal.Location = new System.Drawing.Point(23, 310);
        lblTotal.Name = "lblTotal";
        lblTotal.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
        lblTotal.Size = new System.Drawing.Size(419, 35);
        lblTotal.TabIndex = 4;
        lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // OrderDetailsForm
        // 
        ClientSize = new System.Drawing.Size(584, 361);
        Controls.Add(panel);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Détails de la commande";
        panel.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label lblTitle;

    #endregion
    
    
    private int orderId;
    private System.Windows.Forms.Panel panel;
    private System.Windows.Forms.Button btnClose;
}