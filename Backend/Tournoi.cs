using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTournoi.Backend
{
    public class Tournoi : IObservable<NotificationTournoi>
    {
        private string NomTournoi { get; set; } = "";
        private int NbJoueursMin { get; set; }

        private List<Equipe> _equipes { get; set; } = new List<Equipe>();
        private List<Joueur> joueurs { get; set; } = new List<Joueur>();

        private static readonly object _lock = new object();
        private static Tournoi _instance = null;
        // Une liste des observateurs (observers) - ici les frames admin et joueur
        private readonly HashSet<IObserver<NotificationTournoi>> _observateurs = new();
        // Une liste des notifications
        private readonly HashSet<NotificationTournoi> _notifications = new();
        private Tournoi() { }

        

        public static Tournoi GetInstance()
        {
            if (_instance == null)
            {
                lock(_lock){
                    if (_instance == null)
                    {
                       
                    Tournoi._instance = new Tournoi();
                    }
                }
            }
            return Tournoi._instance;
        }
        public List<Equipe> GetEquipes()
        {
            return this._equipes;
        }
        public Equipe GetEquipe(int id)
        {
            return this._equipes[id - 1];
        }
        public List<Joueur> GetJoueurs()
        {
            return this.joueurs;
        }
        public Boolean IsUniquePseudo(string pseudo)
        {
            foreach (Joueur j in this.GetJoueurs())
            {
                if ( j.GetPseudo()== pseudo)
                {
                    return false;
                }
            }
            return true;
        }
        public Boolean IsUniqueNomEquipe(string nom)
        {
            foreach (Equipe e in this.GetEquipes())
            {
                if (e.GetNomEquipe() == nom)
                {
                    return false;
                }
            }
            return true;
        }
        public Boolean IsEquipeComplete(int id)
        {
            if (this.GetEquipe(id).GetJoueurs().Count == this.NbJoueursMin)
            {
                return true;
            }
            return false;
        }
        public Joueur AddJoueur(string pseudo ,int idEquipe)
        {
            Joueur j;
            lock (_lock)
            {
                if (!this.IsUniquePseudo(pseudo))
                {
                    throw new Exception("Pseudo déjà utilisé");
                }
                
                j = new Joueur(this.GetEquipe(idEquipe).GetJoueurs().Count + 1, pseudo);
                this.GetEquipe(idEquipe).GetJoueurs().Add(j);
                //Trace.WriteLine("heree");
                this.joueurs.Add(j);
                ///////////// Notification de l'ajout d'un joueur dans une équipe
                foreach (var observateur in _observateurs)
                {
                    NotificationTournoi notif = new NotificationTournoi { Equipe = this.GetEquipe(idEquipe), Type = NotificationTournoiType.NewPlayer, Joueur = j };
                    observateur.OnNext(notif);
                }

            }
            return j;
        }

        public Equipe AddEquipe(string nom)
        {
            Equipe e;
            lock (_lock)
            {
                if (!this.IsUniqueNomEquipe(nom))
                {
                    throw new Exception("Nom d'équipe déjà utilisé");
                }

                e = new Equipe(GetEquipes().Count + 1, nom);
                this.GetEquipes().Add(e);
                foreach (var observateur in _observateurs)
                {
                    NotificationTournoi notif = new NotificationTournoi { Equipe = e, Type = NotificationTournoiType.NewTeam,};
                    observateur.OnNext(notif);
                }
            }
            return e;
        }
        public void SetNbJoueursMin(int nb)
        {
            this.NbJoueursMin = nb;
        }
        public void SetNomTournoi(string nom)
        {
            this.NomTournoi = nom;
        }
        public string GetNomTournoi()
        {
            return this.NomTournoi;
        }
        public int GetNbJoueursMin()
        {
            return this.NbJoueursMin;
        }
        // Méthode qui permet d'ajouter un nouvel observateur (implémente la méthode Subscribe de l'interface IObservable)
        public IDisposable Subscribe(IObserver<NotificationTournoi> observateur)
        {
            // Si l'obervateur n'est pas encore dans la liste, on l'ajoute
            if (_observateurs.Add(observateur))
            {
                // On lui envoie les notifications
                foreach (var notification in _notifications)
                {
                    observateur.OnNext(notification);
                }
            }
            return new Unsubscriber<NotificationTournoi>(_observateurs, observateur);
        }

    }
}
