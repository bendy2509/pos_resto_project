using System.ComponentModel;
using Timer = System.Windows.Forms.Timer;

namespace POS_RESTO.Forms;

partial class MainForm
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
        menuStrip1 = new System.Windows.Forms.MenuStrip();
        fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        aproposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        statusStrip1 = new System.Windows.Forms.StatusStrip();
        lblStatusUser = new System.Windows.Forms.ToolStripStatusLabel();
        lblStatusTime = new System.Windows.Forms.ToolStripStatusLabel();
        lblStatusInfo = new System.Windows.Forms.ToolStripStatusLabel();
        splitContainer1 = new System.Windows.Forms.SplitContainer();
        panelSidebar = new System.Windows.Forms.Panel();
        btnDashboard = new System.Windows.Forms.Button();
        btnOrders = new System.Windows.Forms.Button();
        btnMenus = new System.Windows.Forms.Button();
        btnClients = new System.Windows.Forms.Button();
        btnPayments = new System.Windows.Forms.Button();
        btnReports = new System.Windows.Forms.Button();
        panelContent = new System.Windows.Forms.Panel();
        menuStrip1.SuspendLayout();
        statusStrip1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        panelSidebar.SuspendLayout();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fichierToolStripMenuItem, aideToolStripMenuItem });
        menuStrip1.Location = new System.Drawing.Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new System.Drawing.Size(1200, 24);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "menuStrip1";
        // 
        // fichierToolStripMenuItem
        // 
        fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { logoutToolStripMenuItem, quitterToolStripMenuItem });
        fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
        fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
        fichierToolStripMenuItem.Text = "Fichier";
        // 
        // logoutToolStripMenuItem
        // 
        logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
        logoutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        logoutToolStripMenuItem.Text = "Deconnexion";
        // 
        // quitterToolStripMenuItem
        // 
        quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
        quitterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        quitterToolStripMenuItem.Text = "Quitter";
        // 
        // aideToolStripMenuItem
        // 
        aideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { aproposToolStripMenuItem });
        aideToolStripMenuItem.Name = "aideToolStripMenuItem";
        aideToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
        aideToolStripMenuItem.Text = "Aide";
        // 
        // aproposToolStripMenuItem
        // 
        aproposToolStripMenuItem.Name = "aproposToolStripMenuItem";
        aproposToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        aproposToolStripMenuItem.Text = "A propos";
        // 
        // statusStrip1
        // 
        statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { lblStatusUser, lblStatusTime, lblStatusInfo });
        statusStrip1.Location = new System.Drawing.Point(0, 678);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Size = new System.Drawing.Size(1200, 22);
        statusStrip1.TabIndex = 1;
        statusStrip1.Text = "statusStrip1";
        // 
        // lblStatusUser
        // 
        lblStatusUser.Name = "lblStatusUser";
        lblStatusUser.Size = new System.Drawing.Size(102, 17);
        lblStatusUser.Text = "Utilisateur: Admin";
        // 
        // lblStatusTime
        // 
        lblStatusTime.Name = "lblStatusTime";
        lblStatusTime.Size = new System.Drawing.Size(34, 17);
        lblStatusTime.Text = "14:30";
        // 
        // lblStatusInfo
        // 
        lblStatusInfo.Name = "lblStatusInfo";
        lblStatusInfo.Size = new System.Drawing.Size(28, 17);
        lblStatusInfo.Text = "Pret";
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer1.Location = new System.Drawing.Point(0, 24);
        splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)((byte)248)), ((int)((byte)249)), ((int)((byte)250)));
        splitContainer1.Panel1.Controls.Add(panelSidebar);
        splitContainer1.Panel1MinSize = 200;
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(panelContent);
        splitContainer1.Size = new System.Drawing.Size(1200, 654);
        splitContainer1.SplitterDistance = 202;
        splitContainer1.TabIndex = 2;
        // 
        // panelSidebar
        // 
        panelSidebar.Controls.Add(btnDashboard);
        panelSidebar.Controls.Add(btnOrders);
        panelSidebar.Controls.Add(btnMenus);
        panelSidebar.Controls.Add(btnClients);
        panelSidebar.Controls.Add(btnPayments);
        panelSidebar.Controls.Add(btnReports);
        panelSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
        panelSidebar.Location = new System.Drawing.Point(0, 0);
        panelSidebar.Name = "panelSidebar";
        panelSidebar.Size = new System.Drawing.Size(202, 654);
        panelSidebar.TabIndex = 0;
        // 
        // btnDashboard
        // 
        btnDashboard.FlatAppearance.BorderSize = 0;
        btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnDashboard.Font = new System.Drawing.Font("Segoe UI", 11F);
        btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        btnDashboard.Location = new System.Drawing.Point(3, 21);
        btnDashboard.Name = "btnDashboard";
        btnDashboard.Size = new System.Drawing.Size(197, 45);
        btnDashboard.TabIndex = 0;
        btnDashboard.Text = "Tableau de bord";
        btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
        btnDashboard.UseVisualStyleBackColor = true;
        // 
        // btnOrders
        // 
        btnOrders.FlatAppearance.BorderSize = 0;
        btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnOrders.Font = new System.Drawing.Font("Segoe UI", 11F);
        btnOrders.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        btnOrders.Location = new System.Drawing.Point(3, 71);
        btnOrders.Name = "btnOrders";
        btnOrders.Size = new System.Drawing.Size(197, 45);
        btnOrders.TabIndex = 1;
        btnOrders.Text = "Commandes";
        btnOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        btnOrders.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
        btnOrders.UseVisualStyleBackColor = true;
        // 
        // btnMenus
        // 
        btnMenus.FlatAppearance.BorderSize = 0;
        btnMenus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnMenus.Font = new System.Drawing.Font("Segoe UI", 11F);
        btnMenus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        btnMenus.Location = new System.Drawing.Point(3, 121);
        btnMenus.Name = "btnMenus";
        btnMenus.Size = new System.Drawing.Size(197, 45);
        btnMenus.TabIndex = 2;
        btnMenus.Text = "Menus";
        btnMenus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        btnMenus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
        btnMenus.UseVisualStyleBackColor = true;
        // 
        // btnClients
        // 
        btnClients.FlatAppearance.BorderSize = 0;
        btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnClients.Font = new System.Drawing.Font("Segoe UI", 11F);
        btnClients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        btnClients.Location = new System.Drawing.Point(3, 171);
        btnClients.Name = "btnClients";
        btnClients.Size = new System.Drawing.Size(197, 45);
        btnClients.TabIndex = 3;
        btnClients.Text = "Clients";
        btnClients.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        btnClients.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
        btnClients.UseVisualStyleBackColor = true;
        // 
        // btnPayments
        // 
        btnPayments.FlatAppearance.BorderSize = 0;
        btnPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnPayments.Font = new System.Drawing.Font("Segoe UI", 11F);
        btnPayments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        btnPayments.Location = new System.Drawing.Point(3, 221);
        btnPayments.Name = "btnPayments";
        btnPayments.Size = new System.Drawing.Size(197, 45);
        btnPayments.TabIndex = 4;
        btnPayments.Text = "Paiements";
        btnPayments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        btnPayments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
        btnPayments.UseVisualStyleBackColor = true;
        // 
        // btnReports
        // 
        btnReports.FlatAppearance.BorderSize = 0;
        btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnReports.Font = new System.Drawing.Font("Segoe UI", 11F);
        btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        btnReports.Location = new System.Drawing.Point(3, 271);
        btnReports.Name = "btnReports";
        btnReports.Size = new System.Drawing.Size(197, 45);
        btnReports.TabIndex = 5;
        btnReports.Text = "Rapports";
        btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        btnReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
        btnReports.UseVisualStyleBackColor = true;
        // 
        // panelContent
        // 
        panelContent.BackColor = System.Drawing.Color.White;
        panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
        panelContent.Location = new System.Drawing.Point(0, 0);
        panelContent.Name = "panelContent";
        panelContent.Size = new System.Drawing.Size(994, 654);
        panelContent.TabIndex = 0;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1200, 700);
        Controls.Add(splitContainer1);
        Controls.Add(statusStrip1);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        MinimumSize = new System.Drawing.Size(1216, 718);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "POS RESTO - Systeme de gestion";
        WindowState = System.Windows.Forms.FormWindowState.Maximized;
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        panelSidebar.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aproposToolStripMenuItem;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel lblStatusUser;
    private System.Windows.Forms.ToolStripStatusLabel lblStatusTime;
    private System.Windows.Forms.ToolStripStatusLabel lblStatusInfo;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.Panel panelSidebar;
    private System.Windows.Forms.Button btnDashboard;
    private System.Windows.Forms.Button btnOrders;
    private System.Windows.Forms.Button btnMenus;
    private System.Windows.Forms.Button btnClients;
    private System.Windows.Forms.Button btnPayments;
    private System.Windows.Forms.Button btnReports;
    private System.Windows.Forms.Panel panelContent;
    private Timer timer1;
    private UserControl currentView;
    private Button currentButton;
}