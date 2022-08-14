using SpanJson.Resolvers;

namespace Json.Benchmarks.Server.Formatters.SpanJson;

internal sealed class SpanJsonFormatter<TSymbol> : ResolverBase<TSymbol, SpanJsonFormatter<TSymbol>>
    where TSymbol : struct
{
    public SpanJsonFormatter() : base(new SpanJsonOptions
    {
        NamingConvention = NamingConventions.CamelCase,
        NullOption = NullOptions.ExcludeNulls,
        EnumOption = EnumOptions.String
    })
    {
    }
}