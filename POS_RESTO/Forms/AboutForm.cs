namespace POS_RESTO.Forms;

public partial class AboutForm : Form
{
    public AboutForm()
    {
        InitializeComponent();
        
        lblCredits.Text = """
                          Développé par :
                                          Albikendy JEAN
                                          Bendy SERVILUS
                                          Blemy JOSEPH
                          """;
    }

    private void btnCloseAbout(object sender, EventArgs e)
    {
        this.Close();
    }
}