using GestionTournoi.Backend;
using GestionTournoi.Frontend;
using GestionTournoiEtape3.Frontend;

namespace GestionTournoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            JoueurForm joueurForm = new JoueurForm();
            joueurForm.Show();

            AdminForm adminForm = new AdminForm();
            adminForm.Subscribe(Tournoi.GetInstance());
            adminForm.Show();

        }
    }
}
