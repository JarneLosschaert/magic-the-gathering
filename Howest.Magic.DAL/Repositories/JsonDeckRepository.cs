using Howest.MagicCards.DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Howest.MagicCards.DAL.Repositories
{
    public class JsonDeckRepository : IDeckRepository
    {
        private readonly string _filePath = "./Data/Deck.json";

        public IQueryable<CardDeck> GetAllCards()
        {
            var cardsJson = File.ReadAllText(_filePath);
            var cards = JsonSerializer.Deserialize<List<CardDeck>>(cardsJson);

            return cards.AsQueryable();
        }

        public void AddCard(CardDeck card)
        {
            var existingCards = GetAllCards().ToList();
            var existingCard = existingCards.FirstOrDefault(c => c.Id == card.Id);

            if (existingCard != null)
            {
                existingCard.Amount++;
            }
            else
            {
                existingCards.Add(card);
            }

            WriteCardsToFile(existingCards);
        }

        public bool RemoveCard(int id)
        {
            var existingCards = GetAllCards().ToList();
            var cardToRemove = existingCards.FirstOrDefault(card => card.Id == id);

            if (cardToRemove != null)
            {
                if (cardToRemove.Amount > 1)
                {
                    cardToRemove.Amount--;
                    WriteCardsToFile(existingCards);
                }
                else
                {
                    existingCards.Remove(cardToRemove);
                    WriteCardsToFile(existingCards);
                }
                return true;
            }
            return false;
        }

        public void ClearAllCards()
        {
            WriteCardsToFile(new List<CardDeck>());
        }

        private void WriteCardsToFile(List<CardDeck> cards)
        {
            var cardsJson = JsonSerializer.Serialize(cards);
            File.WriteAllText(_filePath, cardsJson);
        }
    }
}
