using EshopOnline.Domain.Entities;
using EshopOnline.Domain.Interface;
using EshopOnline.Infra.Data.Context;

namespace EshopOnline.Infra.Data.Repositories
{
    public class PropertisTitleRepository : IPropertiseTitleRepository
    {
        private readonly EshopOnlineContext _context;

        public PropertisTitleRepository(EshopOnlineContext context)
        {
            _context = context;
        }
        public async Task<PropertisTitle> InsertAsync(PropertisTitle model)
        {
            await _context.AddAsync(model);
            return model;
        }
    }
}
