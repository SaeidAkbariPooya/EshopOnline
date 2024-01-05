using EshopOnline.Domain.Entities;

namespace EshopOnline.Domain.Interface
{
    public interface IPropertisRepository
    {
        IQueryable<Propertis> GetAll();
        Task<Propertis> InsertAsync(Propertis model);
    }
}
