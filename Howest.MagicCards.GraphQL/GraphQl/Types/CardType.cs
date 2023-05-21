using GraphQL.Types;
using GraphQLParser.AST;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.Shared.DTO;

namespace Howest.MagicCards.GraphQL.GraphQl.Types
{
    public class CardType : ObjectGraphType<Card>
    {
        public CardType()
        {
            Name = "Card";

            Field(c => c.Id, type: typeof(IdGraphType));
            Field(c => c.Name);
            Field(c => c.ManaCost, nullable: true);
            Field(c => c.ConvertedManaCost);
            Field(c => c.Type);
            Field(c => c.Text, nullable: true);
            Field(c => c.Flavor, nullable: true);
            Field(c => c.Number);
            Field(c => c.Power, nullable: true);
            Field(c => c.Toughness, nullable: true);
            Field(c => c.Layout);
            Field(c => c.MutiverseId, type: typeof(IntGraphType), nullable: true);
            Field(c => c.OriginalImageUrl, nullable: true);
            Field(c => c.Image);
            Field(c => c.OriginalText, nullable: true);
            Field(c => c.OriginalType, nullable: true);
            Field(c => c.MtgId);
        }
    }
}