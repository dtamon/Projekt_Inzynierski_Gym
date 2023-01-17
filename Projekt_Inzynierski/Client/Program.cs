using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Projekt_Inzynierski.Client;
using Projekt_Inzynierski.Client.Authentication;
using Projekt_Inzynierski.Client.Extensions;
using Projekt_Inzynierski.DataAccess.Context;
using Projekt_Inzynierski.DataAccess.Repositories.Interfaces;
using Projekt_Inzynierski.DataAccess.Repositories.Repositories;
using Projekt_Inzynierski.DataAccess.Repositories;
using BlazorDownloadFile;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();

builder.Services.AddBlazorDownloadFile();


await builder.Build().RunAsync();
