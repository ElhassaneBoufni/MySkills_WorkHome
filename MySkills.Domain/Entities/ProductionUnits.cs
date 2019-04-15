using System;
using System.Collections.Generic;

namespace MySkills.Domain.Entities
{
    public partial class ProductionUnits
    {
        public ProductionUnits()
        {
            Staffs = new HashSet<Staffs>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Staffs> Staffs { get; set; }
    }
}
