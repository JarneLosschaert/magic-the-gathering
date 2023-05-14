using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.Shared.DTO
{
    public record SetReadDTO
    {
        public long? Id { get; init; }
        public string Name { get; init; }
        public string Code { get; init; }
    }
}
