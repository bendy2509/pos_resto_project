using System;
using System.Drawing;
using System.Windows.Forms;
using POS_RESTO.Data;

namespace POS_RESTO.Forms
{
    public partial class PaymentForm : Form
    {
        private decimal orderTotal = 0;
        private decimal amountPaid = 0;
        private decimal remainingAmount = 0;
        
        public PaymentForm()
        {
            InitializeComponent();
        }
        
        private void NumOrderId_ValueChanged(object sender, EventArgs e)
        {
            if (numOrderId.Value > 0)
            {
                try
                {
                    int orderId = (int)numOrderId.Value;
                    
                    // Obtenir les détails de la commande
                    var order = PaymentDao.GetOrderDetails(orderId);
                    if (order != null)
                    {
                        // Calculer les montants
                        orderTotal = PaymentDao.GetOrderTotal(orderId);
                        amountPaid = PaymentDao.GetAmountPaidForOrder(orderId);
                        remainingAmount = PaymentDao.GetRemainingAmountForOrder(orderId);
                        bool isFullyPaid = PaymentDao.IsOrderFullyPaid(orderId);
                        
                        // Mettre à jour l'interface
                        lblOrderTotal.Text = $"Total commande: {orderTotal:N0} HTG";
                        lblAmountPaid.Text = $"Déjà payé: {amountPaid:N0} HTG";
                        lblRemaining.Text = $"Reste à payer: {remainingAmount:N0} HTG";
                        lblOrderDetails.Text = $"{order.MenuName} x{order.Quantity} - Client: {order.ClientName}";
                        
                        if (isFullyPaid)
                        {
                            lblRemaining.ForeColor = Color.Green;
                            lblRemaining.Text += " (Commande payée)";
                        }
                        else
                        {
                            lblRemaining.ForeColor = Color.Red;
                        }
                        
                        // Configurer le NumericUpDown pour le montant
                        numAmount.Value = remainingAmount > 0 ? remainingAmount : 0;
                        
                        // Afficher l'historique des paiements
                        LoadPaymentHistory(orderId);
                    }
                    else
                    {
                        ClearOrderInfo();
                        MessageBox.Show("Commande non trouvée", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    ClearOrderInfo();
                    MessageBox.Show($"Erreur: {ex.Message}", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ClearOrderInfo();
            }
        }
        
        private void LoadPaymentHistory(int orderId)
        {
            try
            {
                dgvPayments.Rows.Clear();
                dgvPayments.Columns.Clear();
        
                // Créer les colonnes
                dgvPayments.Columns.Add("PaymentId", "ID");
                dgvPayments.Columns.Add("Date", "Date");
                dgvPayments.Columns.Add("Amount", "Montant");
                dgvPayments.Columns.Add("Mode", "Mode");
        
                // Configurer les colonnes
                dgvPayments.Columns["PaymentId"].Width = 50;
                dgvPayments.Columns["Date"].Width = 120;
                dgvPayments.Columns["Amount"].Width = 100;
                dgvPayments.Columns["Mode"].Width = 80;
        
                var payments = PaymentDao.GetPaymentsByOrderId(orderId);
        
                foreach (var payment in payments)
                {
                    dgvPayments.Rows.Add(
                        payment.PaymentId,
                        payment.PaymentDate.ToString("dd/MM/yyyy HH:mm"),
                        payment.Amount.ToString("N0") + " HTG",
                        payment.PaymentMode
                    );
                }
        
                // Ajuster la hauteur du DataGridView selon le nombre de lignes
                int rowHeight = dgvPayments.RowTemplate.Height;
                int headerHeight = dgvPayments.ColumnHeadersHeight;
                int totalHeight = Math.Min(payments.Count * rowHeight + headerHeight + 5, 150);
                dgvPayments.Height = totalHeight;
            }
            catch (Exception ex)
            {
                // Ne pas bloquer l'interface si l'historique ne charge pas
                Console.WriteLine($"Erreur chargement historique: {ex.Message}");
            }
        }
        
        private void ClearOrderInfo()
        {
            lblOrderTotal.Text = "Total commande: -- HTG";
            lblAmountPaid.Text = "Déjà payé: -- HTG";
            lblRemaining.Text = "Reste à payer: -- HTG";
            lblOrderDetails.Text = "";
            dgvPayments.Rows.Clear();
            orderTotal = 0;
            amountPaid = 0;
            remainingAmount = 0;
            numAmount.Value = 0;
        }
        
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (numOrderId.Value <= 0)
            {
                MessageBox.Show("ID commande invalide", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numOrderId.Focus();
                return;
            }
            
            if (numAmount.Value <= 0)
            {
                MessageBox.Show("Montant invalide", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numAmount.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(cmbPaymentMode.Text))
            {
                MessageBox.Show("Veuillez sélectionner un mode de paiement", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPaymentMode.Focus();
                return;
            }
            
            try
            {
                int orderId = (int)numOrderId.Value;
                decimal amount = numAmount.Value;
                string paymentMode = cmbPaymentMode.Text;
                
                // Vérifier si la commande est déjà entièrement payée
                if (PaymentDao.IsOrderFullyPaid(orderId))
                {
                    MessageBox.Show("Cette commande est déjà entièrement payée.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                // Créer le paiement
                PaymentDao.CreatePayment(orderId, amount, paymentMode);
                
                // Recharger les informations
                NumOrderId_ValueChanged(sender, e);
                
                MessageBox.Show("Paiement enregistré avec succès", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur sauvegarde: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}