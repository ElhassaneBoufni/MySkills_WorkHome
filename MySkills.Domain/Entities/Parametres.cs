using System;
using System.Collections.Generic;

namespace MySkills.Domain.Entities
{
    public partial class Parametres
    {
        public int ParametreId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Help { get; set; }
    }
}
