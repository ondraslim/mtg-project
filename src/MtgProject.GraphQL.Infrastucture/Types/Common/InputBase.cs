namespace MtgProject.GraphQL.Infrastructure.Types.Common
{
    public class InputBase
    {
        public string? ClientMutationId { get; }

        public InputBase(string? clientMutationId)
        {
            ClientMutationId = clientMutationId;
        }
    }
}