using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using POS_RESTO.Configuration;

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
            CreateStatCard("MENUS", "0", Color.FromArgb(255, 193, 7), "En stock");
            CreateStatCard("CLIENTS", "0", Color.FromArgb(220, 53, 69), "Enregistrés");
        }
        
        private void LoadDashboardData()
        {
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    // Commandes pour aujourd'hui
                    string query = @"SELECT COUNT(*) FROM Orders WHERE DATE(order_date) = CURDATE()";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        var result = cmd.ExecuteScalar();
                        UpdateCardValue(0, result?.ToString() ?? "0");
                    }
                    
                    // Chiffre d'affaires
                    query = @"SELECT COALESCE(SUM(m.unit_price * o.quantity), 0) 
                             FROM Orders o 
                             JOIN Menus m ON o.menu_id = m.menu_id 
                             WHERE DATE(o.order_date) = CURDATE()";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        decimal revenue = (result != null && result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
                        UpdateCardValue(1, $"{revenue:N0} HTG");
                    }
                    
                    // Menus disponibles
                    query = "SELECT COUNT(*) FROM Menus WHERE stock_quantity > 0";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        var result = cmd.ExecuteScalar();
                        UpdateCardValue(2, result?.ToString() ?? "0");
                    }
                    
                    // Clients
                    query = "SELECT COUNT(*) FROM Clients";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        var result = cmd.ExecuteScalar();
                        UpdateCardValue(3, result?.ToString() ?? "0");
                    }
                    
                    // Commandes récentes
                    query = @"SELECT DATE(o.order_date) as Date, 
                                     COUNT(*) as 'Nb Commandes', 
                                     SUM(m.unit_price * o.quantity) as 'Total HTG'
                              FROM Orders o
                              JOIN Menus m ON o.menu_id = m.menu_id
                              WHERE o.order_date >= DATE_SUB(CURDATE(), INTERVAL 7 DAY)
                              GROUP BY DATE(o.order_date)
                              ORDER BY Date DESC";
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridViewRecent.DataSource = dt;
                    }
                }
            }
            catch (MySqlException mysqlex)
            {
                MessageBox.Show($@"Erreur base de données: {mysqlex.Message}", 
                    "Erreur BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Erreur chargement données: {ex.Message}", 
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void UpdateCardValue(int cardIndex, string? value)
        {
            if (flowPanelStats.Controls.Count > cardIndex)
            {
                var panel = flowPanelStats.Controls[cardIndex];
                var lblValue = panel.Controls[1] as Label;
                if (lblValue != null)
                {
                    lblValue.Text = value;
                }
            }
        }
        
        private void CreateStatCard(string title, string value, Color color, string subtitle)
        {
            var panel = new Panel();
            panel.Size = new Size(250, 140);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(10);
    
            var lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblTitle.Location = new Point(15, 15);
            lblTitle.Size = new Size(220, 25);
    
            var lblValue = new Label();
            lblValue.Text = value;
            lblValue.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            lblValue.ForeColor = color;
            lblValue.Location = new Point(15, 45);
            lblValue.Size = new Size(220, 60);
    
            var lblSub = new Label();
            lblSub.Text = subtitle;
            lblSub.Font = new Font("Segoe UI", 9);
            lblSub.ForeColor = Color.Gray;
            lblSub.Location = new Point(15, 105);
            lblSub.Size = new Size(220, 25);
    
            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblValue);
            panel.Controls.Add(lblSub);
    
            flowPanelStats.Controls.Add(panel);
        }
    }
}