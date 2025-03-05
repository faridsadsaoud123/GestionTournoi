using System.Diagnostics;

namespace GestionTournoi.Backend;

public class Seed
{
    public static void SeedData()
    {
        Tournoi tournoi = Tournoi.GetInstance();


        tournoi.AddEquipe("The best"); // Id=1
        tournoi.AddEquipe("The blue jackets");// Id=2

        tournoi.AddJoueur("Dark Maul", 1);// Id=3
        tournoi.AddJoueur("Calimero", 1);// Id=4
        tournoi.AddJoueur("Casimir", 1);// Id=5
        tournoi.AddJoueur("Dragon ball", 2);// Id=6
        tournoi.AddJoueur("Pikachu", 2);// Id=7
        tournoi.AddJoueur("The beast", 2);// Id=8
        foreach (Equipe t in tournoi.GetEquipes())
        {
            t.IsReady = true;
        }

        //Trace.WriteLine("************ Tournoi : " + tournoi.NomTournoi);
        //Trace.WriteLine("************ Nombre d'équipes : " + tournoi.GetEquipes().Count);
        //Trace.WriteLine("************ Nom d'equipe : " + tournoi.GetEquipe(1).GetNomEquipe());
        //Trace.WriteLine("************ Nombre de joueurs : " + tournoi.GetEquipe(1).GetJoueurs().Count());

        foreach (var equipe in tournoi.GetEquipes())
        {
            // Trace permet d'écrire dans la console de debug
            Trace.WriteLine("************ Equipe " + equipe.id + " : " + equipe.GetNomEquipe());
            foreach (var joueur in equipe.GetJoueurs())
            {
                Trace.WriteLine("\t joueur " + joueur.Id + " : " + joueur.GetPseudo());
            }
        }
    }
}