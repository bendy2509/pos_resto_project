using System;
using System.Drawing;
using System.Windows.Forms;
using POS_RESTO.Data;
using POS_RESTO.Models;

namespace POS_RESTO.Forms
{
    public partial class ClientForm : Form
    {
        // private int? clientId;
        
        public ClientForm(int? id = null)
        {
            clientId = id;
            InitializeComponent();
            
            // Ajouter l'événement pour le bouton Annuler
            btnCancel.Click += BtnCancel_Click;
            
            if (clientId.HasValue)
            {
                this.Text = "MODIFIER CLIENT";
                lblTitle.Text = "MODIFIER CLIENT";
                LoadClientData();
            }
            else
            {
                this.Text = "NOUVEAU CLIENT";
                lblTitle.Text = "NOUVEAU CLIENT";
            }
        }
        
        private void LoadClientData()
        {
            try
            {
                var client = ClientDao.GetClientById(clientId.Value);
                if (client != null)
                {
                    txtLastName.Text = client.LastName;
                    txtFirstName.Text = client.FirstName;
                    cmbGender.Text = client.Gender;
                    txtPhone.Text = client.Phone ?? "";
                    txtEmail.Text = client.Email ?? "";
                    numDebt.Value = client.DebtAmount;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement client: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Veuillez saisir le nom", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Veuillez saisir le prénom", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return;
            }
            
            try
            {
                var client = new Client
                {
                    LastName = txtLastName.Text,
                    FirstName = txtFirstName.Text,
                    Gender = cmbGender.Text,
                    Phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text,
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text,
                    DebtAmount = numDebt.Value
                };
                
                if (clientId.HasValue)
                {
                    client.ClientId = clientId.Value;
                }
                
                ClientDao.SaveClient(client);
                
                MessageBox.Show(clientId.HasValue ? "Client modifié avec succès" : "Client ajouté avec succès",
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