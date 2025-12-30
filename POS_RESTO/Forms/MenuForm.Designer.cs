using System.ComponentModel;

namespace POS_RESTO.Forms;

partial class MenuForm
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
        panel = new System.Windows.Forms.Panel();
        lblTitle = new System.Windows.Forms.Label();
        lblName = new System.Windows.Forms.Label();
        txtName = new System.Windows.Forms.TextBox();
        lblCategory = new System.Windows.Forms.Label();
        cmbCategory = new System.Windows.Forms.ComboBox();
        lblPrice = new System.Windows.Forms.Label();
        numPrice = new System.Windows.Forms.NumericUpDown();
        lblStock = new System.Windows.Forms.Label();
        numStock = new System.Windows.Forms.NumericUpDown();
        lblDescription = new System.Windows.Forms.Label();
        txtDescription = new System.Windows.Forms.TextBox();
        panelButtons = new System.Windows.Forms.Panel();
        btnSave = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        panel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
        panelButtons.SuspendLayout();
        SuspendLayout();
        // 
        // panel
        // 
        panel.Controls.Add(lblTitle);
        panel.Controls.Add(lblName);
        panel.Controls.Add(txtName);
        panel.Controls.Add(lblCategory);
        panel.Controls.Add(cmbCategory);
        panel.Controls.Add(lblPrice);
        panel.Controls.Add(numPrice);
        panel.Controls.Add(lblStock);
        panel.Controls.Add(numStock);
        panel.Controls.Add(lblDescription);
        panel.Controls.Add(txtDescription);
        panel.Dock = System.Windows.Forms.DockStyle.Fill;
        panel.Location = new System.Drawing.Point(0, 0);
        panel.Name = "panel";
        panel.Padding = new System.Windows.Forms.Padding(20);
        panel.Size = new System.Drawing.Size(484, 301);
        panel.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        lblTitle.Location = new System.Drawing.Point(0, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new System.Drawing.Size(484, 40);
        lblTitle.TabIndex = 0;
        lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblName
        // 
        lblName.Font = new System.Drawing.Font("Segoe UI", 10F);
        lblName.Location = new System.Drawing.Point(0, 50);
        lblName.Name = "lblName";
        lblName.Size = new System.Drawing.Size(100, 25);
        lblName.TabIndex = 1;
        lblName.Text = "Nom:*";
        // 
        // txtName
        // 
        txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtName.Location = new System.Drawing.Point(120, 50);
        txtName.Name = "txtName";
        txtName.Size = new System.Drawing.Size(300, 25);
        txtName.TabIndex = 2;
        // 
        // lblCategory
        // 
        lblCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
        lblCategory.Location = new System.Drawing.Point(0, 90);
        lblCategory.Name = "lblCategory";
        lblCategory.Size = new System.Drawing.Size(100, 25);
        lblCategory.TabIndex = 3;
        lblCategory.Text = "Catégorie:*";
        // 
        // cmbCategory
        // 
        cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
        cmbCategory.Items.AddRange(new object[] { "plats", "boissons", "desserts" });
        cmbCategory.Location = new System.Drawing.Point(120, 90);
        cmbCategory.Name = "cmbCategory";
        cmbCategory.Size = new System.Drawing.Size(150, 25);
        cmbCategory.TabIndex = 4;
        // 
        // lblPrice
        // 
        lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
        lblPrice.Location = new System.Drawing.Point(0, 130);
        lblPrice.Name = "lblPrice";
        lblPrice.Size = new System.Drawing.Size(100, 25);
        lblPrice.TabIndex = 5;
        lblPrice.Text = "Prix (HTG):*";
        // 
        // numPrice
        // 
        numPrice.DecimalPlaces = 2;
        numPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
        numPrice.Location = new System.Drawing.Point(120, 130);
        numPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numPrice.Name = "numPrice";
        numPrice.Size = new System.Drawing.Size(150, 25);
        numPrice.TabIndex = 6;
        // 
        // lblStock
        // 
        lblStock.Font = new System.Drawing.Font("Segoe UI", 10F);
        lblStock.Location = new System.Drawing.Point(0, 170);
        lblStock.Name = "lblStock";
        lblStock.Size = new System.Drawing.Size(100, 25);
        lblStock.TabIndex = 7;
        lblStock.Text = "Stock:";
        // 
        // numStock
        // 
        numStock.Font = new System.Drawing.Font("Segoe UI", 10F);
        numStock.Location = new System.Drawing.Point(120, 170);
        numStock.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        numStock.Name = "numStock";
        numStock.Size = new System.Drawing.Size(150, 25);
        numStock.TabIndex = 8;
        // 
        // lblDescription
        // 
        lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
        lblDescription.Location = new System.Drawing.Point(0, 210);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new System.Drawing.Size(100, 25);
        lblDescription.TabIndex = 9;
        lblDescription.Text = "Description:";
        // 
        // txtDescription
        // 
        txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtDescription.Location = new System.Drawing.Point(120, 210);
        txtDescription.Multiline = true;
        txtDescription.Name = "txtDescription";
        txtDescription.Size = new System.Drawing.Size(300, 80);
        txtDescription.TabIndex = 10;
        // 
        // panelButtons
        // 
        panelButtons.Controls.Add(btnSave);
        panelButtons.Controls.Add(btnCancel);
        panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelButtons.Location = new System.Drawing.Point(0, 301);
        panelButtons.Name = "panelButtons";
        panelButtons.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
        panelButtons.Size = new System.Drawing.Size(484, 60);
        panelButtons.TabIndex = 1;
        // 
        // btnSave
        // 
        btnSave.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btnSave.ForeColor = System.Drawing.Color.White;
        btnSave.Location = new System.Drawing.Point(200, 10);
        btnSave.Name = "btnSave";
        btnSave.Size = new System.Drawing.Size(120, 35);
        btnSave.TabIndex = 0;
        btnSave.Text = "Enregistrer";
        btnSave.UseVisualStyleBackColor = false;
        btnSave.Click += BtnSave_Click;
        // 
        // btnCancel
        // 
        btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)((byte)108)), ((int)((byte)117)), ((int)((byte)125)));
        btnCancel.FlatAppearance.BorderSize = 0;
        btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
        btnCancel.ForeColor = System.Drawing.Color.White;
        btnCancel.Location = new System.Drawing.Point(330, 10);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new System.Drawing.Size(120, 35);
        btnCancel.TabIndex = 1;
        btnCancel.Text = "Annuler";
        btnCancel.UseVisualStyleBackColor = false;
        btnCancel.Click += BtnCancel_Click;
        // 
        // MenuForm
        // 
        ClientSize = new System.Drawing.Size(484, 361);
        Controls.Add(panel);
        Controls.Add(panelButtons);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        panel.ResumeLayout(false);
        panel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
        ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
        panelButtons.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label lblTitle;

    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnSave; 
    private System.Windows.Forms.TextBox txtDescription; 
    private System.Windows.Forms.NumericUpDown numStock; 
    private System.Windows.Forms.NumericUpDown numPrice; 
    private System.Windows.Forms.ComboBox cmbCategory; 
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label lblDescription;
    private System.Windows.Forms.Label lblStock;
    private System.Windows.Forms.Label lblPrice;
    private System.Windows.Forms.Label lblCategory;
    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.Panel panelButtons;
    private System.Windows.Forms.Panel panel;

    #endregion
    
    private int? menuId;
}