using GraphQL;
using GraphQL.Types;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.GraphQL.GraphQl.Types;
using Microsoft.IdentityModel.Tokens;

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
                "getAllCards",
                Description = "Get all cards",
                arguments: new QueryArguments
                {
                    new QueryArgument<IntGraphType> { Name = "power" },
                    new QueryArgument<IntGraphType> { Name = "toughness" }
                },
                resolve: context =>
                {
                    string power = context.GetArgument<int?>("power").ToString();
                    string toughness = context.GetArgument<int?>("toughness").ToString();

                    return cardRepository.GetAllCards().Where(c => 
                        string.IsNullOrEmpty(power) || c.Power == power && 
                        string.IsNullOrEmpty(toughness) || c.Toughness == toughness
                    ).ToList();
                }
            );
            #endregion

            #region Artists
            Field<ListGraphType<ArtistType>>(
                "getAllArtists",
                Description = "Get all artists",
                arguments: new QueryArguments
                {
                    new QueryArgument<IntGraphType> { Name = "limit" }
                },
                resolve: context =>
                {
                    int? limit = context.GetArgument<int?>("limit");

                    var query = artistRepository.GetAllArtists();
                    if (limit != null)
                    {
                        query = query.Take(limit.Value);
                    }

                    return query.ToList();
                }
            );

            Field<ArtistType>(
               "getArtistById",
               Description = "Get the artist by id",
               arguments: new QueryArguments
               {
               new  QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
               },
               resolve: context =>
               {
                   int id = context.GetArgument<int>("id");

                   return artistRepository
                   .GetAllArtists()
                   .FirstOrDefault(a => a.Id == id);
               }
            );
            #endregion
        }
    }
}
