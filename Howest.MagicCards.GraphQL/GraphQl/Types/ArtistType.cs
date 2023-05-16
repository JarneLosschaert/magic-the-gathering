using GraphQL.Types;
using Howest.MagicCards.Shared.DTO;

namespace Howest.MagicCards.GraphQL.GraphQl.Types
{
    public class ArtistType : ObjectGraphType<ArtistReadDTO>
    {
        public ArtistType() {
            Field(a => a.Id);
            Field(a => a.FullName);
        }
    }
}
