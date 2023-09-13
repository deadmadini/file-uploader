using FileUploader.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<DataValidations>();
builder.Services.AddSingleton<FileUploaderService>();

// Configure information about Blob Storage
BlobConfiguration.ConnectionString = builder.Configuration.GetValue<string>("BlobConnString");
BlobConfiguration.BlobContainerName = builder.Configuration.GetValue<string>("BlobContainerName");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
