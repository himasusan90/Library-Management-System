// See https://aka.ms/new-console-template for more information

public class NotificationManager : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    public void NotifyObserver(string message)
    {
        foreach(var obs in observers)
        {
            obs.Update(message);
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }
}

