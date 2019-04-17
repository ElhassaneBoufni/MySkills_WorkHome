using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MySkills.DomainModel
{
    public class Faq
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string question { get; set; }
        public string response { get; set; }
    }
}
