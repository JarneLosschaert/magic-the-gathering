using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.Shared.Filters
{
    public class CardFilter : PaginationFilter
    {
        public string Name { get; set; } = "";
        public string SetCode { get; set; } = "";
        public string ArtistName { get; set; } = "";
        public string CardType { get; set; } = "";
        public string Text { get; set; } = "";

        // add more filters

    }
}
