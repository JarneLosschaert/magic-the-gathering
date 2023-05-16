using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.Shared.DTO
{
    public record ArtistReadDTO
    {
        public long? Id { get; init; }
        public string FullName { get; init; }

    }
}
