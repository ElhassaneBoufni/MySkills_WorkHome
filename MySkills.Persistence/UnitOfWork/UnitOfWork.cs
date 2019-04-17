using MySkills.DomainModel;
using MySkills.Persistence.Contracts;
using MySkills.Persistence.Contracts.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySkills.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;

            this.FaqsRepository = new BaseRepository<Faq>(dbContext);
        }

        public IRepository<Faq> FaqsRepository
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
            this.dbContext.SaveChanges();
        }
    }
}
