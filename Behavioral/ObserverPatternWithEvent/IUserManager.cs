
namespace ObserverPattern
{
    public interface IUserManager
    {
        event Action<User> UserChanged;

        void UpdateUserAge(int age);
    }
}