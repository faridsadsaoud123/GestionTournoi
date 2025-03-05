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
                    richTextTrace.Text += "\n" + DateTime.Now + " - Ajout de l'équipe " + notification.Equipe.DisplayEquipe;
                    break;
                case NotificationTournoiType.NewPlayer:
                    richTextTrace.Text += "\n" + DateTime.Now + " - Ajout du joueur " + notification.Joueur.DisplayJoueur + " dans l'équipe  " + notification.Equipe.DisplayEquipe;
                    break;
                case NotificationTournoiType.TeamReady:
                    richTextTrace.Text += "\n" + DateTime.Now + " - Equipe  " + notification.Equipe.DisplayEquipe + " prête à jouer";
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
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            refreshForm();
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
    }
}
