using EshopOnline.Domain.Interface.Pattern;
using EshopOnline.Infra.Data.Context;

namespace EshopOnline.Infra.Data.Patterns
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EshopOnlineContext context;

        public UnitOfWork(EshopOnlineContext context)
        {
            this.context = context;
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public void SaveChanges()
        {
             context.SaveChanges();
        }
    }
}
