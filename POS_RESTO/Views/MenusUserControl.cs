using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using POS_RESTO.Configuration;
using POS_RESTO.Forms;

namespace POS_RESTO.Views
{
    public partial class MenusUserControl : UserControl
    {
        public MenusUserControl()
        {
            InitializeComponent();
            LoadMenus();
        }
        
        private void SetupDataGridViewColumns()
        {
            var colId = new DataGridViewTextBoxColumn();
            colId.Name = "ID";
            colId.HeaderText = "ID";
            colId.Width = 50;
            
            var colNom = new DataGridViewTextBoxColumn();
            colNom.Name = "Nom";
            colNom.HeaderText = "Nom";
            colNom.Width = 150;
            
            var colCategorie = new DataGridViewTextBoxColumn();
            colCategorie.Name = "Categorie";
            colCategorie.HeaderText = "Categorie";
            colCategorie.Width = 100;
            
            var colPrix = new DataGridViewTextBoxColumn();
            colPrix.Name = "Prix";
            colPrix.HeaderText = "Prix HTG";
            colPrix.Width = 100;
            
            var colStock = new DataGridViewTextBoxColumn();
            colStock.Name = "Stock";
            colStock.HeaderText = "Stock";
            colStock.Width = 80;
            
            var colDescription = new DataGridViewTextBoxColumn();
            colDescription.Name = "Description";
            colDescription.HeaderText = "Description";
            colDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
            dgvMenus.Columns.AddRange(new DataGridViewColumn[] {
                colId, colNom, colCategorie, colPrix, colStock, colDescription
            });
        }
        
        private void LoadMenus()
        {
            try
            {
                dgvMenus.Rows.Clear();
                
                string query = "SELECT * FROM Menus";
                if (cmbFilterCategory.SelectedIndex > 0)
                {
                    query += $" WHERE category = '{cmbFilterCategory.SelectedItem}'";
                }
                query += " ORDER BY category, name";
                
                using (var conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgvMenus.Rows.Add(
                                reader["menu_id"],
                                reader["name"],
                                reader["category"],
                                $"{Convert.ToDecimal(reader["unit_price"]):N0}",
                                reader["stock_quantity"],
                                reader["description"]
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement menus: {ex.Message}");
            }
        }
        
        private void BtnAddMenu_Click(object sender, EventArgs e)
        {
            var menuForm = new MenuForm();
            if (menuForm.ShowDialog() == DialogResult.OK)
            {
                LoadMenus();
            }
        }
        
        private void BtnEditMenu_Click(object sender, EventArgs e)
        {
            if (dgvMenus.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez selectionner un menu a modifier");
                return;
            }
            
            object idValue = dgvMenus.SelectedRows[0].Cells[0].Value;
            if (idValue != null && int.TryParse(idValue.ToString(), out int menuId))
            {
                var menuForm = new MenuForm(menuId);
                if (menuForm.ShowDialog() == DialogResult.OK)
                {
                    LoadMenus();
                }
            }
        }
        
        private void BtnDeleteMenu_Click(object sender, EventArgs e)
        {
            if (dgvMenus.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez selectionner un menu a supprimer");
                return;
            }
            
            object idValue = dgvMenus.SelectedRows[0].Cells[0].Value;
            object nomValue = dgvMenus.SelectedRows[0].Cells[1].Value;
            
            if (idValue != null && nomValue != null && 
                int.TryParse(idValue.ToString(), out int menuId))
            {
                string menuName = nomValue.ToString();
                
                if (MessageBox.Show($"Voulez-vous vraiment supprimer le menu '{menuName}' ?",
                        "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM Menus WHERE menu_id = @id";
                        
                        using (var conn = DatabaseConfig.GetConnection())
                        {
                            conn.Open();
                            
                            using (var cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", menuId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        
                        LoadMenus();
                        MessageBox.Show("Menu supprime avec succes");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur suppression: {ex.Message}");
                    }
                }
            }
        }
        
        private void CmbFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMenus();
        }
    }
}