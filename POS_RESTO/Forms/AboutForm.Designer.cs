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
        panelMain = new System.Windows.Forms.Panel();
        btnClose = new System.Windows.Forms.Button();
        lblInstitution = new System.Windows.Forms.Label();
        lblCredits = new System.Windows.Forms.Label();
        listBoxFeatures = new System.Windows.Forms.ListBox();
        lblFeaturesTitle = new System.Windows.Forms.Label();
        lblDescription = new System.Windows.Forms.Label();
        lblVersion = new System.Windows.Forms.Label();
        lblTitle = new System.Windows.Forms.Label();
        panelMain.SuspendLayout();
        SuspendLayout();
        // 
        // panelMain
        // 
        panelMain.BackColor = System.Drawing.Color.White;
        panelMain.Controls.Add(btnClose);
        panelMain.Controls.Add(lblInstitution);
        panelMain.Controls.Add(lblCredits);
        panelMain.Controls.Add(listBoxFeatures);
        panelMain.Controls.Add(lblFeaturesTitle);
        panelMain.Controls.Add(lblDescription);
        panelMain.Controls.Add(lblVersion);
        panelMain.Controls.Add(lblTitle);
        panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        panelMain.Location = new System.Drawing.Point(0, 0);
        panelMain.Name = "panelMain";
        panelMain.Size = new System.Drawing.Size(500, 600);
        panelMain.TabIndex = 0;
        // 
        // btnClose
        // 
        btnClose.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
        btnClose.ForeColor = System.Drawing.Color.White;
        btnClose.Location = new System.Drawing.Point(192, 539);
        btnClose.Name = "btnClose";
        btnClose.Size = new System.Drawing.Size(100, 35);
        btnClose.TabIndex = 8;
        btnClose.Text = "Fermer";
        btnClose.UseVisualStyleBackColor = false;
        btnClose.Click += btnCloseAbout;
        // 
        // lblInstitution
        // 
        lblInstitution.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblInstitution.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
        lblInstitution.Location = new System.Drawing.Point(50, 496);
        lblInstitution.Name = "lblInstitution";
        lblInstitution.Size = new System.Drawing.Size(400, 40);
        lblInstitution.TabIndex = 7;
        lblInstitution.Text = ("Université d\'État d\'Haïti\nCampus Henry Christophe de Limonade - Dépt. Sciences In" + "formatiques");
        lblInstitution.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblCredits
        // 
        lblCredits.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
        lblCredits.Location = new System.Drawing.Point(50, 105);
        lblCredits.Name = "lblCredits";
        lblCredits.Size = new System.Drawing.Size(400, 106);
        lblCredits.TabIndex = 6;
        lblCredits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // listBoxFeatures
        // 
        listBoxFeatures.BackColor = System.Drawing.Color.WhiteSmoke;
        listBoxFeatures.BorderStyle = System.Windows.Forms.BorderStyle.None;
        listBoxFeatures.Font = new System.Drawing.Font("Segoe UI", 10F);
        listBoxFeatures.FormattingEnabled = true;
        listBoxFeatures.Items.AddRange(new object[] { "Gestion des commandes", "Gestion des menus (plats, boissons, desserts)", "Suivi des clients et dettes", "Statistiques de vente en temps réel", "Paiements (Cash, Carte, Chèque)", "Dashboard analytique", "Gestion des stocks", "Rapports détaillés" });
        listBoxFeatures.Location = new System.Drawing.Point(50, 343);
        listBoxFeatures.Name = "listBoxFeatures";
        listBoxFeatures.SelectionMode = System.Windows.Forms.SelectionMode.None;
        listBoxFeatures.Size = new System.Drawing.Size(400, 136);
        listBoxFeatures.TabIndex = 5;
        // 
        // lblFeaturesTitle
        // 
        lblFeaturesTitle.AutoSize = true;
        lblFeaturesTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        lblFeaturesTitle.Location = new System.Drawing.Point(50, 302);
        lblFeaturesTitle.Name = "lblFeaturesTitle";
        lblFeaturesTitle.Size = new System.Drawing.Size(124, 20);
        lblFeaturesTitle.TabIndex = 4;
        lblFeaturesTitle.Text = "Fonctionnalités :";
        // 
        // lblDescription
        // 
        lblDescription.Font = new System.Drawing.Font("Segoe UI", 11F);
        lblDescription.Location = new System.Drawing.Point(50, 211);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new System.Drawing.Size(400, 60);
        lblDescription.TabIndex = 3;
        lblDescription.Text = "Système de gestion de caisse pour restaurants et cafés";
        lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblVersion
        // 
        lblVersion.Font = new System.Drawing.Font("Segoe UI", 10F);
        lblVersion.ForeColor = System.Drawing.Color.Gray;
        lblVersion.Location = new System.Drawing.Point(0, 59);
        lblVersion.Name = "lblVersion";
        lblVersion.Size = new System.Drawing.Size(500, 25);
        lblVersion.TabIndex = 2;
        lblVersion.Text = "Version 1.0.0";
        lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblTitle
        // 
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        lblTitle.Location = new System.Drawing.Point(0, 9);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new System.Drawing.Size(500, 50);
        lblTitle.TabIndex = 1;
        lblTitle.Text = "POS RESTO";
        lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // AboutForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(500, 600);
        Controls.Add(panelMain);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "À propos - POS RESTO";
        panelMain.ResumeLayout(false);
        panelMain.PerformLayout();
        ResumeLayout(false);
    }

// Ajouter ces déclarations
private System.Windows.Forms.Panel panelMain;
private System.Windows.Forms.Label lblTitle;
private System.Windows.Forms.Label lblVersion;
private System.Windows.Forms.Label lblDescription;
private System.Windows.Forms.Label lblFeaturesTitle;
private System.Windows.Forms.ListBox listBoxFeatures;
private System.Windows.Forms.Label lblCredits;
private System.Windows.Forms.Label lblInstitution;
private System.Windows.Forms.Button btnClose;

    #endregion
}