namespace Sirius.GymGraphQL.Mutation;

public partial class Mutation
{
    private static void NotFound<T>()
    {
        var type = typeof(T).ToString();
        var typename = type[(type.LastIndexOf('.')+1)..];
        throw new GraphQLException(new Error($"No {typename} with this id", "404"));
    }
}