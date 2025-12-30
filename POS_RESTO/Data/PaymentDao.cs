using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using POS_RESTO.Models;

namespace POS_RESTO.Data
{
    public static class PaymentDao
    {
        // Méthode pour obtenir le total d'une commande (utilisée dans NumOrderId_ValueChanged)
        public static decimal GetOrderTotal(int orderId)
        {
            try
            {
                string query = @"
                    SELECT SUM(m.unit_price * o.quantity) as total
                    FROM Orders o
                    JOIN Menus m ON o.menu_id = m.menu_id
                    WHERE o.order_id = @orderId
                    GROUP BY o.order_id";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur calcul total commande: {ex.Message}", ex);
            }
            
            return 0;
        }
        
        // Méthode pour créer un paiement (utilisée dans BtnSave_Click)
        public static void CreatePayment(int orderId, decimal amount, string paymentMode)
        {
            try
            {
                // Vérifier si la commande existe
                string checkOrderQuery = "SELECT COUNT(*) FROM Orders WHERE order_id = @orderId";
                bool orderExists = false;
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    // Vérifier l'existence de la commande
                    using (var cmd = new MySqlCommand(checkOrderQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        orderExists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                    
                    if (!orderExists)
                    {
                        throw new Exception($"La commande #{orderId} n'existe pas.");
                    }
                    
                    // Vérifier si un paiement existe déjà pour cette commande
                    string checkPaymentQuery = "SELECT COUNT(*) FROM Payments WHERE order_id = @orderId";
                    using (var cmd = new MySqlCommand(checkPaymentQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        bool paymentExists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                        
                        if (paymentExists)
                        {
                            throw new Exception($"Un paiement existe déjà pour la commande #{orderId}.");
                        }
                    }
                    
                    // Insérer le paiement (le trigger trg_update_client_debt gère automatiquement la dette)
                    string insertQuery = @"INSERT INTO Payments (order_id, amount, payment_mode) 
                                          VALUES (@orderId, @amount, @mode)";
                    
                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@mode", paymentMode);
                        
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur création paiement: {ex.Message}", ex);
            }
        }
        
        // Méthode pour obtenir les détails d'une commande (pour affichage)
        public static Order GetOrderDetails(int orderId)
        {
            try
            {
                string query = @"
                    SELECT o.*, m.name as menu_name, m.unit_price, 
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
                throw new Exception($"Erreur chargement détails commande: {ex.Message}", ex);
            }
            
            return null;
        }
        
        // Méthode pour obtenir les détails d'un paiement
        public static Payment GetPaymentById(int paymentId)
        {
            try
            {
                string query = @"
                    SELECT p.*, o.*, m.name as menu_name, m.unit_price,
                           CONCAT(c.last_name, ' ', c.first_name) as client_name
                    FROM Payments p
                    JOIN Orders o ON p.order_id = o.order_id
                    JOIN Menus m ON o.menu_id = m.menu_id
                    JOIN Clients c ON o.client_id = c.client_id
                    WHERE p.payment_id = @paymentId";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@paymentId", paymentId);
                        
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Payment
                                {
                                    PaymentId = Convert.ToInt32(reader["payment_id"]),
                                    OrderId = Convert.ToInt32(reader["order_id"]),
                                    Amount = Convert.ToDecimal(reader["amount"]),
                                    PaymentDate = Convert.ToDateTime(reader["payment_date"]),
                                    PaymentMode = reader["payment_mode"].ToString(),
                                    OrderDetails = new Order
                                    {
                                        MenuName = reader["menu_name"].ToString(),
                                        ClientName = reader["client_name"].ToString(),
                                        Quantity = Convert.ToInt32(reader["quantity"]),
                                        UnitPrice = Convert.ToDecimal(reader["unit_price"])
                                    }
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement paiement: {ex.Message}", ex);
            }
            
            return null;
        }
        
        // Méthode pour obtenir tous les paiements
        public static List<Payment> GetAllPayments()
        {
            var payments = new List<Payment>();
            
            try
            {
                string query = @"
                    SELECT p.*, o.*, m.name as menu_name, m.unit_price,
                           CONCAT(c.last_name, ' ', c.first_name) as client_name
                    FROM Payments p
                    JOIN Orders o ON p.order_id = o.order_id
                    JOIN Menus m ON o.menu_id = m.menu_id
                    JOIN Clients c ON o.client_id = c.client_id
                    ORDER BY p.payment_date DESC";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            payments.Add(new Payment
                            {
                                PaymentId = Convert.ToInt32(reader["payment_id"]),
                                OrderId = Convert.ToInt32(reader["order_id"]),
                                Amount = Convert.ToDecimal(reader["amount"]),
                                PaymentDate = Convert.ToDateTime(reader["payment_date"]),
                                PaymentMode = reader["payment_mode"].ToString(),
                                OrderDetails = new Order
                                {
                                    MenuName = reader["menu_name"].ToString(),
                                    ClientName = reader["client_name"].ToString(),
                                    Quantity = Convert.ToInt32(reader["quantity"]),
                                    UnitPrice = Convert.ToDecimal(reader["unit_price"])
                                }
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement paiements: {ex.Message}", ex);
            }
            
            return payments;
        }
        
        // Méthode pour obtenir les paiements par date
        public static List<Payment> GetPaymentsByDate(DateTime date)
        {
            var payments = new List<Payment>();
            
            try
            {
                string query = @"
                    SELECT p.*, o.*, m.name as menu_name, m.unit_price,
                           CONCAT(c.last_name, ' ', c.first_name) as client_name
                    FROM Payments p
                    JOIN Orders o ON p.order_id = o.order_id
                    JOIN Menus m ON o.menu_id = m.menu_id
                    JOIN Clients c ON o.client_id = c.client_id
                    WHERE DATE(p.payment_date) = @date
                    ORDER BY p.payment_date DESC";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", date.Date);
                        
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                payments.Add(new Payment
                                {
                                    PaymentId = Convert.ToInt32(reader["payment_id"]),
                                    OrderId = Convert.ToInt32(reader["order_id"]),
                                    Amount = Convert.ToDecimal(reader["amount"]),
                                    PaymentDate = Convert.ToDateTime(reader["payment_date"]),
                                    PaymentMode = reader["payment_mode"].ToString(),
                                    OrderDetails = new Order
                                    {
                                        MenuName = reader["menu_name"].ToString(),
                                        ClientName = reader["client_name"].ToString(),
                                        Quantity = Convert.ToInt32(reader["quantity"]),
                                        UnitPrice = Convert.ToDecimal(reader["unit_price"])
                                    }
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement paiements par date: {ex.Message}", ex);
            }
            
            return payments;
        }
        
        // Méthode pour obtenir le total des paiements par jour
        public static decimal GetDailyPaymentsTotal(DateTime date)
        {
            try
            {
                string query = "SELECT COALESCE(SUM(amount), 0) FROM Payments WHERE DATE(payment_date) = @date";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", date.Date);
                        var result = cmd.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur calcul total paiements: {ex.Message}", ex);
            }
        }
        
        // Méthode pour supprimer un paiement
        public static int DeletePayment(int paymentId)
        {
            try
            {
                string query = "DELETE FROM Payments WHERE payment_id = @id";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", paymentId);
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur suppression paiement: {ex.Message}", ex);
            }
        }
        
        // Méthode pour vérifier si une commande est déjà payée
        public static bool IsOrderPaid(int orderId)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Payments WHERE order_id = @orderId";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur vérification paiement commande: {ex.Message}", ex);
            }
        }
        
        // Méthode pour obtenir le montant déjà payé pour une commande
        public static decimal GetAmountPaidForOrder(int orderId)
        {
            try
            {
                string query = "SELECT COALESCE(SUM(amount), 0) FROM Payments WHERE order_id = @orderId";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        var result = cmd.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur calcul montant payé: {ex.Message}", ex);
            }
        }
        
         // Méthode pour obtenir un DataTable formaté pour l'affichage
        public static DataTable GetPaymentsDataTable(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            
            try
            {
                string query = @"
                    SELECT 
                        p.payment_id as 'ID',
                        p.order_id as 'Commande',
                        FORMAT(p.amount, 2) as 'Montant (HTG)',
                        DATE_FORMAT(p.payment_date, '%d/%m/%Y %H:%i') as 'Date',
                        p.payment_mode as 'Mode paiement'
                    FROM Payments p
                    WHERE DATE(p.payment_date) BETWEEN @fromDate AND @toDate
                    ORDER BY p.payment_date DESC";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fromDate", fromDate.Date);
                        cmd.Parameters.AddWithValue("@toDate", toDate.Date);
                        
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement DataTable paiements: {ex.Message}", ex);
            }
            
            return dt;
        }
        
        // Méthode pour obtenir le total des paiements sur une période
        public static decimal GetTotalPaymentsByPeriod(DateTime fromDate, DateTime toDate)
        {
            try
            {
                string query = @"
                    SELECT COALESCE(SUM(amount), 0) 
                    FROM Payments 
                    WHERE DATE(payment_date) BETWEEN @fromDate AND @toDate";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fromDate", fromDate.Date);
                        cmd.Parameters.AddWithValue("@toDate", toDate.Date);
                        
                        var result = cmd.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur calcul total paiements période: {ex.Message}", ex);
            }
        }
        
        // Méthode pour obtenir le total par mode de paiement
        public static decimal GetPaymentsByModeTotal(string paymentMode, DateTime fromDate, DateTime toDate)
        {
            try
            {
                string query = @"
                    SELECT COALESCE(SUM(amount), 0) 
                    FROM Payments 
                    WHERE payment_mode = @mode 
                      AND DATE(payment_date) BETWEEN @fromDate AND @toDate";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@mode", paymentMode);
                        cmd.Parameters.AddWithValue("@fromDate", fromDate.Date);
                        cmd.Parameters.AddWithValue("@toDate", toDate.Date);
                        
                        var result = cmd.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur calcul total par mode paiement: {ex.Message}", ex);
            }
        }
        
        // Méthode pour obtenir les statistiques détaillées des paiements
        public static DataTable GetPaymentStatistics(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            
            try
            {
                string query = @"
                    SELECT 
                        DATE(p.payment_date) as 'Date',
                        COUNT(*) as 'Nb Paiements',
                        FORMAT(SUM(p.amount), 2) as 'Total HTG',
                        SUM(CASE WHEN p.payment_mode = 'cash' THEN p.amount ELSE 0 END) as 'Espèces',
                        SUM(CASE WHEN p.payment_mode = 'card' THEN p.amount ELSE 0 END) as 'Carte',
                        SUM(CASE WHEN p.payment_mode = 'cheque' THEN p.amount ELSE 0 END) as 'Chèque'
                    FROM Payments p
                    WHERE DATE(p.payment_date) BETWEEN @fromDate AND @toDate
                    GROUP BY DATE(p.payment_date)
                    ORDER BY DATE(p.payment_date) DESC";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fromDate", fromDate.Date);
                        cmd.Parameters.AddWithValue("@toDate", toDate.Date);
                        
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement statistiques paiements: {ex.Message}", ex);
            }
            
            return dt;
        }
        
        // Méthode pour obtenir les paiements non liés à une commande (pour vérification)
        public static DataTable GetOrphanedPayments()
        {
            DataTable dt = new DataTable();
            
            try
            {
                string query = @"
                    SELECT 
                        p.payment_id as 'ID',
                        p.order_id as 'Commande',
                        FORMAT(p.amount, 2) as 'Montant (HTG)',
                        DATE_FORMAT(p.payment_date, '%d/%m/%Y %H:%i') as 'Date',
                        p.payment_mode as 'Mode paiement'
                    FROM Payments p
                    LEFT JOIN Orders o ON p.order_id = o.order_id
                    WHERE o.order_id IS NULL
                    ORDER BY p.payment_date DESC";
                
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
                throw new Exception($"Erreur chargement paiements orphelins: {ex.Message}", ex);
            }
            
            return dt;
        }
        
        // Méthode pour obtenir les commandes non payées
        public static DataTable GetUnpaidOrders()
        {
            DataTable dt = new DataTable();
            
            try
            {
                string query = @"
                    SELECT 
                        o.order_id as 'ID',
                        CONCAT(c.first_name, ' ', c.last_name) as 'Client',
                        DATE_FORMAT(o.order_date, '%d/%m/%Y %H:%i') as 'Date',
                        FORMAT(m.unit_price * o.quantity, 2) as 'Montant (HTG)',
                        o.status as 'Statut'
                    FROM Orders o
                    JOIN Menus m ON o.menu_id = m.menu_id
                    JOIN Clients c ON o.client_id = c.client_id
                    LEFT JOIN Payments p ON o.order_id = p.order_id
                    WHERE p.payment_id IS NULL
                    ORDER BY o.order_date DESC";
                
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
                throw new Exception($"Erreur chargement commandes non payées: {ex.Message}", ex);
            }
            
            return dt;
        }
        
        // Méthode pour obtenir le montant total des paiements par jour
        public static Dictionary<DateTime, decimal> GetDailyPayments(DateTime fromDate, DateTime toDate)
        {
            var dailyPayments = new Dictionary<DateTime, decimal>();
            
            try
            {
                string query = @"
                    SELECT DATE(payment_date) as payment_date, 
                           SUM(amount) as total
                    FROM Payments
                    WHERE DATE(payment_date) BETWEEN @fromDate AND @toDate
                    GROUP BY DATE(payment_date)
                    ORDER BY DATE(payment_date)";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fromDate", fromDate.Date);
                        cmd.Parameters.AddWithValue("@toDate", toDate.Date);
                        
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime date = Convert.ToDateTime(reader["payment_date"]);
                                decimal total = Convert.ToDecimal(reader["total"]);
                                dailyPayments[date] = total;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement paiements journaliers: {ex.Message}", ex);
            }
            
            return dailyPayments;
        }
    }
}