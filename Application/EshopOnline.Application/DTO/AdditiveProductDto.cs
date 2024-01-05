using EshopOnline.Application.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EshopOnline.Application.DTOs
{
    public class AdditiveProductDto
    {
        public int ID { get; set; }
        public int ProductID { get; set; }

        [Display(Name = "عنوان افزودنی")]
        public string Title { get; set; }

        [Display(Name = "قیمت افزوده")]
        public decimal Price { get; set; }
    }
}
