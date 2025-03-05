using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTournoi.Backend
{
    public class Joueur
    {
        public int Id { get; set; }
        private string Pseudo { get; set; }

        public Joueur(int id,string pseudo)
        {
            this.Id = id;
            this.Pseudo = pseudo;
        }
        public string GetPseudo()
        {
            return this.Pseudo;
        }



        public string DisplayJoueur
        {
            get
            {
                return Id + " : " + Pseudo;
            }
        }
    }
}
