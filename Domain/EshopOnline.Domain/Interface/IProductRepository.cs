using EshopOnline.Domain.Models;

namespace EshopOnline.Domain.Interface
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAll();
        Task<Product> InsertAsync(Product model);
    }
}
