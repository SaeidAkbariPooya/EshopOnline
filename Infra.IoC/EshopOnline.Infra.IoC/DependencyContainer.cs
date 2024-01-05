using EshopOnline.Application.Interfaces;
using EshopOnline.Application.Services;
using EshopOnline.Domain.Interface;
using EshopOnline.Domain.Interface.Pattern;
using EshopOnline.Infra.Data.Patterns;
using EshopOnline.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EshopOnline.Infra.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #region repository
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPropertiseTitleRepository, PropertisTitleRepository>();
            services.AddScoped<IPropertisRepository, PropertisRepository>();
            services.AddScoped<IAdditiveProductRepository, AdditiveProductRepository>();
            services.AddScoped<IPropertisProductsRepository, PropertisProductsRepository>();
            #endregion

            #region service
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPropertisTitleService, PropertisTitleService>();
            services.AddScoped<IPropertisService, PropertisService>();
            #endregion
        }
    }
}
