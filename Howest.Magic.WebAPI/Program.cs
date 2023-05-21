using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.Shared;
using Howest.MagicCards.Shared.Mappings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager config = builder.Configuration;

builder.Services.AddControllers();

builder.Services.AddMemoryCache();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1.5", new OpenApiInfo
    {
        Title = "Magic cards API version 1.5",
        Version = "v1.5",
        Description = "API to manage the magic cards with sorting and detail of a card"
    });
    c.SwaggerDoc("v1.1", new OpenApiInfo
    {
        Title = "Magic cards API version 1.1",
        Version = "v1.1",
        Description = "API to manage magic cards without sorting and detail of a card"
    });
});

builder.Services.AddDbContext<MyCardsContext>
    (options => options.UseSqlServer(config.GetConnectionString("CardsDb")));
builder.Services.AddScoped<ICardRepository, SqlCardRepository>();
builder.Services.AddScoped<ISetRepository, SqlSetRepository>();
builder.Services.AddScoped<IRarityRepository, SqlRarityRepository>();
builder.Services.AddScoped<IArtistRepository, SqlArtistRepository>();

builder.Services.AddAutoMapper(new System.Type[] {
    typeof(CardProfile),
    typeof(SetProfile),
    typeof(RarityProfile),
    typeof(ArtistProfile)
});

builder.Services.AddApiVersioning(o => {
    o.ReportApiVersions = true;
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new ApiVersion(1, 5);
});
builder.Services.AddVersionedApiExplorer(
    options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    }
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1.5/swagger.json", "My Magic cards API v1.5");
        c.SwaggerEndpoint("/swagger/v1.1/swagger.json", "My Magic cards API v1.1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
