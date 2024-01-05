using EshopOnline.Application.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EshopOnline.Application.DTOs
{
    public class PropertisProductDto
    {
        public int ProductID { get; set; }
        public int PropertiseID { get; set; }

        [Display(Name = "قیمت افزوده")]
        public decimal Price { get; set; }

        [Display(Name = "موجودی")]
        [Required]
        public int Count { get; set; }
    }
}
