using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.Shared.Mappings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<ICardRepository, SqlCardRepository>();
builder.Services.AddDbContext<MyCardsContext>
    (options => options.UseSqlServer(config.GetConnectionString("CardsDb")));
builder.Services.AddAutoMapper(new System.Type[] { typeof(CardProfile) });

builder.Services.AddHttpClient("CardsApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7103/api/");
});
builder.Services.AddHttpClient("DeckApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7061/api/");
});

var app = builder.Build();


// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
