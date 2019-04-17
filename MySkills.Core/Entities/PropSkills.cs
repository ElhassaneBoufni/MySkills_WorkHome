using System;
using System.Collections.Generic;

namespace MySkills.Core.Entities
{
    public partial class PropSkills
    {
        public PropSkills()
        {
            InverseParentPropSkill = new HashSet<PropSkills>();
        }

        public int PropSkillId { get; set; }
        public string Title { get; set; }
        public string Commentaire { get; set; }
        public DateTime DateProposition { get; set; }
        public int? SkillId { get; set; }
        public string ApplicationUserId { get; set; }
        public bool? IsRemoved { get; set; }
        public int? ParentPropSkillId { get; set; }

        public virtual AspNetUsers ApplicationUser { get; set; }
        public virtual PropSkills ParentPropSkill { get; set; }
        public virtual ICollection<PropSkills> InverseParentPropSkill { get; set; }
    }
}
