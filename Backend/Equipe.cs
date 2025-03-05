using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTournoi.Backend
{
    public class Equipe
    {
        public int Id { get; set; }
        public string NomEquipe { get; set; } = string.Empty;
        public List<Joueur> Joueurs { get; set; } = new();
        public bool isReady { get; set; } = false;


        public string DisplayEquipe => $"{Id} : {NomEquipe} (Joueurs: {Joueurs.Count})";
    }
}
