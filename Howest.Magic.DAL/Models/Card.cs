using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.DAL.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManaCost { get; set; }
        public string ConvertedManaCost { get; set; }
        public string CardType { get; set; } // CardType is a class
        public string RarityCode { get; set; }
        public string SetCode { get; set; }
        public string Text { get; set; }
        public string Flavor { get; set; }
        public int ArtistId { get; set; }
        public string Number { get; set; }
        public string Pwer { get; set; }
        public string Toughness { get; set; }
        public string Layout { get; set; }
        public int MutiverseId { get; set; }
        public string OriginalImageUrl { get; set; }
        public string Image { get; set; }
        public string OriginalText { get; set; }
        public string OriginalType { get; set; }
        public string MtgId { get; set; }
        public string Variations { get; set; }
    }
}
