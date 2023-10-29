using Sirius.GymGraphQL.Interfaces;
using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Query;

public partial class Query
{
    public async Task<Customer[]> Customers([Service] ICustomerRepository repo)
    {
        return (await repo.GetAllCustomers()).ToArray();
    }
    public async Task<Customer> CustomerById(Guid id, [Service] ICustomerRepository repo)
    {
        return await repo.GetCustomerByIdAsync(id) ?? throw new GraphQLException("Customer with this id not found");
    }
}