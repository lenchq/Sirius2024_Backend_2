using Microsoft.EntityFrameworkCore;
using Sirius.GymGraphQL.Database;
using Sirius.GymGraphQL.Interfaces;
using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Repository;

public sealed class PurchaseRepository : IPurchaseRepository
{
    private readonly DbSet<Purchase> _purchases;
    private readonly AppDbContext _ctx;

    public PurchaseRepository(AppDbContext ctx)
    {
        _purchases = ctx.Purchases!;
        _ctx = ctx;
    }
    
    public async Task<Purchase> AddPurchaseAsync(Purchase purchase)
    {
        var entity = (await _purchases.AddAsync(purchase)).Entity;
        await _ctx.SaveChangesAsync();
        
        return await GetPurchaseByIdAsync(entity.Id);
    }

    public async Task<Purchase> RemovePurchaseAsync(Guid id)
    {
        var purchase = await GetPurchaseByIdAsync(id);
        _purchases.Remove(purchase);
        await _ctx.SaveChangesAsync();
        return purchase;
    }

    public async Task<Purchase> UpdatePurchaseAsync(Purchase purchase)
    {
        _purchases.Update(purchase);
        await _ctx.SaveChangesAsync();
        return await GetPurchaseByIdAsync(purchase.Id);
    }

    public async Task<Purchase?> GetPurchaseByIdAsync(Guid id)
    {
        return await _purchases.AsNoTracking().Include(_ => _.Training).ThenInclude(_ => _.Gym).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Purchase>> GetAllPurchases()
    {
        return await _purchases
            .AsNoTracking()
            .Include(_ => _.Training)
                .ThenInclude(_ => _.Gym)
            .Include(_ => _.Customer)
            .Take(50)
            .ToArrayAsync();
    }

    public async Task<IEnumerable<Purchase>> GetCustomerPurchases(Guid customerId)
    {
        return await _purchases
            .AsNoTracking()
            .Include(_ => _.Training)
                .ThenInclude(_ => _.Gym)
            .Include(_ => _.Customer)
            .Where(x => x.CustomerId == customerId)
            .ToArrayAsync();
    }
}