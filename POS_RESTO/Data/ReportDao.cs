using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace POS_RESTO.Data
{
    public static class ReportDao
    {
        // Méthodes pour le Dashboard
        public static class Dashboard
        {
            public static int GetTodayOrdersCount()
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM Orders WHERE DATE(order_date) = CURDATE()";
                    
                    using (var conn = Configuration.DatabaseConfig.GetConnection())
                    {
                        conn.Open();
                        
                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            return Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erreur comptage commandes du jour: {ex.Message}", ex);
                }
            }
            
            public static decimal GetTodayRevenue()
            {
                try
                {
                    string query = @"
                        SELECT COALESCE(SUM(m.unit_price * o.quantity), 0) 
                        FROM Orders o 
                        JOIN Menus m ON o.menu_id = m.menu_id 
                        WHERE DATE(o.order_date) = CURDATE()";
                    
                    using (var conn = Configuration.DatabaseConfig.GetConnection())
                    {
                        conn.Open();
                        
                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            var result = cmd.ExecuteScalar();
                            return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erreur calcul chiffre d'affaires: {ex.Message}", ex);
                }
            }
            
            public static int GetAvailableMenusCount()
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM Menus WHERE stock_quantity > 0";
                    
                    using (var conn = Configuration.DatabaseConfig.GetConnection())
                    {
                        conn.Open();
                        
                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            return Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erreur comptage menus disponibles: {ex.Message}", ex);
                }
            }
            
            public static int GetTotalClientsCount()
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM Clients";
                    
                    using (var conn = Configuration.DatabaseConfig.GetConnection())
                    {
                        conn.Open();
                        
                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            return Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erreur comptage clients: {ex.Message}", ex);
                }
            }
            
            public static DataTable GetRecentOrders(int days = 7)
            {
                DataTable dt = new DataTable();
                
                try
                {
                    string query = @"
                        SELECT DATE(o.order_date) as 'Date', 
                               COUNT(*) as 'Nb Commandes', 
                               FORMAT(SUM(m.unit_price * o.quantity), 2) as 'Total HTG'
                        FROM Orders o
                        JOIN Menus m ON o.menu_id = m.menu_id
                        WHERE o.order_date >= DATE_SUB(CURDATE(), INTERVAL @days DAY)
                        GROUP BY DATE(o.order_date)
                        ORDER BY Date DESC";
                    
                    using (var conn = Configuration.DatabaseConfig.GetConnection())
                    {
                        conn.Open();
                        
                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@days", days);
                            
                            using (var adapter = new MySqlDataAdapter(cmd))
                            {
                                adapter.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erreur chargement commandes récentes: {ex.Message}", ex);
                }
                
                return dt;
            }
            
            public static DataTable GetBestSellingMenus(int limit = 5)
            {
                DataTable dt = new DataTable();
                
                try
                {
                    string query = @"
                        SELECT m.name as 'Menu',
                               m.category as 'Catégorie',
                               SUM(o.quantity) as 'Quantité vendue',
                               FORMAT(SUM(m.unit_price * o.quantity), 2) as 'Chiffre d\'affaires'
                        FROM Orders o
                        JOIN Menus m ON o.menu_id = m.menu_id
                        WHERE DATE(o.order_date) = CURDATE()
                        GROUP BY m.menu_id
                        ORDER BY SUM(o.quantity) DESC
                        LIMIT @limit";
                    
                    using (var conn = Configuration.DatabaseConfig.GetConnection())
                    {
                        conn.Open();
                        
                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@limit", limit);
                            
                            using (var adapter = new MySqlDataAdapter(cmd))
                            {
                                adapter.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erreur chargement meilleures ventes: {ex.Message}", ex);
                }
                
                return dt;
            }
            
            public static decimal GetTotalDebt()
            {
                try
                {
                    string query = "SELECT COALESCE(SUM(debt_amount), 0) FROM Clients";
                    
                    using (var conn = Configuration.DatabaseConfig.GetConnection())
                    {
                        conn.Open();
                        
                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            var result = cmd.ExecuteScalar();
                            return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erreur calcul total dette: {ex.Message}", ex);
                }
            }
        }
    }
}