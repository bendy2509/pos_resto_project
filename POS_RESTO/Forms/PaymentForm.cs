using MySql.Data.MySqlClient;
using POS_RESTO.Configuration;

namespace POS_RESTO.Forms;

public partial class PaymentForm : Form
{
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
                    string query = @"SELECT SUM(m.unit_price * o.quantity) as total
                                    FROM Orders o
                                    JOIN Menus m ON o.menu_id = m.menu_id
                                    WHERE o.order_id = @orderId
                                    GROUP BY o.order_id";
                    
                    using (var conn = DatabaseConfig.GetConnection())
                    {
                        conn.Open();
                        
                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@orderId", (int)numOrderId.Value);
                            
                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                decimal total = Convert.ToDecimal(result);
                                lblOrderTotal.Text = $"Montant commande: {total:N0} HTG";
                                numAmount.Maximum = total * 2; // Permet de payer plus que le total (pour les pourboires)
                            }
                            else
                            {
                                lblOrderTotal.Text = "Commande non trouvee";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblOrderTotal.Text = "Erreur chargement";
                }
            }
        }
        
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (numOrderId.Value <= 0)
            {
                MessageBox.Show("ID commande invalide");
                numOrderId.Focus();
                return;
            }
            
            if (numAmount.Value <= 0)
            {
                MessageBox.Show("Montant invalide");
                numAmount.Focus();
                return;
            }
            
            try
            {
                string query = @"INSERT INTO Payments (order_id, amount, payment_mode) 
                                 VALUES (@orderId, @amount, @mode)";
                
                using (var conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", (int)numOrderId.Value);
                        cmd.Parameters.AddWithValue("@amount", numAmount.Value);
                        cmd.Parameters.AddWithValue("@mode", cmbPaymentMode.Text);
                        
                        cmd.ExecuteNonQuery();
                    }
                }
                
                MessageBox.Show("Paiement enregistre avec succes");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur sauvegarde: {ex.Message}");
            }
        }
        
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
}