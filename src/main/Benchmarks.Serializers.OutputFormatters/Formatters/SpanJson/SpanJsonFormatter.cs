using SpanJson.Resolvers;

namespace Benchmarks.Serializers.OutputFormatters.Formatters.SpanJson;

sealed internal class SpanJsonFormatter<TSymbol>() : ResolverBase<TSymbol, SpanJsonFormatter<TSymbol>>(new SpanJsonOptions
{
    NamingConvention = NamingConventions.CamelCase,
    NullOption = NullOptions.ExcludeNulls,
    EnumOption = EnumOptions.String
})
    where TSymbol : struct;