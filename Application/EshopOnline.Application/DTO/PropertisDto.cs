using EshopOnline.Application.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EshopOnline.Application.DTOs
{
    public class PropertisDto
    {
        public int ID { get; set; }

        [Display(Name = "تاپیک")]
        public int? TitleID { get; set; }

        [Display(Name = "عنوان")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(50)]
        [MinLength(3)]
        public string Title { get; set; }

        [Display(Name = "تاریخ")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime CreateDate { get; set; }
    }
}
