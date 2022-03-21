using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProjectsManager.Client;
using HttpClientHandler = ProjectsManager.Client.Services.HttpClientHandler;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient();
builder.Services.AddScoped<HttpClientHandler>();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var app = builder.Build();

await app.RunAsync();
