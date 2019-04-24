using System;
using System.Collections.Generic;
using System.Text;
using MySkills.Core.Entities;

namespace MySkills.Core.Interfaces.Services
{
    public interface ICompEtCertifService
    {
        IEnumerable<Skills> GetTechno();
        IEnumerable<Skills> GetSkills(int parentId);
        IEnumerable<Skills> GetUserSkills(string appUserId);
    }
}
