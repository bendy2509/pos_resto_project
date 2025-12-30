using System;
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
            SetupDataGridViewColumns();
            LoadOrders();
        }
        
        private void SetupDataGridViewColumns()
        {
            // Créer les colonnes
            var colId = new DataGridViewTextBoxColumn();
            colId.Name = "ID";
            colId.HeaderText = "ID";
            colId.Width = 50;
            
            var colClient = new DataGridViewTextBoxColumn();
            colClient.Name = "Client";
            colClient.HeaderText = "Client";
            colClient.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
            var colDate = new DataGridViewTextBoxColumn();
            colDate.Name = "Date";
            colDate.HeaderText = "Date";
            colDate.Width = 150;
            
            var colStatut = new DataGridViewTextBoxColumn();
            colStatut.Name = "Statut";
            colStatut.HeaderText = "Statut";
            colStatut.Width = 100;
            
            var colTotal = new DataGridViewTextBoxColumn();
            colTotal.Name = "Total";
            colTotal.HeaderText = "Total HTG";
            colTotal.Width = 120;
            colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            // Ajouter les colonnes
            dgvOrders.Columns.AddRange(new DataGridViewColumn[] {
                colId, colClient, colDate, colStatut, colTotal
            });
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
                                 WHERE 1=1";
                
                // Appliquer le filtre de statut si sélectionné
                if (cmbFilterStatus.SelectedIndex > 0)
                {
                    string statusFilter = cmbFilterStatus.SelectedItem.ToString();
                    query += $" AND o.status = '{statusFilter}'";
                }
                
                query += @" GROUP BY o.order_id, o.order_date, c.first_name, c.last_name, o.status
                           ORDER BY o.order_date DESC";
                
                using (var conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null)
                    {
                        MessageBox.Show("Erreur de connexion à la base de données", 
                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            object orderId = reader["order_id"];
                            object client = reader["client"];
                            object orderDate = reader["order_date"];
                            object statut = reader["statut"];
                            object total = reader["total"];
                            
                            string dateString = "";
                            if (orderDate != DBNull.Value)
                            {
                                dateString = Convert.ToDateTime(orderDate).ToString("dd/MM/yyyy HH:mm");
                            }
                            
                            string totalString = "0 HTG";
                            if (total != DBNull.Value)
                            {
                                decimal totalValue = Convert.ToDecimal(total);
                                totalString = $"{totalValue:N0} HTG";
                            }
                            
                            dgvOrders.Rows.Add(
                                orderId,
                                client ?? "",
                                dateString,
                                statut ?? "En cours",
                                totalString
                            );
                        }
                    }
                }
                
                lblStatus.Text = $"{dgvOrders.Rows.Count} commandes trouvées";
            }
            catch (MySqlException mysqlex)
            {
                MessageBox.Show($"Erreur base de données: {mysqlex.Message}", 
                    "Erreur BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement commandes: {ex.Message}", 
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnNewOrder_Click(object sender, EventArgs e)
        {
            try
            {
                var orderForm = new OrderForm();
                if (orderForm.ShowDialog() == DialogResult.OK)
                {
                    LoadOrders();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur ouverture formulaire commande: {ex.Message}", 
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        
        // Méthode pour rafraîchir manuellement
        public void RefreshData()
        {
            LoadOrders();
        }
        
        // Méthode pour formater les cellules selon le statut
        private void DgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvOrders.Columns[e.ColumnIndex].Name == "Statut" && e.Value != null)
            {
                string status = e.Value.ToString();
                
                switch (status.ToLower())
                {
                    case "en cours":
                        e.CellStyle.ForeColor = Color.FromArgb(255, 193, 7); // Orange
                        e.CellStyle.Font = new Font(dgvOrders.Font, FontStyle.Bold);
                        break;
                        
                    case "prête":
                        e.CellStyle.ForeColor = Color.FromArgb(0, 123, 255); // Bleu
                        e.CellStyle.Font = new Font(dgvOrders.Font, FontStyle.Bold);
                        break;
                        
                    case "servie":
                        e.CellStyle.ForeColor = Color.FromArgb(40, 167, 69); // Vert
                        break;
                        
                    case "annulée":
                        e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69); // Rouge
                        e.CellStyle.Font = new Font(dgvOrders.Font, FontStyle.Strikeout);
                        break;
                }
            }
            
            if (dgvOrders.Columns[e.ColumnIndex].Name == "Total" && e.Value != null)
            {
                e.CellStyle.ForeColor = Color.FromArgb(33, 37, 41); // Gris foncé
                e.CellStyle.Font = new Font(dgvOrders.Font, FontStyle.Bold);
            }
        }
        
        // Gestion du double-clic sur une ligne
        private void DgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Récupérer l'ID de la commande
                object orderIdValue = dgvOrders.Rows[e.RowIndex].Cells["ID"].Value;
                
                if (orderIdValue != null && int.TryParse(orderIdValue.ToString(), out int orderId))
                {
                    // Ouvrir le formulaire de modification
                    var orderForm = new OrderForm();
                    if (orderForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadOrders();
                    }
                }
            }
        }
        
        // Méthode pour exporter les commandes
        private void ExportToExcel()
        {
            if (dgvOrders.Rows.Count == 0)
            {
                MessageBox.Show("Aucune donnée à exporter", 
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Fichier CSV (*.csv)|*.csv|Fichier Excel (*.xlsx)|*.xlsx";
                    sfd.FileName = $"Commandes_{DateTime.Now:yyyyMMdd_HHmmss}";
                    
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName))
                        {
                            // En-têtes
                            for (int i = 0; i < dgvOrders.Columns.Count; i++)
                            {
                                sw.Write(dgvOrders.Columns[i].HeaderText);
                                if (i < dgvOrders.Columns.Count - 1)
                                    sw.Write(";");
                            }
                            sw.WriteLine();
                            
                            // Données
                            foreach (DataGridViewRow row in dgvOrders.Rows)
                            {
                                for (int i = 0; i < dgvOrders.Columns.Count; i++)
                                {
                                    sw.Write(row.Cells[i].Value?.ToString() ?? "");
                                    if (i < dgvOrders.Columns.Count - 1)
                                        sw.Write(";");
                                }
                                sw.WriteLine();
                            }
                        }
                        
                        MessageBox.Show($"Données exportées vers: {sfd.FileName}", 
                            "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur export: {ex.Message}", 
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}