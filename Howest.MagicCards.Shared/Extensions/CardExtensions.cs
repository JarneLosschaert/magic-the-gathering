using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.Shared.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.Shared.Extensions
{
    public static class CardExtensions
    {
        public static IQueryable<Card> ToFilteredList(this IQueryable<Card> cards, CardFilter filter)
        {
            return cards
                .Where(c => 
                    c.Set.Name.Contains(filter.SetName) && 
                    c.Artist.FullName.Contains(filter.ArtistName) && 
                    c.Rarity.Name.Contains(filter.RarityName) &&
                    c.Type.Contains(filter.CardType) && 
                    c.Name.Contains(filter.CardName) && 
                    c.Text.Contains(filter.CardText));
        }

        public static IQueryable<Card> ToSortedList(this IQueryable<Card> cards, CardSorter sorter)
        {
            return cards
                .OrderBy(c => sorter.OrderByNameAscending ? c.Name : null)
                .ThenByDescending(c => sorter.OrderByNameAscending ? null : c.Name);
        }

        public static IQueryable<Card> ToPagedList(this IQueryable<Card> cards, PaginationFilter filter)
        {
            return cards
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);
        }
    }
}
