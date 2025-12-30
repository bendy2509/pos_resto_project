using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using POS_RESTO.Configuration;
using POS_RESTO.Forms;

namespace POS_RESTO.Views
{
    public partial class OrdersUserControl : UserControl
    {
        public OrdersUserControl()
        {
            InitializeComponent();
            LoadOrders();
        }
        
        private void LoadOrders()
        {
            try
            {
                dgvOrders.Rows.Clear();
                
                string query = @"SELECT o.order_id, 
                                        CONCAT(c.first_name, ' ', c.last_name) as client,
                                        o.order_date,
                                        'En cours' as statut,
                                        SUM(m.unit_price * o.quantity) as total
                                 FROM Orders o
                                 JOIN Clients c ON o.client_id = c.client_id
                                 JOIN Menus m ON o.menu_id = m.menu_id
                                 GROUP BY o.order_id, o.order_date, c.first_name, c.last_name
                                 ORDER BY o.order_date DESC";
                
                using (var conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgvOrders.Rows.Add(
                                reader["order_id"],
                                reader["client"],
                                Convert.ToDateTime(reader["order_date"]).ToString("dd/MM/yyyy HH:mm"),
                                reader["statut"],
                                $"{Convert.ToDecimal(reader["total"]):N0} HTG"
                            );
                        }
                    }
                }
                
                lblStatus.Text = $"{dgvOrders.Rows.Count} commandes trouvees";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement commandes: {ex.Message}");
            }
        }
        
        private void BtnNewOrder_Click(object sender, EventArgs e)
        {
            var orderForm = new OrderForm();
            if (orderForm.ShowDialog() == DialogResult.OK)
            {
                LoadOrders();
            }
        }
        
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }
        
        private void CmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOrders();
        }
    }
}