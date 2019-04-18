using System;
using System.Collections.Generic;
using System.Text;
using MySkills.Core.Entities;

namespace MySkills.Core.Interfaces.Services
{
    public interface INotesService
    {
        IEnumerable<Notes> GetNotes();
    }
}
