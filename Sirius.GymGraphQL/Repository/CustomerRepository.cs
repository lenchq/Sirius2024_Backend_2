using Microsoft.EntityFrameworkCore;
using Sirius.GymGraphQL.Database;
using Sirius.GymGraphQL.Interfaces;
using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly DbSet<Customer> _customers;
    private readonly AppDbContext _ctx;

    public CustomerRepository(AppDbContext ctx)
    {
        _customers = ctx.Customers!;
        _ctx = ctx;
    }

    public async Task<Customer> AddCustomerAsync(Customer customer)
    {
        var entity = (await _customers.AddAsync(customer)).Entity;
        await _ctx.SaveChangesAsync();
        return entity;
    }

    public async Task<Customer> RemoveCustomerAsync(Guid id)
    {
        var customer = await GetCustomerByIdAsync(id);
        _customers.Remove(customer);
        await _ctx.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer> UpdateCustomerAsync(Customer customer)
    {
        _customers.Update(customer);
        await _ctx.SaveChangesAsync();
        return await GetCustomerByIdAsync(customer.Id);
    }

    public async Task<Customer?> GetCustomerByIdAsync(Guid id)
    {
        return await _customers
            .AsNoTracking()
            .Include(_ => _.Purchases)
                .ThenInclude(_ => _.Training)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Customer>> GetAllCustomers()
    {
        return await _customers
            .AsNoTracking()
            .Include(_ => _.Purchases)
            .ThenInclude(_ => _.Training)
            .Take(50)
            .ToListAsync();
    }
}