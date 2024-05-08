namespace ObserverPattern;

public interface IUserManager
{
    List<IObserver<User>> Observers { get; }

    void Dispose();
    IDisposable Subscribe(IObserver<User> observer);
    void UpdateUserAge(int age);
}

public class UserManager : IObservable<User>, IDisposable, IUserManager
{
    private readonly User user;
    public List<IObserver<User>> Observers { get; private set; } = [];

    public UserManager(string name, int age)
    {
        user = new User { Name = name, Age = age };
    }

    public IDisposable Subscribe(IObserver<User> observer)
    {
        Observers.Add(observer);
        return this;
    }

    public void UpdateUserAge(int age)
    {
        user.Age = age;
        foreach (var observer in Observers)
            observer.OnNext(user);
    }

    public void Dispose()
    {
        Observers.Clear();
    }
}
