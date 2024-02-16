using System.ComponentModel.DataAnnotations;

namespace Blazor.Data.Entities.NewsEntities
{
    public class News
    {
        public int NewsId { get; set; }

        [Display(Name = "عنوان")]
        [MaxLength(300, ErrorMessage ="{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage ="لطفا {} را وارد نمایید")]
        public string Title { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "لطفا {} را وارد نمایید")]
        public string ShortDescription { get; set; }

        [Display(Name = "توضیحات اصلی")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "لطفا {} را وارد نمایید")]
        public string Description { get; set; }

        

        [Display(Name = "نام تصویر")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "لطفا {} را وارد نمایید")]
        public string ImageUrl { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime CreatedDate { get; set; }

    }
}
