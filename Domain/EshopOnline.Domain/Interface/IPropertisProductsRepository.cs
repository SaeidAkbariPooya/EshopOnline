using EshopOnline.Domain.Entities;

namespace EshopOnline.Domain.Interface
{
    public interface IPropertisProductsRepository
    {
        Task<PropertisProduct> InsertAsync(PropertisProduct model);
    }
}
