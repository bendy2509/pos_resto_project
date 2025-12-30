using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using POS_RESTO.Data;
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
        
        private void LoadMenus()
        {
            try
            {
                DataTable dt;
                
                if (cmbFilterCategory.SelectedIndex > 0)
                {
                    string category = cmbFilterCategory.SelectedItem.ToString();
                    dt = MenuDao.GetMenusByCategoryDataTable(category);
                }
                else
                {
                    dt = MenuDao.GetAllMenusDataTableForDisplay();
                }
                
                dgvMenus.DataSource = dt;
                
                // Formater les colonnes
                if (dgvMenus.Columns.Contains("ID"))
                {
                    dgvMenus.Columns["ID"].Visible = false;
                    dgvMenus.Columns["ID"].Width = 0;
                }
                
                if (dgvMenus.Columns.Contains("Prix (HTG)"))
                {
                    dgvMenus.Columns["Prix (HTG)"].DefaultCellStyle.Alignment = 
                        DataGridViewContentAlignment.MiddleRight;
                }
                
                if (dgvMenus.Columns.Contains("Stock"))
                {
                    dgvMenus.Columns["Stock"].DefaultCellStyle.Alignment = 
                        DataGridViewContentAlignment.MiddleCenter;
                    
                    // Colorer le stock faible
                    dgvMenus.CellFormatting += (sender, e) =>
                    {
                        if (e.ColumnIndex == dgvMenus.Columns["Stock"].Index && e.Value != null)
                        {
                            if (int.TryParse(e.Value.ToString(), out int stock))
                            {
                                if (stock == 0)
                                {
                                    e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69);
                                    e.CellStyle.Font = new Font(dgvMenus.Font, FontStyle.Bold);
                                    e.CellStyle.BackColor = Color.FromArgb(255, 245, 245);
                                }
                                else if (stock <= 5)
                                {
                                    e.CellStyle.ForeColor = Color.FromArgb(255, 193, 7);
                                    e.CellStyle.Font = new Font(dgvMenus.Font, FontStyle.Bold);
                                }
                            }
                        }
                    };
                }
                
                dgvMenus.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                
                // Afficher le statut
                lblStatus.Text = $"{dt.Rows.Count} menus trouvés";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement menus: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Erreur de chargement";
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
                MessageBox.Show("Veuillez sélectionner un menu à modifier", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            try
            {
                int menuId = GetSelectedMenuId();
                
                if (menuId > 0)
                {
                    var menuForm = new MenuForm(menuId);
                    if (menuForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadMenus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnDeleteMenu_Click(object sender, EventArgs e)
        {
            if (dgvMenus.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un menu à supprimer", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            try
            {
                int menuId = GetSelectedMenuId();
                string menuName = GetSelectedMenuName();
                
                if (menuId > 0 && !string.IsNullOrEmpty(menuName))
                {
                    if (MessageBox.Show($"Voulez-vous vraiment supprimer le menu '{menuName}' ?",
                        "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            MenuDao.DeleteMenu(menuId);
                            LoadMenus();
                            
                            MessageBox.Show("Menu supprimé avec succès", "Succès",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erreur suppression: {ex.Message}\n\n" +
                                          "Le menu ne peut pas être supprimé s'il a des commandes associées.", 
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void CmbFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMenus();
        }
        
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }
        
        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            LoadMenus();
        }
        
        private void DgvMenus_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnEditMenu_Click(sender, e);
            }
        }
        
        private int GetSelectedMenuId()
        {
            if (dgvMenus.SelectedRows.Count > 0)
            {
                var selectedRow = dgvMenus.SelectedRows[0];
                
                if (selectedRow.DataBoundItem is DataRowView rowView)
                {
                    if (rowView["ID"] != DBNull.Value)
                    {
                        return Convert.ToInt32(rowView["ID"]);
                    }
                }
                
                if (dgvMenus.Columns.Contains("ID") && 
                    selectedRow.Cells["ID"].Value != null && 
                    selectedRow.Cells["ID"].Value != DBNull.Value)
                {
                    return Convert.ToInt32(selectedRow.Cells["ID"].Value);
                }
            }
            
            return 0;
        }
        
        private string GetSelectedMenuName()
        {
            if (dgvMenus.SelectedRows.Count > 0)
            {
                var selectedRow = dgvMenus.SelectedRows[0];
                
                if (dgvMenus.Columns.Contains("Nom") && 
                    selectedRow.Cells["Nom"].Value != null)
                {
                    return selectedRow.Cells["Nom"].Value.ToString();
                }
            }
            
            return "";
        }
        
        private void MenusUserControl_Load(object sender, EventArgs e)
        {
            // Le timer est déjà initialisé dans InitializeComponent
        }
        
    }
}