using System.ComponentModel.DataAnnotations;

namespace Blazor.Model.NewsDtos
{
    public class NewsDTO
    {
        [Key]
        public int NewsId { get; set; }

        [MaxLength(300)]
        [Required]
        public string Title { get; set; }

        [MaxLength(300)]
        [Required(ErrorMessage = "لطفا {} را وارد نمایید")]
        public string ShortDescription { get; set; }

        [MaxLength(300)]
        [Required]
        public string Description { get; set; }

        [MaxLength(300)]
        [Required]
        public string ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; }
        
        public string CreatedBy { get; set; }

        public string EditedBy { get; set; }
    }
}
