using System;
using System.Collections.Generic;

namespace MySkills.Domain.Entities
{
    public partial class Skills
    {
        public Skills()
        {
            InverseParent = new HashSet<Skills>();
            Ptlskills = new HashSet<Ptlskills>();
            UserSkillL3 = new HashSet<UserSkillL3>();
            UserSkills = new HashSet<UserSkills>();
        }

        public int SkillId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
        public int? ParentId { get; set; }
        public bool IsExperienceUsed { get; set; }
        public int? ImportSkillFileId { get; set; }
        public int? Level { get; set; }
        public int? DisplayOrder { get; set; }
        public string Code { get; set; }

        public virtual Skills Parent { get; set; }
        public virtual ICollection<Skills> InverseParent { get; set; }
        public virtual ICollection<Ptlskills> Ptlskills { get; set; }
        public virtual ICollection<UserSkillL3> UserSkillL3 { get; set; }
        public virtual ICollection<UserSkills> UserSkills { get; set; }
    }
}
