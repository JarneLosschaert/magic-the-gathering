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

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Cards API version 1",
        Version = "v1",
        Description = "API to manage books without sorting and detail of a card"
    });
    c.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "Cards API version 2",
        Version = "v2",
        Description = "API to manage books"
    });
});


builder.Services.AddDbContext<MyCardsContext>
    (options => options.UseSqlServer(config.GetConnectionString("CardsDb")));
builder.Services.AddScoped<ICardRepository, SqlCardRepository>();

builder.Services.AddAutoMapper(new System.Type[] {
    typeof(CardProfile)
});

builder.Services.AddApiVersioning(o => {
    o.ReportApiVersions = true;
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new ApiVersion(1, 0);
    o.ApiVersionReader = ApiVersionReader.Combine(
                                    new QueryStringApiVersionReader("version"),
                                    new HeaderApiVersionReader("api-version"),
                                    new MediaTypeApiVersionReader("v"));
});






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My cards API v1");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "My cards API v2");
    });

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
