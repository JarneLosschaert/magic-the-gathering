using Howest.MagicCards.DAL.Models;
using System;
using System.Collections.Generic;
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

        public IQueryable<Card> GetAllBooks()
        {
            IQueryable<Card> allBooks = _db.Books
                                            //.Include(b => b.Publisher)
                                           // .Include(c => c.Booksauthors)
                                             //   .ThenInclude(c => c.Author)
                                          // .Select(c => c);
            return allBooks;
        }

        public async Task<Card?> GetCardbyIdAsync(int id)
        {
            Card? singleBook = await _db.Cards
                                    //.Include(b => b.Publisher)
                                    // .SingleOrDefaultAsync(c => c.Bno == id);

            return singleBook;
        }
    }
}
