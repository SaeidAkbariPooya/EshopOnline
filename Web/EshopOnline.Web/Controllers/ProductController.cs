using EshopOnline.Application.DTOs;
using EshopOnline.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EshopOnline.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public IConfiguration Configuration { get; }

        public ProductController(IProductService productService,
                                 IConfiguration configuration)
        {
            _productService = productService;
            Configuration = configuration;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            ProductAppSettingDto model = new ProductAppSettingDto();

            string price = Configuration["AppSettings:price"];
            string discountAmount = Configuration["AppSettings:discountAmount"];
            string discountExpireAt = Configuration["AppSettings:discountExpireAt"];

            model.DiscountAmount = discountAmount;
            model.DiscountExpireAt = discountExpireAt;
            model.PriceCONSTANT = double.Parse(price);

            var result = _productService.GetAll(model);
            return Ok(result);
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> InsertAsync(ProductDto model)
        {
            var final = _productService.InsertAsync(model);
            return Ok(final.Result);
        }
    }
}
