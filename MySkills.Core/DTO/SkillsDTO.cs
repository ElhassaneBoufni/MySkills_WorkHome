using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MySkills.Core.DTO
{
    public class SkillsDTO
    {
        [Required]
        public int SkillId { get; set; }
        [Required, StringLength(300, MinimumLength = 2)]
        public string Title { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
