using EshopOnline.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EshopOnline.Infra.Data
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                            new Product
                            {
                                Id = 1
                            },
                            new Product
                            {
                                Id = 2
                            });
        }
    }
}
