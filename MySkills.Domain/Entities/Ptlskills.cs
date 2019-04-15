using System;
using System.Collections.Generic;

namespace MySkills.Domain.Entities
{
    public partial class Ptlskills
    {
        public int SkillId { get; set; }
        public string ApplicationUserId { get; set; }
        public DateTime? DateCreation { get; set; }
        public int PtlskillsId { get; set; }

        public virtual AspNetUsers ApplicationUser { get; set; }
        public virtual Skills Skill { get; set; }
    }
}
