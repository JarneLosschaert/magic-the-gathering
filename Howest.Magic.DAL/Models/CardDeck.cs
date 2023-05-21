using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.DAL.Models
{
    public class CardDeck
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
