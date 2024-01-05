using EshopOnline.Domain.Entities;

namespace EshopOnline.Domain.Interface
{
    public interface IPropertiseTitleRepository
    {
        Task<PropertisTitle> InsertAsync(PropertisTitle model);
    }
}
