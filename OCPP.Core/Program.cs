using CPMS.OcppProxy.Chargers.Implementations;
using CPMS.OcppProxy.Chargers.Interfaces;
using CPMS.OcppProxy.Data;
using CPMS.OcppProxy.Middlewares;
using CPMS.OcppProxy.Services.Implementations;
using CPMS.OcppProxy.Services.Interfaces;
using CPMS.Shared.JsonFormatters.CPMS;
using CPMS.Shared.Messages_OCPP16;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

string keyVaultName = configuration.GetSection("keyVaultName").Value;


// builder.Services.AddControllers();
builder.Services.AddControllers(
        options =>
        {
            options.OutputFormatters.Clear();
            options.OutputFormatters.Add(new Utf8JsonOutputFormatter(Utf8JsonContractResolver.Instance));

            options.InputFormatters.Clear();
            options.InputFormatters.Add(new Utf8JsonInputFormatter(Utf8JsonContractResolver.Instance));
        })
    //.AddNewtonsoftJson(options =>
    //options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
//)
    ;



builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHttpClient();

#region Services

builder.Services.AddSingleton<IChargerV16, ChargerV16>();

builder.Services.AddSingleton<IOCPP16StateManager, OCPP16StateManager>();
builder.Services.AddSingleton<IOCPPMiddlewareService, OcppMiddlewareService>();


builder.Services.AddSingleton<IChargePointStatusService, ChargePointStatusService>();

builder.Services.AddSingleton<IMessageQueueService, MessageQueueService>();

builder.Services.AddSingleton<IChargerService, ChargerService>();

builder.Services.AddSingleton<IControllerFactory, ControllerFactory>();
builder.Services.AddSingleton<ISessionService, SessionService>();


#endregion


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

#region Swagger

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "API Key needed to access the endpoints. ApiKey: My_API_Key_123",
        In = ParameterLocation.Header,
        Name = "ApiKey",  // The name of the header or query parameter that Swagger will use
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyScheme"
    });

    // Apply this globally to all endpoints
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            new string[] {}
        }
    });
    
    void MapEnum<TEnum>() where TEnum : Enum
    {
        options.MapType<TEnum>(() => new OpenApiSchema
        {
            Type = "string",
            Enum = Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(e => new OpenApiString(e.ToString()) as IOpenApiAny)
                .ToList()
        });
    }
    
    MapEnum<ChargingProfilePurposeType>();
    MapEnum<ChargingProfileKindType>();
    MapEnum<RecurrencyKindType>();
    MapEnum<ChargingRateUnitType>();
});

#endregion  
builder.Services.AddHttpContextAccessor();





builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();
app.UseCors();



app.UseSwagger();
app.UseSwaggerUI(opt =>
{
    opt.DisplayRequestDuration();
    opt.EnableTryItOutByDefault();
    opt.DefaultModelsExpandDepth(-1);
});

app.UseRouting();


// Set WebSocketsOptions
var webSocketOptions = new WebSocketOptions() 
{
    ReceiveBufferSize = 16 * 1024,
};

// Accept WebSocket
app.UseWebSockets(webSocketOptions);
            
// Integrate custom OCPP middleware for message processing
app.UseOCPPMiddleware();

app.MapControllers();


app.Run();

public class ProxyProgram {}
