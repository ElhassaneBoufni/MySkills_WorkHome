using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using MySkills.Core.Entities;
using MySkills.Core.Interfaces.IUnitOfWork;
using MySkills.Core.Interfaces.Services;
using System.Linq;

namespace MySkills.Core.Services
{
    public class CompEtCertifService : ICompEtCertifService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompEtCertifService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Skills> GetTechno()
        {
            List<string> validValues = new List<string>() { "Soft skills", "Service Management & Support" };
            Expression<Func<Skills, bool>> isTechnoExp = s => s.Parent.ParentId == null && !validValues.Contains(s.Parent.Title) && s.Parent.SkillId == s.ParentId;

            IEnumerable<Skills> skillsQuery = _unitOfWork.SkillsRepository.Get(isTechnoExp);
            //Expression <Func<Skills, bool>> isTechnoExp2 = sk => sk.ParentId == null && sk.Title != "Soft skills" && sk.Title != "Service Management & Support";
            //IEnumerable<Skills> skillsQuery2 = _unitOfWork.SkillsRepository.Get(isTechnoExp2);
            /* var res = skillsQuery.Join(
                 skillsQuery2,
                 s => s.ParentId,
                 sk => sk.SkillId,
                 (s,) => new {S Skills=s}
             ).ToList();
            var x = from s in skillsQuery.AsQueryable()
                                     join sk in skillsQuery.AsQueryable()
                                     on s.ParentId equals sk.SkillId
                                     where sk.ParentId == null && sk.Title != "Soft skills" && sk.Title != "Service Management & Support"
                                     select  new { s.SkillId, s.Description ,s.Title, s.Level, s.ParentId, s.Code} ; */
            return skillsQuery;
        }

        public IEnumerable<Skills> GetSkills(int parentId)
        {
            Expression<Func<Skills, bool>> perLevelExp = s => s.ParentId == parentId;
            return _unitOfWork.SkillsRepository.Get(perLevelExp);
        }
    }
}
