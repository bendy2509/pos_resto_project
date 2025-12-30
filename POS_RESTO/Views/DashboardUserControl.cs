using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using POS_RESTO.Data;
using Timer = System.Windows.Forms.Timer;

namespace POS_RESTO.Views
{
    public partial class DashboardUserControl : UserControl
    {
        public DashboardUserControl()
        {
            InitializeComponent();
            CreateStatCards();
            LoadDashboardData();
        }
        
        private void CreateStatCards()
        {
            CreateStatCard("COMMANDES", "0", Color.FromArgb(0, 123, 255), "Aujourd'hui");
            CreateStatCard("CHIFFRE D'AFF.", "0 HTG", Color.FromArgb(40, 167, 69), "Aujourd'hui");
            CreateStatCard("MENUS DISPON.", "0", Color.FromArgb(255, 193, 7), "En stock");
            CreateStatCard("CLIENTS", "0", Color.FromArgb(220, 53, 69), "Enregistrés");
            CreateStatCard("DETTES CLIENTS", "0 HTG", Color.FromArgb(111, 66, 193), "Total");
            CreateStatCard("CAISSE DU JOUR", "0 HTG", Color.FromArgb(23, 162, 184), "Paiements");
        }
        
        private void LoadDashboardData()
        {
            lblDate.Text = $"Aujourd'hui: {DateTime.Now:dddd dd MMMM yyyy}";
            try
            {
                // Commandes pour aujourd'hui
                int todayOrders = ReportDao.Dashboard.GetTodayOrdersCount();
                UpdateCardValue(0, todayOrders.ToString("N0"));
                
                // Chiffre d'affaires
                decimal todayRevenue = ReportDao.Dashboard.GetTodayRevenue();
                UpdateCardValue(1, $"{todayRevenue:N0} HTG");
                
                // Menus disponibles
                int availableMenus = ReportDao.Dashboard.GetAvailableMenusCount();
                UpdateCardValue(2, availableMenus.ToString("N0"));
                
                // Clients
                int totalClients = ReportDao.Dashboard.GetTotalClientsCount();
                UpdateCardValue(3, totalClients.ToString("N0"));
                
                // Dettes clients
                decimal totalDebt = ReportDao.Dashboard.GetTotalDebt();
                UpdateCardValue(4, $"{totalDebt:N0} HTG");
                
                // Caisse du jour
                decimal todayPayments = PaymentDao.GetDailyPaymentsTotal(DateTime.Today);
                UpdateCardValue(5, $"{todayPayments:N0} HTG");
                
                // Commandes récentes (7 derniers jours)
                DataTable recentOrders = ReportDao.Dashboard.GetRecentOrders(7);
                dataGridViewRecent.DataSource = recentOrders;
                
                // Meilleures ventes du jour
                DataTable bestSellers = ReportDao.Dashboard.GetBestSellingMenus(5);
                dataGridViewBestSellers.DataSource = bestSellers;
                
                // Ajuster les colonnes
                if (dataGridViewRecent.Columns.Count > 0)
                {
                    dataGridViewRecent.Columns[0].Width = 100;
                    dataGridViewRecent.Columns[1].Width = 100;
                    dataGridViewRecent.Columns[2].Width = 120;
                }
                
                if (dataGridViewBestSellers.Columns.Count > 0)
                {
                    dataGridViewBestSellers.Columns[0].Width = 150;
                    dataGridViewBestSellers.Columns[1].Width = 100;
                    dataGridViewBestSellers.Columns[2].Width = 100;
                    dataGridViewBestSellers.Columns[3].Width = 120;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement données: {ex.Message}", 
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void UpdateCardValue(int cardIndex, string value)
        {
            if (flowPanelStats.Controls.Count > cardIndex)
            {
                var panel = flowPanelStats.Controls[cardIndex];
                var lblValue = panel.Controls[1] as Label;
                if (lblValue != null)
                {
                    lblValue.Text = value;
                    
                    // Mettre en évidence les valeurs importantes
                    if (cardIndex == 4) // Dettes
                    {
                        lblValue.ForeColor = Color.FromArgb(220, 53, 69);
                    }
                    else if (cardIndex == 1 || cardIndex == 5) // Chiffre d'affaires et caisse
                    {
                        lblValue.ForeColor = Color.FromArgb(40, 167, 69);
                    }
                }
            }
        }
        
        private void CreateStatCard(string title, string value, Color color, string subtitle)
        {
            var panel = new Panel();
            panel.Size = new Size(200, 120);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(8);
    
            var lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTitle.Location = new Point(10, 10);
            lblTitle.Size = new Size(180, 20);
            lblTitle.ForeColor = Color.FromArgb(73, 80, 87);
    
            var lblValue = new Label();
            lblValue.Text = value;
            lblValue.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblValue.ForeColor = color;
            lblValue.Location = new Point(10, 35);
            lblValue.Size = new Size(180, 45);
            lblValue.TextAlign = ContentAlignment.MiddleLeft;
    
            var lblSub = new Label();
            lblSub.Text = subtitle;
            lblSub.Font = new Font("Segoe UI", 8);
            lblSub.ForeColor = Color.Gray;
            lblSub.Location = new Point(10, 85);
            lblSub.Size = new Size(180, 25);
    
            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblValue);
            panel.Controls.Add(lblSub);
    
            flowPanelStats.Controls.Add(panel);
        }
    }
}