using System.ComponentModel;

namespace POS_RESTO.Forms;

partial class AboutForm
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
        lblInstitution = new System.Windows.Forms.Label();
        lblNames = new System.Windows.Forms.Label();
        lblDevelopers = new System.Windows.Forms.Label();
        listBox = new System.Windows.Forms.ListBox();
        lblFeaturesTitle = new System.Windows.Forms.Label();
        lblDescription = new System.Windows.Forms.Label();
        lblVersion = new System.Windows.Forms.Label();
        lblTitle = new System.Windows.Forms.Label();
        panel.SuspendLayout();
        SuspendLayout();
        // 
        // panel
        // 
        panel.BackColor = System.Drawing.Color.White;
        panel.Controls.Add(btnClose);
        panel.Controls.Add(lblInstitution);
        panel.Controls.Add(lblNames);
        panel.Controls.Add(lblDevelopers);
        panel.Controls.Add(listBox);
        panel.Controls.Add(lblFeaturesTitle);
        panel.Controls.Add(lblDescription);
        panel.Controls.Add(lblVersion);
        panel.Controls.Add(lblTitle);
        panel.Dock = System.Windows.Forms.DockStyle.Fill;
        panel.Location = new System.Drawing.Point(0, 0);
        panel.Name = "panel";
        panel.Padding = new System.Windows.Forms.Padding(20);
        panel.Size = new System.Drawing.Size(484, 492);
        panel.TabIndex = 0;
        // 
        // btnClose
        // 
        btnClose.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        btnClose.FlatAppearance.BorderSize = 0;
        btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btnClose.ForeColor = System.Drawing.Color.White;
        btnClose.Location = new System.Drawing.Point(204, 452);
        btnClose.Name = "btnClose";
        btnClose.Size = new System.Drawing.Size(100, 35);
        btnClose.TabIndex = 0;
        btnClose.Text = "Fermer";
        btnClose.UseVisualStyleBackColor = false;
        btnClose.Click += btnClose_Click;
        // 
        // lblInstitution
        // 
        lblInstitution.Dock = System.Windows.Forms.DockStyle.Top;
        lblInstitution.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblInstitution.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
        lblInstitution.Location = new System.Drawing.Point(20, 389);
        lblInstitution.Name = "lblInstitution";
        lblInstitution.Size = new System.Drawing.Size(444, 60);
        lblInstitution.TabIndex = 1;
        lblInstitution.Text = ("Universite d\'Etat d\'Haiti\nCampus Henry Christophe de Limonade\nDepartement: Scienc" + "es Informatiques");
        lblInstitution.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblNames
        // 
        lblNames.Dock = System.Windows.Forms.DockStyle.Top;
        lblNames.Font = new System.Drawing.Font("Segoe UI", 10F);
        lblNames.Location = new System.Drawing.Point(20, 329);
        lblNames.Name = "lblNames";
        lblNames.Size = new System.Drawing.Size(444, 60);
        lblNames.TabIndex = 2;
        lblNames.Text = "[Albikendy JEAN]\n[Bendy SERVILUS]\n[Blemy JOSEPH]";
        lblNames.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblDevelopers
        // 
        lblDevelopers.Dock = System.Windows.Forms.DockStyle.Top;
        lblDevelopers.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        lblDevelopers.Location = new System.Drawing.Point(20, 299);
        lblDevelopers.Name = "lblDevelopers";
        lblDevelopers.Size = new System.Drawing.Size(444, 30);
        lblDevelopers.TabIndex = 3;
        lblDevelopers.Text = "Developpe par:";
        lblDevelopers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // listBox
        // 
        listBox.BackColor = System.Drawing.Color.WhiteSmoke;
        listBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
        listBox.Dock = System.Windows.Forms.DockStyle.Top;
        listBox.Enabled = false;
        listBox.Font = new System.Drawing.Font("Segoe UI", 10F);
        listBox.Items.AddRange(new object[] { "Gestion des commandes", "Gestion des menus (plats, boissons, desserts)", "Suivi des clients et dettes", "Statistiques de vente en temps reel", "Paiements (Cash, Carte, Cheque)", "Dashboard analytique", "Gestion des stocks", "Rapports detailles" });
        listBox.Location = new System.Drawing.Point(20, 180);
        listBox.Name = "listBox";
        listBox.Size = new System.Drawing.Size(444, 119);
        listBox.TabIndex = 4;
        // 
        // lblFeaturesTitle
        // 
        lblFeaturesTitle.Dock = System.Windows.Forms.DockStyle.Top;
        lblFeaturesTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        lblFeaturesTitle.Location = new System.Drawing.Point(20, 150);
        lblFeaturesTitle.Name = "lblFeaturesTitle";
        lblFeaturesTitle.Size = new System.Drawing.Size(444, 30);
        lblFeaturesTitle.TabIndex = 5;
        lblFeaturesTitle.Text = "Fonctionnalites principales:";
        lblFeaturesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblDescription
        // 
        lblDescription.Dock = System.Windows.Forms.DockStyle.Top;
        lblDescription.Font = new System.Drawing.Font("Segoe UI", 11F);
        lblDescription.Location = new System.Drawing.Point(20, 110);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new System.Drawing.Size(444, 40);
        lblDescription.TabIndex = 6;
        lblDescription.Text = "Systeme de gestion de caisse pour restaurants et cafes";
        lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblVersion
        // 
        lblVersion.Dock = System.Windows.Forms.DockStyle.Top;
        lblVersion.Font = new System.Drawing.Font("Segoe UI", 10F);
        lblVersion.ForeColor = System.Drawing.Color.Gray;
        lblVersion.Location = new System.Drawing.Point(20, 80);
        lblVersion.Name = "lblVersion";
        lblVersion.Size = new System.Drawing.Size(444, 30);
        lblVersion.TabIndex = 7;
        lblVersion.Text = "Version 1.0.0";
        lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblTitle
        // 
        lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        lblTitle.Location = new System.Drawing.Point(20, 20);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new System.Drawing.Size(444, 60);
        lblTitle.TabIndex = 8;
        lblTitle.Text = "POS RESTO";
        lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // AboutForm
        // 
        ClientSize = new System.Drawing.Size(484, 492);
        Controls.Add(panel);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "A propos - POS RESTO";
        panel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Panel panel;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Label lblInstitution;
    private System.Windows.Forms.Label lblNames;
    private System.Windows.Forms.Label lblDevelopers;
    private System.Windows.Forms.ListBox listBox;
    private System.Windows.Forms.Label lblFeaturesTitle;
    private System.Windows.Forms.Label lblDescription;
    private System.Windows.Forms.Label lblVersion;
    private System.Windows.Forms.Label lblTitle;

    #endregion
}