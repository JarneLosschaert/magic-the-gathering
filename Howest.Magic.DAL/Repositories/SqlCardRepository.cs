using Howest.MagicCards.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            IQueryable<Card> allBooks = _db.Cards
                                            .Include(c => c.Artist)
                                            .Include(c => c.Rarity)
                                            .Include(c => c.Set)
                                            .Include(c => c.CardColors)
                                            .ThenInclude(cc => cc.Color)
                                            .Select(c => c);
            return allBooks;
        }

        public async Task<Card?> GetCardbyIdAsync(int id)
        {
            Card? singleBook = await _db.Cards
                                    //.Include(b => b.Publisher)
                                    .SingleOrDefaultAsync(c => c.Id == id);


            return singleBook;
        }
    }
}
