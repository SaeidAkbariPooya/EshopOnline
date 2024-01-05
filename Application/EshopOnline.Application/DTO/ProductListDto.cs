using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EshopOnline.Application.DTOs
{
    public class ProductListDto
    {
        public virtual ICollection<ProductDto> ProductList { get; set; }
    }
}
