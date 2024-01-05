namespace EshopOnline.Domain.Interface.Pattern
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
