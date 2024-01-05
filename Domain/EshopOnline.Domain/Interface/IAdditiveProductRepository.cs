using EshopOnline.Domain.Entities;

namespace EshopOnline.Domain.Interface
{
    public interface IAdditiveProductRepository
    {
        Task<AdditiveProduct> InsertAsync(AdditiveProduct model);
    }
}
