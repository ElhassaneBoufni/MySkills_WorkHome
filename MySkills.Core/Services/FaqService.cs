using System;
using System.Collections.Generic;
using System.Text;
using MySkills.Core.Entities;
using MySkills.Core.Interfaces.Services;
using MySkills.Core.Interfaces.IUnitOfWork;
namespace MySkills.Core.Services
{
    public class FaqService : IFaqService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FaqService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Faq> GetFaqs()
        {
            return _unitOfWork.FaqRepository.GetAll();
        }
    }
}
