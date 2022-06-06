global using BlazorApp1.Client.Services.VehicleService;
global using BlazorApp1.Client.Services.DriverService;
global using BlazorApp1.Client.Services.LocationService;
global using BlazorApp1.Client.Services.TripService;
global using BlazorApp1.Shared;
using BlazorApp1.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ITripService, TripService>();

await builder.Build().RunAsync();
