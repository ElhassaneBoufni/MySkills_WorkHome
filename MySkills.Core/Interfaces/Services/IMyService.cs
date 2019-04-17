using System;
using System.Collections.Generic;
using System.Text;
using MySkills.Core.Entities;

namespace MySkills.Core.Interfaces.Services
{
    public interface IMyService
    {
        List<Notes> GetNotes();
    }
}
