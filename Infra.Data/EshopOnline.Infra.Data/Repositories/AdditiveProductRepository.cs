using EshopOnline.Domain.Entities;
using EshopOnline.Domain.Interface;
using EshopOnline.Infra.Data.Context;

namespace EshopOnline.Infra.Data.Repositories
{
    public class AdditiveProductRepository : IAdditiveProductRepository
    {
        private readonly EshopOnlineContext _context;

        public AdditiveProductRepository(EshopOnlineContext context)
        {
            _context = context;
        }
        public async Task<AdditiveProduct> InsertAsync(AdditiveProduct model)
        {
            await _context.AddAsync(model);
            return model;
        }
    }
}
