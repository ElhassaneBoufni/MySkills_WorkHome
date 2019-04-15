using MediatR;

namespace MySkills.Application.Skills.Queries
{
    public class GetSkillsListQuery :IRequest<SkillsListViewModel>
    {
        public int Level { get; set; }
    }
}