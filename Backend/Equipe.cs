using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTournoi.Backend
{
    public class Equipe
    {
        private int id { get; set; }
        private string NomEquipe { get; set; }
        public Boolean IsReady { get; set; }

        private List<Joueur> _joueurs { get; set; }
    }
}
