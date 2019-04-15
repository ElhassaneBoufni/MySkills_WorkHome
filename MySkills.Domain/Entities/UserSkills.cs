using System;
using System.Collections.Generic;

namespace MySkills.Domain.Entities
{
    public partial class UserSkills
    {
        public int SkillId { get; set; }
        public string ApplicationUserId { get; set; }
        public string ValidatorUserId { get; set; }
        public DateTime? DateValidation { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
        public int Etat { get; set; }
        public int NoteId { get; set; }

        public virtual AspNetUsers ApplicationUser { get; set; }
        public virtual Notes Note { get; set; }
        public virtual Skills Skill { get; set; }
    }
}
