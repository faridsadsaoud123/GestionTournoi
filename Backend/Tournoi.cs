using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTournoi.Backend
{
    public class Tournoi
    {
        public string NomTournoi { get; set; }
        public string NbJoueurs { get; set; }

        private List<Equipe> _equipes { get; set; }
        private List<Joueur> joueurs { get; set; }



    }
}
