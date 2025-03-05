using System.Diagnostics;
using System.Timers;

namespace GestionTournoi.Backend
{
    public class Chronometre
    {
        private System.Timers.Timer? Chrono;
        private int Frequence = 1000;
        private DateTime debut = DateTime.Now;
        private TimeSpan dureeChrono = new TimeSpan(0, 2, 0);
        private TimeSpan tempsRestant;
        public bool isActif = true;

        // Événement pour notifier l'interface Admin
        public event Action<string>? OnTick;
        public event Action? OnTimeUp;

        public void Start(int delai, TimeSpan dureeChrono)
        {
            isActif = true;
            this.dureeChrono = dureeChrono;
            this.tempsRestant = dureeChrono;
            Frequence = delai;
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

        private void Tick(object? sender, ElapsedEventArgs e)
        {
            tempsRestant = dureeChrono - (e.SignalTime - debut);
            string tempsRestantString = $"{tempsRestant.Minutes:00}:{tempsRestant.Seconds:00}";

            Trace.WriteLine(tempsRestantString);
            OnTick?.Invoke(tempsRestantString);

            if (Chrono != null && tempsRestant <= TimeSpan.Zero)
            {
                Chrono.Stop();
                Chrono.Enabled = false;
                Trace.WriteLine("Chrono arrêté");
                isActif = false;
                OnTimeUp?.Invoke();
            }
        }
    }
}