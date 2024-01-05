using EshopOnline.Application.DTOs;

namespace EshopOnline.Application.Interfaces
{
    public interface IPropertisService
    {
        public Task<long> InsertAsync(PropertisDto model);
    }
}
