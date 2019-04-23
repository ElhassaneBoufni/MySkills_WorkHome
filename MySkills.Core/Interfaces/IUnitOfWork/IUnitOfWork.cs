using System;
using System.Collections.Generic;
using System.Text;
using MySkills.Core.Entities;

namespace MySkills.Core.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {

        IRepository<Notes> NotesRepository { get; }
        IRepository<Skills> SkillsRepository { get; }
        IRepository<AspNetUsers> AspNetUsersRepository { get; }
     

        IRepository<Faq> FaqRepository { get; }
        void Commit();
    }
}
