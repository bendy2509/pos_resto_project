using System.ComponentModel;

namespace POS_RESTO.Forms;

partial class ClientForm
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
        lblLastName = new System.Windows.Forms.Label();
        txtLastName = new System.Windows.Forms.TextBox();
        lblFirstName = new System.Windows.Forms.Label();
        txtFirstName = new System.Windows.Forms.TextBox();
        lblGender = new System.Windows.Forms.Label();
        cmbGender = new System.Windows.Forms.ComboBox();
        lblPhone = new System.Windows.Forms.Label();
        txtPhone = new System.Windows.Forms.TextBox();
        lblEmail = new System.Windows.Forms.Label();
        txtEmail = new System.Windows.Forms.TextBox();
        lblDebt = new System.Windows.Forms.Label();
        numDebt = new System.Windows.Forms.NumericUpDown();
        panelButtons = new System.Windows.Forms.Panel();
        btnSave = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        panel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numDebt).BeginInit();
        panelButtons.SuspendLayout();
        SuspendLayout();
        // 
        // panel
        // 
        panel.Controls.Add(lblTitle);
        panel.Controls.Add(lblLastName);
        panel.Controls.Add(txtLastName);
        panel.Controls.Add(lblFirstName);
        panel.Controls.Add(txtFirstName);
        panel.Controls.Add(lblGender);
        panel.Controls.Add(cmbGender);
        panel.Controls.Add(lblPhone);
        panel.Controls.Add(txtPhone);
        panel.Controls.Add(lblEmail);
        panel.Controls.Add(txtEmail);
        panel.Controls.Add(lblDebt);
        panel.Controls.Add(numDebt);
        panel.Dock = System.Windows.Forms.DockStyle.Fill;
        panel.Location = new System.Drawing.Point(0, 0);
        panel.Name = "panel";
        panel.Padding = new System.Windows.Forms.Padding(20);
        panel.Size = new System.Drawing.Size(484, 351);
        panel.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        lblTitle.Location = new System.Drawing.Point(0, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new System.Drawing.Size(484, 30);
        lblTitle.TabIndex = 0;
        lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblLastName
        // 
        lblLastName.Font = new System.Drawing.Font("Segoe UI", 10F);
        lblLastName.Location = new System.Drawing.Point(12, 50);
        lblLastName.Name = "lblLastName";
        lblLastName.Size = new System.Drawing.Size(88, 25);
        lblLastName.TabIndex = 1;
        lblLastName.Text = "Nom:*";
        // 
        // txtLastName
        // 
        txtLastName.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtLastName.Location = new System.Drawing.Point(120, 50);
        txtLastName.Name = "txtLastName";
        txtLastName.Size = new System.Drawing.Size(300, 25);
        txtLastName.TabIndex = 2;
        // 
        // lblFirstName
        // 
        lblFirstName.Font = new System.Drawing.Font("Segoe UI", 10F);
        lblFirstName.Location = new System.Drawing.Point(12, 90);
        lblFirstName.Name = "lblFirstName";
        lblFirstName.Size = new System.Drawing.Size(88, 25);
        lblFirstName.TabIndex = 3;
        lblFirstName.Text = "Prénom:*";
        // 
        // txtFirstName
        // 
        txtFirstName.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtFirstName.Location = new System.Drawing.Point(120, 90);
        txtFirstName.Name = "txtFirstName";
        txtFirstName.Size = new System.Drawing.Size(300, 25);
        txtFirstName.TabIndex = 4;
        // 
        // lblGender
        // 
        lblGender.Font = new System.Drawing.Font("Segoe UI", 10F);
        lblGender.Location = new System.Drawing.Point(12, 130);
        lblGender.Name = "lblGender";
        lblGender.Size = new System.Drawing.Size(88, 25);
        lblGender.TabIndex = 5;
        lblGender.Text = "Genre:";
        // 
        // cmbGender
        // 
        cmbGender.Font = new System.Drawing.Font("Segoe UI", 10F);
        cmbGender.Items.AddRange(new object[] { "M", "F" });
        cmbGender.Location = new System.Drawing.Point(120, 130);
        cmbGender.Name = "cmbGender";
        cmbGender.Size = new System.Drawing.Size(100, 25);
        cmbGender.TabIndex = 6;
        // 
        // lblPhone
        // 
        lblPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
        lblPhone.Location = new System.Drawing.Point(12, 170);
        lblPhone.Name = "lblPhone";
        lblPhone.Size = new System.Drawing.Size(88, 25);
        lblPhone.TabIndex = 7;
        lblPhone.Text = "Téléphone:";
        // 
        // txtPhone
        // 
        txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtPhone.Location = new System.Drawing.Point(120, 170);
        txtPhone.Name = "txtPhone";
        txtPhone.Size = new System.Drawing.Size(200, 25);
        txtPhone.TabIndex = 8;
        // 
        // lblEmail
        // 
        lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
        lblEmail.Location = new System.Drawing.Point(12, 210);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new System.Drawing.Size(88, 25);
        lblEmail.TabIndex = 9;
        lblEmail.Text = "Email:";
        // 
        // txtEmail
        // 
        txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtEmail.Location = new System.Drawing.Point(120, 210);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new System.Drawing.Size(300, 25);
        txtEmail.TabIndex = 10;
        // 
        // lblDebt
        // 
        lblDebt.Font = new System.Drawing.Font("Segoe UI", 10F);
        lblDebt.Location = new System.Drawing.Point(12, 250);
        lblDebt.Name = "lblDebt";
        lblDebt.Size = new System.Drawing.Size(88, 25);
        lblDebt.TabIndex = 11;
        lblDebt.Text = "Dette (HTG):";
        // 
        // numDebt
        // 
        numDebt.DecimalPlaces = 2;
        numDebt.Font = new System.Drawing.Font("Segoe UI", 10F);
        numDebt.Location = new System.Drawing.Point(120, 250);
        numDebt.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
        numDebt.Name = "numDebt";
        numDebt.Size = new System.Drawing.Size(150, 25);
        numDebt.TabIndex = 12;
        // 
        // panelButtons
        // 
        panelButtons.Controls.Add(btnSave);
        panelButtons.Controls.Add(btnCancel);
        panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelButtons.Location = new System.Drawing.Point(0, 351);
        panelButtons.Name = "panelButtons";
        panelButtons.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
        panelButtons.Size = new System.Drawing.Size(484, 60);
        panelButtons.TabIndex = 1;
        // 
        // btnSave
        // 
        btnSave.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btnSave.ForeColor = System.Drawing.Color.White;
        btnSave.Location = new System.Drawing.Point(200, 10);
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
        btnCancel.Location = new System.Drawing.Point(330, 10);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new System.Drawing.Size(120, 35);
        btnCancel.TabIndex = 1;
        btnCancel.Text = "Annuler";
        btnCancel.UseVisualStyleBackColor = false;
        // 
        // ClientForm
        // 
        ClientSize = new System.Drawing.Size(484, 411);
        Controls.Add(panel);
        Controls.Add(panelButtons);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        panel.ResumeLayout(false);
        panel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numDebt).EndInit();
        panelButtons.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Panel panel;
    private System.Windows.Forms.Panel panelButtons;
    private System.Windows.Forms.Label lblFirstName;
    private System.Windows.Forms.Label lblGender;
    private System.Windows.Forms.Label lblPhone;
    private System.Windows.Forms.Label lblEmail;
    private System.Windows.Forms.Label lblDebt;
    private System.Windows.Forms.Label lblLastName;
    private System.Windows.Forms.Label lblTitle;
    private int? clientId;
    private TextBox txtLastName;
    private TextBox txtFirstName;
    private ComboBox cmbGender;
    private TextBox txtPhone;
    private TextBox txtEmail;
    private NumericUpDown numDebt;
    private Button btnSave;
    private Button btnCancel;
    

    #endregion
}