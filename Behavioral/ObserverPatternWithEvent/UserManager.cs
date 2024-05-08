namespace ObserverPattern;

public class UserManager : IUserManager
{
    private readonly User user;
    public event Action<User> UserChanged = default!;

    public UserManager(string name, int age)
    {
        user = new User { Name = name, Age = age };
    }

    public void UpdateUserAge(int age)
    {
        user.Age = age;
        if (UserChanged != null) UserChanged(user);
    }
}
