//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//var app = builder.Build();

//// Configure the HTTP request pipeline.

//app.Run();


using CustomConfigProvider.Models;
using CustomConfigProvider.Providers;
using Microsoft.Extensions.Options;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((_, configuration) =>
    {
        configuration.Sources.Clear();
        configuration.AddEntityConfiguration();
    })
    .ConfigureServices((context, services) =>
        services.Configure<WidgetOptions>(
            context.Configuration.GetSection("WidgetOptions")))
    .Build();

var options = host.Services.GetRequiredService<IOptions<WidgetOptions>>().Value;
Console.WriteLine($"DisplayLabel={options.DisplayLabel}");
Console.WriteLine($"EndpointId={options.EndpointId}");
Console.WriteLine($"WidgetRoute={options.WidgetRoute}");

await host.RunAsync();