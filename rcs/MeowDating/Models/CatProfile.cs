using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeowDating.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CatProfile
    {
        [Key]
        public int CatId { get; set; }

        [Display(Name ="Vārds")]
        [Required(ErrorMessage ="Kaķim vajag vārdu!")]
        public string CatName { get; set; }

        [Display(Name = "Vecums")]
        [Range(1, 20, ErrorMessage = "Kaķa vecums var būt no 1-20 gadiem")]
        public int CatAge { get; set; }

        [Display(Name = "Foto")]
        public string CatImage { get; set; }

        [Display(Name = "Apraksts")]
        [Required (ErrorMessage ="Kādu vārdu par kaķīti vajag")]
        public string CatDescription { get; set; }

        public virtual File ProfilePicture { get; set; }
    }
}