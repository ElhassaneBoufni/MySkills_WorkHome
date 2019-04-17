using System;
using System.Collections.Generic;

namespace MySkills.Core.Entities
{
    public partial class Ptlcertifications
    {
        public int CertificationId { get; set; }
        public string ApplicationUserId { get; set; }
        public int PtlcertifId { get; set; }
        public DateTime? DateCreation { get; set; }

        public virtual AspNetUsers ApplicationUser { get; set; }
        public virtual Certifications Certification { get; set; }
    }
}
