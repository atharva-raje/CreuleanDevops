using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAPplication.UI;
using WebAPplication.UI.Apicall;
using WebAPplication.UI.IApicall;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7294/")});

//builder.Services.AddHttpClient<IWorkItemAPiCall, WorkItemCall>(client => { client.BaseAddress = new Uri("https://localhost:7294/"); client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("accept: */*")); });
builder.Services.AddScoped<WorkItemCall>();
await builder.Build().RunAsync();
