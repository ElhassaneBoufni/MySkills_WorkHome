using System;
using System.Collections.Generic;
using System.Text;
using MySkills.Core.Interfaces.IUnitOfWork;
using MySkills.Core.Entities;
using MySkills.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace MySkills.Persistance.EntityFramework.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MySkillsDbContext _dbContext;
        private readonly ILogger _logger;

        public UnitOfWork(MySkillsDbContext dbContext, ILogger<UnitOfWork> logger)
        {
            _logger = logger;
            _dbContext = dbContext;

            NotesRepository = new GenericRepository<Notes>(dbContext);

            _logger.LogInformation("L'UnitOfWork est appelé");

        }

        public IRepository<Notes> NotesRepository
        {
            get;
            protected set;
        }
        //private IFaqRepository _Faq;

        //public IFaqRepository Faq
        //{
        //    get
        //    {
        //        if (this._Faq == null)
        //        {
        //            this._Faq = new FaqRepository(dbContext);
        //        }
        //        return this._Faq;
        //    }
        //}

        private bool _disposedValue = false; // To detect redundant calls  

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;

            if (disposing)
            {
                //dispose managed state (managed objects).  
            }

            // free unmanaged resources (unmanaged objects) and override a finalizer below.  
            // set large fields to null.  

            _disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Rollback()
        {
            _dbContext = new MySkillsDbContext();
        }
    }
}

