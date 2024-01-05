using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EshopOnline.Domain.Entities
{
    public class PropertisTitle
    {
        public int ID { get; set; }

        [Display(Name = "عنوان")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(50)]
        [MinLength(3)]
        [RegularExpression(@"[a-zا-یA-Z0-9آ\s_]*")]
        public string Title { get; set; }

        [Display(Name = "تاریخ")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime CreateDate { get; set; }

        public virtual ICollection<Propertis> Propertises { get; set; }
    }
}
