using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTournoi.Backend
{
    public readonly record struct NotificationTournoi(NotificationTournoiType Type, Equipe Equipe, Joueur? Joueur);

    public enum NotificationTournoiType
    {
        NewTeam, NewPlayer, TeamReady, TeamRemoved
    }
}
