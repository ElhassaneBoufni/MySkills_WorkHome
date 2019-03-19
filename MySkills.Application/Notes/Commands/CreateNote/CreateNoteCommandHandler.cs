using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MySkills.Domain.Entities;
using MySkills.Persistence;

namespace MySkills.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, int>
    {
        private readonly MySkillsDbContext _context;
        public CreateNoteCommandHandler(MySkillsDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = new Note
            {
                NoteId = request.NoteId,
                Titre = request.Titre,
                Description =request.Description
            };
            _context.Notes.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.NoteId;
        }
    }
}
