using GestionTournoi.Backend;

public readonly record struct NotificationTournoi(NotificationTournoiType Type, Equipe Equipe, Joueur? Joueur);

public enum NotificationTournoiType
{
    NewTeam, NewPlayer, TeamReady, TeamRemoved
}