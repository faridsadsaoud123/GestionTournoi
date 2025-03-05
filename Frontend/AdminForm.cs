using GestionTournoi.Backend;
using System.Data;

namespace GestionTournoiEtape3.Frontend
{
    public partial class AdminForm : Form, IObserver<NotificationTournoi> 
    {
        private IDisposable? _subscription;
        public virtual void Subscribe(Tournoi provider) => _subscription = provider.Subscribe(this);
        public virtual void Unsubscribe()
        {
            _subscription?.Dispose();
        }

        public AdminForm()
        {
            InitializeComponent();
            Controls.Add(labelChrono);
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // S'abonner aux notifications du tournoi pour être informé des changements
            _subscription = Tournoi.Instance.Subscribe(this);

            // Rafraîchir les informations au chargement
            refreshForm();
            Tournoi.Instance.Chrono.OnTick += UpdateChronoDisplay;
            Tournoi.Instance.Chrono.OnTimeUp += OnTimeUp;
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Se désabonner lorsqu'on ferme la fenêtre pour éviter les fuites de mémoire
            _subscription?.Dispose();
        }

        private void buttonDemarrerCompetition_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Equipe[]? GetEquipes(bool isInscrite)
        {
            return Tournoi.Instance.GetEquipes().Where(t => t.isReady == isInscrite).ToArray();
        }

        private void refreshForm()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(refreshForm));
                return;
            }

            textNomTournoi.Text = Tournoi.Instance.NomTournoi;

            listEquipesInscrites.Items.Clear();
            listEquipesInscrites.Items.AddRange(GetEquipes(true));
            listEquipesInscrites.DisplayMember = "DisplayEquipe";

            listEquipesEnCours.Items.Clear();
            listEquipesEnCours.Items.AddRange(GetEquipes(false));
            listEquipesEnCours.DisplayMember = "DisplayEquipe";

            listJoueurs.Items.Clear();
            listJoueurs.Items.AddRange(Tournoi.Instance.GetJoueurs().ToArray());
            listJoueurs.DisplayMember = "DisplayJoueur";
        }


        public void OnNext(NotificationTournoi notification)
        {
            switch (notification.Type)
            {
                case NotificationTournoiType.NewTeam:
                    richTextTrace.Text += "\n" + DateTime.Now + " - Nouvelle équipe : " + notification.Equipe.DisplayEquipe;
                    break;
                case NotificationTournoiType.NewPlayer:
                    richTextTrace.Text += "\n" + DateTime.Now + " - Nouveau joueur : " + notification.Joueur.DisplayJoueur + " ajouté à " + notification.Equipe.DisplayEquipe;
                    break;
                case NotificationTournoiType.TeamReady:
                    richTextTrace.Text += "\n" + DateTime.Now + " - Équipe prête : " + notification.Equipe.DisplayEquipe;
                    break;
                case NotificationTournoiType.TeamRemoved:
                    if (InvokeRequired)
                    {
                        Invoke(new Action(() =>
                        {
                            richTextTrace.Text += "\n" + DateTime.Now + " - Équipe supprimée : " + notification.Equipe.DisplayEquipe;
                        }));
                    }
                    else
                    {
                        richTextTrace.Text += "\n" + DateTime.Now + " - Équipe supprimée : " + notification.Equipe.DisplayEquipe;
                    }
                    break;

            }

            refreshForm();
        }
        

        public void OnCompleted() { }
        public void OnError(Exception error) { }
        private Label labelChrono = new Label
        {
            AutoSize = true,
            Font = new Font("Arial", 12, FontStyle.Bold),
            ForeColor = Color.Red,
            Location = new Point(1180, 10),
            Text = "Temps restant : 02:00"
        };
        private void UpdateChronoDisplay(string tempsRestant)   
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => labelChrono.Text = "Temps restant : " + tempsRestant));
            }
            else
            {
                labelChrono.Text = "Temps restant : " + tempsRestant;
            }
        }
        private void OnTimeUp()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    labelChrono.Text = "Temps écoulé !";
                    buttonDemarrerCompetition.Enabled = true;
                    refreshForm(); 
                }));
            }
            else
            {
                labelChrono.Text = "Temps écoulé !";
                buttonDemarrerCompetition.Enabled = true;
                refreshForm();
            }
        }



    }
}
