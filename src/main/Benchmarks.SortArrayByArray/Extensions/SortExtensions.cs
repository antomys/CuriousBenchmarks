namespace Benchmarks.SortArrayByArray.Extensions;

public static class SortExtensions
{
    public static IOrderedEnumerable<TestModel> OrderV1(
        this IEnumerable<TestModel> source, string[] ids)
    {
        var order = ids
            .Distinct()
            .Select((s, i) => (s, i))
            .ToDictionary(kvp => kvp.s, kvp => kvp.i);
        
        var result = source
            .OrderBy(i => order.GetValueOrDefault(i.Id, int.MaxValue));

        return result;
    }
    
    public static IOrderedEnumerable<TestModel> OrderV1Improved(
        this TestModel[] source,
        string[] ids)
    {
        var order = new Dictionary<string, int>(ids.Length);

        var idsSpan = ids.AsSpan();
        for (var i = 0; i < idsSpan.Length; i++)
        {
            order.TryAdd(idsSpan[i], i);

        }
        
        var result = source
            .OrderBy(i => order.GetValueOrDefault(i.Id, int.MaxValue));

        return result;
    }
    
    public static IOrderedEnumerable<TestModel> OrderV2(
        this TestModel[] source,
        string[] ids)
    {
        return source.OrderBy(x =>
        {
            var index = Array.IndexOf(ids, x.Id);
            
            return index is -1 ? int.MaxValue : index;
        });
    }
    
    public static List<TestModel> OrderV3(
        this TestModel[] source,
        string[] ids)
    {
        var sortedList = new List<TestModel>();

        for (var i = 0; i < ids.Length; i++) 
        { // "i" spares indexof.
            for (int j = 0, l = source.Length; j < l; j++)
            {
                if (!ids[i].Equals(source[j].Id))
                {
                    continue;
                }
                
                sortedList.Add(source[j]);
                //might as well Remove from listToBeSorted to decrease complexity.
                //listToBeSorted.RemoveAt(j);
                break;
            }
        }

        return sortedList;
    }
    
    
    public static List<TestModel> OrderV3Improved(
        this Span<TestModel> source,
        Span<string> ids)
    {
        var sortedList = new List<TestModel>(source.Length);

        for (var i = 0; i < ids.Length; i++) 
        { // "i" spares indexof.
            for (int j = 0, l = source.Length; j < l; j++)
            {
                if (!ids[i].Equals(source[j].Id))
                {
                    continue;
                }
                
                sortedList.Add(source[j]);
                //might as well Remove from listToBeSorted to decrease complexity.
                //listToBeSorted.RemoveAt(j);
                break;
            }
        }

        return sortedList;
    }
    
    public static void OrderV4(
        this TestModel[] source,
        string[] ids)
    {
        source.AsSpan().Sort((model1, model2) => Comparison(model1, model2, ids));
        return;

        int Comparison(TestModel x, TestModel y, Span<string> idsS)
        {
            var idx1 = idsS.IndexOf(x.Id);
            var idx2 = idsS.IndexOf(y.Id);

            return Comparer<int>.Default.Compare(idx1, idx2);
        }
    }
}