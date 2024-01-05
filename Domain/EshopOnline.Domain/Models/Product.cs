using EshopOnline.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace EshopOnline.Domain.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(255)]
        [MinLength(3)]
        public string Title { get; set; }

        [Display(Name = "تاریخ")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "فعال/غیرفعال")]
        public bool IsActive { get; set; }
        [Display(Name = "تصویر ")]
        public string Image { get; set; }

        [Display(Name = "قیمت")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(14)]
        [MinLength(3)]
        public string Price { get; set; }

        public virtual ICollection<PropertisProduct> PropertisProducts { get; set; }

        public virtual ICollection<AdditiveProduct> AdditiveProducts { get; set; }
    }
}
