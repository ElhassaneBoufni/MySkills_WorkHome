using System;
using System.Collections.Generic;
using System.Text;
using MySkills.Core.Entities;
using MySkills.Core.DTO;

namespace MySkills.Core.Interfaces.Services
{
    public interface ICompEtCertifService
    {
        IEnumerable<SkillsDTO> GetTechno();
        IEnumerable<SkillsDTO> GetSkills(int parentId, string userId, bool? islvl3);
        IEnumerable<SkillsDTO> GetUserSkills(string appUserId);
        void PostUserSkill(SkillsDTO userSkill);
    }
}
