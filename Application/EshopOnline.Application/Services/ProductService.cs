using EshopOnline.Application.DTOs;
using EshopOnline.Application.Interfaces;
using EshopOnline.Domain.Entities;
using EshopOnline.Domain.Interface;
using EshopOnline.Domain.Interface.Pattern;
using EshopOnline.Domain.Models;
using System;

namespace EshopOnline.Application.Services
{
    public class ProductService : IProductService
    {
        #region constractor
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IAdditiveProductRepository _additiveProductRepository;
        private readonly IPropertisProductsRepository _propertisProductsRepository;

        public ProductService(IProductRepository productRepository,
                              IUnitOfWork unitOfWork,
                              IAdditiveProductRepository additiveProductRepository,
                              IPropertisProductsRepository propertisProductsRepository)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _additiveProductRepository = additiveProductRepository;
            _propertisProductsRepository = propertisProductsRepository;
        }
        #endregion

        public IEnumerable<ProductDto> GetAll(ProductAppSettingDto model)
        {
            var result = _productRepository.GetAll();

            if (!result.Any()) return null;

            ProductListDto vmp = new ProductListDto();
            vmp.ProductList = new List<ProductDto>();

            foreach (var item in result)
            {
                ProductDto product = new ProductDto();
                product.Id = item.Id;
                product.Title = item.Title;
                product.Date = item.Date;

                double pricebyDiscountAmount = 0;
                if (model.DiscountAmount != null)
                {
                    //product.DiscountAmount = model.DiscountAmount;
                    //product.DiscountExpireAt = model.DiscountExpireAt;

                    pricebyDiscountAmount = double.Parse(item.Price) - double.Parse(model.DiscountAmount);
                    if (pricebyDiscountAmount >= 0)
                    {
                        product.Price = (pricebyDiscountAmount + model.PriceCONSTANT).ToString();
                    }
                }

                if (pricebyDiscountAmount < 0)
                {
                    product.Price = (double.Parse(item.Price) + model.PriceCONSTANT).ToString();
                }

                product.Image = item.Image;

                product.AdditiveProductsDto = new List<AdditiveProductDto>();

                foreach (var additive in item.AdditiveProducts)
                {
                    AdditiveProductDto additiveProduct = new AdditiveProductDto();
                    additiveProduct.ProductID = product.Id;
                    additiveProduct.Price = additive.Price;
                    additiveProduct.Title = additive.Title;

                    product.AdditiveProductsDto.Add(additiveProduct);
                }

                product.PropertisProductsDto = new List<PropertisProductDto>();

                foreach (var property in item.PropertisProducts)
                {
                    PropertisProductDto propertisProduct = new PropertisProductDto();
                    propertisProduct.ProductID = product.Id;
                    propertisProduct.PropertiseID = property.PropertiseID;
                    propertisProduct.Price = property.Price;
                    propertisProduct.Count = property.Count;

                    product.PropertisProductsDto.Add(propertisProduct);
                }


                vmp.ProductList.Add(product);
            }

            return vmp.ProductList.OrderByDescending(s => s.Price);
        }

        public async Task<long> InsertAsync(ProductDto model)
        {
            Product product = new Product();
            product.Title = model.Title;
            product.Date = DateTime.Now;
            product.IsActive = model.IsActive;
            product.Price = model.Price.ToString();

            if (model.Image != null)
            {
                string FileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(model.Image);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", FileName);
                var stram = new FileStream(imagePath, FileMode.Create);
                product.Image = FileName;
            }

            var result = await _productRepository.InsertAsync(product);
            _unitOfWork.SaveChanges();

            foreach (var item in model.AdditiveProductsDto)
            {
                AdditiveProduct additiveProduct = new AdditiveProduct();
                additiveProduct.ProductID = result.Id;
                additiveProduct.Title = item.Title;
                additiveProduct.Price = item.Price;

                await _additiveProductRepository.InsertAsync(additiveProduct);
            }
            _unitOfWork.SaveChanges();

            foreach (var item in model.PropertisProductsDto)
            {
                PropertisProduct propertisProduct = new PropertisProduct();
                propertisProduct.ProductID = result.Id;
                propertisProduct.Count = item.Count;
                propertisProduct.Price = item.Price;
                propertisProduct.PropertiseID = item.PropertiseID;

                await _propertisProductsRepository.InsertAsync(propertisProduct);
            }
            _unitOfWork.SaveChanges();


            return result.Id;
        }
    }
}
