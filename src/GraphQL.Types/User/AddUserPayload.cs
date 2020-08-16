using DAL.Common.Entities;

namespace GraphQL.Types.User
{
    public class AddUserPayload
    {
        public UserEntity User { get; }
        public string ClientMutationId { get; }

        public AddUserPayload(UserEntity user, string clientMutationId)
        {
            User = user;
            ClientMutationId = clientMutationId;
        }
    }
}