using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.DAL.Models
{
    public class CardColor
    {
        public long CardId { get; set; }
        public long ColorId { get; set; }

        public virtual Card Card { get; set; }
        public virtual Color Color { get; set; }
    }
}
