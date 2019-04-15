using System;
using System.Collections.Generic;

namespace MySkills.Domain.Entities
{
    public partial class Ranks
    {
        public Ranks()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
            Tumranks = new HashSet<Tumranks>();
        }

        public int RankId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
        public virtual ICollection<Tumranks> Tumranks { get; set; }
    }
}
