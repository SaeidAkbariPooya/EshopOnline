using EshopOnline.Application.DTO;
using EshopOnline.Application.DTOs;
using EshopOnline.Application.Interfaces;
using EshopOnline.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EshopOnline.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertisController : Controller
    {
        private readonly IPropertisService _propertiseService;
        public PropertisController(IPropertisService propertiseService)
        {
            _propertiseService = propertiseService;
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> InsertAsync(PropertisDto model) 
        {
            var final = _propertiseService.InsertAsync(model);
            return Ok(final.Result);
        }
    }
}
