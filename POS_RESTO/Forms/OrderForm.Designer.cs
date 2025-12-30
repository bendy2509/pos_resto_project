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
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        splitContainer = new System.Windows.Forms.SplitContainer();
        panelLeft = new System.Windows.Forms.Panel();
        lblMenusTitle = new System.Windows.Forms.Label();
        dgvMenus = new System.Windows.Forms.DataGridView();
        colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
        panelQuantity = new System.Windows.Forms.Panel();
        lblQuantity = new System.Windows.Forms.Label();
        numQuantity = new System.Windows.Forms.NumericUpDown();
        btnAddToCart = new System.Windows.Forms.Button();
        panelRight = new System.Windows.Forms.Panel();
        lblCartTitle = new System.Windows.Forms.Panel();
        lblCartTitleText = new System.Windows.Forms.Label();
        lblClient = new System.Windows.Forms.Label();
        cmbClients = new System.Windows.Forms.ComboBox();
        panelCart = new System.Windows.Forms.Panel();
        lstCart = new System.Windows.Forms.ListBox();
        panelCartActions = new System.Windows.Forms.Panel();
        btnRemoveFromCart = new System.Windows.Forms.Button();
        lblTotal = new System.Windows.Forms.Label();
        panelBottom = new System.Windows.Forms.Panel();
        btnCancel = new System.Windows.Forms.Button();
        btnConfirmOrder = new System.Windows.Forms.Button();
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
        splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer.Location = new System.Drawing.Point(0, 0);
        splitContainer.Name = "splitContainer";
        // 
        // splitContainer.Panel1
        // 
        splitContainer.Panel1.Controls.Add(panelLeft);
        splitContainer.Panel1MinSize = 400;
        // 
        // splitContainer.Panel2
        // 
        splitContainer.Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
        splitContainer.Panel2.Controls.Add(panelRight);
        splitContainer.Panel2MinSize = 300;
        splitContainer.Size = new System.Drawing.Size(1000, 650);
        splitContainer.SplitterDistance = 650;
        splitContainer.SplitterWidth = 10;
        splitContainer.TabIndex = 0;
        // 
        // panelLeft
        // 
        panelLeft.BackColor = System.Drawing.Color.White;
        panelLeft.Controls.Add(lblMenusTitle);
        panelLeft.Controls.Add(dgvMenus);
        panelLeft.Controls.Add(panelQuantity);
        panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
        panelLeft.Location = new System.Drawing.Point(0, 0);
        panelLeft.Name = "panelLeft";
        panelLeft.Padding = new System.Windows.Forms.Padding(20, 20, 20, 10);
        panelLeft.Size = new System.Drawing.Size(650, 650);
        panelLeft.TabIndex = 0;
        // 
        // lblMenusTitle
        // 
        lblMenusTitle.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
        lblMenusTitle.AllowDrop = true;
        lblMenusTitle.AutoEllipsis = true;
        lblMenusTitle.BackColor = System.Drawing.Color.White;
        lblMenusTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        lblMenusTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lblMenusTitle.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        lblMenusTitle.Location = new System.Drawing.Point(3, 9);
        lblMenusTitle.Name = "lblMenusTitle";
        lblMenusTitle.Size = new System.Drawing.Size(644, 41);
        lblMenusTitle.TabIndex = 0;
        lblMenusTitle.Text = "MENUS DISPONIBLES";
        lblMenusTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // dgvMenus
        // 
        dgvMenus.AllowUserToAddRows = false;
        dgvMenus.AllowUserToDeleteRows = false;
        dgvMenus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        dgvMenus.BackgroundColor = System.Drawing.Color.White;
        dgvMenus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
        dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
        dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        dgvMenus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvMenus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvMenus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colId, colName, colCategory, colPrice, colStock });
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
        dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        dgvMenus.DefaultCellStyle = dataGridViewCellStyle2;
        dgvMenus.GridColor = System.Drawing.Color.FromArgb(((int)((byte)240)), ((int)((byte)240)), ((int)((byte)240)));
        dgvMenus.Location = new System.Drawing.Point(20, 60);
        dgvMenus.Margin = new System.Windows.Forms.Padding(10);
        dgvMenus.Name = "dgvMenus";
        dgvMenus.ReadOnly = true;
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
        dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        dgvMenus.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
        dgvMenus.RowHeadersVisible = false;
        dgvMenus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvMenus.Size = new System.Drawing.Size(610, 470);
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
        colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        colName.HeaderText = "Nom";
        colName.Name = "colName";
        colName.ReadOnly = true;
        // 
        // colCategory
        // 
        colCategory.HeaderText = "Catégorie";
        colCategory.Name = "colCategory";
        colCategory.ReadOnly = true;
        // 
        // colPrice
        // 
        colPrice.HeaderText = "Prix (HTG)";
        colPrice.Name = "colPrice";
        colPrice.ReadOnly = true;
        // 
        // colStock
        // 
        colStock.HeaderText = "Stock";
        colStock.Name = "colStock";
        colStock.ReadOnly = true;
        colStock.Width = 80;
        // 
        // panelQuantity
        // 
        panelQuantity.BackColor = System.Drawing.Color.White;
        panelQuantity.Controls.Add(lblQuantity);
        panelQuantity.Controls.Add(numQuantity);
        panelQuantity.Controls.Add(btnAddToCart);
        panelQuantity.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelQuantity.Location = new System.Drawing.Point(20, 580);
        panelQuantity.Name = "panelQuantity";
        panelQuantity.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
        panelQuantity.Size = new System.Drawing.Size(610, 60);
        panelQuantity.TabIndex = 2;
        // 
        // lblQuantity
        // 
        lblQuantity.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        lblQuantity.Location = new System.Drawing.Point(0, 15);
        lblQuantity.Name = "lblQuantity";
        lblQuantity.Size = new System.Drawing.Size(80, 25);
        lblQuantity.TabIndex = 0;
        lblQuantity.Text = "Quantité:";
        lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // numQuantity
        // 
        numQuantity.Font = new System.Drawing.Font("Segoe UI", 10F);
        numQuantity.Location = new System.Drawing.Point(90, 15);
        numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numQuantity.Name = "numQuantity";
        numQuantity.Size = new System.Drawing.Size(80, 25);
        numQuantity.TabIndex = 1;
        numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // btnAddToCart
        // 
        btnAddToCart.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        btnAddToCart.FlatAppearance.BorderSize = 0;
        btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnAddToCart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btnAddToCart.ForeColor = System.Drawing.Color.White;
        btnAddToCart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        btnAddToCart.Location = new System.Drawing.Point(190, 10);
        btnAddToCart.Name = "btnAddToCart";
        btnAddToCart.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
        btnAddToCart.Size = new System.Drawing.Size(180, 35);
        btnAddToCart.TabIndex = 2;
        btnAddToCart.Text = "  Ajouter au panier";
        btnAddToCart.UseVisualStyleBackColor = false;
        btnAddToCart.Click += BtnAddToCart_Click;
        // 
        // panelRight
        // 
        panelRight.BackColor = System.Drawing.Color.White;
        panelRight.Controls.Add(lblCartTitle);
        panelRight.Controls.Add(lblClient);
        panelRight.Controls.Add(cmbClients);
        panelRight.Controls.Add(panelCart);
        panelRight.Controls.Add(panelCartActions);
        panelRight.Controls.Add(panelBottom);
        panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
        panelRight.Location = new System.Drawing.Point(0, 0);
        panelRight.Name = "panelRight";
        panelRight.Padding = new System.Windows.Forms.Padding(20, 20, 20, 10);
        panelRight.Size = new System.Drawing.Size(340, 650);
        panelRight.TabIndex = 0;
        // 
        // lblCartTitle
        // 
        lblCartTitle.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        lblCartTitle.Controls.Add(lblCartTitleText);
        lblCartTitle.Dock = System.Windows.Forms.DockStyle.Top;
        lblCartTitle.Location = new System.Drawing.Point(20, 20);
        lblCartTitle.Name = "lblCartTitle";
        lblCartTitle.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
        lblCartTitle.Size = new System.Drawing.Size(300, 50);
        lblCartTitle.TabIndex = 0;
        // 
        // lblCartTitleText
        // 
        lblCartTitleText.Dock = System.Windows.Forms.DockStyle.Fill;
        lblCartTitleText.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        lblCartTitleText.ForeColor = System.Drawing.Color.White;
        lblCartTitleText.Location = new System.Drawing.Point(10, 5);
        lblCartTitleText.Name = "lblCartTitleText";
        lblCartTitleText.Size = new System.Drawing.Size(280, 40);
        lblCartTitleText.TabIndex = 0;
        lblCartTitleText.Text = "PANIER";
        lblCartTitleText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblClient
        // 
        lblClient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        lblClient.Location = new System.Drawing.Point(20, 80);
        lblClient.Name = "lblClient";
        lblClient.Size = new System.Drawing.Size(60, 25);
        lblClient.TabIndex = 1;
        lblClient.Text = "Client:";
        lblClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // cmbClients
        // 
        cmbClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbClients.Font = new System.Drawing.Font("Segoe UI", 10F);
        cmbClients.FormattingEnabled = true;
        cmbClients.Location = new System.Drawing.Point(90, 80);
        cmbClients.Name = "cmbClients";
        cmbClients.Size = new System.Drawing.Size(230, 25);
        cmbClients.TabIndex = 2;
        // 
        // panelCart
        // 
        panelCart.BackColor = System.Drawing.Color.White;
        panelCart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        panelCart.Controls.Add(lstCart);
        panelCart.Location = new System.Drawing.Point(20, 115);
        panelCart.Name = "panelCart";
        panelCart.Padding = new System.Windows.Forms.Padding(1);
        panelCart.Size = new System.Drawing.Size(300, 300);
        panelCart.TabIndex = 3;
        // 
        // lstCart
        // 
        lstCart.BackColor = System.Drawing.Color.White;
        lstCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
        lstCart.Dock = System.Windows.Forms.DockStyle.Fill;
        lstCart.Font = new System.Drawing.Font("Segoe UI", 10F);
        lstCart.FormattingEnabled = true;
        lstCart.Location = new System.Drawing.Point(1, 1);
        lstCart.Name = "lstCart";
        lstCart.Size = new System.Drawing.Size(296, 296);
        lstCart.TabIndex = 0;
        // 
        // panelCartActions
        // 
        panelCartActions.Controls.Add(btnRemoveFromCart);
        panelCartActions.Controls.Add(lblTotal);
        panelCartActions.Location = new System.Drawing.Point(20, 425);
        panelCartActions.Name = "panelCartActions";
        panelCartActions.Size = new System.Drawing.Size(300, 50);
        panelCartActions.TabIndex = 4;
        // 
        // btnRemoveFromCart
        // 
        btnRemoveFromCart.BackColor = System.Drawing.Color.FromArgb(((int)((byte)220)), ((int)((byte)53)), ((int)((byte)69)));
        btnRemoveFromCart.FlatAppearance.BorderSize = 0;
        btnRemoveFromCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnRemoveFromCart.Font = new System.Drawing.Font("Segoe UI", 10F);
        btnRemoveFromCart.ForeColor = System.Drawing.Color.White;
        btnRemoveFromCart.Location = new System.Drawing.Point(0, 10);
        btnRemoveFromCart.Name = "btnRemoveFromCart";
        btnRemoveFromCart.Size = new System.Drawing.Size(100, 35);
        btnRemoveFromCart.TabIndex = 0;
        btnRemoveFromCart.Text = "Retirer";
        btnRemoveFromCart.UseVisualStyleBackColor = false;
        btnRemoveFromCart.Click += BtnRemoveFromCart_Click;
        // 
        // lblTotal
        // 
        lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)40)), ((int)((byte)167)), ((int)((byte)69)));
        lblTotal.Location = new System.Drawing.Point(110, 10);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new System.Drawing.Size(190, 35);
        lblTotal.TabIndex = 1;
        lblTotal.Text = "Total: 0 HTG";
        lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // panelBottom
        // 
        panelBottom.Controls.Add(btnCancel);
        panelBottom.Controls.Add(btnConfirmOrder);
        panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelBottom.Location = new System.Drawing.Point(20, 575);
        panelBottom.Name = "panelBottom";
        panelBottom.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
        panelBottom.Size = new System.Drawing.Size(300, 65);
        panelBottom.TabIndex = 5;
        // 
        // btnCancel
        // 
        btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)((byte)108)), ((int)((byte)117)), ((int)((byte)125)));
        btnCancel.FlatAppearance.BorderSize = 0;
        btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
        btnCancel.ForeColor = System.Drawing.Color.White;
        btnCancel.Location = new System.Drawing.Point(170, 10);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new System.Drawing.Size(120, 40);
        btnCancel.TabIndex = 1;
        btnCancel.Text = "Annuler";
        btnCancel.UseVisualStyleBackColor = false;
        btnCancel.Click += BtnCancel_Click;
        // 
        // btnConfirmOrder
        // 
        btnConfirmOrder.BackColor = System.Drawing.Color.FromArgb(((int)((byte)40)), ((int)((byte)167)), ((int)((byte)69)));
        btnConfirmOrder.FlatAppearance.BorderSize = 0;
        btnConfirmOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnConfirmOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btnConfirmOrder.ForeColor = System.Drawing.Color.White;
        btnConfirmOrder.Location = new System.Drawing.Point(30, 10);
        btnConfirmOrder.Name = "btnConfirmOrder";
        btnConfirmOrder.Size = new System.Drawing.Size(120, 40);
        btnConfirmOrder.TabIndex = 0;
        btnConfirmOrder.Text = "Valider";
        btnConfirmOrder.UseVisualStyleBackColor = false;
        btnConfirmOrder.Click += BtnConfirmOrder_Click;
        // 
        // OrderForm
        // 
        ClientSize = new System.Drawing.Size(1000, 650);
        Controls.Add(splitContainer);
        Font = new System.Drawing.Font("Segoe UI", 9F);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimumSize = new System.Drawing.Size(800, 500);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
    private System.Windows.Forms.Label lblMenusTitle;
    private System.Windows.Forms.DataGridView dgvMenus;
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