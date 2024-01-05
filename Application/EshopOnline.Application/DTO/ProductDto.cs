using System.ComponentModel.DataAnnotations;

namespace EshopOnline.Application.DTOs
{
    public class ProductDto
    {
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

        public virtual ICollection<PropertisProductDto> PropertisProductsDto { get; set; }

        public virtual ICollection<AdditiveProductDto> AdditiveProductsDto { get; set; }
    }

    public class ProductAppSettingDto
    {
        [Display(Name = "قیمت تخفیف")]
        [Required(AllowEmptyStrings = false)]
        public string DiscountAmount { get; set; }

        [Display(Name = "تاریخ انقضا")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public string DiscountExpireAt { get; set; }

        [Display(Name = "قیمت ثابت")]
        public double PriceCONSTANT { get; set; }
    }
}
