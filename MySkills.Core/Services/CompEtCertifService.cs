using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using MySkills.Core.Entities;
using MySkills.Core.Interfaces.IUnitOfWork;
using MySkills.Core.Interfaces.Services;
using System.Linq;
using MySkills.Core.DTO;

namespace MySkills.Core.Services
{
    public class CompEtCertifService : ICompEtCertifService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompEtCertifService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<SkillsDTO> GetTechno()
        {
            List<string> validValues = new List<string>() { "Soft skills", "Service Management & Support" };
            Expression<Func<Skills, bool>> isTechnoExp = s => s.Parent.ParentId == null && !validValues.Contains(s.Parent.Title) && s.Parent.SkillId == s.ParentId;
            IEnumerable<SkillsDTO> skillsQuery = _unitOfWork.SkillsRepository.Get(isTechnoExp)
                .Select(s => new SkillsDTO { SkillId = s.SkillId, Title = s.Title })
                .Distinct();
            return skillsQuery;
        }

        public IEnumerable<SkillsDTO> GetSkills(int parentId, string userId, bool? islvl3)
        {
            IEnumerable<SkillsDTO> res;

            Expression <Func<Skills, bool>> perLevelExp = s => s.ParentId == parentId;
            IQueryable<Skills> skillsQuery = _unitOfWork.SkillsRepository.Get(perLevelExp, null, "UserSkills").AsQueryable();
            if (islvl3.HasValue && islvl3 == true)
            {
                res = from s in skillsQuery
                      where !(from c in s.UserSkills.AsQueryable()
                              where c.ApplicationUserId == userId
                              select c.SkillId).Contains(s.SkillId)
                      select new SkillsDTO { SkillId = s.SkillId, Title = s.Title };

                return res;
            }
            else
            {
                res = skillsQuery.Select(s => new SkillsDTO { SkillId = s.SkillId, Title = s.Title });
                return res;
            }
            
        }

        public IEnumerable<SkillsDTO> GetUserSkills(string appUserId)
        {
            var userSkillsquery = _unitOfWork.UserSkillsRepository.Get(us => us.ApplicationUserId == appUserId).Select(s => new UserSkills { SkillId = s.SkillId, ApplicationUserId = s.ApplicationUserId });
            var skillsQuery = _unitOfWork.SkillsRepository.GetAll().Select(s => new Skills { SkillId = s.SkillId, Title = s.Title });
            var res = from s in skillsQuery.AsQueryable()
                      join us in userSkillsquery.AsQueryable()
                      on s.SkillId equals us.SkillId
                      where us.ApplicationUserId == appUserId
                      select new SkillsDTO { SkillId = s.SkillId, Title = s.Title};
            return res;
        }

        public void PostUserSkill(SkillsDTO userSkill)
        {
            var userSkillDb = new UserSkills()
            {
                SkillId = userSkill.SkillId,
                ApplicationUserId = userSkill.ApplicationUserId,
                NoteId = 1,
                DateCreation = DateTime.Now,
                Etat = 1
            };

            _unitOfWork.UserSkillsRepository.Add(userSkillDb);
            _unitOfWork.Commit();
        }

        public void d()
        {

        }
    }
}
