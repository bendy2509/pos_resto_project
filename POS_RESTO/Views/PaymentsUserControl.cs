using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using POS_RESTO.Data;
using POS_RESTO.Forms;

namespace POS_RESTO.Views
{
    public partial class PaymentsUserControl : UserControl
    {
        public PaymentsUserControl()
        {
            InitializeComponent();
            LoadPayments();
        }

        private void LoadPayments()
        {
            try
            {
                DateTime fromDate = dtpFrom.Value.Date;
                DateTime toDate = dtpTo.Value.Date;
                
                // Utiliser le DAO pour charger les paiements
                var dt = PaymentDao.GetPaymentsDataTable(fromDate, toDate);
                dgvPayments.DataSource = dt;
                
                // Formater les colonnes
                FormatDataGridView();
                
                // Calculer et afficher les statistiques
                UpdateStatistics(fromDate, toDate);
            }
            catch (Exception ex)
            {
                // MessageBox.Show($"Erreur chargement paiements: {ex.Message}", "Erreur",
                //     MessageBoxButtons.OK, MessageBoxIcon.Error);
                // lblStatus.Text = "Erreur de chargement";
                
                // Dans la console pour debug
                Console.WriteLine($"Erreur chargement données: {ex.Message}");
            }
        }

        private void FormatDataGridView()
        {
            if (dgvPayments.Columns.Count > 0)
            {
                // Masquer la colonne ID
                if (dgvPayments.Columns.Contains("ID"))
                {
                    dgvPayments.Columns["ID"].Visible = false;
                    dgvPayments.Columns["ID"].Width = 0;
                }
                
                // Formater les colonnes
                if (dgvPayments.Columns.Contains("Montant (HTG)"))
                {
                    dgvPayments.Columns["Montant (HTG)"].DefaultCellStyle.Alignment = 
                        DataGridViewContentAlignment.MiddleRight;
                    
                    // Colorer selon le mode de paiement
                    dgvPayments.CellFormatting += (sender, e) =>
                    {
                        if (e.ColumnIndex == dgvPayments.Columns["Montant (HTG)"].Index && e.Value != null)
                        {
                            e.CellStyle.ForeColor = Color.FromArgb(40, 167, 69); // Vert
                            e.CellStyle.Font = new Font(dgvPayments.Font, FontStyle.Bold);
                        }
                    };
                }
                
                if (dgvPayments.Columns.Contains("Date"))
                {
                    dgvPayments.Columns["Date"].Width = 150;
                }
                
                if (dgvPayments.Columns.Contains("Mode paiement"))
                {
                    dgvPayments.Columns["Mode paiement"].Width = 100;
                    
                    // Colorer selon le mode de paiement
                    dgvPayments.CellFormatting += DgvPayments_CellFormatting;
                }
                
                // Ajuster automatiquement les colonnes
                dgvPayments.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        private void UpdateStatistics(DateTime fromDate, DateTime toDate)
        {
            try
            {
                // Calculer les statistiques
                decimal totalPayments = PaymentDao.GetTotalPaymentsByPeriod(fromDate, toDate);
                decimal cashPayments = PaymentDao.GetPaymentsByModeTotal("cash", fromDate, toDate);
                decimal cardPayments = PaymentDao.GetPaymentsByModeTotal("card", fromDate, toDate);
                decimal chequePayments = PaymentDao.GetPaymentsByModeTotal("cheque", fromDate, toDate);
                
                // Afficher les statistiques
                lblTotalAmount.Text = $"Total: {totalPayments:N0} HTG";
                lblCashAmount.Text = $"Espèces: {cashPayments:N0} HTG";
                lblCardAmount.Text = $"Carte: {cardPayments:N0} HTG";
                lblChequeAmount.Text = $"Chèque: {chequePayments:N0} HTG";
                
                // Mettre à jour le statut
                lblStatus.Text = $"{dgvPayments.Rows.Count} paiements trouvés";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur calcul statistiques: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvPayments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Formattage du mode de paiement
                if (dgvPayments.Columns[e.ColumnIndex].Name == "Mode paiement" && e.Value != null)
                {
                    string mode = e.Value.ToString().ToLower();
                    
                    switch (mode)
                    {
                        case "cash":
                            e.CellStyle.ForeColor = Color.FromArgb(40, 167, 69); // Vert
                            break;
                            
                        case "card":
                            e.CellStyle.ForeColor = Color.FromArgb(0, 123, 255); // Bleu
                            break;
                            
                        case "cheque":
                            e.CellStyle.ForeColor = Color.FromArgb(255, 193, 7); // Orange
                            break;
                    }
                    
                    e.CellStyle.Font = new Font(dgvPayments.Font, FontStyle.Bold);
                }
            }
        }

        private void BtnNewPayment_Click(object sender, EventArgs e)
        {
            var paymentForm = new PaymentForm();
            if (paymentForm.ShowDialog() == DialogResult.OK)
            {
                LoadPayments();
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadPayments();
        }

        private void DateFilter_Changed(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("La date 'Du' ne peut pas être après la date 'Au'", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFrom.Value = dtpTo.Value.AddDays(-7);
                return;
            }
            
            LoadPayments();
        }

        private void BtnToday_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
            LoadPayments();
        }

        private void BtnThisWeek_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
            dtpFrom.Value = today.AddDays(-diff);
            dtpTo.Value = today;
            LoadPayments();
        }

        private void BtnThisMonth_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            dtpFrom.Value = new DateTime(today.Year, today.Month, 1);
            dtpTo.Value = today;
            LoadPayments();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void DgvPayments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                ShowPaymentDetails();
            }
        }

        private void ShowPaymentDetails()
        {
            if (dgvPayments.SelectedRows.Count > 0)
            {
                try
                {
                    int paymentId = GetSelectedPaymentId();
                    
                    if (paymentId > 0)
                    {
                        var payment = PaymentDao.GetPaymentById(paymentId);
                        if (payment != null)
                        {
                            string message = $"Détails du paiement #{paymentId}\n\n" +
                                           $"Commande: #{payment.OrderId}\n" +
                                           $"Montant: {payment.Amount:N0} HTG\n" +
                                           $"Mode: {payment.PaymentMode}\n" +
                                           $"Date: {payment.PaymentDate:dd/MM/yyyy HH:mm}";
                            
                            MessageBox.Show(message, "Détails paiement",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur affichage détails: {ex.Message}", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int GetSelectedPaymentId()
        {
            if (dgvPayments.SelectedRows.Count > 0)
            {
                var selectedRow = dgvPayments.SelectedRows[0];
                
                if (selectedRow.DataBoundItem is DataRowView rowView)
                {
                    if (rowView["ID"] != DBNull.Value)
                    {
                        return Convert.ToInt32(rowView["ID"]);
                    }
                }
                
                if (dgvPayments.Columns.Contains("ID") && 
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
            if (dgvPayments.Rows.Count == 0)
            {
                MessageBox.Show("Aucune donnée à exporter", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Fichier CSV (*.csv)|*.csv|Fichier Excel (*.xlsx)|*.xlsx";
                    sfd.FileName = $"Paiements_{DateTime.Now:yyyyMMdd_HHmmss}";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName))
                        {
                            // En-têtes
                            for (int i = 0; i < dgvPayments.Columns.Count; i++)
                            {
                                if (dgvPayments.Columns[i].Visible)
                                {
                                    sw.Write(dgvPayments.Columns[i].HeaderText);
                                    if (i < dgvPayments.Columns.Count - 1)
                                        sw.Write(";");
                                }
                            }
                            sw.WriteLine();

                            // Données
                            foreach (DataGridViewRow row in dgvPayments.Rows)
                            {
                                for (int i = 0; i < dgvPayments.Columns.Count; i++)
                                {
                                    if (dgvPayments.Columns[i].Visible)
                                    {
                                        sw.Write(row.Cells[i].Value?.ToString() ?? "");
                                        if (i < dgvPayments.Columns.Count - 1)
                                            sw.Write(";");
                                    }
                                }
                                sw.WriteLine();
                            }
                        }

                        MessageBox.Show($"Données exportées vers: {sfd.FileName}", "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur export: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshData()
        {
            LoadPayments();
        }
    }
}