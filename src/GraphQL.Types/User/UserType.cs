namespace GraphQL.Types.User
{
    public class UserType : ObjectGraphType<DAL.Common.Model.User>
    {
        public UserType()
        {
            Field(x => x.Name);
            Field(x => x.RolesString);
            Field(x => x.PasswordHash);
        }
    }
}