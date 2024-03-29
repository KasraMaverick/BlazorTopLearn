﻿using System.ComponentModel.DataAnnotations;

namespace Blazor.Data.Entities.NewsEntities
{
    public class News
    {
       

        [Key]
        public int NewsId { get; set; }

        [MaxLength(300)]
        [Required]
        public string Title { get; set; }

        [MaxLength(300)]
        [Required]
        public string ShortDescription { get; set; }

        [MaxLength(300)]
        [Required]
        public string Description { get; set; }

        [MaxLength(300)]
        [Required]
        public string ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string EditedBy { get; set; }
    }
}
