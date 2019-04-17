using MySkills.BL.Contracts;
using MySkills.DomainModel;
using MySkills.Persistence.Contracts.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySkills.BL
{
    public class BLFaq : IFaq
    {
        private readonly IUnitOfWork unitOfWork;
        public BLFaq(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Faq> GetFaqs()
        {
            return unitOfWork.FaqsRepository.GetAll();
        }
    }
}
