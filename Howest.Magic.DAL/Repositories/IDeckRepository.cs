using Howest.MagicCards.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.DAL.Repositories
{
    public interface IDeckRepository
    {
        IQueryable<CardDeck> GetAllCards();
        void AddCard(CardDeck card);
        bool RemoveCard(int id);
        void ClearAllCards();
    }
}
