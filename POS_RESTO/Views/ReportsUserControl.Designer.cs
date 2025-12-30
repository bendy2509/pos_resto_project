namespace POS_RESTO.Views
{
    partial class ReportsUserControl
    {
        private System.ComponentModel.IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
        
        private System.Windows.Forms.DataGridView dgvReport;
        private Button btnGenerate;
        private Button btnExport;
        private ComboBox cmbReportType;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Label lblTotal;
        private Label lblReportType;
        private Label lblFrom;
        private Label lblTo;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvReport = new System.Windows.Forms.DataGridView();
            btnGenerate = new System.Windows.Forms.Button();
            btnExport = new System.Windows.Forms.Button();
            cmbReportType = new System.Windows.Forms.ComboBox();
            dtpFrom = new System.Windows.Forms.DateTimePicker();
            dtpTo = new System.Windows.Forms.DateTimePicker();
            lblTotal = new System.Windows.Forms.Label();
            lblTitle = new System.Windows.Forms.Label();
            panelControls = new System.Windows.Forms.Panel();
            lblReportType = new System.Windows.Forms.Label();
            lblFrom = new System.Windows.Forms.Label();
            lblTo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            panelControls.SuspendLayout();
            SuspendLayout();
            // 
            // dgvReport
            // 
            dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.BackgroundColor = System.Drawing.Color.White;
            dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvReport.Location = new System.Drawing.Point(20, 150);
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dgvReport.RowHeadersVisible = false;
            dgvReport.Size = new System.Drawing.Size(633, 275);
            dgvReport.TabIndex = 0;
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
            btnGenerate.FlatAppearance.BorderSize = 0;
            btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGenerate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnGenerate.ForeColor = System.Drawing.Color.White;
            btnGenerate.Location = new System.Drawing.Point(10, 40);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new System.Drawing.Size(150, 35);
            btnGenerate.TabIndex = 6;
            btnGenerate.Text = "Generer Rapport";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += BtnGenerate_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = System.Drawing.Color.FromArgb(((int)((byte)40)), ((int)((byte)167)), ((int)((byte)69)));
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnExport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnExport.ForeColor = System.Drawing.Color.White;
            btnExport.Location = new System.Drawing.Point(170, 40);
            btnExport.Name = "btnExport";
            btnExport.Size = new System.Drawing.Size(150, 35);
            btnExport.TabIndex = 7;
            btnExport.Text = "Exporter Excel";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += BtnExport_Click;
            // 
            // cmbReportType
            // 
            cmbReportType.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbReportType.Items.AddRange(new object[] { "Ventes par jour", "Ventes par categorie", "Top menus vendus", "Clients avec dette", "Ventes par mode paiement" });
            cmbReportType.Location = new System.Drawing.Point(125, 7);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new System.Drawing.Size(180, 25);
            cmbReportType.TabIndex = 1;
            // 
            // dtpFrom
            // 
            dtpFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpFrom.Location = new System.Drawing.Point(355, 7);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new System.Drawing.Size(120, 25);
            dtpFrom.TabIndex = 3;
            dtpFrom.Value = new System.DateTime(2025, 11, 29, 17, 4, 49, 494);
            // 
            // dtpTo
            // 
            dtpTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpTo.Location = new System.Drawing.Point(515, 7);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new System.Drawing.Size(120, 25);
            dtpTo.TabIndex = 5;
            dtpTo.Value = new System.DateTime(2025, 12, 29, 17, 4, 49, 597);
            // 
            // lblTotal
            // 
            lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
            lblTotal.Location = new System.Drawing.Point(650, 40);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new System.Drawing.Size(200, 35);
            lblTotal.TabIndex = 8;
            lblTotal.Text = "Total: 0 HTG";
            lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
            lblTitle.Location = new System.Drawing.Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(633, 50);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "RAPPORTS ET STATISTIQUES";
            // 
            // panelControls
            // 
            panelControls.BackColor = System.Drawing.Color.WhiteSmoke;
            panelControls.Controls.Add(lblReportType);
            panelControls.Controls.Add(cmbReportType);
            panelControls.Controls.Add(lblFrom);
            panelControls.Controls.Add(dtpFrom);
            panelControls.Controls.Add(lblTo);
            panelControls.Controls.Add(dtpTo);
            panelControls.Controls.Add(btnGenerate);
            panelControls.Controls.Add(btnExport);
            panelControls.Controls.Add(lblTotal);
            panelControls.Dock = System.Windows.Forms.DockStyle.Top;
            panelControls.Location = new System.Drawing.Point(20, 70);
            panelControls.Name = "panelControls";
            panelControls.Padding = new System.Windows.Forms.Padding(10);
            panelControls.Size = new System.Drawing.Size(633, 80);
            panelControls.TabIndex = 1;
            // 
            // lblReportType
            // 
            lblReportType.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblReportType.Location = new System.Drawing.Point(10, 10);
            lblReportType.Name = "lblReportType";
            lblReportType.Size = new System.Drawing.Size(110, 25);
            lblReportType.TabIndex = 0;
            lblReportType.Text = "Type de rapport:";
            // 
            // lblFrom
            // 
            lblFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblFrom.Location = new System.Drawing.Point(320, 10);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new System.Drawing.Size(30, 25);
            lblFrom.TabIndex = 2;
            lblFrom.Text = "Du:";
            // 
            // lblTo
            // 
            lblTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblTo.Location = new System.Drawing.Point(485, 10);
            lblTo.Name = "lblTo";
            lblTo.Size = new System.Drawing.Size(25, 25);
            lblTo.TabIndex = 4;
            lblTo.Text = "Au:";
            // 
            // ReportsUserControl
            // 
            BackColor = System.Drawing.Color.White;
            Controls.Add(dgvReport);
            Controls.Add(panelControls);
            Controls.Add(lblTitle);
            Padding = new System.Windows.Forms.Padding(20);
            Size = new System.Drawing.Size(673, 445);
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            panelControls.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelControls;
    }
}