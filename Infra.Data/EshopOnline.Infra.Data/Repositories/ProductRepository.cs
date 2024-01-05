using EshopOnline.Domain.Entities;
using EshopOnline.Domain.Interface;
using EshopOnline.Domain.Models;
using EshopOnline.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EshopOnline.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region constractor
        private readonly EshopOnlineContext _context;
        public ProductRepository(EshopOnlineContext context)
        {
            _context = context;
        }
        #endregion

        public IQueryable<Product> GetAll()
        {
            return _context.Products.Include(s => s.PropertisProducts)
                                    .Include(s => s.AdditiveProducts)
                                    .AsNoTracking();
        }

        public async Task<Product> InsertAsync(Product model)
        {
            await _context.AddAsync(model);
            return model;
        }
    }
}
