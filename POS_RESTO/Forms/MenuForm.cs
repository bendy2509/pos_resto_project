using System;
using System.Drawing;
using System.Windows.Forms;
using POS_RESTO.Data;
using POS_RESTO.Models;

namespace POS_RESTO.Forms
{
    public partial class MenuForm : Form
    {
        // private int? menuId;
        public MenuForm(int? id = null)
        {
            menuId = id;
            InitializeComponent();
            
            // Ajouter l'événement pour le bouton Annuler si ce n'est pas déjà fait
            if (btnCancel != null)
                btnCancel.Click += BtnCancel_Click;
            
            if (menuId.HasValue)
            {
                this.Text = "Modifier Menu";
                lblTitle.Text = "MODIFIER MENU";
                LoadMenuData();
            }
            else
            {
                this.Text = "Nouveau Menu";
                lblTitle.Text = "NOUVEAU MENU";
            }
        }
        
        private void LoadMenuData()
        {
            try
            {
                var menu = MenuDao.GetMenuById(menuId.Value);
                if (menu != null)
                {
                    txtName.Text = menu.Name;
                    cmbCategory.Text = menu.Category;
                    numPrice.Value = menu.UnitPrice;
                    numStock.Value = menu.StockQuantity;
                    txtDescription.Text = menu.Description ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement menu: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Veuillez saisir le nom du menu", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show("Veuillez sélectionner une catégorie", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return;
            }
            
            if (numPrice.Value <= 0)
            {
                MessageBox.Show("Le prix doit être supérieur à 0", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPrice.Focus();
                return;
            }
            
            try
            {
                var menu = new Menu
                {
                    Name = txtName.Text,
                    Category = cmbCategory.Text,
                    UnitPrice = numPrice.Value,
                    StockQuantity = (int)numStock.Value,
                    Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text
                };
                
                if (menuId.HasValue)
                {
                    menu.MenuId = menuId.Value;
                }
                
                MenuDao.SaveMenu(menu);
                
                MessageBox.Show(menuId.HasValue ? "Menu modifié avec succès" : "Menu ajouté avec succès",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
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