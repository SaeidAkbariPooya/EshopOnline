using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EshopOnline.Domain.Entities
{
    public class Propertis
    {
        [Key]
        public int ID { get; set; }

        //public int TopicID { get; set; }

        [Display(Name = "تاپیک")]
        public int? TitleID { get; set; }

        [Display(Name = "عنوان")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(50)]
        [MinLength(3)]
        [RegularExpression(@"[a-zا-یA-Z0-9آ\s_]*")]
        public string Title { get; set; }

        [Display(Name = "تاریخ")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime CreateDate { get; set; }

        [ForeignKey(nameof(TitleID))]
        public virtual PropertisTitle PropertiseTitle { get; set; }
        public virtual ICollection<PropertisProduct> PropertisProducts { get; set; }
    }
}
