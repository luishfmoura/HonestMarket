using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.TryAddSingleton(builder.Configuration);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages()
                .AddRazorRuntimeCompilation();

var app = builder.Build();

var url = app.Environment.IsDevelopment() ? null : Environment.GetEnvironmentVariable("HOST_PRD");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}");

app.Run(url);
