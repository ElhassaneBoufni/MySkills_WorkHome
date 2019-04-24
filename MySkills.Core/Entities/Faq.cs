using System;
using System.Collections.Generic;

namespace MySkills.Core.Entities
{
    public partial class Faq
    {
        public int FaqId { get; set; }
        public string Question { get; set; }
        public string Response { get; set; }
    }
}
