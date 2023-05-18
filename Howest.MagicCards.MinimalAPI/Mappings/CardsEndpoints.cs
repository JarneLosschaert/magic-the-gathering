using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;

namespace Howest.MagicCards.MinimalAPI.Mappings
{
    public static class CardsEndpoints
    {
        public static void MapCardsEndpoints(this WebApplication app, string urlPrefix)
        {

            app.MapGet($"{urlPrefix}/cards", (JsonDeckRepository deckRepo) =>
            {
                return (deckRepo.GetAllCards() is IEnumerable<CardDeck> cards)
                        ? Results.Ok(cards)
                        : Results.NotFound("No cards found");

            }).WithTags("Deck");

            app.MapPost($"{urlPrefix}/cards", (JsonDeckRepository deckRepo, CardDeck newCard) =>
            {
                deckRepo.AddCard(newCard);
            }
            ).Accepts<CardDeck>("application/json")
             .WithTags("Deck");

            app.MapDelete($"{urlPrefix}/cards/{{id}}", (JsonDeckRepository deckRepo, int id) =>
            {
                return deckRepo.RemoveCard(id)
                    ? Results.Ok($"Card with id {id} is deleted!")
                    : Results.NotFound($"No card with id {id} found");
            }
            ).WithTags("Deck");
        }

        public static void AddCardsServices(this IServiceCollection services)
        {
            services.AddSingleton<JsonDeckRepository>();
        }

    }
}
