using System;
using System.Collections.Generic;
using System.Text;
using MySkills.Core.Entities;

namespace MySkills.Core.Interfaces.Repositories
{
    public interface INotesRepository
    {
        List<Notes> selectAll();
    }
}
