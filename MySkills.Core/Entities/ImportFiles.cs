using System;
using System.Collections.Generic;

namespace MySkills.Core.Entities
{
    public partial class ImportFiles
    {
        public int ImportFileId { get; set; }
        public DateTime DateImport { get; set; }
        public string FileName { get; set; }
        public double ContentLength { get; set; }
        public string ApplicationUserId { get; set; }
        public string Type { get; set; }

        public virtual AspNetUsers ApplicationUser { get; set; }
    }
}
