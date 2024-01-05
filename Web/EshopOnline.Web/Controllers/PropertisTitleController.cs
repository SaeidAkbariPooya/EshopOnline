using EshopOnline.Application.DTO;
using EshopOnline.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EshopOnline.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertisTitleController : Controller
    {
        private readonly IPropertisTitleService _propertiseTitleService;
        public PropertisTitleController(IPropertisTitleService propertiseTitleService)
        {
            _propertiseTitleService = propertiseTitleService;
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> InsertAsync(PropertisTitleDto model) 
        {
            var final = _propertiseTitleService.InsertAsync(model);
            return Ok(final.Result);
        }
    }
}
