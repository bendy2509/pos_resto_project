using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using POS_RESTO.Models;
using POS_RESTO.Data;

namespace POS_RESTO.Services
{
    public static class OrderService
    {
        public static int CreateOrder(int clientId, Dictionary<int, int> menuQuantities)
        {
            // Utiliser une transaction pour garantir l'intégrité
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        decimal totalAmount = 0;
                        
                        foreach (var item in menuQuantities)
                        {
                            int menuId = item.Key;
                            int quantity = item.Value;
                            
                            // Insérer la commande
                            string query = @"
                                INSERT INTO Orders (menu_id, client_id, quantity) 
                                VALUES (@menuId, @clientId, @quantity)";
                            
                            var parameters = new[]
                            {
                                new MySqlParameter("@menuId", MySqlDbType.Int32) { Value = menuId },
                                new MySqlParameter("@clientId", MySqlDbType.Int32) { Value = clientId },
                                new MySqlParameter("@quantity", MySqlDbType.Int32) { Value = quantity }
                            };
                            
                            using (var cmd = new MySqlCommand(query, conn, transaction))
                            {
                                cmd.Parameters.AddRange(parameters);
                                cmd.ExecuteNonQuery();
                            }
                            
                            // Calculer le total (pour le paiement)
                            var menu = GetMenuById(menuId);
                            totalAmount += menu.UnitPrice * quantity;
                        }
                        
                        transaction.Commit();
                        return GetLastOrderId();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        
        private static Menu GetMenuById(int menuId)
        {
            string query = "SELECT unit_price FROM Menus WHERE menu_id = @id";
            var param = new MySqlParameter("@id", MySqlDbType.Int32) { Value = menuId };
            
            var price = (decimal)DatabaseHelper.ExecuteScalar(query, param);
            
            return new Menu { MenuId = menuId, UnitPrice = price };
        }
        
        private static int GetLastOrderId()
        {
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT LAST_INSERT_ID()"));
        }
        
        public static void ProcessPayment(int orderId, decimal amount, string paymentMode)
        {
            string query = @"
                INSERT INTO Payments (order_id, amount, payment_mode) 
                VALUES (@orderId, @amount, @mode)";
            
            var parameters = new[]
            {
                new MySqlParameter("@orderId", MySqlDbType.Int32) { Value = orderId },
                new MySqlParameter("@amount", MySqlDbType.Decimal) { Value = amount },
                new MySqlParameter("@mode", MySqlDbType.VarChar) { Value = paymentMode }
            };
            
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }
    }
}