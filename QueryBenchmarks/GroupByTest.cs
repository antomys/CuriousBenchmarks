using BenchmarkDotNet.Attributes;
using Bogus;

namespace QueryBenchmarks;

[MemoryDiagnoser(true)]
public class GroupByTest
{
    private List<Event> _tournamentEvents = new();
    private Dictionary<string, Tournament> _tournaments = new();
    private const string TestTournamentId = "TestTournamentId";

    [GlobalSetup]
    public void Setup()
    {
        var faker = new Faker<Event>();
        Randomizer.Seed = new Random(420);
        _tournamentEvents = faker
            .RuleFor(x => x.Integer, y => y.Random.Int())
            .RuleFor(x => x.TournamentId, y => y.Random.String2(20))
            .RuleFor(x => x.DateOnly, y => y.Date.Past())
            .RuleFor(x => x.EventId, y => y.Random.String2(20))
            .Generate(500);
        
        _tournamentEvents.AddRange(faker
            .RuleFor(x => x.Integer, y => y.Random.Int())
            .RuleFor(x => x.TournamentId, _ => TestTournamentId)
            .RuleFor(x => x.DateOnly, y => y.Date.Past())
            .RuleFor(x => x.EventId, y => y.Random.String2(20))
            .Generate(500));

        var eventFaker = new Faker<Tournament>();


        var generatedFakes2 = eventFaker
            .RuleFor(x => x.TournamentId, y => y.Random.String2(20))
            .RuleFor(x => x.DateOnly, y => y.Date.Past())
            .RuleFor(x => x.Integer, y => y.Random.Int())
            .Generate(999).ToDictionary(x => x.TournamentId);
        _tournaments = generatedFakes2;
        _tournaments.Add(TestTournamentId, new Tournament{TournamentId = TestTournamentId, Integer = default, DateOnly = DateTime.Now});
    }

    [Benchmark(Baseline = true)]
    public void GroupByTake()
    {
        var aa = _tournamentEvents.GroupBy(x => x.TournamentId)
            .Select(x => _tournaments[TestTournamentId]);
    }
    
    [Benchmark]
    public void DistinctTake()
    {
        var aa = _tournamentEvents.Select(x => x.TournamentId).Distinct()
            .Select(x => _tournaments[TestTournamentId]);
    }
}