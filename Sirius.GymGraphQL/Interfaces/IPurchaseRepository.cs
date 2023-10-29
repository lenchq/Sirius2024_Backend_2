using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Interfaces;

public interface IPurchaseRepository
{
    public Task<Purchase> AddPurchaseAsync(Purchase purchase);
    public Task<Purchase> RemovePurchaseAsync(Guid id);
    public Task<Purchase> UpdatePurchaseAsync(Purchase purchase);
    public Task<Purchase?> GetPurchaseByIdAsync(Guid id);
    public Task<IEnumerable<Purchase>> GetAllPurchases();

    public Task<IEnumerable<Purchase>> GetCustomerPurchases(Guid customerId);
}