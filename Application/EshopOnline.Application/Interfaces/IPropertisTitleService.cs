using EshopOnline.Application.DTO;

namespace EshopOnline.Application.Interfaces
{
    public interface IPropertisTitleService
    {
        public Task<long> InsertAsync(PropertisTitleDto model);
    }
}
