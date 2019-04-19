
using MySkills.DomainModel;
using System.Collections.Generic;

namespace MySkills.BL.Contracts
{
    public interface IProfil
    {
        IEnumerable<Profil> GetProfils();
    }
}