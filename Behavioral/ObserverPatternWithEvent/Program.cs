using ObserverPattern;

var userManager = new UserManager("John", 35);
var observer = new Observer(userManager);
userManager.UpdateUserAge(36);

Console.ReadKey(true);
