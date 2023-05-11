using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.DAL.Models
{
    public class CardType
    {
        public long CardId { get; set; }
        public long TypeId { get; set; }

        public virtual Card Card { get; set; }
        public virtual Type Type { get; set; }
    }
}
