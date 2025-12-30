using System;
using System.Drawing;
using System.Windows.Forms;
using POS_RESTO.Data;

namespace POS_RESTO.Forms
{
    public partial class PaymentForm : Form
    {
        private decimal orderTotal = 0;
        
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
                    
                    // Vérifier si la commande existe
                    var order = PaymentDao.GetOrderDetails(orderId);
                    if (order != null)
                    {
                        // Calculer le total de la commande
                        orderTotal = order.Subtotal;
                        lblOrderTotal.Text = $"Montant commande: {orderTotal:N0} HTG";
                        lblOrderDetails.Text = $"{order.MenuName} x{order.Quantity} - Client: {order.ClientName}";
                        
                        // Vérifier si la commande est déjà payée
                        if (PaymentDao.IsOrderPaid(orderId))
                        {
                            decimal amountPaid = PaymentDao.GetAmountPaidForOrder(orderId);
                            lblOrderTotal.Text += $" (Déjà payé: {amountPaid:N0} HTG)";
                        }
                        
                        // Configurer le NumericUpDown pour le montant
                        numAmount.Value = orderTotal; // Par défaut, montant exact
                        numAmount.Maximum = orderTotal * 2; // Permet de payer plus que le total
                        numAmount.Minimum = 0;
                    }
                    else
                    {
                        lblOrderTotal.Text = "Commande non trouvée";
                        lblOrderDetails.Text = "";
                        orderTotal = 0;
                        numAmount.Value = 0;
                    }
                }
                catch (Exception ex)
                {
                    lblOrderTotal.Text = "Erreur chargement";
                    lblOrderDetails.Text = "";
                    orderTotal = 0;
                    MessageBox.Show($"Erreur: {ex.Message}", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                
                // Vérifier si la commande est déjà payée
                if (PaymentDao.IsOrderPaid(orderId))
                {
                    var result = MessageBox.Show(
                        $"Un paiement existe déjà pour cette commande. Voulez-vous ajouter un nouveau paiement?",
                        "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                    if (result != DialogResult.Yes)
                    {
                        return;
                    }
                }
                
                // Créer le paiement
                PaymentDao.CreatePayment(orderId, amount, paymentMode);
                
                // Mettre à jour le statut de la commande si le paiement est complet
                if (amount >= orderTotal)
                {
                    OrderDao.UpdateOrderStatus(orderId, "terminee");
                }
                
                MessageBox.Show("Paiement enregistré avec succès", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
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