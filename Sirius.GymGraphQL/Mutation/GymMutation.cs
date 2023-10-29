using Sirius.GymGraphQL.Interfaces;
using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Mutation;

public partial class Mutation
{
    public async Task<Gym> AddGymAsync(
        Gym input,
        [Service] IGymRepository customerRepo)
    {
        var customer = new Gym
        {
            Id = Guid.NewGuid(),
            Name = input.Name,
            ManagerName = input.ManagerName,
            ManagerPhoneNumber = input.ManagerPhoneNumber,
        };

        await customerRepo.AddGymAsync(customer);

        return customer;
    }
    public async Task<Gym> DeleteGymAsync(
        Guid input,
        [Service] IGymRepository customerRepo)
    {
        if (await customerRepo.GetGymByIdAsync(input) is null)
            NotFound<Gym>();
        
        return await customerRepo.RemoveGymAsync(input);
    }
    
    public async Task<Gym> UpdateGymAsync(
        Gym input,
        [Service] IGymRepository gymRepo)
    {
        if (await gymRepo.GetGymByIdAsync(input.Id) is null)
            NotFound<Gym>();

        var gym = await gymRepo.GetGymByIdAsync(input.Id);

        gym.ManagerName = input.ManagerName ?? gym.ManagerName;
        gym.ManagerPhoneNumber = input.ManagerPhoneNumber ?? gym.ManagerPhoneNumber;
        gym.Name = input.Name ?? gym.Name;

        return await gymRepo.UpdateGymAsync(gym);
    }
}