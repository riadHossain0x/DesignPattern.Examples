namespace EventSourcing.Events;

public class AgeChangeEvent : Event
{
    public Person Target { get; set; }
    public int OldValue, NewValue;

    public AgeChangeEvent(Person target, int oldValue, int newValue)
    {
        Target = target;
        OldValue = oldValue;
        NewValue = newValue;
    }

    public override string ToString()
    {
        return $"Age changed from {OldValue} to {NewValue}";
    }
}
