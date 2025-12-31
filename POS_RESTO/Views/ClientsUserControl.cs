using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using POS_RESTO.Data;
using POS_RESTO.Forms;
using Timer = System.Windows.Forms.Timer;

namespace POS_RESTO.Views
{
    public partial class ClientsUserControl : UserControl
    {
        public ClientsUserControl()
        {
            InitializeComponent();
            InitializeSearchTimer();
            LoadClients();
        }
        
        private void LoadClients()
        {
            try
            {
                lblStatus.Text = "Chargement en cours...";
                dgvClients.DataSource = null;
                
                // Utiliser le DAO pour charger les données
                DataTable dt;
                
                if (!string.IsNullOrEmpty(txtSearch.Text))
                {
                    dt = ClientDao.SearchClientsDataTable(txtSearch.Text);
                }
                else
                {
                    dt = ClientDao.GetAllClientsDataTable();
                }
                
                // Formater les colonnes de dette
                if (dt.Columns.Contains("Dette (HTG)"))
                {
                    dgvClients.DataSource = dt;
                    
                    // Formater l'affichage des dettes
                    dgvClients.Columns["Dette (HTG)"].DefaultCellStyle.Alignment = 
                        DataGridViewContentAlignment.MiddleRight;
                    
                    dgvClients.CellFormatting += (sender, e) =>
                    {
                        if (e.ColumnIndex == dgvClients.Columns["Dette (HTG)"].Index && e.Value != null)
                        {
                            string value = e.Value.ToString();
                            if (value.Contains("HTG"))
                            {
                                string numStr = value.Replace(" HTG", "").Replace(" ", "").Replace(",", "");
                                if (decimal.TryParse(numStr, out decimal dette) && dette > 0)
                                {
                                    e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69);
                                    e.CellStyle.Font = new Font(dgvClients.Font, FontStyle.Bold);
                                }
                            }
                        }
                    };
                    
                    // Ajuster automatiquement les colonnes
                    dgvClients.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    
                    // Masquer la colonne ID
                    if (dgvClients.Columns.Contains("ID"))
                    {
                        dgvClients.Columns["ID"].Visible = false;
                        dgvClients.Columns["ID"].Width = 0;
                    }
                    
                    lblStatus.Text = $"{dt.Rows.Count} clients trouvés";
                }
                else
                {
                    dgvClients.DataSource = dt;
                    dgvClients.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    lblStatus.Text = $"{dt.Rows.Count} clients trouvés";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Erreur de chargement";
                MessageBox.Show($"Erreur chargement clients: {ex.Message}", 
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnAddClient_Click(object sender, EventArgs e)
        {
            var clientForm = new ClientForm();
            if (clientForm.ShowDialog() == DialogResult.OK)
            {
                LoadClients();
            }
        }
        
        private void BtnEditClient_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un client à modifier", 
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            try
            {
                // Récupérer l'ID du client sélectionné
                int clientId = GetSelectedClientId();
                
                if (clientId > 0)
                {
                    var clientForm = new ClientForm(clientId);
                    if (clientForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadClients();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnDeleteClient_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un client à supprimer", 
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            try
            {
                // Récupérer l'ID et le nom du client sélectionné
                int clientId = GetSelectedClientId();
                string clientName = GetSelectedClientName();
                
                if (clientId > 0 && !string.IsNullOrEmpty(clientName))
                {
                    if (MessageBox.Show($"Voulez-vous vraiment supprimer le client '{clientName}' ?",
                        "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            ClientDao.DeleteClient(clientId);
                            LoadClients();
                            
                            MessageBox.Show("Client supprimé avec succès", 
                                "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erreur suppression: {ex.Message}\n\n" +
                                          "Le client ne peut pas être supprimé s'il a des commandes associées.", 
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
        
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            // Utiliser un timer pour éviter de recharger à chaque frappe
            searchTimer.Stop();
            searchTimer.Start();
        }
        
        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            LoadClients();
        }
        
        private int GetSelectedClientId()
        {
            if (dgvClients.SelectedRows.Count > 0)
            {
                var selectedRow = dgvClients.SelectedRows[0];
                
                // Essayer d'abord avec DataBoundItem
                if (selectedRow.DataBoundItem is DataRowView rowView)
                {
                    if (rowView["ID"] != DBNull.Value)
                    {
                        return Convert.ToInt32(rowView["ID"]);
                    }
                }
                
                // Sinon, utiliser directement les cellules
                if (dgvClients.Columns.Contains("ID") && 
                    selectedRow.Cells["ID"].Value != null && 
                    selectedRow.Cells["ID"].Value != DBNull.Value)
                {
                    return Convert.ToInt32(selectedRow.Cells["ID"].Value);
                }
            }
            
            return 0;
        }
        
        private string GetSelectedClientName()
        {
            if (dgvClients.SelectedRows.Count > 0)
            {
                var selectedRow = dgvClients.SelectedRows[0];
                
                string nom = "", prenom = "";
                
                // Récupérer nom et prénom
                if (dgvClients.Columns.Contains("Nom") && selectedRow.Cells["Nom"].Value != null)
                {
                    nom = selectedRow.Cells["Nom"].Value.ToString();
                }
                
                if (dgvClients.Columns.Contains("Prénom") && selectedRow.Cells["Prénom"].Value != null)
                {
                    prenom = selectedRow.Cells["Prénom"].Value.ToString();
                }
                
                return $"{prenom} {nom}".Trim();
            }
            
            return "";
        }
        
        private void DgvClients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnEditClient_Click(sender, e);
            }
        }
        
        public void RefreshData()
        {
            LoadClients();
        }
        
        // Ajouter un timer pour la recherche
        private Timer searchTimer;
        
        private void InitializeSearchTimer()
        {
            searchTimer = new Timer();
            searchTimer.Interval = 500; // 500ms de délai
            searchTimer.Tick += SearchTimer_Tick;
        }
        
        private void ClientsUserControl_Load(object sender, EventArgs e)
        {
            InitializeSearchTimer();
        }
    }
}