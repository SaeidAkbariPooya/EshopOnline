using EshopOnline.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EshopOnline.Domain.Entities
{
    public class PropertisProduct
    {
        [Key]
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int PropertiseID { get; set; }

        [Display(Name = "قیمت افزوده")]
        public decimal Price { get; set; }

        [Display(Name = "موجودی")]
        [Required]
        public int Count { get; set; }


        [ForeignKey(nameof(PropertiseID))]
        public virtual Propertis Propertis { get; set; }

        [ForeignKey(nameof(ProductID))]
        public virtual Product Product { get; set; }
    }
}
