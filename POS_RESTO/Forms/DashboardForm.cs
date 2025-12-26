using POS_RESTO.Utils;
using Timer = System.Windows.Forms.Timer;

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

    // Ne pas oublier de stopper le timer quand le form se ferme
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        timer1?.Stop();
        timer1?.Dispose();
        base.OnFormClosing(e);
    }
    
    private void LoadDashboardData()
    {
        // TODO: Charger les donnees du tableau de bord
    }

    private void logout_click(object sender, EventArgs e)
    {
        // Demander confirmation
        if (MessageBox.Show("Voulez-vous vraiment vous deconnecter ?", 
                "Deconnexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            // Fermer ce DashboardForm
            this.Close();
        
            // Reouvrir le LoginForm
            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Recreer un nouveau DashboardForm
                Application.Run(new DashboardForm());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}