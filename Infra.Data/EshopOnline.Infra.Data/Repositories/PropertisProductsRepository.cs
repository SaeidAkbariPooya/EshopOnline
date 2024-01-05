using EshopOnline.Domain.Entities;
using EshopOnline.Domain.Interface;
using EshopOnline.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EshopOnline.Infra.Data.Repositories
{
    public class PropertisProductsRepository : IPropertisProductsRepository
    {
        private readonly EshopOnlineContext _context;

        public PropertisProductsRepository(EshopOnlineContext context)
        {
            _context = context;
        }

        public async Task<PropertisProduct> InsertAsync(PropertisProduct model)
        {
            await _context.AddAsync(model);
            return model;
        }
    }
}
