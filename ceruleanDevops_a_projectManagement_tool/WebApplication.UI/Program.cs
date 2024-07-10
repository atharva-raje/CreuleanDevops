using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Blazorise.Licensing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAPplication.UI;
using WebAPplication.UI.Apicall;
using WebAPplication.UI.IApicall;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders().AddFontAwesomeIcons();
     
builder.RootComponents.Add<App>("#app");  
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7294/")});

//builder.Services.AddHttpClient<IWorkItemAPiCall, WorkItemCall>(client => { client.BaseAddress = new Uri("https://localhost:7294/"); client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("accept: */*")); });
builder.Services.AddScoped<WorkItemCall>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<FileUploadApiCall>();
builder.Services.AddScoped<WorkItemLinkApiCall>();
builder.Services.AddScoped<CommentCallApi>();
builder.Services.AddScoped<UserAPiCall>();
await builder.Build().RunAsync();
