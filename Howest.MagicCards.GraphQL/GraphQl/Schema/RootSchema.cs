using GraphQL.Types;
using Howest.MagicCards.GraphQL.GraphQl.Query;

namespace Howest.MagicCards.GraphQL.GraphQl.Types
{
    public class RootSchema : Schema
    {
        public RootSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<RootQuery>();
        }
    }
}
