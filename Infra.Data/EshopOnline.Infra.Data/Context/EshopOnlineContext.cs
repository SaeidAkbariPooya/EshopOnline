using EshopOnline.Domain.Entities;
using EshopOnline.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EshopOnline.Infra.Data.Context
{
    public class EshopOnlineContext : DbContext
    {
        public EshopOnlineContext(DbContextOptions<EshopOnlineContext> options) : base(options)
        {

        }

        #region DbSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Propertis> Propertis { get; set; }
        public DbSet<PropertisProduct> PropertisProducts { get; set; }
        public DbSet<PropertisTitle> PropertiseTitles { get; set; }
        #endregion

        #region on model creating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Seed();

            modelBuilder.Entity<Product>()
               .Property(s => s.Id)
               .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
