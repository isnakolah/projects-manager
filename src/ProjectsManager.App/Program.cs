using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProjectsManager.App;
using ProjectsManager.App.Data;
using ProjectsManager.App.Services;
using HttpClientHandler = ProjectsManager.App.Services.Handlers.HttpClientHandler;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddSingleton<HttpClientHandler>();
builder.Services.AddScoped(typeof(CacheService<>));
builder.Services.AddScoped<ProjectsRepository>();

var app = builder.Build();

await app.RunAsync();
