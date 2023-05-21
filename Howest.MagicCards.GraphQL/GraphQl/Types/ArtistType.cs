using GraphQL.Types;
using GraphQLParser.AST;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.Shared.DTO;

namespace Howest.MagicCards.GraphQL.GraphQl.Types
{
    public class ArtistType : ObjectGraphType<Artist>
    {
        public ArtistType() {
            Field(a => a.Id, type: typeof(IdGraphType));
            Field(a => a.FullName);
            Field(a => a.Cards, type: typeof(ListGraphType<CardType>));
        }
    }
}
