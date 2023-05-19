using Howest.MagicCards.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.DAL.Repositories
{
    public class SqlArtistRepository : IArtistRepository
    {
        private readonly MyCardsContext _db;

        public SqlArtistRepository(MyCardsContext myCardsDBContext)
        {
            _db = myCardsDBContext;
        }

        public IQueryable<Artist> GetAllArtists()
        {
            return _db.Artists
                .Include(a => a.Cards)
                .Select(a => a);
        }

        public async Task<Artist?> GetArtistbyIdAsync(int id)
        {
            Artist? singleArtist = await _db.Artists
                .SingleOrDefaultAsync(c => c.Id == id);

            return singleArtist;
        }
    }
}
