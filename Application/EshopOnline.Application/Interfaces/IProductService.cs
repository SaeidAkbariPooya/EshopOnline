using EshopOnline.Application.DTOs;

namespace EshopOnline.Application.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAll(ProductAppSettingDto model);
        public Task<long> InsertAsync(ProductDto model);
    }
}
