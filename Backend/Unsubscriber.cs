
namespace GestionTournoi.Backend
{
    internal sealed class Unsubscriber<NotificationTournoi> : IDisposable
    {
        private readonly ISet<IObserver<NotificationTournoi>> _observers;
        private readonly IObserver<NotificationTournoi> _observer;

        internal Unsubscriber(ISet<IObserver<NotificationTournoi>> observers, IObserver<NotificationTournoi> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose() => _observers.Remove(_observer);
    }

}
