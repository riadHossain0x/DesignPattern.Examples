using ObserverPattern;

var userManager = new UserManager("John", 35);
userManager.Subscribe(new Observer());
userManager.UpdateUserAge(36);

Console.ReadKey(true);