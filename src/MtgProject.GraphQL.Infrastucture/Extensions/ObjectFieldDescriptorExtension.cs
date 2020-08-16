namespace GraphQL.Types.Extensions
{
    public static class ObjectFieldDescriptorExtensions
    {
        // TODO: uncomment when db context pooling with logging enabled
        // public static IObjectFieldDescriptor UseDbContext<TDbContext>(
        //     this IObjectFieldDescriptor descriptor)
        //     where TDbContext : DbContext
        // {
        //     // return descriptor.UseScopedService<TDbContext>(
        //     //     create: s => s.GetRequiredService<DbContextPool<TDbContext>>().Rent(),
        //     //     dispose: (s, c) => s.GetRequiredService<DbContextPool<TDbContext>>().Return(c));
        // }
    }
}