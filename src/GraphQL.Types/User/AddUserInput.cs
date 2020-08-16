namespace GraphQL.Types.User
{
    public class AddUserInput
    {
        public string Name { get; }
        public string Roles { get; }
        public string PasswordHash { get; }
        public string ClientMutationId { get; }

        public AddUserInput(string name, string roles, string passwordHash, string clientMutationId)
        {
            Name = name;
            Roles = roles;
            PasswordHash = passwordHash;
            ClientMutationId = clientMutationId;
        }
    }
}