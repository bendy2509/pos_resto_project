using System.ComponentModel;

namespace POS_RESTO.Forms;

partial class DashboardForm
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
        gestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        commandesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        menusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        clientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        paiementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        rapportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        ventesJournalièresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        topVentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        àProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        statusStrip1 = new System.Windows.Forms.StatusStrip();
        lblStatusUser = new System.Windows.Forms.ToolStripStatusLabel();
        lblStatusTime = new System.Windows.Forms.ToolStripStatusLabel();
        lblStatusInfo = new System.Windows.Forms.ToolStripStatusLabel();
        panelHeader = new System.Windows.Forms.Panel();
        lblDashboardTitle = new System.Windows.Forms.Label();
        lblDate = new System.Windows.Forms.Label();
        flowPanelStats = new System.Windows.Forms.FlowLayoutPanel();
        panelOrders = new System.Windows.Forms.Panel();
        lblOrdersTitle = new System.Windows.Forms.Label();
        lblOrdersCount = new System.Windows.Forms.Label();
        lblOrdersSub = new System.Windows.Forms.Label();
        panelRevenue = new System.Windows.Forms.Panel();
        lblRevenueTitle = new System.Windows.Forms.Label();
        lblRevenueValue = new System.Windows.Forms.Label();
        lblRevenueSub = new System.Windows.Forms.Label();
        panelMenus = new System.Windows.Forms.Panel();
        lblMenusTitle = new System.Windows.Forms.Label();
        lblMenusCount = new System.Windows.Forms.Label();
        lblMenusSub = new System.Windows.Forms.Label();
        panelClients = new System.Windows.Forms.Panel();
        lblClientsTitle = new System.Windows.Forms.Label();
        lblClientsCount = new System.Windows.Forms.Label();
        lblClientsSub = new System.Windows.Forms.Label();
        panelChart = new System.Windows.Forms.Panel();
        labelChartTitle = new System.Windows.Forms.Label();
        dataGridViewRecent = new System.Windows.Forms.DataGridView();
        toolStrip1 = new System.Windows.Forms.ToolStrip();
        menuStrip1.SuspendLayout();
        statusStrip1.SuspendLayout();
        panelHeader.SuspendLayout();
        flowPanelStats.SuspendLayout();
        panelOrders.SuspendLayout();
        panelRevenue.SuspendLayout();
        panelMenus.SuspendLayout();
        panelClients.SuspendLayout();
        panelChart.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridViewRecent).BeginInit();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fichierToolStripMenuItem, gestionToolStripMenuItem, rapportsToolStripMenuItem, aideToolStripMenuItem });
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
        logoutToolStripMenuItem.Text = "Déconnexion";
        logoutToolStripMenuItem.Click += logout_click;
        // 
        // quitterToolStripMenuItem
        // 
        quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
        quitterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        quitterToolStripMenuItem.Text = "Quitter";
        // 
        // gestionToolStripMenuItem
        // 
        gestionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { commandesToolStripMenuItem, menusToolStripMenuItem, clientsToolStripMenuItem, paiementsToolStripMenuItem });
        gestionToolStripMenuItem.Name = "gestionToolStripMenuItem";
        gestionToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
        gestionToolStripMenuItem.Text = "Gestion";
        // 
        // commandesToolStripMenuItem
        // 
        commandesToolStripMenuItem.Name = "commandesToolStripMenuItem";
        commandesToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
        commandesToolStripMenuItem.Text = "Commandes";
        // 
        // menusToolStripMenuItem
        // 
        menusToolStripMenuItem.Name = "menusToolStripMenuItem";
        menusToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
        menusToolStripMenuItem.Text = "Menus";
        // 
        // clientsToolStripMenuItem
        // 
        clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
        clientsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
        clientsToolStripMenuItem.Text = "Clients";
        // 
        // paiementsToolStripMenuItem
        // 
        paiementsToolStripMenuItem.Name = "paiementsToolStripMenuItem";
        paiementsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
        paiementsToolStripMenuItem.Text = "Paiements";
        // 
        // rapportsToolStripMenuItem
        // 
        rapportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { ventesJournalièresToolStripMenuItem, topVentesToolStripMenuItem });
        rapportsToolStripMenuItem.Name = "rapportsToolStripMenuItem";
        rapportsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
        rapportsToolStripMenuItem.Text = "Rapports";
        // 
        // ventesJournalièresToolStripMenuItem
        // 
        ventesJournalièresToolStripMenuItem.Name = "ventesJournalièresToolStripMenuItem";
        ventesJournalièresToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
        ventesJournalièresToolStripMenuItem.Text = "Ventes journalières";
        // 
        // topVentesToolStripMenuItem
        // 
        topVentesToolStripMenuItem.Name = "topVentesToolStripMenuItem";
        topVentesToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
        topVentesToolStripMenuItem.Text = "Top ventes";
        // 
        // aideToolStripMenuItem
        // 
        aideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { àProposToolStripMenuItem });
        aideToolStripMenuItem.Name = "aideToolStripMenuItem";
        aideToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
        aideToolStripMenuItem.Text = "Aide";
        // 
        // àProposToolStripMenuItem
        // 
        àProposToolStripMenuItem.Name = "àProposToolStripMenuItem";
        àProposToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
        àProposToolStripMenuItem.Text = "À propos";
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
        lblStatusInfo.Text = "Prêt";
        // 
        // panelHeader
        // 
        panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        panelHeader.Controls.Add(lblDashboardTitle);
        panelHeader.Controls.Add(lblDate);
        panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
        panelHeader.Location = new System.Drawing.Point(0, 24);
        panelHeader.Name = "panelHeader";
        panelHeader.Size = new System.Drawing.Size(1200, 100);
        panelHeader.TabIndex = 2;
        // 
        // lblDashboardTitle
        // 
        lblDashboardTitle.Dock = System.Windows.Forms.DockStyle.Top;
        lblDashboardTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
        lblDashboardTitle.ForeColor = System.Drawing.Color.White;
        lblDashboardTitle.Location = new System.Drawing.Point(0, 0);
        lblDashboardTitle.Name = "lblDashboardTitle";
        lblDashboardTitle.Size = new System.Drawing.Size(1200, 60);
        lblDashboardTitle.TabIndex = 0;
        lblDashboardTitle.Text = "TABLEAU DE BORD";
        lblDashboardTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblDate
        // 
        lblDate.Dock = System.Windows.Forms.DockStyle.Bottom;
        lblDate.Font = new System.Drawing.Font("Segoe UI", 10F);
        lblDate.ForeColor = System.Drawing.Color.White;
        lblDate.Location = new System.Drawing.Point(0, 70);
        lblDate.Name = "lblDate";
        lblDate.Size = new System.Drawing.Size(1200, 30);
        lblDate.TabIndex = 1;
        lblDate.Text = "lundi 16 décembre 2024";
        lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // flowPanelStats
        // 
        flowPanelStats.BackColor = System.Drawing.Color.WhiteSmoke;
        flowPanelStats.Controls.Add(panelOrders);
        flowPanelStats.Controls.Add(panelRevenue);
        flowPanelStats.Controls.Add(panelMenus);
        flowPanelStats.Controls.Add(panelClients);
        flowPanelStats.Dock = System.Windows.Forms.DockStyle.Top;
        flowPanelStats.Location = new System.Drawing.Point(0, 124);
        flowPanelStats.Name = "flowPanelStats";
        flowPanelStats.Padding = new System.Windows.Forms.Padding(20);
        flowPanelStats.Size = new System.Drawing.Size(1200, 200);
        flowPanelStats.TabIndex = 3;
        // 
        // panelOrders
        // 
        panelOrders.BackColor = System.Drawing.Color.White;
        panelOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        panelOrders.Controls.Add(lblOrdersTitle);
        panelOrders.Controls.Add(lblOrdersCount);
        panelOrders.Controls.Add(lblOrdersSub);
        panelOrders.Location = new System.Drawing.Point(23, 23);
        panelOrders.Name = "panelOrders";
        panelOrders.Size = new System.Drawing.Size(250, 150);
        panelOrders.TabIndex = 0;
        // 
        // lblOrdersTitle
        // 
        lblOrdersTitle.AutoSize = true;
        lblOrdersTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        lblOrdersTitle.Location = new System.Drawing.Point(20, 20);
        lblOrdersTitle.Name = "lblOrdersTitle";
        lblOrdersTitle.Size = new System.Drawing.Size(107, 20);
        lblOrdersTitle.TabIndex = 0;
        lblOrdersTitle.Text = "COMMANDES";
        // 
        // lblOrdersCount
        // 
        lblOrdersCount.AutoSize = true;
        lblOrdersCount.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
        lblOrdersCount.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        lblOrdersCount.Location = new System.Drawing.Point(20, 50);
        lblOrdersCount.Name = "lblOrdersCount";
        lblOrdersCount.Size = new System.Drawing.Size(50, 59);
        lblOrdersCount.TabIndex = 1;
        lblOrdersCount.Text = "0";
        // 
        // lblOrdersSub
        // 
        lblOrdersSub.AutoSize = true;
        lblOrdersSub.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblOrdersSub.ForeColor = System.Drawing.Color.Gray;
        lblOrdersSub.Location = new System.Drawing.Point(20, 120);
        lblOrdersSub.Name = "lblOrdersSub";
        lblOrdersSub.Size = new System.Drawing.Size(70, 15);
        lblOrdersSub.TabIndex = 2;
        lblOrdersSub.Text = "Aujourd\'hui";
        // 
        // panelRevenue
        // 
        panelRevenue.BackColor = System.Drawing.Color.White;
        panelRevenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        panelRevenue.Controls.Add(lblRevenueTitle);
        panelRevenue.Controls.Add(lblRevenueValue);
        panelRevenue.Controls.Add(lblRevenueSub);
        panelRevenue.Location = new System.Drawing.Point(279, 23);
        panelRevenue.Name = "panelRevenue";
        panelRevenue.Size = new System.Drawing.Size(250, 150);
        panelRevenue.TabIndex = 1;
        // 
        // lblRevenueTitle
        // 
        lblRevenueTitle.AutoSize = true;
        lblRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        lblRevenueTitle.Location = new System.Drawing.Point(20, 20);
        lblRevenueTitle.Name = "lblRevenueTitle";
        lblRevenueTitle.Size = new System.Drawing.Size(117, 20);
        lblRevenueTitle.TabIndex = 0;
        lblRevenueTitle.Text = "CHIFFRE D\'AFF.";
        // 
        // lblRevenueValue
        // 
        lblRevenueValue.AutoSize = true;
        lblRevenueValue.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
        lblRevenueValue.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)40)), ((int)((byte)167)), ((int)((byte)69)));
        lblRevenueValue.Location = new System.Drawing.Point(20, 50);
        lblRevenueValue.Name = "lblRevenueValue";
        lblRevenueValue.Size = new System.Drawing.Size(149, 59);
        lblRevenueValue.TabIndex = 1;
        lblRevenueValue.Text = "0 HTG";
        // 
        // lblRevenueSub
        // 
        lblRevenueSub.AutoSize = true;
        lblRevenueSub.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblRevenueSub.ForeColor = System.Drawing.Color.Gray;
        lblRevenueSub.Location = new System.Drawing.Point(20, 120);
        lblRevenueSub.Name = "lblRevenueSub";
        lblRevenueSub.Size = new System.Drawing.Size(70, 15);
        lblRevenueSub.TabIndex = 2;
        lblRevenueSub.Text = "Aujourd\'hui";
        // 
        // panelMenus
        // 
        panelMenus.BackColor = System.Drawing.Color.White;
        panelMenus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        panelMenus.Controls.Add(lblMenusTitle);
        panelMenus.Controls.Add(lblMenusCount);
        panelMenus.Controls.Add(lblMenusSub);
        panelMenus.Location = new System.Drawing.Point(535, 23);
        panelMenus.Name = "panelMenus";
        panelMenus.Size = new System.Drawing.Size(250, 150);
        panelMenus.TabIndex = 2;
        // 
        // lblMenusTitle
        // 
        lblMenusTitle.AutoSize = true;
        lblMenusTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        lblMenusTitle.Location = new System.Drawing.Point(20, 20);
        lblMenusTitle.Name = "lblMenusTitle";
        lblMenusTitle.Size = new System.Drawing.Size(62, 20);
        lblMenusTitle.TabIndex = 0;
        lblMenusTitle.Text = "MENUS";
        // 
        // lblMenusCount
        // 
        lblMenusCount.AutoSize = true;
        lblMenusCount.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
        lblMenusCount.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)193)), ((int)((byte)7)));
        lblMenusCount.Location = new System.Drawing.Point(20, 50);
        lblMenusCount.Name = "lblMenusCount";
        lblMenusCount.Size = new System.Drawing.Size(50, 59);
        lblMenusCount.TabIndex = 1;
        lblMenusCount.Text = "0";
        // 
        // lblMenusSub
        // 
        lblMenusSub.AutoSize = true;
        lblMenusSub.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblMenusSub.ForeColor = System.Drawing.Color.Gray;
        lblMenusSub.Location = new System.Drawing.Point(20, 120);
        lblMenusSub.Name = "lblMenusSub";
        lblMenusSub.Size = new System.Drawing.Size(115, 15);
        lblMenusSub.TabIndex = 2;
        lblMenusSub.Text = "Disponibles en stock";
        // 
        // panelClients
        // 
        panelClients.BackColor = System.Drawing.Color.White;
        panelClients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        panelClients.Controls.Add(lblClientsTitle);
        panelClients.Controls.Add(lblClientsCount);
        panelClients.Controls.Add(lblClientsSub);
        panelClients.Location = new System.Drawing.Point(791, 23);
        panelClients.Name = "panelClients";
        panelClients.Size = new System.Drawing.Size(250, 150);
        panelClients.TabIndex = 3;
        // 
        // lblClientsTitle
        // 
        lblClientsTitle.AutoSize = true;
        lblClientsTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        lblClientsTitle.Location = new System.Drawing.Point(20, 20);
        lblClientsTitle.Name = "lblClientsTitle";
        lblClientsTitle.Size = new System.Drawing.Size(68, 20);
        lblClientsTitle.TabIndex = 0;
        lblClientsTitle.Text = "CLIENTS";
        // 
        // lblClientsCount
        // 
        lblClientsCount.AutoSize = true;
        lblClientsCount.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
        lblClientsCount.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)220)), ((int)((byte)53)), ((int)((byte)69)));
        lblClientsCount.Location = new System.Drawing.Point(20, 50);
        lblClientsCount.Name = "lblClientsCount";
        lblClientsCount.Size = new System.Drawing.Size(50, 59);
        lblClientsCount.TabIndex = 1;
        lblClientsCount.Text = "0";
        // 
        // lblClientsSub
        // 
        lblClientsSub.AutoSize = true;
        lblClientsSub.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblClientsSub.ForeColor = System.Drawing.Color.Gray;
        lblClientsSub.Location = new System.Drawing.Point(20, 120);
        lblClientsSub.Name = "lblClientsSub";
        lblClientsSub.Size = new System.Drawing.Size(103, 15);
        lblClientsSub.TabIndex = 2;
        lblClientsSub.Text = "Clients enregistrés";
        // 
        // panelChart
        // 
        panelChart.BackColor = System.Drawing.Color.White;
        panelChart.Controls.Add(labelChartTitle);
        panelChart.Controls.Add(dataGridViewRecent);
        panelChart.Dock = System.Windows.Forms.DockStyle.Fill;
        panelChart.Location = new System.Drawing.Point(0, 324);
        panelChart.Name = "panelChart";
        panelChart.Padding = new System.Windows.Forms.Padding(20);
        panelChart.Size = new System.Drawing.Size(1200, 354);
        panelChart.TabIndex = 4;
        // 
        // labelChartTitle
        // 
        labelChartTitle.AutoSize = true;
        labelChartTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        labelChartTitle.Location = new System.Drawing.Point(20, 20);
        labelChartTitle.Name = "labelChartTitle";
        labelChartTitle.Size = new System.Drawing.Size(201, 25);
        labelChartTitle.TabIndex = 1;
        labelChartTitle.Text = "Commandes récentes";
        labelChartTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // dataGridViewRecent
        // 
        dataGridViewRecent.AllowUserToAddRows = false;
        dataGridViewRecent.AllowUserToDeleteRows = false;
        dataGridViewRecent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        dataGridViewRecent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dataGridViewRecent.BackgroundColor = System.Drawing.Color.White;
        dataGridViewRecent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewRecent.Location = new System.Drawing.Point(20, 60);
        dataGridViewRecent.Name = "dataGridViewRecent";
        dataGridViewRecent.ReadOnly = true;
        dataGridViewRecent.Size = new System.Drawing.Size(1160, 274);
        dataGridViewRecent.TabIndex = 0;
        // 
        // toolStrip1
        // 
        toolStrip1.Location = new System.Drawing.Point(0, 324);
        toolStrip1.Name = "toolStrip1";
        toolStrip1.Size = new System.Drawing.Size(1200, 25);
        toolStrip1.TabIndex = 5;
        toolStrip1.Text = "toolStrip1";
        // 
        // DashboardForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1200, 700);
        Controls.Add(toolStrip1);
        Controls.Add(panelChart);
        Controls.Add(flowPanelStats);
        Controls.Add(panelHeader);
        Controls.Add(statusStrip1);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        MinimumSize = new System.Drawing.Size(1216, 718);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "POS RESTO - Tableau de bord";
        WindowState = System.Windows.Forms.FormWindowState.Maximized;
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        panelHeader.ResumeLayout(false);
        flowPanelStats.ResumeLayout(false);
        panelOrders.ResumeLayout(false);
        panelOrders.PerformLayout();
        panelRevenue.ResumeLayout(false);
        panelRevenue.PerformLayout();
        panelMenus.ResumeLayout(false);
        panelMenus.PerformLayout();
        panelClients.ResumeLayout(false);
        panelClients.PerformLayout();
        panelChart.ResumeLayout(false);
        panelChart.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridViewRecent).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.ToolStrip toolStrip1;

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.Panel panelHeader;
    private System.Windows.Forms.Label lblDashboardTitle;
    private System.Windows.Forms.Label lblDate;
    private System.Windows.Forms.FlowLayoutPanel flowPanelStats;
    private System.Windows.Forms.Panel panelOrders;
    private System.Windows.Forms.Label lblOrdersTitle;
    private System.Windows.Forms.Label lblOrdersCount;
    private System.Windows.Forms.Label lblOrdersSub;
    private System.Windows.Forms.Panel panelRevenue;
    private System.Windows.Forms.Label lblRevenueTitle;
    private System.Windows.Forms.Label lblRevenueValue;
    private System.Windows.Forms.Label lblRevenueSub;
    private System.Windows.Forms.Panel panelMenus;
    private System.Windows.Forms.Label lblMenusTitle;
    private System.Windows.Forms.Label lblMenusCount;
    private System.Windows.Forms.Label lblMenusSub;
    private System.Windows.Forms.Panel panelClients;
    private System.Windows.Forms.Label lblClientsTitle;
    private System.Windows.Forms.Label lblClientsCount;
    private System.Windows.Forms.Label lblClientsSub;
    private System.Windows.Forms.Panel panelChart;
    private System.Windows.Forms.DataGridView dataGridViewRecent;
    private System.Windows.Forms.Label labelChartTitle;
    private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem gestionToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem commandesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem menusToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem clientsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem paiementsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem rapportsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem ventesJournalièresToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem topVentesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem àProposToolStripMenuItem;
    private System.Windows.Forms.ToolStripStatusLabel lblStatusUser;
    private System.Windows.Forms.ToolStripStatusLabel lblStatusTime;
    private System.Windows.Forms.ToolStripStatusLabel lblStatusInfo;
}