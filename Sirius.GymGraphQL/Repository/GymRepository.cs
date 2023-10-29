using Microsoft.EntityFrameworkCore;
using Sirius.GymGraphQL.Database;
using Sirius.GymGraphQL.Interfaces;
using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Repository;

public sealed class GymRepository : IGymRepository
{
    private readonly DbSet<Gym> _gyms;
    private readonly AppDbContext _ctx;

    public GymRepository(AppDbContext ctx)
    {
        _gyms = ctx.Gyms!;
        _ctx = ctx;
    }

    public async Task<Gym> AddGymAsync(Gym gym)
    {
        var entity = (await _gyms.AddAsync(gym)).Entity;
        await _ctx.SaveChangesAsync();
        return entity;
    }

    public async Task<Gym> RemoveGymAsync(Guid id)
    {
        var gym = await GetGymByIdAsync(id);
        _gyms.Remove(gym);
        await _ctx.SaveChangesAsync();
        return gym;
    }

    public async Task<Gym> UpdateGymAsync(Gym gym)
    {
        _gyms.Update(gym);
        await _ctx.SaveChangesAsync();
        return await GetGymByIdAsync(gym.Id);
    }

    public async Task<Gym?> GetGymByIdAsync(Guid id)
    {
        return await _gyms
            .AsNoTracking()
            .Include(_ => _.Trainings)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Gym>> GetAllGyms()
    {
        return await _gyms
            .AsNoTracking()
            .Include(_ => _.Trainings)
            .Take(50)
            .ToArrayAsync();
    }

    public async Task<int> GetAvailableTrainingsCount(Guid id)
    {
        return await _ctx.Trainings.CountAsync(x => x.GymId == id);
    }
}