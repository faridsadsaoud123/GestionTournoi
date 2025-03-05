using GestionTournoi.Backend;
using GestionTournoi.Frontend;
using GestionTournoiEtape3.Frontend;

namespace Tournoi_ad
{
    public partial class MainForm : Form
    {
        public  MainForm()
        {
            InitializeComponent();
            JoueurForm joueurForm = new JoueurForm();
            joueurForm.Show();

            AdminForm adminForm = new AdminForm();
            adminForm.Subscribe(Tournoi.Instance);
            adminForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
