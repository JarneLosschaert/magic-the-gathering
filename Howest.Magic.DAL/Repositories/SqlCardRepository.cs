using Howest.MagicCards.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Howest.MagicCards.DAL.Repositories
{
    public class SqlCardRepository : ICardRepository
    {
        private readonly MyCardsContext _db;

        public SqlCardRepository(MyCardsContext myCardsDBContext)
        {
            _db = myCardsDBContext;
        }

        public IQueryable<Card> GetAllCards()
        {
            IQueryable<Card> allCards = _db.Cards
                                            .Include(c => c.Artist)
                                            .Include(c => c.Rarity)
                                            .Include(c => c.Set)
                                            .Include(c => c.CardColors)
                                                .ThenInclude(cc => cc.Color)
                                            .Include(c => c.CardTypes)
                                                .ThenInclude(ct => ct.Type)
                                            .Select(c => c);
            return allCards;
        }

        public async Task<Card?> GetCardbyIdAsync(int id)
        {
            Card? singleCard = await _db.Cards
                .Include(c => c.Artist)
                .Include(c => c.Rarity)
                .Include(c => c.Set)
                .Include(c => c.CardColors)
                .Include(c => c.CardColors)
                    .ThenInclude(cc => cc.Color)
                .Include(c => c.CardTypes)
                    .ThenInclude(ct => ct.Type)
                .SingleOrDefaultAsync(c => c.Id == id);

            return singleCard;
        }
        public IQueryable<Card> GetCardsByArtist(long id)
        {
            IQueryable<Card> allCards = _db.Cards
                                            .Include(c => c.Artist)
                                            .Include(c => c.Rarity)
                                            .Include(c => c.Set)
                                            .Include(c => c.CardColors)
                                                .ThenInclude(cc => cc.Color)
                                            .Include(c => c.CardTypes)
                                                .ThenInclude(ct => ct.Type)
                                            .Where(c => c.Artist.Id == id)
                                            .Select(c => c);
            return allCards;
        }
    }
}
