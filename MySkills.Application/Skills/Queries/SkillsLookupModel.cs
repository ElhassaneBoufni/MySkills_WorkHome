using AutoMapper;
using MySkills.Application.Interfaces.Mapping;
using MySkills.Domain.Entities;

namespace MySkills.Application.Skills.Queries
{
    public class SkillsLookupModel
    {
       public int Id { get; set; }
        public string Title { get; set; }
        public int Level { get; set; }
        public int ParentId { get; set; }
        

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<MySkills.Domain.Entities.Skills, SkillsLookupModel>()
                .ForMember(cDTO => cDTO.Id, opt => opt.MapFrom(c => c.SkillId))
                .ForMember(cDTO => cDTO.Title, opt => opt.MapFrom(c => c.Title))
                .ForMember(cDTO => cDTO.ParentId, opt => opt.MapFrom(c => c.ParentId))
                .ForMember(cDTO => cDTO.Level, opt => opt.MapFrom(c => c.Level));
        }
    }
}
