using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using POS_RESTO.Models;

namespace POS_RESTO.Data
{
    public static class MenuDao
    {
        public static List<Menu> GetAllMenus()
        {
            var menus = new List<Menu>();
            
            string query = "SELECT * FROM Menus ORDER BY category, name";
            var dt = DatabaseHelper.ExecuteQuery(query);
            
            foreach (DataRow row in dt.Rows)
            {
                menus.Add(new Menu
                {
                    MenuId = Convert.ToInt32(row["menu_id"]),
                    Name = row["name"].ToString(),
                    Category = row["category"].ToString(),
                    StockQuantity = Convert.ToInt32(row["stock_quantity"]),
                    UnitPrice = Convert.ToDecimal(row["unit_price"]),
                    Description = row["description"]?.ToString()
                });
            }
            
            return menus;
        }
        
        public static List<Menu> GetMenusByCategory(string category)
        {
            var menus = new List<Menu>();
            
            string query = "SELECT * FROM Menus WHERE category = @category AND stock_quantity > 0";
            var param = new MySqlParameter("@category", MySqlDbType.VarChar) { Value = category };
            
            var dt = DatabaseHelper.ExecuteQuery(query, param);
            
            foreach (DataRow row in dt.Rows)
            {
                menus.Add(new Menu
                {
                    MenuId = Convert.ToInt32(row["menu_id"]),
                    Name = row["name"].ToString(),
                    Category = row["category"].ToString(),
                    StockQuantity = Convert.ToInt32(row["stock_quantity"]),
                    UnitPrice = Convert.ToDecimal(row["unit_price"]),
                    Description = row["description"]?.ToString()
                });
            }
            
            return menus;
        }
        
        public static int AddMenu(Menu menu)
        {
            string query = @"
                INSERT INTO Menus (name, category, stock_quantity, unit_price, description) 
                VALUES (@name, @category, @stock, @price, @description)";
            
            var parameters = new[]
            {
                new MySqlParameter("@name", MySqlDbType.VarChar) { Value = menu.Name },
                new MySqlParameter("@category", MySqlDbType.VarChar) { Value = menu.Category },
                new MySqlParameter("@stock", MySqlDbType.Int32) { Value = menu.StockQuantity },
                new MySqlParameter("@price", MySqlDbType.Decimal) { Value = menu.UnitPrice },
                new MySqlParameter("@description", MySqlDbType.VarChar) { Value = menu.Description ?? (object)DBNull.Value }
            };
            
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }
        
        public static void UpdateStock(int menuId, int quantityChange)
        {
            string query = "UPDATE Menus SET stock_quantity = stock_quantity + @change WHERE menu_id = @id";
            
            var parameters = new[]
            {
                new MySqlParameter("@change", MySqlDbType.Int32) { Value = quantityChange },
                new MySqlParameter("@id", MySqlDbType.Int32) { Value = menuId }
            };
            
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }
        
        // Récupérer le menu le plus vendu
        public static Menu GetBestSellingMenu(DateTime date)
        {
            string query = @"
                SELECT m.*, SUM(o.quantity) as total_sold
                FROM Orders o
                JOIN Menus m ON o.menu_id = m.menu_id
                WHERE DATE(o.order_date) = @date
                GROUP BY m.menu_id
                ORDER BY total_sold DESC
                LIMIT 1";
            
            var param = new MySqlParameter("@date", MySqlDbType.Date) { Value = date.Date };
            var dt = DatabaseHelper.ExecuteQuery(query, param);
            
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                return new Menu
                {
                    MenuId = Convert.ToInt32(row["menu_id"]),
                    Name = row["name"].ToString(),
                    Category = row["category"].ToString(),
                    StockQuantity = Convert.ToInt32(row["stock_quantity"]),
                    UnitPrice = Convert.ToDecimal(row["unit_price"]),
                    Description = row["description"]?.ToString()
                };
            }
            
            return null;
        }
    }
}