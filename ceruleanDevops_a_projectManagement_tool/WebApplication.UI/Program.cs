using Blazorise;
using MudBlazor.Services;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Blazorise.Licensing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAPplication.UI;
using WebAPplication.UI.Apicall;
using Plk.Blazor.DragDrop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
         
    })
    .AddBootstrap5Providers().AddFontAwesomeIcons();
  
builder.RootComponents.Add<App>("#app");  
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7294/")});
builder.Services.AddMudServices();
builder.Services.AddBlazorDragDrop();
//builder.Services.AddHttpClient<IWorkItemAPiCall, WorkItemCall>(client => { client.BaseAddress = new Uri("https://localhost:7294/"); client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("accept: */*")); });
builder.Services.AddScoped<WorkItemCall>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<FileUploadApiCall>();
builder.Services.AddScoped<WorkItemLinkApiCall>();
builder.Services.AddScoped<CommentCallApi>();
builder.Services.AddScoped<UserAPiCall>();
await builder.Build().RunAsync();
