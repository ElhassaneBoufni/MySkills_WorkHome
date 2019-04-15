using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MySkills.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MySkills.Application.Skills.Queries
{
    public class GetSkillsListQueryHandler : IRequestHandler<GetSkillsListQuery, SkillsListViewModel>
    {
        private readonly MySkillsDbContext _context;
        private readonly IMapper _mapper;

        public GetSkillsListQueryHandler(MySkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SkillsListViewModel> Handle(GetSkillsListQuery request, CancellationToken cancellationToken)
        {
            var level = request.Level;

            IQueryable<MySkills.Domain.Entities.Skills> s =  _context.Skills.AsQueryable();
            
            return new SkillsListViewModel
            {
                Skills = await s.Where(skill => skill.Level == level)
                .ProjectTo<SkillsLookupModel>(_mapper.ConfigurationProvider).ToListAsync()
            };
        }
    }
}
