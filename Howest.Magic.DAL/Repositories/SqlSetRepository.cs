using Howest.MagicCards.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.DAL.Repositories
{
    public class SqlSetRepository : ISetRepository
    {
        private readonly MyCardsContext _db;

        public SqlSetRepository(MyCardsContext myCardsDBContext)
        {
            _db = myCardsDBContext;
        }

        public IQueryable<Set> GetAllSets()
        {
            return _db.Sets
                .Select(s => s);
        }
    }
}
