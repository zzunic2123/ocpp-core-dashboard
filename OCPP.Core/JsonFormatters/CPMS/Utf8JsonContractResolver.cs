using System.Reflection;
using Utf8Json;
using Utf8Json.Resolvers;

namespace CPMS.Shared.JsonFormatters.CPMS;

public class Utf8JsonContractResolver : IJsonFormatterResolver
{
    public static IJsonFormatterResolver Instance = new Utf8JsonContractResolver();

    // configure your resolver and formatters.
    static readonly IJsonFormatter[] formatters = new IJsonFormatter[]{
    };

    static readonly IJsonFormatterResolver[] resolvers = new[]
    {
        EnumResolver.UnderlyingValue,
        StandardResolver.ExcludeNullCamelCase
    };

    Utf8JsonContractResolver()
    {
    }

    public IJsonFormatter<T> GetFormatter<T>()
    {
        return FormatterCache<T>.formatter;
    }

    static class FormatterCache<T>
    {
        public static readonly IJsonFormatter<T> formatter;

        static FormatterCache()
        {
            foreach (var item in formatters)
            {
                foreach (var implInterface in item.GetType().GetTypeInfo().ImplementedInterfaces)
                {
                    var ti = implInterface.GetTypeInfo();
                    if (ti.IsGenericType && ti.GenericTypeArguments[0] == typeof(T))
                    {
                        formatter = (IJsonFormatter<T>)item;
                        return;
                    }
                }
            }

            foreach (var item in resolvers)
            {
                var f = item.GetFormatter<T>();
                if (f != null)
                {
                    formatter = f;
                    return;
                }
            }
        }
    }
}