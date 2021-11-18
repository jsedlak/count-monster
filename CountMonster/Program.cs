using BlazorApplicationInsights;
using Blazored.LocalStorage;
using CountMonster;
using CountMonster.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Configuration.AddApplicationInsightsSettings()
//builder.Services.AddApplicationInsightsTelemetry("01ecb14e-841c-47f9-9caa-1af301e50465");

builder.Services.AddBlazorApplicationInsights();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AppStateManager>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
