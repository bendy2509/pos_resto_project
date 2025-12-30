namespace POS_RESTO.Views
{
    partial class DashboardUserControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowPanelStats;
        private System.Windows.Forms.DataGridView dataGridViewRecent;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRecentTitle;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowPanelStats = new System.Windows.Forms.FlowLayoutPanel();
            dataGridViewRecent = new System.Windows.Forms.DataGridView();
            lblTitle = new System.Windows.Forms.Label();
            lblDate = new System.Windows.Forms.Label();
            lblRecentTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRecent).BeginInit();
            SuspendLayout();
            // 
            // flowPanelStats
            // 
            flowPanelStats.BackColor = System.Drawing.Color.White;
            flowPanelStats.Dock = System.Windows.Forms.DockStyle.Top;
            flowPanelStats.Location = new System.Drawing.Point(20, 100);
            flowPanelStats.Name = "flowPanelStats";
            flowPanelStats.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            flowPanelStats.Size = new System.Drawing.Size(645, 180);
            flowPanelStats.TabIndex = 2;
            // 
            // dataGridViewRecent
            // 
            dataGridViewRecent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRecent.BackgroundColor = System.Drawing.Color.White;
            dataGridViewRecent.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewRecent.Location = new System.Drawing.Point(20, 320);
            dataGridViewRecent.Name = "dataGridViewRecent";
            dataGridViewRecent.ReadOnly = true;
            dataGridViewRecent.RowHeadersVisible = false;
            dataGridViewRecent.Size = new System.Drawing.Size(645, 110);
            dataGridViewRecent.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
            lblTitle.Location = new System.Drawing.Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(645, 50);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "TABLEAU DE BORD";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDate
            // 
            lblDate.Dock = System.Windows.Forms.DockStyle.Top;
            lblDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblDate.ForeColor = System.Drawing.Color.Gray;
            lblDate.Location = new System.Drawing.Point(20, 70);
            lblDate.Name = "lblDate";
            lblDate.Size = new System.Drawing.Size(645, 30);
            lblDate.TabIndex = 3;
            lblDate.Text = "Chargement...";
            lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRecentTitle
            // 
            lblRecentTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblRecentTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblRecentTitle.Location = new System.Drawing.Point(20, 280);
            lblRecentTitle.Name = "lblRecentTitle";
            lblRecentTitle.Size = new System.Drawing.Size(645, 40);
            lblRecentTitle.TabIndex = 1;
            lblRecentTitle.Text = "Commandes récentes (7 derniers jours)";
            lblRecentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DashboardUserControl
            // 
            AutoScroll = true;
            BackColor = System.Drawing.Color.White;
            Controls.Add(dataGridViewRecent);
            Controls.Add(lblRecentTitle);
            Controls.Add(flowPanelStats);
            Controls.Add(lblDate);
            Controls.Add(lblTitle);
            Padding = new System.Windows.Forms.Padding(20);
            Size = new System.Drawing.Size(685, 450);
            ((System.ComponentModel.ISupportInitialize)dataGridViewRecent).EndInit();
            ResumeLayout(false);
        }
    }
}