using Sirius.GymGraphQL.Interfaces;
using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Query;

public partial class Query
{
    public async Task<Purchase[]> Purchases(Guid customerId, [Service] IPurchaseRepository repo)
    {
        return (await repo.GetCustomerPurchases(customerId))
            .ToArray();
    }
    public async Task<Purchase> PurchaseById(Guid id, [Service] IPurchaseRepository repo)
    {
        return await repo.GetPurchaseByIdAsync(id) ?? throw new GraphQLException("Purchase with this id not found");
    }
}