using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using POS_RESTO.Configuration;
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
                dgvPayments.Rows.Clear();

                string query = @"SELECT p.payment_id, 
                                        p.order_id,
                                        p.amount,
                                        p.payment_date,
                                        p.payment_mode
                                 FROM Payments p
                                 WHERE DATE(p.payment_date) BETWEEN @from AND @to
                                 ORDER BY p.payment_date DESC";

                using (var conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@from", dtpFrom.Value.Date);
                        cmd.Parameters.AddWithValue("@to", dtpTo.Value.Date);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgvPayments.Rows.Add(
                                    reader["payment_id"],
                                    reader["order_id"],
                                    $"{Convert.ToDecimal(reader["amount"]):N0}",
                                    Convert.ToDateTime(reader["payment_date"]).ToString("dd/MM/yyyy HH:mm"),
                                    reader["payment_mode"]
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement paiements: {ex.Message}");
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
            LoadPayments();
        }
    }
}