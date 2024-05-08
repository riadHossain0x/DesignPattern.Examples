namespace ObserverPattern;

public class Observer
{
    public Observer(IUserManager userManager)
    {
        userManager.UserChanged += UserManager_UserChanged;
    }

    private void UserManager_UserChanged(User user)
    {
        Console.WriteLine($"Name: {user.Name}, Age: {user.Age}");
    }
}
