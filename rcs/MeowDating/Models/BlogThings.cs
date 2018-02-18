using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeowDating.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BlogThings
    {
        [Key]
        public int BlogId { get; set; }

        public string UserId { get; set; }

        [Display(Name ="Nosaukums")]
        public string BlogTitle { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Ieraksts")]
        public string BlogWrite { get; set; }

        public DateTime BlogCreated { get; set; }

        public DateTime BlogModifield { get; set; }

    }
}