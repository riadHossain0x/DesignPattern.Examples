using EventSourcing;
using EventSourcing.Commands;
using EventSourcing.Queries;

var eb = new EventBroker();
var p = new Person(eb);

eb.Command(new ChangeAgeCommand(p, 23));

// Print event
foreach (var e in eb.AllEvents)
{
    Console.WriteLine(e.ToString());
}

int age  = eb.Query<int>(new AgeQuery { Target = p });
Console.ReadKey(true);