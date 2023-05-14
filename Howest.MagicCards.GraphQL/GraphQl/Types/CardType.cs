using GraphQL.Types;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.Shared.DTO;

namespace Howest.MagicCards.GraphQL.GraphQl.Types
{
    public class CardType : ObjectGraphType<CardDetailReadDTO>
    {
        public CardType()
        {
            Field(c => c.Id);
            Field(c => c.Name);
            Field(c => c.ManaCost);
            Field(c => c.ConvertedManaCost);
            Field(c => c.Type);
            Field(c => c.RarityName);
            Field(c => c.SetName);
            Field(c => c.Text);
            Field(c => c.Flavor);
            Field(c => c.ArtistFullName);
            Field(c => c.Number);
            Field(c => c.Power);
            Field(c => c.Toughness);
            Field(c => c.Layout);
            Field(c => c.MutiverseId);
            Field(c => c.OriginalImageUrl);
            Field(c => c.Image);
            Field(c => c.OriginalText);
            Field(c => c.OriginalType);
            Field(c => c.MtgId);
            Field(c => c.Variations);
            Field(c => c.ColorCodes);
            Field(c => c.TypeNames);
        }
    }
}