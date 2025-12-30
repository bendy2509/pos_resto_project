namespace POS_RESTO.Views
{
    partial class PaymentsUserControl
    {
        private System.ComponentModel.IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
        
        
        private System.Windows.Forms.DataGridView dgvPayments;
        private Button btnNewPayment;
        private Button btnRefresh;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Commande;
        private System.Windows.Forms.DataGridViewTextBoxColumn Montant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mode;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dgvPayments = new System.Windows.Forms.DataGridView();
            ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Commande = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Montant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Mode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            btnNewPayment = new System.Windows.Forms.Button();
            btnRefresh = new System.Windows.Forms.Button();
            dtpFrom = new System.Windows.Forms.DateTimePicker();
            dtpTo = new System.Windows.Forms.DateTimePicker();
            lblTitle = new System.Windows.Forms.Label();
            panelTools = new System.Windows.Forms.Panel();
            lblFrom = new System.Windows.Forms.Label();
            lblTo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            panelTools.SuspendLayout();
            SuspendLayout();
            // 
            // dgvPayments
            // 
            dgvPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayments.BackgroundColor = System.Drawing.Color.White;
            dgvPayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { ID, Commande, Montant, Date, Mode });
            dgvPayments.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvPayments.Location = new System.Drawing.Point(20, 120);
            dgvPayments.Name = "dgvPayments";
            dgvPayments.ReadOnly = true;
            dgvPayments.RowHeadersVisible = false;
            dgvPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvPayments.Size = new System.Drawing.Size(613, 316);
            dgvPayments.TabIndex = 0;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // Commande
            // 
            Commande.HeaderText = "Commande";
            Commande.Name = "Commande";
            Commande.ReadOnly = true;
            // 
            // Montant
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            Montant.DefaultCellStyle = dataGridViewCellStyle1;
            Montant.HeaderText = "Montant HTG";
            Montant.Name = "Montant";
            Montant.ReadOnly = true;
            // 
            // Date
            // 
            Date.HeaderText = "Date";
            Date.Name = "Date";
            Date.ReadOnly = true;
            // 
            // Mode
            // 
            Mode.HeaderText = "Mode";
            Mode.Name = "Mode";
            Mode.ReadOnly = true;
            // 
            // btnNewPayment
            // 
            btnNewPayment.BackColor = System.Drawing.Color.FromArgb(((int)((byte)40)), ((int)((byte)167)), ((int)((byte)69)));
            btnNewPayment.FlatAppearance.BorderSize = 0;
            btnNewPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNewPayment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnNewPayment.ForeColor = System.Drawing.Color.White;
            btnNewPayment.Location = new System.Drawing.Point(330, 10);
            btnNewPayment.Name = "btnNewPayment";
            btnNewPayment.Size = new System.Drawing.Size(160, 35);
            btnNewPayment.TabIndex = 4;
            btnNewPayment.Text = "Nouveau Paiement";
            btnNewPayment.UseVisualStyleBackColor = false;
            btnNewPayment.Click += BtnNewPayment_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)((byte)108)), ((int)((byte)117)), ((int)((byte)125)));
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnRefresh.ForeColor = System.Drawing.Color.White;
            btnRefresh.Location = new System.Drawing.Point(500, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(100, 35);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Rafraichir";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // dtpFrom
            // 
            dtpFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpFrom.Location = new System.Drawing.Point(35, 12);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new System.Drawing.Size(120, 25);
            dtpFrom.TabIndex = 1;
            dtpFrom.Value = new System.DateTime(2025, 12, 22, 18, 18, 23, 209);
            dtpFrom.ValueChanged += DateFilter_Changed;
            // 
            // dtpTo
            // 
            dtpTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpTo.Location = new System.Drawing.Point(195, 12);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new System.Drawing.Size(120, 25);
            dtpTo.TabIndex = 3;
            dtpTo.Value = new System.DateTime(2025, 12, 29, 18, 18, 23, 350);
            dtpTo.ValueChanged += DateFilter_Changed;
            // 
            // lblTitle
            // 
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
            lblTitle.Location = new System.Drawing.Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(613, 50);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "GESTION DES PAIEMENTS";
            // 
            // panelTools
            // 
            panelTools.BackColor = System.Drawing.Color.White;
            panelTools.Controls.Add(lblFrom);
            panelTools.Controls.Add(dtpFrom);
            panelTools.Controls.Add(lblTo);
            panelTools.Controls.Add(dtpTo);
            panelTools.Controls.Add(btnNewPayment);
            panelTools.Controls.Add(btnRefresh);
            panelTools.Dock = System.Windows.Forms.DockStyle.Top;
            panelTools.Location = new System.Drawing.Point(20, 70);
            panelTools.Name = "panelTools";
            panelTools.Size = new System.Drawing.Size(613, 50);
            panelTools.TabIndex = 1;
            // 
            // lblFrom
            // 
            lblFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblFrom.Location = new System.Drawing.Point(0, 15);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new System.Drawing.Size(30, 25);
            lblFrom.TabIndex = 0;
            lblFrom.Text = "Du:";
            // 
            // lblTo
            // 
            lblTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblTo.Location = new System.Drawing.Point(165, 15);
            lblTo.Name = "lblTo";
            lblTo.Size = new System.Drawing.Size(25, 25);
            lblTo.TabIndex = 2;
            lblTo.Text = "Au:";
            // 
            // PaymentsUserControl
            // 
            BackColor = System.Drawing.Color.White;
            Controls.Add(dgvPayments);
            Controls.Add(panelTools);
            Controls.Add(lblTitle);
            Padding = new System.Windows.Forms.Padding(20);
            Size = new System.Drawing.Size(653, 456);
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            panelTools.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelTools;
    }
}