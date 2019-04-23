using System;
using System.Collections.Generic;
using System.Text;

namespace MySkills.Core.Entities
{
    public class Faq
    {
        public Faq()
        {

        }
        public int FaqId { get; set; }
        public string Question { get; set; }
        public string Response { get; set; }
    }
}
