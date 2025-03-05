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
        public string Pseudo { get; set; } = string.Empty;

        public string DisplayJoueur
        {
            get
            {
                return Id + " : " + Pseudo;
            }
        }
    }
}
