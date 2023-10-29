using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Interfaces;

public interface ICustomerRepository
{
    public Task<Customer> AddCustomerAsync(Customer customer);
    public Task<Customer> RemoveCustomerAsync(Guid id);
    public Task<Customer> UpdateCustomerAsync(Customer customer);
    public Task<Customer?> GetCustomerByIdAsync(Guid id);
    public Task<IEnumerable<Customer>> GetAllCustomers();
}