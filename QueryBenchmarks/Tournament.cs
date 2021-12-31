namespace QueryBenchmarks;

public record Tournament
{
    public string TournamentId { get; set; }
    public DateTime DateOnly { get; set; }
    public int Integer { get; set; }
};

public record Event
{
    public string EventId { get; set; }
    public string TournamentId { get; set; }
    public DateTime DateOnly { get; set; }
    public int Integer { get; set; }
}