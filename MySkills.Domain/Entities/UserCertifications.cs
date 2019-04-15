using System;
using System.Collections.Generic;

namespace MySkills.Domain.Entities
{
    public partial class UserCertifications
    {
        public int CertificationId { get; set; }
        public string ApplicationUserId { get; set; }
        public DateTime? DateValidation { get; set; }
        public string ValidatorUserId { get; set; }
        public string ValidatorUserComment { get; set; }
        public DateTime? CreationDate { get; set; }
        public int Etat { get; set; }

        public virtual AspNetUsers ApplicationUser { get; set; }
        public virtual Certifications Certification { get; set; }
    }
}
