using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProjectsManager.Client;
using HttpClientHandler = ProjectsManager.Client.Services.HttpClientHandler;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseAddress = builder.Configuration.GetServiceUri("projects-api");

builder.Services.AddHttpClient<HttpClientHandler>("ProjectsApi", 
    client => client.BaseAddress = baseAddress);
builder.Services.AddScoped<HttpClientHandler>();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<HttpClientHandler>>();
logger.LogCritical("Base address from the configuration is: {BaseAddress}", baseAddress);

await app.RunAsync();
