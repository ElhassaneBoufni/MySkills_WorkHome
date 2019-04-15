using System;
using System.Collections.Generic;

namespace MySkills.Domain.Entities
{
    public partial class Certifications
    {
        public Certifications()
        {
            InverseParent = new HashSet<Certifications>();
            Ptlcertifications = new HashSet<Ptlcertifications>();
            UserCertifications = new HashSet<UserCertifications>();
        }

        public int CertificationId { get; set; }
        public string Title { get; set; }
        public DateTime DateCreation { get; set; }
        public int? RootId { get; set; }
        public int? Level { get; set; }
        public int? State { get; set; }
        public int? ParentId { get; set; }
        public int NoteId { get; set; }
        public string Description { get; set; }
        public int? ImportSkillFileId { get; set; }
        public int? DisplayOrder { get; set; }

        public virtual Certifications Parent { get; set; }
        public virtual ICollection<Certifications> InverseParent { get; set; }
        public virtual ICollection<Ptlcertifications> Ptlcertifications { get; set; }
        public virtual ICollection<UserCertifications> UserCertifications { get; set; }
    }
}
