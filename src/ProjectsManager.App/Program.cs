using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProjectsManager.App;
using HttpClientHandler = ProjectsManager.App.Services.HttpClientHandler;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddSingleton<HttpClientHandler>();

var app = builder.Build();

await app.RunAsync();
