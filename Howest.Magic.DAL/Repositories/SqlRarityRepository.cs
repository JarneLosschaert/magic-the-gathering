using Howest.MagicCards.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.DAL.Repositories
{
    public class SqlRarityRepository : IRarityRepository
    {
        private readonly MyCardsContext _db;

        public SqlRarityRepository(MyCardsContext myCardsDBContext)
        {
            _db = myCardsDBContext;
        }

        public IQueryable<Rarity> GetAllRarities()
        {
            return _db.Rarities
                .Select(r => r);
        }
    }
}
