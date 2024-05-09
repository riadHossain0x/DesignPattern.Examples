namespace EventSourcing.Queries;

public class AgeQuery : Query
{
    public Person Target { get; set; } = default!;
}
