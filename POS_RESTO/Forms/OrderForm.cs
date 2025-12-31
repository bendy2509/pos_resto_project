using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using POS_RESTO.Data;
using POS_RESTO.Models;

namespace POS_RESTO.Forms
{
    public partial class OrderForm : Form
    {
        private List<OrderDao.CartItem> cartItems = 
            new List<OrderDao.CartItem>();
        
        public OrderForm()
        {
            InitializeComponent();
            LoadMenus();
            LoadClients();
        }

        private void LoadMenus()
        {
            try
            {
                // dgvMenus.Rows.Clear();
                var dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Nom", typeof(string));
                dt.Columns.Add("Catégorie", typeof(string));
                dt.Columns.Add("Prix", typeof(decimal));
                dt.Columns.Add("Stock", typeof(int));
                
                var menus = OrderDao.GetAvailableMenus();
                
                foreach (var menu in menus)
                {
                    dgvMenus.Rows.Add(
                        menu.MenuId,
                        menu.Name,
                        menu.Category,
                        menu.UnitPrice,
                        menu.StockQuantity
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement menus: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadClients()
        {
            try
            {
                cmbClients.Items.Clear();
                var clients = OrderDao.GetClientsForComboBox();
                
                foreach (var client in clients)
                {
                    cmbClients.Items.Add(client);
                }
                
                if (cmbClients.Items.Count > 0)
                    cmbClients.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                // MessageBox.Show($"Erreur chargement clients: {ex.Message}", "Erreur",
                //     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvMenus.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un menu.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dgvMenus.SelectedRows[0];
            int menuId = Convert.ToInt32(selectedRow.Cells[0].Value);
            string menuName = selectedRow.Cells[1].Value.ToString();
            decimal price = Convert.ToDecimal(selectedRow.Cells[3].Value);
            int quantity = (int)numQuantity.Value;
            
            // Vérifier le stock
            int stock = Convert.ToInt32(selectedRow.Cells[4].Value);
            if (quantity > stock)
            {
                MessageBox.Show($"Stock insuffisant! Il reste seulement {stock} unité(s).", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ajouter au panier
            var cartItem = new OrderDao.CartItem
            {
                MenuId = menuId,
                MenuName = menuName,
                Price = price,
                Quantity = quantity
            };
            
            cartItems.Add(cartItem);
            lstCart.Items.Add(cartItem);
            
            UpdateTotal();
        }

        private void BtnRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (lstCart.SelectedIndex >= 0)
            {
                cartItems.RemoveAt(lstCart.SelectedIndex);
                lstCart.Items.RemoveAt(lstCart.SelectedIndex);
                UpdateTotal();
            }
        }

        private void BtnConfirmOrder_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Le panier est vide.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cmbClients.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un client.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var clientId = ((OrderDao.ClientItem)cmbClients.SelectedItem).Id;
        
                // Vérifier le stock AVANT de demander confirmation
                if (!OrderDao.CheckStockAvailability(cartItems, out string stockError))
                {
                    MessageBox.Show($"Impossible de valider la commande:\n\n{stockError}", 
                        "Stock insuffisant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
        
                // Demander confirmation à l'utilisateur
                var result = MessageBox.Show(
                    $"Confirmer la commande pour {cartItems.Count} article(s) ?\n" +
                    $"Client: {cmbClients.Text}\n" +
                    @"Stock disponible vérifié",
                    @"Confirmation de commande",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
        
                if (result != DialogResult.Yes)
                    return;
        
                // Créer les commandes (le stock a déjà été vérifié)
                OrderDao.CreateMultipleOrders(clientId, cartItems);
        
                MessageBox.Show("Commande validée avec succès!", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur validation commande: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void UpdateTotal()
        {
            decimal total = 0;
            foreach (OrderDao.CartItem item in cartItems)
            {
                total += item.Price * item.Quantity;
            }
            lblTotal.Text = $"Total: {total:N0} HTG";
        }
        
        // Événement pour mettre à jour la quantité maximale selon le stock
        private void DgvMenus_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMenus.SelectedRows.Count > 0)
            {
                var selectedRow = dgvMenus.SelectedRows[0];
                int stock = Convert.ToInt32(selectedRow.Cells[4].Value);
                numQuantity.Maximum = stock;
                if (numQuantity.Value > stock)
                {
                    MessageBox.Show("Quantité ajustée selon le stock disponible.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    numQuantity.Value = stock;
                }
            }
        }
    }
}