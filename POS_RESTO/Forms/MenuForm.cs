using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using POS_RESTO.Configuration;

namespace POS_RESTO.Forms
{
    public partial class MenuForm : Form
    {
        public MenuForm(int? id = null)
        {
            menuId = id;
            InitializeComponent();
            
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
                string query = "SELECT * FROM Menus WHERE menu_id = @id";
                
                using (var conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", menuId.Value);
                        
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader["name"].ToString();
                                cmbCategory.Text = reader["category"].ToString();
                                numPrice.Value = Convert.ToDecimal(reader["unit_price"]);
                                numStock.Value = Convert.ToDecimal(reader["stock_quantity"]);
                                txtDescription.Text = reader["description"]?.ToString() ?? "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement menu: {ex.Message}");
            }
        }
        
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Veuillez saisir le nom du menu");
                txtName.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show("Veuillez selectionner une categorie");
                cmbCategory.Focus();
                return;
            }
            
            if (numPrice.Value <= 0)
            {
                MessageBox.Show("Le prix doit etre superieur a 0");
                numPrice.Focus();
                return;
            }
            
            try
            {
                string query;
                
                if (menuId.HasValue)
                {
                    query = @"UPDATE Menus SET 
                             name = @name,
                             category = @category,
                             unit_price = @price,
                             stock_quantity = @stock,
                             description = @desc
                             WHERE menu_id = @id";
                }
                else
                {
                    query = @"INSERT INTO Menus (name, category, unit_price, stock_quantity, description) 
                             VALUES (@name, @category, @price, @stock, @desc)";
                }
                
                using (var conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@category", cmbCategory.Text);
                        cmd.Parameters.AddWithValue("@price", numPrice.Value);
                        cmd.Parameters.AddWithValue("@stock", (int)numStock.Value);
                        cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                        
                        if (menuId.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@id", menuId.Value);
                        }
                        
                        cmd.ExecuteNonQuery();
                    }
                }
                
                MessageBox.Show(menuId.HasValue ? "Menu modifie avec succes" : "Menu ajoute avec succes");
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
}