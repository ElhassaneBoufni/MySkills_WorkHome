using System;
using System.Collections.Generic;
using System.Text;
using MySkills.Core.Entities;
using MySkills.Core.Interfaces.Services;
using MySkills.Core.Interfaces.IUnitOfWork;

namespace MySkills.Core.Services
{
    public class NotesService : INotesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Notes> GetNotes()
        {
            return _unitOfWork.NotesRepository.GetAll();
        }
    }
}
