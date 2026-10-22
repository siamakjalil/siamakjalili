using Core.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.ConfigurePersistenceServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.UseAuthorization();

app.MapGet("/index.html", context =>
{
    context.Response.StatusCode = StatusCodes.Status301MovedPermanently;
    context.Response.Headers.Location = "/";
    return Task.CompletedTask;
});
app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
