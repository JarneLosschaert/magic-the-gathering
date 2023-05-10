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
        public virtual DbSet<CardColor> CardColors { get; set; }
        public virtual DbSet<CardType> CardTypes { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Rarity> Rarity { get; set; }
        public virtual DbSet<Set> Set { get; set; }
        public virtual DbSet<Type> Type { get; set; }
    }
}
