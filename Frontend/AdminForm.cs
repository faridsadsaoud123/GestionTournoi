using GestionTournoi.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionTournoiEtape3.Frontend
{
    public partial class AdminForm : Form, IObserver<NotificationTournoi>
    {
        private IDisposable? _cancellation;
        private IDisposable? _subscription;

        public virtual void Subscribe(Tournoi provider) => _cancellation = provider.Subscribe(this);
        public virtual void Unsubscribe()
        {
            _cancellation?.Dispose();
        }
        public void OnNext(NotificationTournoi notification)
        {
            switch (notification.Type)
            {

                case NotificationTournoiType.NewTeam:
                if (InvokeRequired)
                {
                    Invoke(new Action(() =>
                    {
                        richTextTrace.Text += "\n" + DateTime.Now + " - Ajout de l'équipe " + notification.Equipe.DisplayEquipe;
                    }));
                }
                else
                    {
                        richTextTrace.Text += "\n" + DateTime.Now + " - Ajout de l'équipe " + notification.Equipe.DisplayEquipe;
                    }
                break;
                case NotificationTournoiType.NewPlayer:
                    richTextTrace.Text += "\n" + DateTime.Now + " - Ajout du joueur " + notification.Joueur.DisplayJoueur + " dans l'équipe  " + notification.Equipe.DisplayEquipe;
                    break;
                case NotificationTournoiType.TeamReady:
                    richTextTrace.Text += "\n" + DateTime.Now + " - Equipe  " + notification.Equipe.DisplayEquipe + " prête à jouer";
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
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public AdminForm()
        {
            InitializeComponent();
            Controls.Add(labelChrono);

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            _subscription = Tournoi.GetInstance().Subscribe(this);

            // Rafraîchir les informations au chargement
            refreshForm();
            Tournoi.GetInstance().chrono.OnTick += UpdateChronoDisplay;
            Tournoi.GetInstance().chrono.OnTimeUp += OnTimeUp;

        }

        private void buttonDemarrerCompetition_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Equipe[]? GetEquipes(bool isInscrite)
        {
            return Tournoi.GetInstance().GetEquipes().FindAll(t => t.IsReady == isInscrite).ToArray();
        }
        private void refreshForm()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(refreshForm));
                return;
            }

            textNomTournoi.Text = Tournoi.GetInstance().GetNomTournoi();
            listEquipesInscrites.Items.Clear();
            listEquipesInscrites.Items.AddRange(GetEquipes(true));
            listEquipesInscrites.DisplayMember = "DisplayEquipe";
            listEquipesEnCours.Items.Clear();
            listEquipesEnCours.Items.AddRange(GetEquipes(false));
            listEquipesEnCours.DisplayMember = "DisplayEquipe";
            listJoueurs.Items.Clear();
            listJoueurs.Items.AddRange(Tournoi.GetInstance().GetJoueurs().ToArray());
            listJoueurs.DisplayMember = "DisplayJoueur";
        }
        private Label labelChrono = new Label
        {
            AutoSize = true,
            Font = new Font("Arial", 12, FontStyle.Bold),
            ForeColor = Color.Red,
            Location = new Point(800, 10),
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
