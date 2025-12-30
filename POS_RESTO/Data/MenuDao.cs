using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using POS_RESTO.Models;

namespace POS_RESTO.Data
{
    public static class MenuDao
    {
        // Méthode utilisée dans LoadMenuData()
        public static Menu GetMenuById(int menuId)
        {
            try
            {
                string query = "SELECT * FROM Menus WHERE menu_id = @id";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", menuId);
                        
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Menu
                                {
                                    MenuId = Convert.ToInt32(reader["menu_id"]),
                                    Name = reader["name"].ToString(),
                                    Category = reader["category"].ToString(),
                                    UnitPrice = Convert.ToDecimal(reader["unit_price"]),
                                    StockQuantity = Convert.ToInt32(reader["stock_quantity"]),
                                    Description = reader["description"]?.ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement menu: {ex.Message}", ex);
            }
            
            return null;
        }
        
        // Méthode utilisée dans BtnSave_Click()
        public static void SaveMenu(Menu menu)
        {
            try
            {
                string query;
                
                if (menu.MenuId > 0)
                {
                    query = @"UPDATE Menus SET 
                             name = @name,
                             category = @category,
                             unit_price = @price,
                             stock_quantity = @stock,
                             description = @desc
                             WHERE menu_id = @id";
                }
                else
                {
                    query = @"INSERT INTO Menus (name, category, unit_price, stock_quantity, description) 
                             VALUES (@name, @category, @price, @stock, @desc)";
                }
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", menu.Name);
                        cmd.Parameters.AddWithValue("@category", menu.Category);
                        cmd.Parameters.AddWithValue("@price", menu.UnitPrice);
                        cmd.Parameters.AddWithValue("@stock", menu.StockQuantity);
                        cmd.Parameters.AddWithValue("@desc", menu.Description ?? (object)DBNull.Value);
                        
                        if (menu.MenuId > 0)
                        {
                            cmd.Parameters.AddWithValue("@id", menu.MenuId);
                        }
                        
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur sauvegarde menu: {ex.Message}", ex);
            }
        }
        
        // Méthodes supplémentaires pour compléter le DAO
        public static List<Menu> GetAllMenus()
        {
            var menus = new List<Menu>();
            
            try
            {
                string query = "SELECT * FROM Menus ORDER BY category, name";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
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
                                    StockQuantity = Convert.ToInt32(reader["stock_quantity"]),
                                    Description = reader["description"]?.ToString()
                                });
                            }
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
        
        public static List<Menu> GetMenusByCategory(string category)
        {
            var menus = new List<Menu>();
            
            try
            {
                string query = "SELECT * FROM Menus WHERE category = @category AND stock_quantity > 0 ORDER BY name";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@category", category);
                        
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
                                    StockQuantity = Convert.ToInt32(reader["stock_quantity"]),
                                    Description = reader["description"]?.ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement menus par catégorie: {ex.Message}", ex);
            }
            
            return menus;
        }
        
        public static DataTable GetAllMenusDataTable()
        {
            DataTable dt = new DataTable();
            
            try
            {
                string query = "SELECT * FROM Menus ORDER BY category, name";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement DataTable menus: {ex.Message}", ex);
            }
            
            return dt;
        }
        
        public static int DeleteMenu(int menuId)
        {
            try
            {
                string query = "DELETE FROM Menus WHERE menu_id = @id";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", menuId);
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur suppression menu: {ex.Message}", ex);
            }
        }
        
        public static void UpdateStock(int menuId, int quantityChange)
        {
            try
            {
                string query = "UPDATE Menus SET stock_quantity = stock_quantity + @change WHERE menu_id = @id";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@change", quantityChange);
                        cmd.Parameters.AddWithValue("@id", menuId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur mise à jour stock: {ex.Message}", ex);
            }
        }
        
        public static List<Menu> GetLowStockMenus(int threshold = 10)
        {
            var menus = new List<Menu>();
            
            try
            {
                string query = "SELECT * FROM Menus WHERE stock_quantity <= @threshold ORDER BY stock_quantity ASC";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@threshold", threshold);
                        
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
                                    StockQuantity = Convert.ToInt32(reader["stock_quantity"]),
                                    Description = reader["description"]?.ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement menus faible stock: {ex.Message}", ex);
            }
            
            return menus;
        }
        
        public static decimal GetMenuPrice(int menuId)
        {
            try
            {
                string query = "SELECT unit_price FROM Menus WHERE menu_id = @id";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", menuId);
                        var result = cmd.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur récupération prix menu: {ex.Message}", ex);
            }
        }
        
        public static DataTable GetAllMenusDataTableForDisplay()
        {
            DataTable dt = new DataTable();
            
            try
            {
                string query = @"
                    SELECT 
                        menu_id as 'ID',
                        name as 'Nom',
                        category as 'Catégorie',
                        FORMAT(unit_price, 2) as 'Prix (HTG)',
                        stock_quantity as 'Stock',
                        description as 'Description'
                    FROM Menus 
                    ORDER BY category, name";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement DataTable menus: {ex.Message}", ex);
            }
            
            return dt;
        }
        
        public static DataTable GetMenusByCategoryDataTable(string category)
        {
            DataTable dt = new DataTable();
            
            try
            {
                string query = @"
                    SELECT 
                        menu_id as 'ID',
                        name as 'Nom',
                        category as 'Catégorie',
                        FORMAT(unit_price, 2) as 'Prix (HTG)',
                        stock_quantity as 'Stock',
                        description as 'Description'
                    FROM Menus 
                    WHERE category = @category
                    ORDER BY name";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@category", category);
                        
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement menus par catégorie: {ex.Message}", ex);
            }
            
            return dt;
        }
        
        public static DataTable SearchMenusDataTable(string searchTerm)
        {
            DataTable dt = new DataTable();
            
            try
            {
                string query = @"
                    SELECT 
                        menu_id as 'ID',
                        name as 'Nom',
                        category as 'Catégorie',
                        FORMAT(unit_price, 2) as 'Prix (HTG)',
                        stock_quantity as 'Stock',
                        description as 'Description'
                    FROM Menus 
                    WHERE name LIKE @search 
                       OR category LIKE @search 
                       OR description LIKE @search
                    ORDER BY category, name";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", $"%{searchTerm}%");
                        
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur recherche menus: {ex.Message}", ex);
            }
            
            return dt;
        }
        
        public static DataTable GetLowStockMenusDataTable(int threshold = 10)
        {
            DataTable dt = new DataTable();
            
            try
            {
                string query = @"
                    SELECT 
                        menu_id as 'ID',
                        name as 'Nom',
                        category as 'Catégorie',
                        FORMAT(unit_price, 2) as 'Prix (HTG)',
                        stock_quantity as 'Stock',
                        description as 'Description'
                    FROM Menus 
                    WHERE stock_quantity <= @threshold
                    ORDER BY stock_quantity ASC, name";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@threshold", threshold);
                        
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement menus faible stock: {ex.Message}", ex);
            }
            
            return dt;
        }
    }
}