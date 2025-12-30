using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using POS_RESTO.Configuration;
using POS_RESTO.Forms;

namespace POS_RESTO.Views
{
    public partial class ClientsUserControl : UserControl
    {
        public ClientsUserControl()
        {
            InitializeComponent();
            LoadClients();
        }
        
        private void LoadClients()
        {
            try
            {
                lblStatus.Text = "Chargement en cours...";
                dgvClients.DataSource = null;
                
                string query = @"SELECT 
                                    client_id as 'ID',
                                    last_name as 'Nom',
                                    first_name as 'Prenom',
                                    phone as 'Telephone',
                                    email as 'Email',
                                    debt_amount as 'Dette HTG'
                                FROM Clients 
                                WHERE 1=1";
                
                if (!string.IsNullOrEmpty(txtSearch.Text))
                {
                    query += $" AND (last_name LIKE '%{txtSearch.Text}%' OR first_name LIKE '%{txtSearch.Text}%' OR phone LIKE '%{txtSearch.Text}%')";
                }
                
                query += " ORDER BY last_name, first_name";
                
                using (var conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        
                        if (dt.Columns.Contains("Dette HTG"))
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                if (row["Dette HTG"] != DBNull.Value)
                                {
                                    decimal dette = Convert.ToDecimal(row["Dette HTG"]);
                                    row["Dette HTG"] = $"{dette:N0} HTG";
                                }
                            }
                        }
                        
                        dgvClients.DataSource = dt;
                        
                        if (dgvClients.Columns.Contains("Dette HTG"))
                        {
                            dgvClients.Columns["Dette HTG"].DefaultCellStyle.Alignment = 
                                DataGridViewContentAlignment.MiddleRight;
                            
                            dgvClients.CellFormatting += (sender, e) =>
                            {
                                if (e.ColumnIndex == dgvClients.Columns["Dette HTG"].Index && e.Value != null)
                                {
                                    string value = e.Value.ToString();
                                    if (value.Contains("HTG"))
                                    {
                                        string numStr = value.Replace(" HTG", "").Replace(" ", "");
                                        if (decimal.TryParse(numStr, out decimal dette) && dette > 0)
                                        {
                                            e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69);
                                            e.CellStyle.Font = new Font(dgvClients.Font, FontStyle.Bold);
                                        }
                                    }
                                }
                            };
                        }
                        
                        dgvClients.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                        
                        if (dgvClients.Columns.Contains("ID"))
                        {
                            dgvClients.Columns["ID"].Visible = false;
                        }
                        
                        lblStatus.Text = $"{dt.Rows.Count} clients trouvés";
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Erreur de chargement";
                MessageBox.Show($"Erreur chargement clients: {ex.Message}", 
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnAddClient_Click(object sender, EventArgs e)
        {
            var clientForm = new ClientForm();
            if (clientForm.ShowDialog() == DialogResult.OK)
            {
                LoadClients();
            }
        }
        
        private void BtnEditClient_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez selectionner un client a modifier", 
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            DataGridViewRow selectedRow = dgvClients.SelectedRows[0];
            var rowView = selectedRow.DataBoundItem as DataRowView;
            
            if (rowView != null)
            {
                int clientId = Convert.ToInt32(rowView["ID"]);
                var clientForm = new ClientForm(clientId);
                if (clientForm.ShowDialog() == DialogResult.OK)
                {
                    LoadClients();
                }
            }
            else
            {
                if (dgvClients.Columns.Contains("ID") && selectedRow.Cells["ID"].Value != null)
                {
                    int clientId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                    var clientForm = new ClientForm(clientId);
                    if (clientForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadClients();
                    }
                }
            }
        }
        
        private void BtnDeleteClient_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez selectionner un client a supprimer", 
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            DataGridViewRow selectedRow = dgvClients.SelectedRows[0];
            var rowView = selectedRow.DataBoundItem as DataRowView;
            
            if (rowView != null)
            {
                int clientId = Convert.ToInt32(rowView["ID"]);
                string clientName = $"{rowView["Prenom"]} {rowView["Nom"]}";
                
                if (MessageBox.Show($"Voulez-vous vraiment supprimer le client '{clientName}' ?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM Clients WHERE client_id = @id";
                        
                        using (var conn = DatabaseConfig.GetConnection())
                        {
                            conn.Open();
                            
                            using (var cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", clientId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        
                        LoadClients();
                        MessageBox.Show("Client supprime avec succes", 
                            "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur suppression: {ex.Message}\n\n" +
                                      "Le client ne peut pas etre supprime s'il a des commandes associees.", 
                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadClients();
        }
        
        public void RefreshData()
        {
            LoadClients();
        }
    }
}