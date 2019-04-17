using System;
using System.Collections.Generic;

namespace MySkills.Core.Entities
{
    public partial class Tumranks
    {
        public int RankId { get; set; }
        public string ApplicationUserId { get; set; }
        public DateTime? DateCreation { get; set; }

        public virtual AspNetUsers ApplicationUser { get; set; }
        public virtual Ranks Rank { get; set; }
    }
}
