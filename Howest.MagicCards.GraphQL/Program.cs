using Howest.MagicCards.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager config = builder.Configuration;

builder.Services.AddDbContext<MyCardsContext>
    (options => options.UseSqlServer(config.GetConnectionString("CardsDb")));
builder.Services.AddScoped<ICardRepository, SqlCardRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
