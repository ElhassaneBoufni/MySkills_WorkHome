using System;
using System.Collections.Generic;

namespace MySkills.Core.Entities
{
    public partial class Staffs
    {
        public int StaffId { get; set; }
        public string Type { get; set; }
        public string ProjectName { get; set; }
        public string Office { get; set; }
        public DateTime? AvailabaleDate { get; set; }
        public string UserId { get; set; }
        public int? ProductionUnitId { get; set; }
        public string Practice { get; set; }

        public virtual ProductionUnits ProductionUnit { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
