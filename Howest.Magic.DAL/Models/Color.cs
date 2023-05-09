using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.DAL.Models
{
    public class Color
    {
        public Color() 
        {
            CardColors = new HashSet<CardColor>();
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CardColor> CardColors { get; set; }
    }
}
