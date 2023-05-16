using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.GraphQL.GraphQl.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager config = builder.Configuration;

builder.Services.AddDbContext<MyCardsContext>
    (options => options.UseSqlServer(config.GetConnectionString("CardsDb")));
builder.Services.AddScoped<ICardRepository, SqlCardRepository>();
builder.Services.AddScoped<IArtistRepository, SqlArtistRepository>();

builder.Services.AddScoped<RootSchema>();
builder.Services.AddGraphQL()
    .AddGraphTypes(typeof(RootSchema), ServiceLifetime.Scoped)
    .AddDataLoader()
    .AddSystemTextJson();

var app = builder.Build();

app.UseGraphQL<RootSchema>();
app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions()
{
    EditorTheme = EditorTheme.Light
}
);

app.Run();
