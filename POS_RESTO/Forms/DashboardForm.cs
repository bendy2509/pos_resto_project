using POS_RESTO.Utils;
using Timer = System.Windows.Forms.Timer;
using MySql.Data.MySqlClient;
using System.Data;
using POS_RESTO.Configuration;

namespace POS_RESTO.Forms;

public partial class DashboardForm : Form
{
    private Timer timer1;

    public DashboardForm()
    {
        InitializeComponent();

        // Creer et configurer le timer
        timer1 = new Timer();
        timer1.Interval = 1000; // 1 seconde
        timer1.Tick += Timer1_Tick;
        timer1.Start();

        // Afficher l'utilisateur
        lblStatusUser.Text = $"Utilisateur: {Session.Username} ({Session.Role})";

        // Mettre a jour la date
        lblDate.Text = DateTime.Now.ToString("dddd dd MMMM yyyy");

        // Charger les donnees
        LoadDashboardData();
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
        // Mettre a jour l'heure chaque seconde
        lblStatusTime.Text = DateTime.Now.ToString("HH:mm:ss");
    }

    // Stopper le timer
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        timer1?.Stop();
        timer1?.Dispose();
        base.OnFormClosing(e);
    }

    private void LoadDashboardData()
    {
        try
        {
            using (var conn = DatabaseConfig.GetConnection())
            {
                conn.Open();

                // 1. Nombre de commandes aujourd'hui
                string queryOrders = "SELECT COUNT(*) FROM Orders WHERE DATE(order_date) = CURDATE()";
                using (var cmd = new MySqlCommand(queryOrders, conn))
                {
                    lblOrdersCount.Text = cmd.ExecuteScalar().ToString();
                }

                // 2. Chiffre d'affaires aujourd'hui
                string queryRevenue = @"
                SELECT COALESCE(SUM(m.unit_price * o.quantity), 0) 
                FROM Orders o
                JOIN Menus m ON o.menu_id = m.menu_id
                WHERE DATE(o.order_date) = CURDATE()";
                using (var cmd = new MySqlCommand(queryRevenue, conn))
                {
                    decimal revenue = Convert.ToDecimal(cmd.ExecuteScalar());
                    lblRevenueValue.Text = $"{revenue} HTG";
                }

                // 3. Nombre de menus disponibles
                string queryMenus = "SELECT COUNT(*) FROM Menus WHERE stock_quantity > 0";
                using (var cmd = new MySqlCommand(queryMenus, conn))
                {
                    lblMenusCount.Text = cmd.ExecuteScalar().ToString();
                }

                // 4. Nombre de clients
                string queryClients = "SELECT COUNT(*) FROM Clients";
                using (var cmd = new MySqlCommand(queryClients, conn))
                {
                    lblClientsCount.Text = cmd.ExecuteScalar().ToString();
                }

                // 5. Commandes recentes (7 derniers jours)
                string queryRecent = @"
                SELECT DATE(o.order_date) as Date,
                       COUNT(*) as 'Nombre Commandes',
                       SUM(m.unit_price * o.quantity) as 'Total HTG'
                FROM Orders o
                JOIN Menus m ON o.menu_id = m.menu_id
                WHERE o.order_date >= DATE_SUB(CURDATE(), INTERVAL 7 DAY)
                GROUP BY DATE(o.order_date)
                ORDER BY Date DESC";

                using (var cmd = new MySqlCommand(queryRecent, conn))
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewRecent.DataSource = dt;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur chargement données: {ex.Message}");
        }
    }

    private void logout_click(object sender, EventArgs e)
    {
        // Demander confirmation
        if (MessageBox.Show("Voulez-vous vraiment vous deconnecter ?",
                "Deconnexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            // Vider la session
            Session.Clear();

            // Fermer ce DashboardForm
            this.Close();
            // La boucle nan Dashboard la ap reprann kontwol la
        }
    }

    private void quit_click(object sender, EventArgs e)
    {
        // Demander confirmation
        if (MessageBox.Show("Voulez-vous vraiment quitter l'application ?",
                "Quitter", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            Application.Exit();
        }
    }

    private void about_click(object sender, EventArgs e)
    {
        var aboutForm = new AboutForm();
        aboutForm.ShowDialog();
    }
}