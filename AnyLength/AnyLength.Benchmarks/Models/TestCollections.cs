namespace AnyLength.Benchmarks.Models;

public class TestCollections
{
    public string[] TestArray { get; set; }
    
    public List<string> TestList { get; set; }
    
    public ICollection<string> TestICollection { get; set; }
    
    public IEnumerable<string> TostIEnumerable { get; set; }
}