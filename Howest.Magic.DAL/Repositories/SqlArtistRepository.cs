using Howest.MagicCards.DAL.Models;
using System;
using System.Collections.Generic;
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
                .Select(a => a);
        }
    }
}
