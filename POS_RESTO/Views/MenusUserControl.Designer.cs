using System.ComponentModel;

namespace POS_RESTO.Views;

partial class MenusUserControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.SuspendLayout();
        this.BackColor = Color.White;
        this.Padding = new Padding(20);
        this.Dock = DockStyle.Fill;
        
        // Titre
        var lblTitle = new Label();
        lblTitle.Text = "GESTION DES MENUS";
        lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(0, 123, 255);
        lblTitle.Dock = DockStyle.Top;
        lblTitle.Height = 50;
        
        // Panel d'outils
        var panelTools = new Panel();
        panelTools.Dock = DockStyle.Top;
        panelTools.Height = 60;
        panelTools.BackColor = Color.White;
        panelTools.Padding = new Padding(0, 10, 0, 0);
        
        // Bouton ajouter
        btnAddMenu = new Button();
        btnAddMenu.Text = "Ajouter Menu";
        btnAddMenu.BackColor = Color.FromArgb(40, 167, 69);
        btnAddMenu.ForeColor = Color.White;
        btnAddMenu.FlatStyle = FlatStyle.Flat;
        btnAddMenu.FlatAppearance.BorderSize = 0;
        btnAddMenu.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        btnAddMenu.Size = new Size(120, 35);
        btnAddMenu.Location = new Point(0, 10);
        btnAddMenu.Click += new EventHandler(BtnAddMenu_Click);
        
        // Bouton modifier
        btnEditMenu = new Button();
        btnEditMenu.Text = "Modifier";
        btnEditMenu.BackColor = Color.FromArgb(255, 193, 7);
        btnEditMenu.ForeColor = Color.Black;
        btnEditMenu.FlatStyle = FlatStyle.Flat;
        btnEditMenu.FlatAppearance.BorderSize = 0;
        btnEditMenu.Font = new Font("Segoe UI", 10);
        btnEditMenu.Size = new Size(100, 35);
        btnEditMenu.Location = new Point(130, 10);
        btnEditMenu.Click += new EventHandler(BtnEditMenu_Click);
        
        // Bouton supprimer
        btnDeleteMenu = new Button();
        btnDeleteMenu.Text = "Supprimer";
        btnDeleteMenu.BackColor = Color.FromArgb(220, 53, 69);
        btnDeleteMenu.ForeColor = Color.White;
        btnDeleteMenu.FlatStyle = FlatStyle.Flat;
        btnDeleteMenu.FlatAppearance.BorderSize = 0;
        btnDeleteMenu.Font = new Font("Segoe UI", 10);
        btnDeleteMenu.Size = new Size(100, 35);
        btnDeleteMenu.Location = new Point(240, 10);
        btnDeleteMenu.Click += new EventHandler(BtnDeleteMenu_Click);
        
        // Filtre par categorie
        var lblFilter = new Label();
        lblFilter.Text = "Categorie:";
        lblFilter.Font = new Font("Segoe UI", 10);
        lblFilter.Location = new Point(350, 17);
        lblFilter.Size = new Size(70, 25);
        
        cmbFilterCategory = new ComboBox();
        cmbFilterCategory.Items.AddRange(new object[] { "Tous", "plats", "boissons", "desserts" });
        cmbFilterCategory.SelectedIndex = 0;
        cmbFilterCategory.Font = new Font("Segoe UI", 10);
        cmbFilterCategory.Size = new Size(120, 25);
        cmbFilterCategory.Location = new Point(420, 14);
        cmbFilterCategory.SelectedIndexChanged += new EventHandler(CmbFilterCategory_SelectedIndexChanged);
        
        panelTools.Controls.Add(btnAddMenu);
        panelTools.Controls.Add(btnEditMenu);
        panelTools.Controls.Add(btnDeleteMenu);
        panelTools.Controls.Add(lblFilter);
        panelTools.Controls.Add(cmbFilterCategory);
        
        // DataGridView
        dgvMenus = new DataGridView();
        dgvMenus.Dock = DockStyle.Fill;
        dgvMenus.BackgroundColor = Color.White;
        dgvMenus.ReadOnly = true;
        dgvMenus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvMenus.RowHeadersVisible = false;
        dgvMenus.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        
        SetupDataGridViewColumns();
        
        this.Controls.Add(dgvMenus);
        this.Controls.Add(panelTools);
        this.Controls.Add(lblTitle);
        this.ResumeLayout(false);
    }
    #endregion
    
    private DataGridView dgvMenus;
    private ComboBox cmbFilterCategory;
    private Button btnAddMenu;
    private Button btnEditMenu;
    private Button btnDeleteMenu;
}