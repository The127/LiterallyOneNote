using System.Text.Json;
using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using LiterallyOneNote;
using FluentBlazorRouter;
using LiterallyOneNote.Pages;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddFluentRouting<LandingPage>(_ => { });
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();