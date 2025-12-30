using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using POS_RESTO.Models;

namespace POS_RESTO.Data
{
    public static class OrderDao
    {
        // Classe pour représenter un élément du panier
        public class CartItem
        {
            public int MenuId { get; set; }
            public string MenuName { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public decimal Subtotal => Price * Quantity;
            
            public override string ToString()
            {
                return $"{MenuName} x{Quantity} - {Subtotal:N0} HTG";
            }
        }
        
        // Classe pour représenter un client dans la combobox
        public class ClientItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            
            public override string ToString()
            {
                return Name;
            }
        }
        
        // Méthode pour charger les menus disponibles (utilisée dans LoadMenus)
        public static List<Menu> GetAvailableMenus()
        {
            var menus = new List<Menu>();
            
            try
            {
                string query = "SELECT menu_id, name, category, unit_price, stock_quantity FROM Menus WHERE stock_quantity > 0 ORDER BY category, name";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            menus.Add(new Menu
                            {
                                MenuId = Convert.ToInt32(reader["menu_id"]),
                                Name = reader["name"].ToString(),
                                Category = reader["category"].ToString(),
                                UnitPrice = Convert.ToDecimal(reader["unit_price"]),
                                StockQuantity = Convert.ToInt32(reader["stock_quantity"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement menus: {ex.Message}", ex);
            }
            
            return menus;
        }
        
        // Méthode pour charger les clients (utilisée dans LoadClients)
        public static List<ClientItem> GetClientsForComboBox()
        {
            var clients = new List<ClientItem>();
            
            try
            {
                string query = "SELECT client_id, CONCAT(first_name, ' ', last_name) as nom FROM Clients ORDER BY last_name, first_name";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clients.Add(new ClientItem
                            {
                                Id = Convert.ToInt32(reader["client_id"]),
                                Name = reader["nom"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement clients: {ex.Message}", ex);
            }
            
            return clients;
        }
        
        // Méthode pour créer une commande avec un seul élément (adapté à votre structure de BD)
        public static int CreateOrder(int menuId, int clientId, int quantity)
        {
            try
            {
                // Le trigger trg_process_order_stock gère automatiquement la vérification du stock
                string query = @"
                    INSERT INTO Orders (menu_id, client_id, quantity, status) 
                    VALUES (@menuId, @clientId, @quantity, 'en cours');
                    SELECT LAST_INSERT_ID();";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@menuId", menuId);
                        cmd.Parameters.AddWithValue("@clientId", clientId);
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (MySqlException ex) when (ex.Number == 1644) // Erreur de trigger (stock insuffisant)
            {
                throw new Exception("Stock insuffisant pour ce produit !", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur création commande: {ex.Message}", ex);
            }
        }
        
        // Méthode pour créer plusieurs commandes (une par élément du panier)
        public static void CreateMultipleOrders(int clientId, List<CartItem> cartItems)
        {
            try
            {
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    foreach (var item in cartItems)
                    {
                        string query = @"
                            INSERT INTO Orders (menu_id, client_id, quantity, status) 
                            VALUES (@menuId, @clientId, @quantity, 'en cours')";
                        
                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@menuId", item.MenuId);
                            cmd.Parameters.AddWithValue("@clientId", clientId);
                            cmd.Parameters.AddWithValue("@quantity", item.Quantity);
                            
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (MySqlException ex) when (ex.Number == 1644)
            {
                throw new Exception("Stock insuffisant pour un des produits !", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur création commandes: {ex.Message}", ex);
            }
        }
        
        // Méthodes supplémentaires pour la gestion des commandes
        public static List<Order> GetAllOrders()
        {
            var orders = new List<Order>();
            
            try
            {
                string query = @"
                    SELECT o.*, m.name as menu_name, m.unit_price, 
                           CONCAT(c.last_name, ' ', c.first_name) as client_name
                    FROM Orders o
                    JOIN Menus m ON o.menu_id = m.menu_id
                    JOIN Clients c ON o.client_id = c.client_id
                    ORDER BY o.order_date DESC";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.Add(new Order
                            {
                                OrderId = Convert.ToInt32(reader["order_id"]),
                                MenuId = Convert.ToInt32(reader["menu_id"]),
                                MenuName = reader["menu_name"].ToString(),
                                ClientId = Convert.ToInt32(reader["client_id"]),
                                ClientName = reader["client_name"].ToString(),
                                Quantity = Convert.ToInt32(reader["quantity"]),
                                UnitPrice = Convert.ToDecimal(reader["unit_price"]),
                                OrderDate = Convert.ToDateTime(reader["order_date"]),
                                Status = reader["status"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement commandes: {ex.Message}", ex);
            }
            
            return orders;
        }
        
        public static void UpdateOrderStatus(int orderId, string status)
        {
            try
            {
                string query = "UPDATE Orders SET status = @status WHERE order_id = @id";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@id", orderId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur mise à jour statut commande: {ex.Message}", ex);
            }
        }
        
        public static decimal GetOrderTotal(int orderId)
        {
            try
            {
                string query = @"
                    SELECT m.unit_price * o.quantity as total
                    FROM Orders o
                    JOIN Menus m ON o.menu_id = m.menu_id
                    WHERE o.order_id = @id";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", orderId);
                        var result = cmd.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur calcul total commande: {ex.Message}", ex);
            }
        }
        
        public static DataTable GetOrdersDataTable(DateTime? date = null)
        {
            DataTable dt = new DataTable();
            
            try
            {
                string query = @"
                    SELECT o.order_id as 'ID Commande',
                           CONCAT(c.last_name, ' ', c.first_name) as 'Client',
                           m.name as 'Menu',
                           o.quantity as 'Quantité',
                           FORMAT(m.unit_price, 2) as 'Prix unitaire',
                           FORMAT(m.unit_price * o.quantity, 2) as 'Total',
                           o.order_date as 'Date',
                           o.status as 'Statut'
                    FROM Orders o
                    JOIN Menus m ON o.menu_id = m.menu_id
                    JOIN Clients c ON o.client_id = c.client_id";
                
                if (date.HasValue)
                {
                    query += " WHERE DATE(o.order_date) = @date";
                }
                
                query += " ORDER BY o.order_date DESC";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        if (date.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@date", date.Value.Date);
                        }
                        
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement DataTable commandes: {ex.Message}", ex);
            }
            
            return dt;
        }
        
        // Méthode pour obtenir un DataTable formaté pour l'affichage
        public static DataTable GetOrdersDataTable(string statusFilter = null, DateTime? dateFilter = null)
        {
            DataTable dt = new DataTable();
            
            try
            {
                string query = @"
                    SELECT 
                        o.order_id as 'ID',
                        CONCAT(c.first_name, ' ', c.last_name) as 'Client',
                        DATE_FORMAT(o.order_date, '%d/%m/%Y %H:%i') as 'Date',
                        o.status as 'Statut',
                        FORMAT(SUM(m.unit_price * o.quantity), 2) as 'Total HTG'
                    FROM Orders o
                    JOIN Clients c ON o.client_id = c.client_id
                    JOIN Menus m ON o.menu_id = m.menu_id
                    WHERE 1=1";
                
                // Appliquer les filtres
                if (!string.IsNullOrEmpty(statusFilter))
                {
                    query += " AND o.status = @status";
                }
                
                if (dateFilter.HasValue)
                {
                    query += " AND DATE(o.order_date) = @date";
                }
                
                query += @" GROUP BY o.order_id, o.order_date, c.first_name, c.last_name, o.status
                           ORDER BY o.order_date DESC";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(statusFilter))
                        {
                            cmd.Parameters.AddWithValue("@status", statusFilter);
                        }
                        
                        if (dateFilter.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@date", dateFilter.Value.Date);
                        }
                        
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement DataTable commandes: {ex.Message}", ex);
            }
            
            return dt;
        }
        
        // Méthode pour obtenir les détails d'une commande
        public static DataTable GetOrderDetailsDataTable(int orderId)
        {
            DataTable dt = new DataTable();
            
            try
            {
                string query = @"
                    SELECT 
                        m.name as 'Menu',
                        m.category as 'Catégorie',
                        o.quantity as 'Quantité',
                        FORMAT(m.unit_price, 2) as 'Prix unitaire',
                        FORMAT(m.unit_price * o.quantity, 2) as 'Sous-total'
                    FROM Orders o
                    JOIN Menus m ON o.menu_id = m.menu_id
                    WHERE o.order_id = @orderId
                    ORDER BY m.category, m.name";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement détails commande: {ex.Message}", ex);
            }
            
            return dt;
        }
        
        public static bool CheckStockAvailability(List<CartItem> cartItems, out string errorMessage)
        {
            errorMessage = string.Empty;
            
            try
            {
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    // Regrouper les quantités par menu (au cas où un menu apparaît plusieurs fois)
                    var quantitiesByMenu = cartItems
                        .GroupBy(item => item.MenuId)
                        .ToDictionary(g => g.Key, g => g.Sum(item => item.Quantity));
                    
                    foreach (var kvp in quantitiesByMenu)
                    {
                        int menuId = kvp.Key;
                        int requiredQuantity = kvp.Value;
                        
                        string query = @"
                            SELECT name, stock_quantity 
                            FROM Menus 
                            WHERE menu_id = @menuId";
                        
                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@menuId", menuId);
                            
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string menuName = reader["name"].ToString();
                                    int availableStock = Convert.ToInt32(reader["stock_quantity"]);
                                    
                                    if (availableStock < requiredQuantity)
                                    {
                                        errorMessage = 
                                            $"Stock insuffisant pour '{menuName}'!\n" +
                                            $"Stock disponible: {availableStock}\n" +
                                            $"Quantité demandée: {requiredQuantity}";
                                        return false;
                                    }
                                }
                                else
                                {
                                    errorMessage = $"Produit avec ID {menuId} non trouvé.";
                                    return false;
                                }
                            }
                        }
                    }
                    
                    return true; // Tout le stock est disponible
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"Erreur vérification stock: {ex.Message}";
                return false;
            }
        }
        
        // Méthode pour obtenir les statistiques des commandes
        public static DataTable GetOrdersStatistics(DateTime startDate, DateTime endDate)
        {
            DataTable dt = new DataTable();
            
            try
            {
                string query = @"
                    SELECT 
                        DATE(o.order_date) as 'Date',
                        COUNT(DISTINCT o.order_id) as 'Nb Commandes',
                        COUNT(*) as 'Nb Articles',
                        FORMAT(SUM(m.unit_price * o.quantity), 2) as 'Chiffre d\'affaires',
                        FORMAT(AVG(m.unit_price * o.quantity), 2) as 'Panier moyen'
                    FROM Orders o
                    JOIN Menus m ON o.menu_id = m.menu_id
                    WHERE o.order_date BETWEEN @startDate AND @endDate
                    GROUP BY DATE(o.order_date)
                    ORDER BY DATE(o.order_date) DESC";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@startDate", startDate.Date);
                        cmd.Parameters.AddWithValue("@endDate", endDate.Date.AddDays(1).AddSeconds(-1));
                        
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement statistiques commandes: {ex.Message}", ex);
            }
            
            return dt;
        }
        
        // Méthode pour annuler une commande
        public static int CancelOrder(int orderId)
        {
            try
            {
                // Récupérer les détails de la commande pour restaurer le stock
                string selectQuery = "SELECT menu_id, quantity FROM Orders WHERE order_id = @orderId";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    // Restaurer le stock
                    using (var selectCmd = new MySqlCommand(selectQuery, conn))
                    {
                        selectCmd.Parameters.AddWithValue("@orderId", orderId);
                        
                        using (var reader = selectCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int menuId = Convert.ToInt32(reader["menu_id"]);
                                int quantity = Convert.ToInt32(reader["quantity"]);
                                
                                reader.Close();
                                
                                // Restaurer le stock
                                MenuDao.UpdateStock(menuId, quantity);
                            }
                            else
                            {
                                reader.Close();
                                throw new Exception("Commande non trouvée");
                            }
                        }
                    }
                    
                    // Mettre à jour le statut de la commande
                    string updateQuery = "UPDATE Orders SET status = 'annulee' WHERE order_id = @orderId";
                    
                    using (var updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@orderId", orderId);
                        return updateCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur annulation commande: {ex.Message}", ex);
            }
        }
        
        // Méthode pour obtenir le nombre total de commandes
        public static int GetTotalOrdersCount(DateTime? date = null)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Orders WHERE 1=1";
                
                if (date.HasValue)
                {
                    query += " AND DATE(order_date) = @date";
                }
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        if (date.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@date", date.Value.Date);
                        }
                        
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur comptage commandes: {ex.Message}", ex);
            }
        }
        
        // Méthode pour obtenir une commande par son ID
        public static Order GetOrderById(int orderId)
        {
            try
            {
                string query = @"
            SELECT o.*, 
                   m.name as menu_name, 
                   m.unit_price,
                   CONCAT(c.last_name, ' ', c.first_name) as client_name,
                   c.client_id
            FROM Orders o
            JOIN Menus m ON o.menu_id = m.menu_id
            JOIN Clients c ON o.client_id = c.client_id
            WHERE o.order_id = @orderId";
        
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
            
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Order
                                {
                                    OrderId = Convert.ToInt32(reader["order_id"]),
                                    MenuId = Convert.ToInt32(reader["menu_id"]),
                                    MenuName = reader["menu_name"].ToString(),
                                    ClientId = Convert.ToInt32(reader["client_id"]),
                                    ClientName = reader["client_name"].ToString(),
                                    Quantity = Convert.ToInt32(reader["quantity"]),
                                    UnitPrice = Convert.ToDecimal(reader["unit_price"]),
                                    OrderDate = Convert.ToDateTime(reader["order_date"]),
                                    Status = reader["status"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement commande: {ex.Message}", ex);
            }
    
            return null;
        }
    }
}