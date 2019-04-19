using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MySkills.BL.Contracts;
using MySkills.DomainModel;
using MySkills.Persistence.Contracts.UnitOfWork;

namespace MySkills.BL
{
    public class BLProfil : IProfil
    {
        private readonly IUnitOfWork unitOfWork;
        public BLProfil(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Profil> GetProfils()
        {
            return unitOfWork.ProfilsRepository.GetAll();
        }
    }
}