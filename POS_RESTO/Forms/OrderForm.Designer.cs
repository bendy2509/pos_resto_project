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
        splitContainer = new SplitContainer();
        panelLeft = new Panel();
        lblMenusTitle = new Label();
        dgvMenus = new DataGridView();
        colId = new DataGridViewTextBoxColumn();
        colName = new DataGridViewTextBoxColumn();
        colCategory = new DataGridViewTextBoxColumn();
        colPrice = new DataGridViewTextBoxColumn();
        colStock = new DataGridViewTextBoxColumn();
        panelQuantity = new Panel();
        lblQuantity = new Label();
        numQuantity = new NumericUpDown();
        btnAddToCart = new Button();
        panelRight = new Panel();
        lblCartTitle = new Panel();
        lblCartTitleText = new Label();
        lblClient = new Label();
        cmbClients = new ComboBox();
        panelCart = new Panel();
        lstCart = new ListBox();
        panelCartActions = new Panel();
        btnRemoveFromCart = new Button();
        lblTotal = new Label();
        panelBottom = new Panel();
        btnCancel = new Button();
        btnConfirmOrder = new Button();
        ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
        splitContainer.Panel1.SuspendLayout();
        splitContainer.Panel2.SuspendLayout();
        splitContainer.SuspendLayout();
        panelLeft.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvMenus).BeginInit();
        panelQuantity.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
        panelRight.SuspendLayout();
        lblCartTitle.SuspendLayout();
        panelCart.SuspendLayout();
        panelCartActions.SuspendLayout();
        panelBottom.SuspendLayout();
        SuspendLayout();
        
        // 
        // splitContainer
        // 
        splitContainer.Dock = DockStyle.Fill;
        splitContainer.Location = new Point(0, 0);
        splitContainer.Name = "splitContainer";
        splitContainer.Panel1MinSize = 400;
        splitContainer.Panel2MinSize = 300;
        
        // 
        // splitContainer.Panel1 - Panneau gauche (Menus)
        // 
        splitContainer.Panel1.Controls.Add(panelLeft);
        
        // 
        // splitContainer.Panel2 - Panneau droit (Panier)
        // 
        splitContainer.Panel2.BackColor = Color.WhiteSmoke;
        splitContainer.Panel2.Controls.Add(panelRight);
        
        splitContainer.Size = new Size(1000, 650);
        splitContainer.SplitterDistance = 650;
        splitContainer.SplitterWidth = 10;
        splitContainer.TabIndex = 0;
        
        // 
        // panelLeft - Conteneur principal gauche
        // 
        panelLeft.BackColor = Color.White;
        panelLeft.Controls.Add(lblMenusTitle);
        panelLeft.Controls.Add(dgvMenus);
        panelLeft.Controls.Add(panelQuantity);
        panelLeft.Dock = DockStyle.Fill;
        panelLeft.Padding = new Padding(20, 20, 20, 10);
        
        // 
        // lblMenusTitle
        // 
        lblMenusTitle.Dock = DockStyle.Top;
        lblMenusTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblMenusTitle.ForeColor = Color.FromArgb(0, 123, 255);
        lblMenusTitle.Location = new Point(20, 20);
        lblMenusTitle.Name = "lblMenusTitle";
        lblMenusTitle.Size = new Size(610, 40);
        lblMenusTitle.TabIndex = 0;
        lblMenusTitle.Text = "MENUS DISPONIBLES";
        lblMenusTitle.TextAlign = ContentAlignment.MiddleLeft;
        
        // 
        // dgvMenus
        // 
        dgvMenus.AllowUserToAddRows = false;
        dgvMenus.AllowUserToDeleteRows = false;
        dgvMenus.BackgroundColor = Color.White;
        dgvMenus.BorderStyle = BorderStyle.Fixed3D;
        dgvMenus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvMenus.Columns.AddRange(new DataGridViewColumn[] {
            colId,
            colName,
            colCategory,
            colPrice,
            colStock
        });
        dgvMenus.Dock = DockStyle.Fill;
        dgvMenus.GridColor = Color.FromArgb(240, 240, 240);
        dgvMenus.Location = new Point(20, 60);
        dgvMenus.Margin = new Padding(10);
        dgvMenus.Name = "dgvMenus";
        dgvMenus.ReadOnly = true;
        dgvMenus.RowHeadersVisible = false;
        dgvMenus.RowTemplate.Height = 25;
        dgvMenus.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvMenus.Size = new Size(610, 470);
        dgvMenus.TabIndex = 1;
        dgvMenus.SelectionChanged += DgvMenus_SelectionChanged;
        
        // 
        // colId
        // 
        colId.HeaderText = "ID";
        colId.Name = "colId";
        colId.ReadOnly = true;
        colId.Width = 50;
        
        // 
        // colName
        // 
        colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        colName.HeaderText = "Nom";
        colName.Name = "colName";
        colName.ReadOnly = true;
        
        // 
        // colCategory
        // 
        colCategory.HeaderText = "Catégorie";
        colCategory.Name = "colCategory";
        colCategory.ReadOnly = true;
        colCategory.Width = 100;
        
        // 
        // colPrice
        // 
        colPrice.HeaderText = "Prix (HTG)";
        colPrice.Name = "colPrice";
        colPrice.ReadOnly = true;
        colPrice.Width = 100;
        
        // 
        // colStock
        // 
        colStock.HeaderText = "Stock";
        colStock.Name = "colStock";
        colStock.ReadOnly = true;
        colStock.Width = 80;
        
        // 
        // panelQuantity - Panneau pour la quantité
        // 
        panelQuantity.BackColor = Color.White;
        panelQuantity.Controls.Add(lblQuantity);
        panelQuantity.Controls.Add(numQuantity);
        panelQuantity.Controls.Add(btnAddToCart);
        panelQuantity.Dock = DockStyle.Bottom;
        panelQuantity.Location = new Point(20, 530);
        panelQuantity.Name = "panelQuantity";
        panelQuantity.Padding = new Padding(0, 10, 0, 0);
        panelQuantity.Size = new Size(610, 60);
        panelQuantity.TabIndex = 2;
        
        // 
        // lblQuantity
        // 
        lblQuantity.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblQuantity.Location = new Point(0, 15);
        lblQuantity.Name = "lblQuantity";
        lblQuantity.Size = new Size(80, 25);
        lblQuantity.TabIndex = 0;
        lblQuantity.Text = "Quantité:";
        lblQuantity.TextAlign = ContentAlignment.MiddleLeft;
        
        // 
        // numQuantity
        // 
        numQuantity.Font = new Font("Segoe UI", 10F);
        numQuantity.Location = new Point(90, 15);
        numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numQuantity.Name = "numQuantity";
        numQuantity.Size = new Size(80, 25);
        numQuantity.TabIndex = 1;
        numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
        
        // 
        // btnAddToCart
        // 
        btnAddToCart.BackColor = Color.FromArgb(0, 123, 255);
        btnAddToCart.FlatAppearance.BorderSize = 0;
        btnAddToCart.FlatStyle = FlatStyle.Flat;
        btnAddToCart.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnAddToCart.ForeColor = Color.White;
        btnAddToCart.ImageAlign = ContentAlignment.MiddleLeft;
        btnAddToCart.Location = new Point(190, 10);
        btnAddToCart.Name = "btnAddToCart";
        btnAddToCart.Padding = new Padding(10, 0, 10, 0);
        btnAddToCart.Size = new Size(180, 35);
        btnAddToCart.TabIndex = 2;
        btnAddToCart.Text = "  Ajouter au panier";
        btnAddToCart.UseVisualStyleBackColor = false;
        btnAddToCart.Click += BtnAddToCart_Click;
        
        // 
        // panelRight - Conteneur principal droit
        // 
        panelRight.BackColor = Color.White;
        panelRight.Controls.Add(lblCartTitle);
        panelRight.Controls.Add(lblClient);
        panelRight.Controls.Add(cmbClients);
        panelRight.Controls.Add(panelCart);
        panelRight.Controls.Add(panelCartActions);
        panelRight.Controls.Add(panelBottom);
        panelRight.Dock = DockStyle.Fill;
        panelRight.Padding = new Padding(20, 20, 20, 10);
        
        // 
        // lblCartTitle
        // 
        lblCartTitle.BackColor = Color.FromArgb(0, 123, 255);
        lblCartTitle.Controls.Add(lblCartTitleText);
        lblCartTitle.Dock = DockStyle.Top;
        lblCartTitle.Location = new Point(20, 20);
        lblCartTitle.Name = "lblCartTitle";
        lblCartTitle.Padding = new Padding(10, 5, 10, 5);
        lblCartTitle.Size = new Size(300, 50);
        lblCartTitle.TabIndex = 0;
        
        // 
        // lblCartTitleText
        // 
        lblCartTitleText.Dock = DockStyle.Fill;
        lblCartTitleText.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblCartTitleText.ForeColor = Color.White;
        lblCartTitleText.Location = new Point(10, 5);
        lblCartTitleText.Name = "lblCartTitleText";
        lblCartTitleText.Size = new Size(280, 40);
        lblCartTitleText.TabIndex = 0;
        lblCartTitleText.Text = "PANIER";
        lblCartTitleText.TextAlign = ContentAlignment.MiddleCenter;
        
        // 
        // lblClient
        // 
        lblClient.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblClient.Location = new Point(20, 80);
        lblClient.Name = "lblClient";
        lblClient.Size = new Size(60, 25);
        lblClient.TabIndex = 1;
        lblClient.Text = "Client:";
        lblClient.TextAlign = ContentAlignment.MiddleLeft;
        
        // 
        // cmbClients
        // 
        cmbClients.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbClients.Font = new Font("Segoe UI", 10F);
        cmbClients.FormattingEnabled = true;
        cmbClients.Location = new Point(90, 80);
        cmbClients.Name = "cmbClients";
        cmbClients.Size = new Size(230, 25);
        cmbClients.TabIndex = 2;
        
        // 
        // panelCart - Conteneur pour la liste du panier
        // 
        panelCart.BackColor = Color.White;
        panelCart.BorderStyle = BorderStyle.FixedSingle;
        panelCart.Controls.Add(lstCart);
        panelCart.Location = new Point(20, 115);
        panelCart.Name = "panelCart";
        panelCart.Padding = new Padding(1);
        panelCart.Size = new Size(300, 300);
        panelCart.TabIndex = 3;
        
        // 
        // lstCart
        // 
        lstCart.BackColor = Color.White;
        lstCart.BorderStyle = BorderStyle.None;
        lstCart.Dock = DockStyle.Fill;
        lstCart.Font = new Font("Segoe UI", 10F);
        lstCart.FormattingEnabled = true;
        lstCart.ItemHeight = 17;
        lstCart.Location = new Point(1, 1);
        lstCart.Name = "lstCart";
        lstCart.Size = new Size(296, 296);
        lstCart.TabIndex = 0;
        
        // 
        // panelCartActions - Panneau pour les actions du panier
        // 
        panelCartActions.Controls.Add(btnRemoveFromCart);
        panelCartActions.Controls.Add(lblTotal);
        panelCartActions.Location = new Point(20, 425);
        panelCartActions.Name = "panelCartActions";
        panelCartActions.Size = new Size(300, 50);
        panelCartActions.TabIndex = 4;
        
        // 
        // btnRemoveFromCart
        // 
        btnRemoveFromCart.BackColor = Color.FromArgb(220, 53, 69);
        btnRemoveFromCart.FlatAppearance.BorderSize = 0;
        btnRemoveFromCart.FlatStyle = FlatStyle.Flat;
        btnRemoveFromCart.Font = new Font("Segoe UI", 10F);
        btnRemoveFromCart.ForeColor = Color.White;
        btnRemoveFromCart.Location = new Point(0, 10);
        btnRemoveFromCart.Name = "btnRemoveFromCart";
        btnRemoveFromCart.Size = new Size(100, 35);
        btnRemoveFromCart.TabIndex = 0;
        btnRemoveFromCart.Text = "Retirer";
        btnRemoveFromCart.UseVisualStyleBackColor = false;
        btnRemoveFromCart.Click += BtnRemoveFromCart_Click;
        
        // 
        // lblTotal
        // 
        lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTotal.ForeColor = Color.FromArgb(40, 167, 69);
        lblTotal.Location = new Point(110, 10);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(190, 35);
        lblTotal.TabIndex = 1;
        lblTotal.Text = "Total: 0 HTG";
        lblTotal.TextAlign = ContentAlignment.MiddleRight;
        
        // 
        // panelBottom - Panneau pour les boutons en bas
        // 
        panelBottom.Controls.Add(btnCancel);
        panelBottom.Controls.Add(btnConfirmOrder);
        panelBottom.Dock = DockStyle.Bottom;
        panelBottom.Location = new Point(20, 485);
        panelBottom.Name = "panelBottom";
        panelBottom.Padding = new Padding(0, 10, 0, 0);
        panelBottom.Size = new Size(300, 65);
        panelBottom.TabIndex = 5;
        
        // 
        // btnCancel
        // 
        btnCancel.BackColor = Color.FromArgb(108, 117, 125);
        btnCancel.FlatAppearance.BorderSize = 0;
        btnCancel.FlatStyle = FlatStyle.Flat;
        btnCancel.Font = new Font("Segoe UI", 10F);
        btnCancel.ForeColor = Color.White;
        btnCancel.Location = new Point(170, 10);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(120, 40);
        btnCancel.TabIndex = 1;
        btnCancel.Text = "Annuler";
        btnCancel.UseVisualStyleBackColor = false;
        btnCancel.Click += BtnCancel_Click;
        
        // 
        // btnConfirmOrder
        // 
        btnConfirmOrder.BackColor = Color.FromArgb(40, 167, 69);
        btnConfirmOrder.FlatAppearance.BorderSize = 0;
        btnConfirmOrder.FlatStyle = FlatStyle.Flat;
        btnConfirmOrder.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnConfirmOrder.ForeColor = Color.White;
        btnConfirmOrder.Location = new Point(30, 10);
        btnConfirmOrder.Name = "btnConfirmOrder";
        btnConfirmOrder.Size = new Size(120, 40);
        btnConfirmOrder.TabIndex = 0;
        btnConfirmOrder.Text = "Valider";
        btnConfirmOrder.UseVisualStyleBackColor = false;
        btnConfirmOrder.Click += BtnConfirmOrder_Click;
        
        // 
        // OrderForm
        // 
        ClientSize = new Size(1000, 650);
        Controls.Add(splitContainer);
        Font = new Font("Segoe UI", 9F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimumSize = new Size(800, 500);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Nouvelle Commande";
        
        splitContainer.Panel1.ResumeLayout(false);
        splitContainer.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
        splitContainer.ResumeLayout(false);
        panelLeft.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvMenus).EndInit();
        panelQuantity.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
        panelRight.ResumeLayout(false);
        lblCartTitle.ResumeLayout(false);
        panelCart.ResumeLayout(false);
        panelCartActions.ResumeLayout(false);
        panelBottom.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion
    
    private SplitContainer splitContainer;
    private Panel panelLeft;
    private Panel panelRight;
    private Label lblMenusTitle;
    private DataGridView dgvMenus;
    private Panel panelQuantity;
    private Label lblQuantity;
    private NumericUpDown numQuantity;
    private Button btnAddToCart;
    private Panel lblCartTitle;
    private Label lblCartTitleText;
    private Label lblClient;
    private ComboBox cmbClients;
    private Panel panelCart;
    private ListBox lstCart;
    private Panel panelCartActions;
    private Button btnRemoveFromCart;
    private Label lblTotal;
    private Panel panelBottom;
    private Button btnCancel;
    private Button btnConfirmOrder;
    private DataGridViewTextBoxColumn colId;
    private DataGridViewTextBoxColumn colName;
    private DataGridViewTextBoxColumn colCategory;
    private DataGridViewTextBoxColumn colPrice;
    private DataGridViewTextBoxColumn colStock;
}