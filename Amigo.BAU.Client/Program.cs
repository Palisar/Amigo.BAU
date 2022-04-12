using Amigo.BAU.Client;
using Amigo.BAU.Persistance.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//change the Uri to the address of the Amigo.BAU.API
var AmigoApiUri = new Uri("https://localhost:7130");

builder.Services.AddRefitClient<IAmigoBAUClient>()
    .ConfigureHttpClient(x => x.BaseAddress = AmigoApiUri);

await builder.Build().RunAsync();
