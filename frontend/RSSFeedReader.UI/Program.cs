using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RSSFeedReader.UI;
using RSSFeedReader.UI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var apiBaseUrl = config["ApiBaseUrl"] ?? "http://localhost:5151/api/";
    return new HttpClient { BaseAddress = new Uri(apiBaseUrl) };
});

builder.Services.AddScoped<SubscriptionApiClient>();

await builder.Build().RunAsync();
