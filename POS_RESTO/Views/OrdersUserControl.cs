using System;
using System.Drawing;
using System.Windows.Forms;
using POS_RESTO.Data;
using POS_RESTO.Forms;
using Timer = System.Windows.Forms.Timer;

namespace POS_RESTO.Views
{
    public partial class OrdersUserControl : UserControl
    {
        public OrdersUserControl()
        {
            InitializeComponent();
            LoadOrders();
        }
        
        private void LoadOrders()
        {
            try
            {
                string statusFilter = cmbFilterStatus.SelectedIndex > 0 
                    ? cmbFilterStatus.SelectedItem.ToString() 
                    : null;
                
                DateTime? dateFilter = dateFilterPicker.Value.Date != DateTimePicker.MinimumDateTime 
                    ? dateFilterPicker.Value.Date 
                    : (DateTime?)null;
                
                // Utiliser le DAO pour charger les données
                var dt = OrderDao.GetOrdersDataTable(statusFilter, dateFilter);
                dgvOrders.DataSource = dt;
                
                // Formater les colonnes
                FormatDataGridView();
                
                // Mettre à jour le statut
                UpdateStatusLabel(dt.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement commandes: {ex.Message}", 
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Erreur de chargement";
            }
        }
        
        private void FormatDataGridView()
        {
            if (dgvOrders.Columns.Count > 0)
            {
                // Masquer l'ID
                if (dgvOrders.Columns.Contains("ID"))
                {
                    dgvOrders.Columns["ID"].Visible = false;
                }
                
                // Formater les colonnes
                if (dgvOrders.Columns.Contains("Date"))
                {
                    dgvOrders.Columns["Date"].Width = 150;
                }
                
                if (dgvOrders.Columns.Contains("Statut"))
                {
                    dgvOrders.Columns["Statut"].Width = 100;
                }
                
                if (dgvOrders.Columns.Contains("Total HTG"))
                {
                    dgvOrders.Columns["Total HTG"].Width = 120;
                    dgvOrders.Columns["Total HTG"].DefaultCellStyle.Alignment = 
                        DataGridViewContentAlignment.MiddleRight;
                }
                
                // Ajuster automatiquement les autres colonnes
                dgvOrders.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                
                // Formattage des cellules
                dgvOrders.CellFormatting += DgvOrders_CellFormatting;
            }
        }
        
        private void UpdateStatusLabel(int rowCount)
        {
            decimal totalAmount = 0;
            
            if (dgvOrders.Rows.Count > 0 && dgvOrders.Columns.Contains("Total HTG"))
            {
                foreach (DataGridViewRow row in dgvOrders.Rows)
                {
                    if (row.Cells["Total HTG"].Value != null)
                    {
                        string totalStr = row.Cells["Total HTG"].Value.ToString();
                        if (decimal.TryParse(totalStr.Replace(" HTG", "").Replace(" ", "").Replace(",", ""), 
                            out decimal amount))
                        {
                            totalAmount += amount;
                        }
                    }
                }
            }
            
            lblStatus.Text = $"{rowCount} commandes trouvées | Total: {totalAmount:N0} HTG";
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
        
        private void DateFilterPicker_ValueChanged(object sender, EventArgs e)
        {
            if (!dateFilterPicker.Checked)
            {
                dateFilterPicker.Value = DateTimePicker.MinimumDateTime;
            }
            LoadOrders();
        }
        
        private void BtnClearFilters_Click(object sender, EventArgs e)
        {
            cmbFilterStatus.SelectedIndex = 0;
            dateFilterPicker.Checked = false;
            dateFilterPicker.Value = DateTimePicker.MinimumDateTime;
            LoadOrders();
        }
        
        private void BtnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une commande", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            try
            {
                int orderId = GetSelectedOrderId();
                
                if (orderId > 0)
                {
                    var statusForm = new OrderStatusForm(orderId);
                    if (statusForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadOrders();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur mise à jour statut: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une commande", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            try
            {
                int orderId = GetSelectedOrderId();
                
                if (orderId > 0)
                {
                    var detailsForm = new OrderDetailsForm(orderId);
                    detailsForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur affichage détails: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        
        private void DgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Formattage du statut
                if (dgvOrders.Columns[e.ColumnIndex].Name == "Statut" && e.Value != null)
                {
                    string status = e.Value.ToString().ToLower();
                    
                    switch (status)
                    {
                        case "en cours":
                            e.CellStyle.ForeColor = Color.FromArgb(255, 193, 7); // Orange
                            e.CellStyle.Font = new Font(dgvOrders.Font, FontStyle.Bold);
                            break;
                            
                        case "terminee":
                            e.CellStyle.ForeColor = Color.FromArgb(40, 167, 69); // Vert
                            e.CellStyle.Font = new Font(dgvOrders.Font, FontStyle.Bold);
                            break;
                            
                        case "annulee":
                            e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69); // Rouge
                            e.CellStyle.Font = new Font(dgvOrders.Font, FontStyle.Strikeout);
                            break;
                    }
                }
                
                // Formattage du total
                if (dgvOrders.Columns[e.ColumnIndex].Name == "Total HTG" && e.Value != null)
                {
                    e.CellStyle.ForeColor = Color.FromArgb(33, 37, 41); // Gris foncé
                    e.CellStyle.Font = new Font(dgvOrders.Font, FontStyle.Bold);
                }
            }
        }
        
        private void DgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                BtnViewDetails_Click(sender, e);
            }
        }
        
        private void DgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            UpdateActionButtons();
        }
        
        private void UpdateActionButtons()
        {
            bool hasSelection = dgvOrders.SelectedRows.Count > 0;
            btnUpdateStatus.Enabled = hasSelection;
            btnViewDetails.Enabled = hasSelection;
        }
        
        private int GetSelectedOrderId()
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                var selectedRow = dgvOrders.SelectedRows[0];
                
                if (selectedRow.DataBoundItem is System.Data.DataRowView rowView)
                {
                    if (rowView["ID"] != DBNull.Value)
                    {
                        return Convert.ToInt32(rowView["ID"]);
                    }
                }
                
                if (dgvOrders.Columns.Contains("ID") && 
                    selectedRow.Cells["ID"].Value != null && 
                    selectedRow.Cells["ID"].Value != DBNull.Value)
                {
                    return Convert.ToInt32(selectedRow.Cells["ID"].Value);
                }
            }
            
            return 0;
        }
        
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
                                if (dgvOrders.Columns[i].Visible)
                                {
                                    sw.Write(dgvOrders.Columns[i].HeaderText);
                                    if (i < dgvOrders.Columns.Count - 1)
                                        sw.Write(";");
                                }
                            }
                            sw.WriteLine();
                            
                            // Données
                            foreach (DataGridViewRow row in dgvOrders.Rows)
                            {
                                for (int i = 0; i < dgvOrders.Columns.Count; i++)
                                {
                                    if (dgvOrders.Columns[i].Visible)
                                    {
                                        sw.Write(row.Cells[i].Value?.ToString() ?? "");
                                        if (i < dgvOrders.Columns.Count - 1)
                                            sw.Write(";");
                                    }
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
        
        public void RefreshData()
        {
            LoadOrders();
        }
    }
}