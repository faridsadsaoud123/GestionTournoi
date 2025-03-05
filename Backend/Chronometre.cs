using System.Diagnostics;
using System.Timers;

namespace GestionTournoi.Backend;

public class Chronometre
{
    // System.Timers contient un Timer spécifique aux WinForms
    private System.Timers.Timer? Chrono;
    // Fréquence avec laquelle le Timer envoie le temps écoulé (en ms)
    private int Frequence = 1000;
    // Heure de début du chnronomètre
    private DateTime debut = DateTime.Now;
    // Durée du chronomètre en h, mn , sec
    private TimeSpan dureeChrono = new TimeSpan(0, 5, 0);
    // Temps restant avant la fin du chrono
    private TimeSpan tempsRestant = new TimeSpan(0, 5, 0);
    // Indique si le chrono est écoulé
    private bool isActif = true;
    public void Start(int delai, TimeSpan dureeChrono)
    {
        isActif = true;
        this.dureeChrono = dureeChrono;
        this.tempsRestant = dureeChrono;
        Frequence = delai;
        Chrono = new System.Timers.Timer(Frequence);
        //  Ajout d'un événement qui sera appelé toutes les Frequence ms
        Chrono.Elapsed += Tick;
        // Heure courante
        debut = DateTime.Now;
        // Démarrage du chrono
        Chrono.Enabled = true;
    }
    public void Start()
    {
        isActif = true;
        Chrono = new System.Timers.Timer(Frequence);
        Chrono.Elapsed += Tick;
        debut = DateTime.Now;
        Chrono.Enabled = true;
    }

    public void Stop()
    {
        if (Chrono != null)
        {
            Chrono.Enabled = false;
            Chrono.Stop();
        }
    }
    // Méthode appelée pour le Timer toutes les Frequence ms
    private void Tick(object? sender, ElapsedEventArgs e)
    {
        tempsRestant = dureeChrono - (e.SignalTime - debut);
        string tempsRestantString = String.Format("{0:00}:{1:00}:{2:00}", tempsRestant.Hours, tempsRestant.Minutes, tempsRestant.Seconds);
        Trace.WriteLine(tempsRestantString);
        if (Chrono != null && tempsRestant <= TimeSpan.Zero)
        {
            Chrono.Stop();
            Chrono.Enabled = false;
            Trace.WriteLine("Chrono arrêté");
            isActif = false;
        }
    }
}