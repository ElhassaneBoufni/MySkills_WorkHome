using System;
using System.Collections.Generic;

namespace MySkills.Core.Entities
{
    public partial class ExcelExports
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public DateTime Date { get; set; }
        public string GeneratedPassword { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
