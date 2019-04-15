using System;
using System.Collections.Generic;

namespace MySkills.Domain.Entities
{
    public partial class PropCertifications
    {
        public PropCertifications()
        {
            InverseParentPropCertification = new HashSet<PropCertifications>();
        }

        public int PropCertificationId { get; set; }
        public string Title { get; set; }
        public string Commentaire { get; set; }
        public DateTime DateProposition { get; set; }
        public int? CertificationId { get; set; }
        public string ApplicationUserId { get; set; }
        public bool? IsValid { get; set; }
        public int? ParentPropCertificationId { get; set; }

        public virtual AspNetUsers ApplicationUser { get; set; }
        public virtual PropCertifications ParentPropCertification { get; set; }
        public virtual ICollection<PropCertifications> InverseParentPropCertification { get; set; }
    }
}
