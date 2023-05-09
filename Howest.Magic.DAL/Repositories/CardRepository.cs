using Howest.MagicCards.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.DAL.Repositories
{
    public class CardRepository : ICardRepository
    {
        private IEnumerable<Card> magicCards;
        public CardRepository()
        {
            magicCards = new List<Card>
            {
                new Card { Id = 1, Name = "Fireball", ManaCost = "XRR", ConvertedManaCost = "2", CardType = "Sorcery", RarityCode = "C", SetCode = "LEA", Text = "Fireball deals X damage divided evenly, rounded down, among any number of target creatures and/or players.", Flavor = "", ArtistId = 1, Number = "122", Pwer = "", Toughness = "", Layout = "", MutiverseId = 0, OriginalImageUrl = "", Image = "", OriginalText = "", OriginalType = "", MtgId = "", Variations = "" },
                new Card { Id = 2, Name = "Lightning Bolt", ManaCost = "R", ConvertedManaCost = "1", CardType = "Instant", RarityCode = "C", SetCode = "LEA", Text = "Lightning Bolt deals 3 damage to target creature or player.", Flavor = "", ArtistId = 1, Number = "126", Pwer = "", Toughness = "", Layout = "", MutiverseId = 0, OriginalImageUrl = "", Image = "", OriginalText = "", OriginalType = "", MtgId = "", Variations = "" },
                new Card { Id = 3, Name = "Counterspell", ManaCost = "UU", ConvertedManaCost = "2", CardType = "Instant", RarityCode = "C", SetCode = "LEA", Text = "Counter target spell.", Flavor = "", ArtistId = 1, Number = "43", Pwer = "", Toughness = "", Layout = "", MutiverseId = 0, OriginalImageUrl = "", Image = "", OriginalText = "", OriginalType = "", MtgId = "", Variations = "" },
            };
        }
        public IEnumerable<Card> GetAllCards()
        {
            return magicCards;
        }

        public Card GetCardbyId(int id)
        {
            return magicCards.SingleOrDefault(c => c.Id == id);
        }
    }
}
