using EventSourcing.Commands;
using EventSourcing.Events;
using EventSourcing.Queries;

namespace EventSourcing;

public class EventBroker
{
    // All events that happened.
    public List<Event> AllEvents = new();

    // Commands
    public event EventHandler<Command> Commands = default!;

    // Queries
    public event EventHandler<Query> Queries = default!;

    public void Command(Command c)
    {
        Commands?.Invoke(this, c);
    }

    public T Query<T>(Query q)
    {
        Queries?.Invoke(this, q);
        return (T)q.Result;
    }
}

public class Person
{
    private int age { get; set; }
    public EventBroker broker { get; set; }

    public Person(EventBroker eventBroker)
    {
        broker = eventBroker;
        broker.Commands += BrokerOnCommands;
        broker.Queries += BrokerOnQueries;
    }

    private void BrokerOnQueries(object? sender, Query e)
    {
        var aq = e as AgeQuery;
        if(aq != null && aq.Target == this)
        {
            aq.Result = age;
        }
    }

    private void BrokerOnCommands(object? sender, Command e)
    {
        var cac = e as ChangeAgeCommand;
        if(cac != null && cac.Target == this)
        {
            // Recording the fact what happend
            broker.AllEvents.Add(new AgeChangeEvent(this, age, cac.Age));
            age = cac.Age;
        }
    }
}
