using MySkills.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySkills.Persistence.Contracts.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {

        IRepository<Faq> FaqsRepository { get; }

        IRepository<Profil> ProfilsRepository { get; }

        void Commit();
    }
}
