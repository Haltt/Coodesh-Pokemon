using Coodesh_Pokemon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<PokemonMasterContext>(c => c.UseSqlite("Data Source=pokemonmaster.db"));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Challenge Pokemon V1",
        Description = "API para busca de Pokémons e Controle do Mestre Pokémon",
        TermsOfService = new Uri("https://github.com/Haltt/kotas-pokemon"),
        Contact = new OpenApiContact
        {
            Name = "Wanderson Teixeira",
            Email = "wandersonteixeira@live.com",
            Url = new Uri("https://github.com/Haltt/kotas-pokemon")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Challenge Pokemon V1");
        c.RoutePrefix = "api";
    });
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
