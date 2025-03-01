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
        public int NbJoueursMin { get; set; }

        private List<Equipe> _equipes { get; set; }
        private List<Joueur> joueurs { get; set; }

        public List<Equipe> GetEquipes()
        {
            return this._equipes;
        }
        public Equipe GetEquipe(int id)
        {
            return this._equipes[id];
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
            Joueur j = new Joueur(this.GetEquipe(idEquipe).GetJoueurs().Count+1,pseudo);
            this.GetEquipe(idEquipe).GetJoueurs().Add(j);
            this.joueurs.Add(j);
            return j;
        }

        public Equipe AddEquipe(string nom)
        {
            Equipe e = new Equipe(this.GetEquipes().Count + 1, nom);
            this.GetEquipes().Add(e);
            return e;
        }


    }
}
