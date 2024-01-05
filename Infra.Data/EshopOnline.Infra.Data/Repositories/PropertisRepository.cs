using EshopOnline.Domain.Entities;
using EshopOnline.Domain.Interface;
using EshopOnline.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EshopOnline.Infra.Data.Repositories
{
    public class PropertisRepository : IPropertisRepository
    {
        private readonly EshopOnlineContext _context;

        public PropertisRepository(EshopOnlineContext context)
        {
            _context = context;
        }
        public IQueryable<Propertis> GetAll()
        {
            var result = _context.Propertis.Include(p => p.PropertiseTitle).AsQueryable().AsNoTracking();
            return result;
        }

        public async Task<Propertis> InsertAsync(Propertis model)
        {
            await _context.AddAsync(model);
            return model;
        }
    }
}
