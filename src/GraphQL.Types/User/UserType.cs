using DAL.Common.Entities;

namespace GraphQL.Types.User
{
    public class UserType : ObjectGraphType<UserEntity>
    {
        public UserType()
        {
            Field(x => x.Name);
            Field(x => x.RolesString);
            Field(x => x.PasswordHash);
        }
    }
}