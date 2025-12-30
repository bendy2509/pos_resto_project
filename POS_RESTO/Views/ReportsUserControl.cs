using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using POS_RESTO.Configuration;

namespace POS_RESTO.Views
{
    public partial class ReportsUserControl : UserControl
    {
        public ReportsUserControl()
        {
            InitializeComponent();
        }
        
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                dgvReport.DataSource = null;
                decimal total = 0;
                
                string query = GetReportQuery();
                
                using (var conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@from", dtpFrom.Value.Date);
                        cmd.Parameters.AddWithValue("@to", dtpTo.Value.Date);
                        
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);
                            
                            if (dt.Columns.Contains("Total HTG"))
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    if (decimal.TryParse(row["Total HTG"].ToString(), out decimal rowTotal))
                                    {
                                        total += rowTotal;
                                    }
                                }
                            }
                            
                            dgvReport.DataSource = dt;
                            lblTotal.Text = $"Total: {total:N0} HTG";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur generation rapport: {ex.Message}");
            }
        }
        
        private string GetReportQuery()
        {
            return cmbReportType.SelectedIndex switch
            {
                0 => @"SELECT DATE(o.order_date) as Date,
                              COUNT(*) as 'Nb Commandes',
                              SUM(m.unit_price * o.quantity) as 'Total HTG'
                       FROM Orders o
                       JOIN Menus m ON o.menu_id = m.menu_id
                       WHERE DATE(o.order_date) BETWEEN @from AND @to
                       GROUP BY DATE(o.order_date)
                       ORDER BY Date DESC",
                
                1 => @"SELECT m.category as Categorie,
                              COUNT(*) as 'Nb Ventes',
                              SUM(m.unit_price * o.quantity) as 'Total HTG'
                       FROM Orders o
                       JOIN Menus m ON o.menu_id = m.menu_id
                       WHERE DATE(o.order_date) BETWEEN @from AND @to
                       GROUP BY m.category
                       ORDER BY 'Total HTG' DESC",
                
                2 => @"SELECT m.name as Menu,
                              m.category as Categorie,
                              SUM(o.quantity) as 'Quantite Vendue',
                              SUM(m.unit_price * o.quantity) as 'Total HTG'
                       FROM Orders o
                       JOIN Menus m ON o.menu_id = m.menu_id
                       WHERE DATE(o.order_date) BETWEEN @from AND @to
                       GROUP BY m.menu_id, m.name, m.category
                       ORDER BY 'Quantite Vendue' DESC
                       LIMIT 10",
                
                3 => @"SELECT c.first_name as Prenom,
                              c.last_name as Nom,
                              c.phone as Telephone,
                              c.debt_amount as 'Dette HTG'
                       FROM Clients c
                       WHERE c.debt_amount > 0
                       ORDER BY c.debt_amount DESC",
                
                4 => @"SELECT p.payment_mode as 'Mode Paiement',
                              COUNT(*) as 'Nb Transactions',
                              SUM(p.amount) as 'Total HTG'
                       FROM Payments p
                       WHERE DATE(p.payment_date) BETWEEN @from AND @to
                       GROUP BY p.payment_mode
                       ORDER BY 'Total HTG' DESC",
                
                _ => "SELECT 'Rapport non disponible' as Message"
            };
        }
        
        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (dgvReport.Rows.Count == 0)
            {
                MessageBox.Show("Aucune donnee a exporter");
                return;
            }
            
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Fichier CSV (*.csv)|*.csv|Fichier Excel (*.xlsx)|*.xlsx";
                    sfd.FileName = $"Rapport_{DateTime.Now:yyyyMMdd_HHmmss}";
                    
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName))
                        {
                            for (int i = 0; i < dgvReport.Columns.Count; i++)
                            {
                                sw.Write(dgvReport.Columns[i].HeaderText);
                                if (i < dgvReport.Columns.Count - 1)
                                    sw.Write(",");
                            }
                            sw.WriteLine();
                            
                            foreach (DataGridViewRow row in dgvReport.Rows)
                            {
                                for (int i = 0; i < dgvReport.Columns.Count; i++)
                                {
                                    sw.Write(row.Cells[i].Value?.ToString() ?? "");
                                    if (i < dgvReport.Columns.Count - 1)
                                        sw.Write(",");
                                }
                                sw.WriteLine();
                            }
                        }
                        
                        MessageBox.Show($"Rapport exporte vers: {sfd.FileName}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur export: {ex.Message}");
            }
        }
    }
}