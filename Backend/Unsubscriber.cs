internal sealed class Unsubscriber<Notification> : IDisposable
{
    private readonly ISet<IObserver<Notification>> _observers;
    private readonly IObserver<Notification> _observer;

    internal Unsubscriber(
        ISet<IObserver<Notification>> observers,
        IObserver<Notification> observer) => (_observers, _observer) = (observers, observer);

    public void Dispose() => _observers.Remove(_observer);
}