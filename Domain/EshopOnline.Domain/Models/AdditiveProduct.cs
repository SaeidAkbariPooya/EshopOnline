using EshopOnline.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EshopOnline.Domain.Entities
{
    public class AdditiveProduct
    {
        [Key]
        public int ID { get; set; }
        public int ProductID { get; set; }

        [Display(Name = "عنوان افزودنی")]
        public string Title { get; set; }

        [Display(Name = "قیمت افزوده")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(ProductID))]
        public virtual Product Product { get; set; }
    }
}
