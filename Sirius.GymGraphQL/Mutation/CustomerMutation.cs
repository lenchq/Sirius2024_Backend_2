using Sirius.GymGraphQL.Interfaces;
using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Mutation;

public partial class Mutation
{
    public async Task<Customer> AddCustomerAsync(
        Customer input,
        [Service] ICustomerRepository customerRepo)
    {
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            Name = input.Name,
            Email = input.Email,
        };

        await customerRepo.AddCustomerAsync(customer);

        return customer;
    }
    public async Task<Customer> DeleteCustomerAsync(
        Guid input,
        [Service] ICustomerRepository customerRepo)
    {
        if (await customerRepo.GetCustomerByIdAsync(input) is null)
            NotFound<Customer>();
        
        return await customerRepo.RemoveCustomerAsync(input);
    }
    
    public async Task<Customer> UpdateCustomerAsync(
        Customer input,
        [Service] ICustomerRepository customerRepo)
    {
        if (await customerRepo.GetCustomerByIdAsync(input.Id) is null)
            NotFound<Customer>();
        
        return await customerRepo.UpdateCustomerAsync(input);
    }
}