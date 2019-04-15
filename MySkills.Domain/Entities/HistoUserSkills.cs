using System;
using System.Collections.Generic;

namespace MySkills.Domain.Entities
{
    public partial class HistoUserSkills
    {
        public int HistoUserSkillId { get; set; }
        public string UserId { get; set; }
        public int SkillId { get; set; }
        public string ValidatorId { get; set; }
        public int EtatId { get; set; }
        public int NoteId { get; set; }
        public DateTime? Date { get; set; }
        public string Activite { get; set; }
    }
}
