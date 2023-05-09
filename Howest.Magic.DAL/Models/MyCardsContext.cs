using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.DAL.Models
{
    public class MyCardsContext
    {
        public MyCardsContext()
        {
        }

        public virtual DbSet<Card> Cards { get; set; }
    }
}
