using System;
using System.Collections.Generic;
using System.Text;
using MySkills.Core.Entities;
using MySkills.Core.Interfaces.Services;
using MySkills.Core.Interfaces.Repositories;

namespace MySkills.Core.Services
{
    public class MyService : IMyService
    {
        INotesRepository _notesRepository;

        public MyService(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }
        public List<Notes> GetNotes()
        {
            return _notesRepository.selectAll();
        }
    }
}
