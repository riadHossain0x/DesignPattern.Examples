namespace ObserverPattern;

public class Observer : IObserver<User>
{
    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(User value)
    {
        Console.WriteLine($"Name: {value.Name}, Age: {value.Age}");
    }
}
