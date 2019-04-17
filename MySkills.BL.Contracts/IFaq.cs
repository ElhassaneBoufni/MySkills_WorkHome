using MySkills.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySkills.BL.Contracts
{
    public interface IFaq
    {
        IEnumerable<Faq> GetFaqs();
    }
}
