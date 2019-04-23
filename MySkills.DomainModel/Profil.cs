using System.ComponentModel.DataAnnotations;

namespace MySkills.DomainModel
{
    public class Profil
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string nom { get; set; }
        public string grade { get; set; }
        public string poste { get; set; }
        public string pratice { get; set; }
        public string projet { get; set; }
        public string ptl { get; set; }
        public string exp { get; set; }
        public string total_exp { get; set; }
        public string comp { get; set; }
        public string technique { get; set; }
        public string manag_support { get; set; }
        public string skill { get; set; }
        public string certif { get; set; }
    }
}