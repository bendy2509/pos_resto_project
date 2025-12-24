using System.ComponentModel;

namespace POS_RESTO.Forms;

partial class LoginForm
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
        panelMain = new System.Windows.Forms.Panel();
        panelRight = new System.Windows.Forms.Panel();
        labelWelcome = new System.Windows.Forms.Label();
        labelSubtitle = new System.Windows.Forms.Label();
        labelUsername = new System.Windows.Forms.Label();
        textUsername = new System.Windows.Forms.TextBox();
        labelPassword = new System.Windows.Forms.Label();
        textPassword = new System.Windows.Forms.TextBox();
        checkShowPassword = new System.Windows.Forms.CheckBox();
        btnLogin = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        panelLeft = new System.Windows.Forms.Panel();
        labelRestoName = new System.Windows.Forms.Label();
        labelSlogan = new System.Windows.Forms.Label();
        panelMain.SuspendLayout();
        panelRight.SuspendLayout();
        panelLeft.SuspendLayout();
        SuspendLayout();
        // 
        // panelMain
        // 
        panelMain.Controls.Add(panelRight);
        panelMain.Controls.Add(panelLeft);
        panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        panelMain.Location = new System.Drawing.Point(0, 0);
        panelMain.Name = "panelMain";
        panelMain.Size = new System.Drawing.Size(900, 500);
        panelMain.TabIndex = 0;
        // 
        // panelRight
        // 
        panelRight.BackColor = System.Drawing.Color.White;
        panelRight.Controls.Add(labelWelcome);
        panelRight.Controls.Add(labelSubtitle);
        panelRight.Controls.Add(labelUsername);
        panelRight.Controls.Add(textUsername);
        panelRight.Controls.Add(labelPassword);
        panelRight.Controls.Add(textPassword);
        panelRight.Controls.Add(checkShowPassword);
        panelRight.Controls.Add(btnLogin);
        panelRight.Controls.Add(btnCancel);
        panelRight.Location = new System.Drawing.Point(400, 0);
        panelRight.Name = "panelRight";
        panelRight.Size = new System.Drawing.Size(500, 500);
        panelRight.TabIndex = 0;
        // 
        // labelWelcome
        // 
        labelWelcome.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
        labelWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        labelWelcome.Location = new System.Drawing.Point(50, 80);
        labelWelcome.Name = "labelWelcome";
        labelWelcome.Size = new System.Drawing.Size(400, 60);
        labelWelcome.TabIndex = 0;
        labelWelcome.Text = "BIENVENUE";
        labelWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // labelSubtitle
        // 
        labelSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
        labelSubtitle.ForeColor = System.Drawing.Color.Gray;
        labelSubtitle.Location = new System.Drawing.Point(50, 140);
        labelSubtitle.Name = "labelSubtitle";
        labelSubtitle.Size = new System.Drawing.Size(400, 30);
        labelSubtitle.TabIndex = 1;
        labelSubtitle.Text = "Veuillez vous connecter pour accéder au système";
        labelSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // labelUsername
        // 
        labelUsername.AutoSize = true;
        labelUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
        labelUsername.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
        labelUsername.Location = new System.Drawing.Point(50, 200);
        labelUsername.Name = "labelUsername";
        labelUsername.Size = new System.Drawing.Size(123, 20);
        labelUsername.TabIndex = 2;
        labelUsername.Text = "Nom d\'utilisateur";
        // 
        // textUsername
        // 
        textUsername.BackColor = System.Drawing.Color.WhiteSmoke;
        textUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        textUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
        textUsername.Location = new System.Drawing.Point(50, 225);
        textUsername.Name = "textUsername";
        textUsername.Size = new System.Drawing.Size(400, 27);
        textUsername.TabIndex = 3;
        // 
        // labelPassword
        // 
        labelPassword.AutoSize = true;
        labelPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
        labelPassword.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
        labelPassword.Location = new System.Drawing.Point(50, 270);
        labelPassword.Name = "labelPassword";
        labelPassword.Size = new System.Drawing.Size(98, 20);
        labelPassword.TabIndex = 4;
        labelPassword.Text = "Mot de passe";
        // 
        // textPassword
        // 
        textPassword.BackColor = System.Drawing.Color.WhiteSmoke;
        textPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        textPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
        textPassword.Location = new System.Drawing.Point(50, 295);
        textPassword.Name = "textPassword";
        textPassword.PasswordChar = '●';
        textPassword.Size = new System.Drawing.Size(400, 27);
        textPassword.TabIndex = 5;
        textPassword.UseSystemPasswordChar = true;
        // 
        // checkShowPassword
        // 
        checkShowPassword.AutoSize = true;
        checkShowPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
        checkShowPassword.ForeColor = System.Drawing.Color.Gray;
        checkShowPassword.Location = new System.Drawing.Point(50, 330);
        checkShowPassword.Name = "checkShowPassword";
        checkShowPassword.Size = new System.Drawing.Size(153, 19);
        checkShowPassword.TabIndex = 6;
        checkShowPassword.Text = "Afficher le mot de passe";
        checkShowPassword.UseVisualStyleBackColor = true;
        // 
        // btnLogin
        // 
        btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        btnLogin.FlatAppearance.BorderSize = 0;
        btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        btnLogin.ForeColor = System.Drawing.Color.White;
        btnLogin.Location = new System.Drawing.Point(50, 380);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new System.Drawing.Size(190, 45);
        btnLogin.TabIndex = 7;
        btnLogin.Text = "CONNEXION";
        btnLogin.UseVisualStyleBackColor = false;
        // 
        // btnCancel
        // 
        btnCancel.BackColor = System.Drawing.Color.Silver;
        btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        btnCancel.Location = new System.Drawing.Point(260, 380);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new System.Drawing.Size(190, 45);
        btnCancel.TabIndex = 8;
        btnCancel.Text = "ANNULER";
        btnCancel.UseVisualStyleBackColor = false;
        // 
        // panelLeft
        // 
        panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        panelLeft.Controls.Add(labelRestoName);
        panelLeft.Controls.Add(labelSlogan);
        panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
        panelLeft.Location = new System.Drawing.Point(0, 0);
        panelLeft.Name = "panelLeft";
        panelLeft.Size = new System.Drawing.Size(400, 500);
        panelLeft.TabIndex = 0;
        // 
        // labelRestoName
        // 
        labelRestoName.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
        labelRestoName.ForeColor = System.Drawing.Color.White;
        labelRestoName.Location = new System.Drawing.Point(20, 180);
        labelRestoName.Name = "labelRestoName";
        labelRestoName.Size = new System.Drawing.Size(360, 80);
        labelRestoName.TabIndex = 0;
        labelRestoName.Text = "POS RESTO";
        labelRestoName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // labelSlogan
        // 
        labelSlogan.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Italic);
        labelSlogan.ForeColor = System.Drawing.Color.White;
        labelSlogan.Location = new System.Drawing.Point(20, 260);
        labelSlogan.Name = "labelSlogan";
        labelSlogan.Size = new System.Drawing.Size(360, 40);
        labelSlogan.TabIndex = 1;
        labelSlogan.Text = "Gestion de Restaurant";
        labelSlogan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // LoginForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(900, 500);
        Controls.Add(panelMain);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Connexion - POS Resto";
        panelMain.ResumeLayout(false);
        panelRight.ResumeLayout(false);
        panelRight.PerformLayout();
        panelLeft.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Panel panelMain;
    private System.Windows.Forms.Panel panelRight;
    private System.Windows.Forms.Panel panelLeft;
    private System.Windows.Forms.Label labelWelcome;
    private System.Windows.Forms.Label labelSubtitle;
    private System.Windows.Forms.Label labelUsername;
    private System.Windows.Forms.Label labelPassword;
    private System.Windows.Forms.CheckBox checkShowPassword;
    private System.Windows.Forms.Button btnLogin;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label labelRestoName;
    private System.Windows.Forms.Label labelSlogan;

    private System.Windows.Forms.TextBox textPassword;

    private System.Windows.Forms.TextBox textUsername;

    #endregion
}