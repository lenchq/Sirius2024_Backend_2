using Microsoft.EntityFrameworkCore;
using Sirius.GymGraphQL.Database;
using Sirius.GymGraphQL.Interfaces;
using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Repository;

public sealed class TrainingRepository : ITrainingRepository
{
    private readonly DbSet<Training> _trainings;
    private readonly AppDbContext _ctx;

    public TrainingRepository(AppDbContext ctx)
    {
        _trainings = ctx.Trainings!;
        _ctx = ctx;
    }

    public async Task<Training> AddTrainingAsync(Training training)
    {
        var entity = (await _trainings.AddAsync(training)).Entity;
        await _ctx.SaveChangesAsync();
        return entity;
    }

    public async Task<Training> RemoveTrainingAsync(Guid id)
    {
        var training = await GetTrainingByIdAsync(id);
        _trainings.Remove(training);
        await _ctx.SaveChangesAsync();
        return training;
    }

    public async Task<Training> UpdateTrainingAsync(Training training)
    {
        _trainings.Update(training);
        await _ctx.SaveChangesAsync();
        return await GetTrainingByIdAsync(training.Id);
    }

    public async Task<Training?> GetTrainingByIdAsync(Guid id)
    {
        return await _trainings.AsNoTracking().Include(_ => _.Gym).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Training>> GetAllTrainings()
    {
        return await _trainings.AsNoTracking().Include(_ => _.Gym).Take(50).ToArrayAsync();
    }
}