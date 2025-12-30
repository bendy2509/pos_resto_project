using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace POS_RESTO.Views
{
    partial class DashboardUserControl
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flowPanelStats;
        private DataGridView dataGridViewRecent;
        private Label lblDate;
        private Label lblTitle;
        private Label lblRecentTitle;
        private DataGridView dataGridViewBestSellers;
        private Label lblBestSellersTitle;
        private Panel panelRecent;
        private Panel panelBestSellers;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            flowPanelStats = new FlowLayoutPanel();
            dataGridViewRecent = new DataGridView();
            lblTitle = new Label();
            lblDate = new Label();
            lblRecentTitle = new Label();
            dataGridViewBestSellers = new DataGridView();
            lblBestSellersTitle = new Label();
            panelRecent = new Panel();
            panelBestSellers = new Panel();
            
            ((System.ComponentModel.ISupportInitialize)dataGridViewRecent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBestSellers).BeginInit();
            panelRecent.SuspendLayout();
            panelBestSellers.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowPanelStats
            // 
            flowPanelStats.BackColor = Color.White;
            flowPanelStats.Dock = DockStyle.Top;
            flowPanelStats.Location = new Point(20, 100);
            flowPanelStats.Name = "flowPanelStats";
            flowPanelStats.Padding = new Padding(0, 10, 0, 10);
            flowPanelStats.Size = new Size(726, 150);
            flowPanelStats.TabIndex = 2;
            // 
            // dataGridViewRecent
            // 
            dataGridViewRecent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRecent.BackgroundColor = Color.White;
            dataGridViewRecent.Dock = DockStyle.Fill;
            dataGridViewRecent.Location = new Point(0, 0);
            dataGridViewRecent.Name = "dataGridViewRecent";
            dataGridViewRecent.ReadOnly = true;
            dataGridViewRecent.RowHeadersVisible = false;
            dataGridViewRecent.AllowUserToAddRows = false;
            dataGridViewRecent.Size = new Size(350, 180);
            dataGridViewRecent.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 123, 255);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(726, 50);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "TABLEAU DE BORD";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDate
            // 
            lblDate.Dock = DockStyle.Top;
            lblDate.Font = new Font("Segoe UI", 10);
            lblDate.ForeColor = Color.Gray;
            lblDate.Location = new Point(20, 70);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(726, 30);
            lblDate.TabIndex = 3;
            lblDate.Text = "Chargement...";
            lblDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRecentTitle
            // 
            lblRecentTitle.Dock = DockStyle.Top;
            lblRecentTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblRecentTitle.Location = new Point(0, 0);
            lblRecentTitle.Name = "lblRecentTitle";
            lblRecentTitle.Padding = new Padding(0, 0, 0, 10);
            lblRecentTitle.Size = new Size(350, 40);
            lblRecentTitle.TabIndex = 1;
            lblRecentTitle.Text = "Commandes (7 jours)";
            lblRecentTitle.TextAlign = ContentAlignment.BottomLeft;
            // 
            // dataGridViewBestSellers
            // 
            dataGridViewBestSellers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBestSellers.BackgroundColor = Color.White;
            dataGridViewBestSellers.Dock = DockStyle.Fill;
            dataGridViewBestSellers.Location = new Point(0, 0);
            dataGridViewBestSellers.Name = "dataGridViewBestSellers";
            dataGridViewBestSellers.ReadOnly = true;
            dataGridViewBestSellers.RowHeadersVisible = false;
            dataGridViewBestSellers.AllowUserToAddRows = false;
            dataGridViewBestSellers.Size = new Size(350, 180);
            dataGridViewBestSellers.TabIndex = 0;
            // 
            // lblBestSellersTitle
            // 
            lblBestSellersTitle.Dock = DockStyle.Top;
            lblBestSellersTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblBestSellersTitle.Location = new Point(0, 0);
            lblBestSellersTitle.Padding = new Padding(0, 0, 0, 10);
            lblBestSellersTitle.Size = new Size(350, 40);
            lblBestSellersTitle.TabIndex = 1;
            lblBestSellersTitle.Text = "Meilleures ventes";
            lblBestSellersTitle.TextAlign = ContentAlignment.BottomLeft;
            // 
            // panelRecent
            // 
            panelRecent.Controls.Add(dataGridViewRecent);
            panelRecent.Controls.Add(lblRecentTitle);
            panelRecent.Dock = DockStyle.Left;
            panelRecent.Location = new Point(20, 250);
            panelRecent.Name = "panelRecent";
            panelRecent.Padding = new Padding(0, 0, 10, 20);
            panelRecent.Size = new Size(350, 200);
            panelRecent.TabIndex = 5;
            // 
            // panelBestSellers
            // 
            panelBestSellers.Controls.Add(dataGridViewBestSellers);
            panelBestSellers.Controls.Add(lblBestSellersTitle);
            panelBestSellers.Dock = DockStyle.Left;
            panelBestSellers.Location = new Point(380, 250);
            panelBestSellers.Name = "panelBestSellers";
            panelBestSellers.Padding = new Padding(10, 0, 0, 20);
            panelBestSellers.Size = new Size(350, 200);
            panelBestSellers.TabIndex = 6;
            // 
            // DashboardUserControl
            // 
            this.AutoScroll = true;
            this.BackColor = Color.White;
            this.Controls.Add(panelBestSellers);
            this.Controls.Add(panelRecent);
            this.Controls.Add(flowPanelStats);
            this.Controls.Add(lblDate);
            this.Controls.Add(lblTitle);
            this.Padding = new Padding(20);
            this.Size = new Size(766, 470);
            
            ((System.ComponentModel.ISupportInitialize)dataGridViewRecent).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBestSellers).EndInit();
            panelRecent.ResumeLayout(false);
            panelBestSellers.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}