using System.Reflection;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace MtgProject.GraphQL.Infrastructure.Extensions
{
    public class UseMtgDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            // TODO: uncomment when db context pooling with logging enabled
            //descriptor.UseDbContext<MtgDbContext>();
        }
    }
}