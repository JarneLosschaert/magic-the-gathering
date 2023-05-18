using Howest.MagicCards.MinimalAPI.Mappings;

const string commonPrefix = "/api";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCardsServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
ConfigurationManager config = builder.Configuration;
string urlPrefix = config.GetSection("ApiPrefix").Value ?? commonPrefix;

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapCardsEndpoints(urlPrefix);

app.Run();
