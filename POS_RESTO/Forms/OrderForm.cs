using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using POS_RESTO.Configuration;

namespace POS_RESTO.Forms
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
            InitializeEvents();
            LoadMenus();
            LoadClients();
        }

        private void InitializeEvents()
        {
            btnAddToCart.Click += BtnAddToCart_Click;
            btnRemoveFromCart.Click += BtnRemoveFromCart_Click;
            btnConfirmOrder.Click += BtnConfirmOrder_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void LoadMenus()
        {
            try
            {
                dgvMenus.Rows.Clear();
                string query = "SELECT menu_id, name, category, unit_price, quantity FROM Menus WHERE quantity > 0";
                
                using (var conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgvMenus.Rows.Add(
                                reader["menu_id"],
                                reader["name"],
                                reader["category"],
                                reader["unit_price"],
                                reader["quantity"]
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement menus: {ex.Message}");
            }
        }

        private void LoadClients()
        {
            try
            {
                cmbClients.Items.Clear();
                string query = "SELECT client_id, CONCAT(first_name, ' ', last_name) as nom FROM Clients ORDER BY last_name";
                
                using (var conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbClients.Items.Add(new ClientItem
                            {
                                Id = Convert.ToInt32(reader["client_id"]),
                                Name = reader["nom"].ToString()
                            });
                        }
                    }
                }
                
                if (cmbClients.Items.Count > 0)
                    cmbClients.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement clients: {ex.Message}");
            }
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvMenus.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un menu.");
                return;
            }

            var selectedRow = dgvMenus.SelectedRows[0];
            int menuId = Convert.ToInt32(selectedRow.Cells[0].Value);
            string menuName = selectedRow.Cells[1].Value.ToString();
            decimal price = Convert.ToDecimal(selectedRow.Cells[3].Value);
            int quantity = (int)numQuantity.Value;

            string cartItem = $"{menuName} x{quantity} - {price * quantity} HTG";
            lstCart.Items.Add(new CartItem
            {
                MenuId = menuId,
                MenuName = menuName,
                Price = price,
                Quantity = quantity
            });

            UpdateTotal();
        }

        private void BtnRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (lstCart.SelectedIndex >= 0)
            {
                lstCart.Items.RemoveAt(lstCart.SelectedIndex);
                UpdateTotal();
            }
        }

        private void BtnConfirmOrder_Click(object sender, EventArgs e)
        {
            if (lstCart.Items.Count == 0)
            {
                MessageBox.Show("Le panier est vide.");
                return;
            }

            if (cmbClients.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un client.");
                return;
            }

            try
            {
                var clientId = ((ClientItem)cmbClients.SelectedItem).Id;
                
                using (var conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    // Insérer la commande
                    string orderQuery = "INSERT INTO Orders (client_id, order_date) VALUES (@clientId, NOW()); SELECT LAST_INSERT_ID();";
                    int orderId;
                    
                    using (var cmd = new MySqlCommand(orderQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@clientId", clientId);
                        orderId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    
                    // Insérer les détails de la commande
                    foreach (CartItem item in lstCart.Items)
                    {
                        string detailQuery = @"INSERT INTO OrderDetails (order_id, menu_id, quantity, unit_price) 
                                             VALUES (@orderId, @menuId, @quantity, @unitPrice)";
                        
                        using (var cmd = new MySqlCommand(detailQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@orderId", orderId);
                            cmd.Parameters.AddWithValue("@menuId", item.MenuId);
                            cmd.Parameters.AddWithValue("@quantity", item.Quantity);
                            cmd.Parameters.AddWithValue("@unitPrice", item.Price);
                            cmd.ExecuteNonQuery();
                        }
                        
                        // Mettre à jour le stock
                        string updateStock = "UPDATE Menus SET quantity = quantity - @quantity WHERE menu_id = @menuId";
                        using (var cmd = new MySqlCommand(updateStock, conn))
                        {
                            cmd.Parameters.AddWithValue("@quantity", item.Quantity);
                            cmd.Parameters.AddWithValue("@menuId", item.MenuId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    
                    MessageBox.Show("Commande validée avec succès!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur validation commande: {ex.Message}");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void UpdateTotal()
        {
            decimal total = 0;
            foreach (CartItem item in lstCart.Items)
            {
                total += item.Price * item.Quantity;
            }
            lblTotal.Text = $"Total: {total:N0} HTG";
        }
    }

    internal class ClientItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public override string ToString()
        {
            return Name;
        }
    }

    internal class CartItem
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        
        public override string ToString()
        {
            return $"{MenuName} x{Quantity} - {Price * Quantity} HTG";
        }
    }
}