using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MySkills.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace MySkills.Application.Notes.Queries.GetNotesList 
{
    public class GetNotesListQueryHandler : IRequestHandler<GetNotesListQuery, NotesListViewModel>
    {
        private readonly MySkillsDbContext _context;
        private readonly IMapper _mapper;

        public GetNotesListQueryHandler(MySkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<NotesListViewModel> Handle(GetNotesListQuery request, CancellationToken cancellationToken)
        {
            return new NotesListViewModel
            {
                Notes = await _context.Notes.ProjectTo<NoteLookupModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
