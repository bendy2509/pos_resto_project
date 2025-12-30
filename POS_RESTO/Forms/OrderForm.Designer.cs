using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace POS_RESTO.Forms;

partial class OrderForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        splitContainer = new System.Windows.Forms.SplitContainer();
        lblMenusTitle = new System.Windows.Forms.Label();
        dgvMenus = new System.Windows.Forms.DataGridView();
        dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        lblQuantity = new System.Windows.Forms.Label();
        numQuantity = new System.Windows.Forms.NumericUpDown();
        btnAddToCart = new System.Windows.Forms.Button();
        lblCartTitle = new System.Windows.Forms.Label();
        lblClient = new System.Windows.Forms.Label();
        cmbClients = new System.Windows.Forms.ComboBox();
        lstCart = new System.Windows.Forms.ListBox();
        btnRemoveFromCart = new System.Windows.Forms.Button();
        lblTotal = new System.Windows.Forms.Label();
        btnConfirmOrder = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
        splitContainer.Panel1.SuspendLayout();
        splitContainer.Panel2.SuspendLayout();
        splitContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvMenus).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
        SuspendLayout();
        // 
        // splitContainer
        // 
        splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer.Location = new System.Drawing.Point(0, 0);
        splitContainer.Name = "splitContainer";
        // 
        // splitContainer.Panel1
        // 
        splitContainer.Panel1.AutoScroll = true;
        splitContainer.Panel1.Controls.Add(lblMenusTitle);
        splitContainer.Panel1.Controls.Add(dgvMenus);
        splitContainer.Panel1.Controls.Add(lblQuantity);
        splitContainer.Panel1.Controls.Add(numQuantity);
        splitContainer.Panel1.Controls.Add(btnAddToCart);
        splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(10);
        // 
        // splitContainer.Panel2
        // 
        splitContainer.Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
        splitContainer.Panel2.Controls.Add(lblCartTitle);
        splitContainer.Panel2.Controls.Add(lblClient);
        splitContainer.Panel2.Controls.Add(cmbClients);
        splitContainer.Panel2.Controls.Add(lstCart);
        splitContainer.Panel2.Controls.Add(btnRemoveFromCart);
        splitContainer.Panel2.Controls.Add(lblTotal);
        splitContainer.Panel2.Controls.Add(btnConfirmOrder);
        splitContainer.Panel2.Controls.Add(btnCancel);
        splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(10);
        splitContainer.Size = new System.Drawing.Size(750, 561);
        splitContainer.SplitterDistance = 605;
        splitContainer.TabIndex = 0;
        // 
        // lblMenusTitle
        // 
        lblMenusTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        lblMenusTitle.Location = new System.Drawing.Point(10, 10);
        lblMenusTitle.Name = "lblMenusTitle";
        lblMenusTitle.Size = new System.Drawing.Size(300, 30);
        lblMenusTitle.TabIndex = 0;
        lblMenusTitle.Text = "MENUS DISPONIBLES";
        // 
        // dgvMenus
        // 
        dgvMenus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
        dgvMenus.Location = new System.Drawing.Point(10, 50);
        dgvMenus.Name = "dgvMenus";
        dgvMenus.ReadOnly = true;
        dgvMenus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvMenus.Size = new System.Drawing.Size(570, 400);
        dgvMenus.TabIndex = 1;
        dgvMenus.SelectionChanged += DgvMenus_SelectionChanged;
        // 
        // dataGridViewTextBoxColumn1
        // 
        dataGridViewTextBoxColumn1.HeaderText = "ID";
        dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
        dataGridViewTextBoxColumn1.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn2
        // 
        dataGridViewTextBoxColumn2.HeaderText = "Nom";
        dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
        dataGridViewTextBoxColumn2.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn3
        // 
        dataGridViewTextBoxColumn3.HeaderText = "Categorie";
        dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
        dataGridViewTextBoxColumn3.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn4
        // 
        dataGridViewTextBoxColumn4.HeaderText = "Prix HTG";
        dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
        dataGridViewTextBoxColumn4.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn5
        // 
        dataGridViewTextBoxColumn5.HeaderText = "Stock";
        dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
        dataGridViewTextBoxColumn5.ReadOnly = true;
        // 
        // lblQuantity
        // 
        lblQuantity.Location = new System.Drawing.Point(10, 460);
        lblQuantity.Name = "lblQuantity";
        lblQuantity.Size = new System.Drawing.Size(60, 25);
        lblQuantity.TabIndex = 2;
        lblQuantity.Text = "Quantite:";
        // 
        // numQuantity
        // 
        numQuantity.Location = new System.Drawing.Point(80, 460);
        numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numQuantity.Name = "numQuantity";
        numQuantity.Size = new System.Drawing.Size(80, 23);
        numQuantity.TabIndex = 3;
        numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // btnAddToCart
        // 
        btnAddToCart.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        btnAddToCart.ForeColor = System.Drawing.Color.White;
        btnAddToCart.Location = new System.Drawing.Point(170, 460);
        btnAddToCart.Name = "btnAddToCart";
        btnAddToCart.Size = new System.Drawing.Size(150, 30);
        btnAddToCart.TabIndex = 4;
        btnAddToCart.Text = "Ajouter au panier";
        btnAddToCart.UseVisualStyleBackColor = false;
        btnAddToCart.Click += BtnAddToCart_Click;
        // 
        // lblCartTitle
        // 
        lblCartTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        lblCartTitle.Location = new System.Drawing.Point(10, 10);
        lblCartTitle.Name = "lblCartTitle";
        lblCartTitle.Size = new System.Drawing.Size(300, 30);
        lblCartTitle.TabIndex = 0;
        lblCartTitle.Text = "PANIER";
        // 
        // lblClient
        // 
        lblClient.Location = new System.Drawing.Point(10, 50);
        lblClient.Name = "lblClient";
        lblClient.Size = new System.Drawing.Size(50, 25);
        lblClient.TabIndex = 1;
        lblClient.Text = "Client:";
        // 
        // cmbClients
        // 
        cmbClients.Location = new System.Drawing.Point(70, 50);
        cmbClients.Name = "cmbClients";
        cmbClients.Size = new System.Drawing.Size(300, 23);
        cmbClients.TabIndex = 2;
        // 
        // lstCart
        // 
        lstCart.Location = new System.Drawing.Point(10, 90);
        lstCart.Name = "lstCart";
        lstCart.Size = new System.Drawing.Size(360, 289);
        lstCart.TabIndex = 3;
        // 
        // btnRemoveFromCart
        // 
        btnRemoveFromCart.Location = new System.Drawing.Point(10, 400);
        btnRemoveFromCart.Name = "btnRemoveFromCart";
        btnRemoveFromCart.Size = new System.Drawing.Size(100, 30);
        btnRemoveFromCart.TabIndex = 4;
        btnRemoveFromCart.Text = "Retirer";
        btnRemoveFromCart.Click += BtnRemoveFromCart_Click;
        // 
        // lblTotal
        // 
        lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        lblTotal.Location = new System.Drawing.Point(120, 400);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new System.Drawing.Size(150, 30);
        lblTotal.TabIndex = 5;
        lblTotal.Text = "Total: 0 HTG";
        // 
        // btnConfirmOrder
        // 
        btnConfirmOrder.BackColor = System.Drawing.Color.FromArgb(((int)((byte)40)), ((int)((byte)167)), ((int)((byte)69)));
        btnConfirmOrder.ForeColor = System.Drawing.Color.White;
        btnConfirmOrder.Location = new System.Drawing.Point(10, 450);
        btnConfirmOrder.Name = "btnConfirmOrder";
        btnConfirmOrder.Size = new System.Drawing.Size(150, 35);
        btnConfirmOrder.TabIndex = 6;
        btnConfirmOrder.Text = "Valider Commande";
        btnConfirmOrder.UseVisualStyleBackColor = false;
        btnConfirmOrder.Click += BtnConfirmOrder_Click;
        // 
        // btnCancel
        // 
        btnCancel.Location = new System.Drawing.Point(170, 450);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new System.Drawing.Size(100, 35);
        btnCancel.TabIndex = 7;
        btnCancel.Text = "Annuler";
        btnCancel.Click += BtnCancel_Click;
        // 
        // OrderForm
        // 
        ClientSize = new System.Drawing.Size(750, 561);
        Controls.Add(splitContainer);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Nouvelle Commande";
        splitContainer.Panel1.ResumeLayout(false);
        splitContainer.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
        splitContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvMenus).EndInit();
        ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
        ResumeLayout(false);
    }

    #endregion
    
    private DataGridView dgvMenus;
    private ListBox lstCart;
    private ComboBox cmbClients;
    private Button btnAddToCart;
    private Button btnRemoveFromCart;
    private Button btnConfirmOrder;
    private Button btnCancel;
    private Label lblTotal;
    private NumericUpDown numQuantity;
    private System.Windows.Forms.SplitContainer splitContainer;
    private Label lblMenusTitle;
    private Label lblQuantity;
    private Label lblCartTitle;
    private Label lblClient;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
}