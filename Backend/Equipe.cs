using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTournoi.Backend
{
    public class Equipe
    {
        public int id { get; set; }
        private string NomEquipe { get; set; }
        public Boolean IsReady { get; set; }

        private List<Joueur> _joueurs { get; set; } = new List<Joueur>();


        public Equipe(int id, string nom)
        {
            this.id = id;
            this.NomEquipe = nom;
        }
        public string GetNomEquipe() { 
        return this.NomEquipe;
        }
        public List<Joueur> GetJoueurs()
        {
            return this._joueurs ; // Retourne une liste vide si _joueurs est null
        }
        public string DisplayEquipe
        {
            get
            {
                return id + " : " + NomEquipe;
            }
        }

    }
}
