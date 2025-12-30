using System;
using System.Drawing;
using System.Windows.Forms;
using POS_RESTO.Utils;
using POS_RESTO.Views;
using Timer = System.Windows.Forms.Timer;

namespace POS_RESTO.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetupTimer();
            SetupSidebarButtons();
            SetupMenuEvents();
            ShowDashboard();
        }

        private void SetupTimer()
        {
            lblStatusUser.Text = $"Utilisateur: {Session.Username} ({Session.Role})";
            lblStatusTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        
        private void SetupSidebarButtons()
        {
            btnDashboard.Click += (s, e) => ShowView<DashboardUserControl>();
            btnOrders.Click += (s, e) => ShowView<OrdersUserControl>();
            btnMenus.Click += (s, e) => ShowView<MenusUserControl>();
            btnClients.Click += (s, e) => ShowView<ClientsUserControl>();
            btnPayments.Click += (s, e) => ShowView<PaymentsUserControl>();
            btnReports.Click += (s, e) => ShowView<ReportsUserControl>();

            HighlightButton(btnDashboard);
        }

        private void SetupMenuEvents()
        {
            logoutToolStripMenuItem.Click += LogoutToolStripMenuItem_Click;
            quitterToolStripMenuItem.Click += QuitterToolStripMenuItem_Click;
            aproposToolStripMenuItem.Click += AproposToolStripMenuItem_Click;
        }

        private void ShowView<T>() where T : UserControl, new()
        {
            if (currentView != null)
            {
                panelContent.Controls.Remove(currentView);
                currentView.Dispose();
            }

            var view = new T();
            view.Dock = DockStyle.Fill;
            panelContent.Controls.Add(view);
            currentView = view;

            HighlightButton(GetButtonForView<T>());
        }

        private void ShowDashboard()
        {
            ShowView<DashboardUserControl>();
        }

        private Button GetButtonForView<T>() where T : UserControl
        {
            string typeName = typeof(T).Name;
            
            switch (typeName)
            {
                case nameof(DashboardUserControl):
                    return btnDashboard;
                case nameof(OrdersUserControl):
                    return btnOrders;
                case nameof(MenusUserControl):
                    return btnMenus;
                case nameof(ClientsUserControl):
                    return btnClients;
                case nameof(PaymentsUserControl):
                    return btnPayments;
                case nameof(ReportsUserControl):
                    return btnReports;
                default:
                    return btnDashboard;
            }
        }

        private void HighlightButton(Button button)
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.Transparent;
                currentButton.ForeColor = Color.Black;
            }

            button.BackColor = Color.FromArgb(0, 123, 255);
            button.ForeColor = Color.White;
            currentButton = button;
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vous deconnecter ?", 
                "Deconnexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Session.Clear();
                timer1?.Stop();
                this.Close();
            }
        }

        private void QuitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous quitter l application ?", 
                "Quitter", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void AproposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new AboutForm();
            about.ShowDialog();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timer1?.Stop();
            timer1?.Dispose();
            base.OnFormClosing(e);
        }
        
        // Methode pour rafraichir la vue courante
        public void RefreshCurrentView()
        {
            if (currentView != null)
            {
                var refreshMethod = currentView.GetType().GetMethod("RefreshData");
                if (refreshMethod != null)
                {
                    refreshMethod.Invoke(currentView, null);
                }
            }
        }
        
        // Methode pour naviguer vers une vue specifique
        public void NavigateTo<T>() where T : UserControl, new()
        {
            ShowView<T>();
        }
    }
}