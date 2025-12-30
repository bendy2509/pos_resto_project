using System;
using System.Drawing;
using System.Windows.Forms;
using POS_RESTO.Data;

namespace POS_RESTO.Forms
{
    public partial class OrderDetailsForm : Form
    {
        public OrderDetailsForm(int id)
        {
            orderId = id;
            InitializeComponent();
            LoadOrderDetails();
        }
        
        private void LoadOrderDetails()
        {
            try
            {
                // Mettre à jour le titre avec l'ID de la commande
                this.Text = $"Détails de la commande: #{orderId}";
                
                // Mettre à jour le label titre
                var lblTitle = this.Controls[0].Controls["lblTitle"] as Label;
                if (lblTitle != null)
                {
                    lblTitle.Text = $"COMMANDE : #{orderId}";
                }
                
                // Charger les informations de la commande
                var order = OrderDao.GetOrderById(orderId);
                if (order != null)
                {
                    lblOrderInfo.Text = $"Client: {order.ClientName} | Date: {order.OrderDate:dd/MM/yyyy HH:mm} | Statut: {order.Status}";
                    
                    // Charger les détails
                    var dt = OrderDao.GetOrderDetailsDataTable(orderId);
                    dgvDetails.DataSource = dt;
                    
                    // Calculer le total
                    decimal total = order.Subtotal;
                    lblTotal.Text = $"Total: {total:N0} HTG";
                    
                    // Formater les colonnes si elles existent
                    if (dgvDetails.Columns.Count > 0)
                    {
                        dgvDetails.Columns[0].Width = 150; // Menu
                        dgvDetails.Columns[1].Width = 100; // Catégorie
                        dgvDetails.Columns[2].Width = 80;  // Quantité
                        dgvDetails.Columns[3].Width = 100; // Prix unitaire
                        dgvDetails.Columns[4].Width = 120; // Sous-total
                        
                        // Formater la colonne Sous-total
                        if (dgvDetails.Columns.Count > 4)
                        {
                            dgvDetails.Columns[4].DefaultCellStyle.Alignment = 
                                DataGridViewContentAlignment.MiddleRight;
                        }
                    }
                }
                else
                {
                    lblOrderInfo.Text = "Commande non trouvée";
                    lblTotal.Text = "Total: 0 HTG";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement détails: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private Label lblOrderInfo;
        private DataGridView dgvDetails;
        private Label lblTotal;
    }
}