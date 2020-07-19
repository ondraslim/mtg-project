using GraphQL.API.Mutations;
using GraphQL.API.Queries;

namespace GraphQL.API.Schema
{
    public class MtgSchema : Types.Schema
    {
        public MtgSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<DeckQuery>();
            Mutation = resolver.Resolve<DeckMutation>();
        }
    }
}