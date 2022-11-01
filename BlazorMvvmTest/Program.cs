using BlazorMvvmTest;
using BlazorMvvmTest.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Prism.Events;
using System.Reflection.Metadata.Ecma335;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IEventAggregator, EventAggregator>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<UserViewModel>(sp=>
{ 
    var ea = sp.GetRequiredService<IEventAggregator>();
    var userviewModel = new UserViewModel(ea);
    return userviewModel;
}
) ;

await builder.Build().RunAsync();
