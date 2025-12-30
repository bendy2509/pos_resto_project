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
        panel = new System.Windows.Forms.Panel();
        lblTitle = new System.Windows.Forms.Label();
        lblOrderInfo = new System.Windows.Forms.Label();
        lblStatus = new System.Windows.Forms.Label();
        cmbStatus = new System.Windows.Forms.ComboBox();
        panelButtons = new System.Windows.Forms.Panel();
        btnSave = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        panel.SuspendLayout();
        panelButtons.SuspendLayout();
        SuspendLayout();
        // 
        // panel
        // 
        panel.Controls.Add(lblTitle);
        panel.Controls.Add(lblOrderInfo);
        panel.Controls.Add(lblStatus);
        panel.Controls.Add(cmbStatus);
        panel.Dock = System.Windows.Forms.DockStyle.Fill;
        panel.Location = new System.Drawing.Point(0, 0);
        panel.Name = "panel";
        panel.Padding = new System.Windows.Forms.Padding(20);
        panel.Size = new System.Drawing.Size(471, 246);
        panel.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        lblTitle.Location = new System.Drawing.Point(20, 20);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new System.Drawing.Size(431, 38);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "MODIFIER LE STATUT";
        lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblOrderInfo
        // 
        lblOrderInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
        lblOrderInfo.Location = new System.Drawing.Point(10, 68);
        lblOrderInfo.Name = "lblOrderInfo";
        lblOrderInfo.Size = new System.Drawing.Size(340, 53);
        lblOrderInfo.TabIndex = 1;
        // 
        // lblStatus
        // 
        lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
        lblStatus.Location = new System.Drawing.Point(4, 138);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new System.Drawing.Size(120, 25);
        lblStatus.TabIndex = 2;
        lblStatus.Text = "Nouveau statut:*";
        // 
        // cmbStatus
        // 
        cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
        cmbStatus.Items.AddRange(new object[] { "en cours", "terminee", "annulee" });
        cmbStatus.Location = new System.Drawing.Point(134, 138);
        cmbStatus.Name = "cmbStatus";
        cmbStatus.Size = new System.Drawing.Size(150, 25);
        cmbStatus.TabIndex = 3;
        // 
        // panelButtons
        // 
        panelButtons.Controls.Add(btnSave);
        panelButtons.Controls.Add(btnCancel);
        panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelButtons.Location = new System.Drawing.Point(0, 246);
        panelButtons.Name = "panelButtons";
        panelButtons.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
        panelButtons.Size = new System.Drawing.Size(471, 60);
        panelButtons.TabIndex = 1;
        // 
        // btnSave
        // 
        btnSave.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btnSave.ForeColor = System.Drawing.Color.White;
        btnSave.Location = new System.Drawing.Point(100, 10);
        btnSave.Name = "btnSave";
        btnSave.Size = new System.Drawing.Size(120, 35);
        btnSave.TabIndex = 0;
        btnSave.Text = "Enregistrer";
        btnSave.UseVisualStyleBackColor = false;
        btnSave.Click += BtnSave_Click;
        // 
        // btnCancel
        // 
        btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)((byte)108)), ((int)((byte)117)), ((int)((byte)125)));
        btnCancel.FlatAppearance.BorderSize = 0;
        btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
        btnCancel.ForeColor = System.Drawing.Color.White;
        btnCancel.Location = new System.Drawing.Point(230, 10);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new System.Drawing.Size(120, 35);
        btnCancel.TabIndex = 1;
        btnCancel.Text = "Annuler";
        btnCancel.UseVisualStyleBackColor = false;
        btnCancel.Click += BtnCancel_Click;
        // 
        // OrderStatusForm
        // 
        ClientSize = new System.Drawing.Size(471, 306);
        Controls.Add(panel);
        Controls.Add(panelButtons);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Changer le statut de la commande";
        panel.ResumeLayout(false);
        panelButtons.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label lblStatus;

    private System.Windows.Forms.Panel panelButtons;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Panel panel;

    #endregion
}