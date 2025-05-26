using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Utf8Json;

namespace CPMS.Shared.JsonFormatters.CPMS;

public class Utf8JsonOutputFormatter : TextOutputFormatter
{
    private readonly IJsonFormatterResolver _resolver;

    public Utf8JsonOutputFormatter() : this(null) { }
    public Utf8JsonOutputFormatter(IJsonFormatterResolver resolver)
    {
        _resolver = resolver ?? JsonSerializer.DefaultResolver;

        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);

        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
        
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("*/*"));
    }

    public async override Task WriteAsync(OutputFormatterWriteContext context)
    {
        if (!context.ContentTypeIsServerDefined)
            context.HttpContext.Response.ContentType = "application/json";

        if (context.ObjectType == typeof(object))
        {
            await JsonSerializer.NonGeneric.SerializeAsync(context.HttpContext.Response.Body, context.Object, _resolver);
        }
        else
        {
            await JsonSerializer.NonGeneric.SerializeAsync(context.ObjectType, context.HttpContext.Response.Body, context.Object, _resolver);
        }
    }

    public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        return WriteAsync(context);
    }
}