using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.DAL.Models
{
    internal class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManaCost { get; set; }
        public string ConvertedManaCost { get; set; }
        public CardType CardType { get; set; }
        public string RarityCode { get; set; }
        public string SetCode { get; set; }
        public string Text { get; set; }
        public string SetCode { get; set; }



        public int Attack { get; set; }
        public int Defense { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int CardTypeId { get; set; }
    }
}
