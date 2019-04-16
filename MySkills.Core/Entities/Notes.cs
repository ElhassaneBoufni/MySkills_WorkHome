using System;
using System.Collections.Generic;

namespace MySkills.Core.Entities
{
    public partial class Notes
    {
        public Notes()
        {
            UserSkills = new HashSet<UserSkills>();
        }

        public int NoteId { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserSkills> UserSkills { get; set; }
    }
}
