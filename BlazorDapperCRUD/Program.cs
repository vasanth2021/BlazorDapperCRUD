using BlazorDapperCRUD.Components;
using BlazorDapperCRUD.Data;
using BlazorDapperCRUD.Data.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSingleton(new DBConnectionString(connectionString));

builder.Services.AddServerSideBlazor(o => o.DetailedErrors = true)
    .AddCircuitOptions(options => options.DetailedErrors = true);

builder.Services.AddScoped<IVideoService, VideoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();    

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
