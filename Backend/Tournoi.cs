using System.Diagnostics;

namespace GestionTournoi.Backend
{
    public class Tournoi : IObservable<NotificationTournoi>
    {
        private static Tournoi? _instance;
        private static readonly object Lock = new object();
        private readonly HashSet<IObserver<NotificationTournoi>> _observateurs = new();
        private readonly HashSet<NotificationTournoi> _notifications = new();

        private int _lastId = 0;
        public string NomTournoi { get; set; }
        public int NbJoueursMinParEquipe { get; set; }
        private Dictionary<int, Joueur> _joueurs = new();
        private Dictionary<int, Equipe> _equipes = new();
        public Chronometre Chrono { get; private set; } = new Chronometre();


        private Tournoi()
        {
            NomTournoi = "Tournoi Intergalactique";
            NbJoueursMinParEquipe = 3;
            Chrono.OnTick += UpdateChronoDisplay;
            Chrono.OnTimeUp += FinishRegistrations;
            Chrono.Start(1000, new TimeSpan(0, 2, 0));

        }

        public static Tournoi Instance
        {
            get
            {
                lock (Lock)
                {
                    return _instance ??= new Tournoi();
                }
            }
        }

        public List<Equipe> GetEquipes()
        {
            return _equipes.Values.ToList();
        }

        public List<Joueur> GetJoueurs()
        {
            return _joueurs.Values.ToList();
        }

        public Equipe AddEquipe(string nomEquipe)
        {
            lock (Lock)
            {
                _lastId++;
                Equipe equipe = new() { Id = _lastId, NomEquipe = nomEquipe };
                _equipes.Add(_lastId, equipe);

                NotifierObservateurs(new NotificationTournoi(NotificationTournoiType.NewTeam, equipe, null));

                return equipe;
            }
        }

        public Joueur AddJoueur(string pseudo, int idEquipe)
        {
            lock (Lock)
            {
                _lastId++;
                Joueur joueur = new() { Id = _lastId, Pseudo = pseudo };
                _joueurs.Add(_lastId, joueur);
                _equipes[idEquipe].Joueurs.Add(joueur);

                NotifierObservateurs(new NotificationTournoi(NotificationTournoiType.NewPlayer, _equipes[idEquipe], joueur));
                
                if (_equipes[idEquipe].Joueurs.Count >= NbJoueursMinParEquipe)
                {
                    _equipes[idEquipe].isReady = true;
                    NotifierObservateurs(new NotificationTournoi(NotificationTournoiType.TeamReady, _equipes[idEquipe], null));
                }

                return joueur;
            }
        }

        public IDisposable Subscribe(IObserver<NotificationTournoi> observateur)
        {
            if (_observateurs.Add(observateur))
            {
                foreach (var notification in _notifications)
                {
                    observateur.OnNext(notification);
                }
            }
            return new Unsubscriber<NotificationTournoi>(_observateurs, observateur);
        }

        private void NotifierObservateurs(NotificationTournoi notification)
        {
            _notifications.Add(notification);
            foreach (var observateur in _observateurs)
            {
                observateur.OnNext(notification);
            }
        }
        
        private void UpdateChronoDisplay(string tempsRestant)
        {
            Trace.WriteLine($"Temps restant : {tempsRestant}");
        }

        private void FinishRegistrations()
        {
            var equipesNonCompletes = _equipes.Values.Where(e => !e.isReady).ToList();

            foreach (var equipe in equipesNonCompletes)
            {
                _equipes.Remove(equipe.Id);
                NotifierObservateurs(new NotificationTournoi(NotificationTournoiType.TeamRemoved, equipe, null));
            }

            Trace.WriteLine("Inscriptions terminées. Tournoi prêt à commencer.");
        }

    }
}
