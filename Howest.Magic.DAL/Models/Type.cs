using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.DAL.Models
{
    public class Type
    {
        public Type()
        {
            CardTypes = new HashSet<CardType>();
        }   
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CardType> CardTypes { get; set; }
    }
}
