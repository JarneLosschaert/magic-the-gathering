using GraphQL;
using GraphQL.Types;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.GraphQL.GraphQl.Types;

namespace Howest.MagicCards.GraphQL.GraphQl.Query
{
    public class RootQuery : ObjectGraphType
    {
        [Obsolete]
        public RootQuery(ICardRepository cardRepository, IArtistRepository artistRepository)
        {
            Name = "Query";
            Description = "Query the Magic cards Database";

            #region Cards
            Field<ListGraphType<CardType>>(
                "Cards",
                Description = "Get all cards",
                resolve: context =>
                {
                    return cardRepository
                                .GetAllCards()
                                .ToList();
                }
            );

            Field<ListGraphType<CardType>>(
                "filter",
                Description = "Get all cards with filters",
                arguments: new QueryArguments
                {
                    new QueryArgument<StringGraphType> { Name = "power" },
                    new QueryArgument<StringGraphType> { Name = "toughness" }
                },
                resolve: context =>
                {
                    string power = context.GetArgument<string>("power");
                    string toughness = context.GetArgument<string>("toughness");
                    return cardRepository
                                .GetAllCards()
                                .Where(c => c.Power == power && c.Toughness == toughness)
                                .ToList();
                }
            ); ;

            Field<ListGraphType<CardType>>(
               "cardsbyartist",
               Description = "Get the all cards from a given artist",
               arguments: new QueryArguments
               {
               new  QueryArgument<NonNullGraphType<StringGraphType>> { Name = "artist" }
               },
               resolve: context =>
               {
                   string artist = context.GetArgument<string>("artist");

                   return cardRepository.GetCardsByArtist(artist)
                                        .ToList();
               }
            );
            #endregion

            #region Artists
            Field<ListGraphType<ArtistType>>(
                "Publishers",
                Description = "Get all artists",
                resolve: context =>
                {
                    return artistRepository
                                .GetAllArtists()
                                .ToList();
                }
            );
            #endregion

        }
    }
}
