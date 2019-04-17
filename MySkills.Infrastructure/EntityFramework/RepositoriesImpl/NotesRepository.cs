using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MySkills.Core.Entities;
using MySkills.Core.Interfaces.Repositories;

namespace MySkills.Infrastructure.EntityFramework.RepositoriesImpl
{
    public class NotesRepository : INotesRepository
    {
        private readonly MySkillsDbContext _context;

        public NotesRepository(MySkillsDbContext context)
        {
            _context = context;
        }

        public List<Notes> selectAll()
        {
            return _context.Notes.ToList();
        }
    }
}
