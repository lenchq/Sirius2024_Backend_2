using Sirius.GymGraphQL.Interfaces;
using Sirius.GymGraphQL.Model;
namespace Sirius.GymGraphQL.Mutation;

public partial class Mutation
{
    public async Task<Purchase> PurchaseTraining(
        Purchase input,
        [Service] ICustomerRepository customerRepo,
        [Service] ITrainingRepository trainingRepo,
        [Service] IPurchaseRepository purchaseRepo)
    {
        if (await customerRepo.GetCustomerByIdAsync(input.CustomerId) is null)
            NotFound<Customer>();

        if (await trainingRepo.GetTrainingByIdAsync(input.TrainingId) is null)
            NotFound<Training>();

        var training = await trainingRepo.GetTrainingByIdAsync(input.TrainingId);
        var purchase = new Purchase
        {
            Id = Guid.NewGuid(),
            CustomerId = input.CustomerId,
            TrainingId = input.TrainingId,
            Price = training!.Price,
            Income = training.Price * Constants.IncomeMultiplier,
        };

        await purchaseRepo.AddPurchaseAsync(purchase);

        return await purchaseRepo.GetPurchaseByIdAsync(purchase.Id);
    }
    public async Task<Purchase> DeletePurchaseAsync(
        Guid input,
        [Service] IPurchaseRepository purchaseRepo)
    {
        if (await purchaseRepo.GetPurchaseByIdAsync(input) is null)
            NotFound<Purchase>();
        
        return await purchaseRepo.RemovePurchaseAsync(input);
    }
    
    public async Task<Purchase> UpdatePurchaseAsync(
        Purchase input,
        [Service] IPurchaseRepository purchaseRepo)
    {
        if (await purchaseRepo.GetPurchaseByIdAsync(input.Id) is null)
            NotFound<Purchase>();
        
        return await purchaseRepo.UpdatePurchaseAsync(input);
    }
}