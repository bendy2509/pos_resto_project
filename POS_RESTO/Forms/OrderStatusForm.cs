using System;
using System.Drawing;
using System.Windows.Forms;
using POS_RESTO.Data;
using POS_RESTO.Models;

namespace POS_RESTO.Forms
{
    public partial class OrderStatusForm : Form
    {
        private int orderId;
        
        public OrderStatusForm(int id)
        {
            orderId = id;
            InitializeComponent();
            LoadOrderInfo();
        }
        
        private void LoadOrderInfo()
        {
            try
            {
                var order = OrderDao.GetOrderById(orderId);
                if (order != null)
                {
                    lblOrderInfo.Text = $"Commande #{orderId} - Client: {order.ClientName}";
                    cmbStatus.Text = order.Status;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement commande: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show("Veuillez sélectionner un statut", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                // Si on annule la commande, restaurer le stock
                if (cmbStatus.Text.ToLower() == "annulee")
                {
                    OrderDao.CancelOrder(orderId);
                }
                else
                {
                    OrderDao.UpdateOrderStatus(orderId, cmbStatus.Text);
                }
                
                MessageBox.Show("Statut mis à jour avec succès", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur mise à jour: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        private Label lblOrderInfo;
        private ComboBox cmbStatus;
        private Button btnSave;
        private Button btnCancel;
    }
}