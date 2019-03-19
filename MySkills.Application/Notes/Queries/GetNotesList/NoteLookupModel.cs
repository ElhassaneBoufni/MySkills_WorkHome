using AutoMapper;
using MySkills.Application.Interfaces.Mapping;
using MySkills.Domain.Entities;

namespace MySkills.Application.Notes.Queries.GetNotesList
{
    public class NoteLookupModel
    {
        public int Id { get; set; }
        public string Titre { get; set; }

        public string Description { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Note, NoteLookupModel>()
                .ForMember(cDTO => cDTO.Id, opt => opt.MapFrom(c => c.NoteId))
                .ForMember(cDTO => cDTO.Titre, opt => opt.MapFrom(c => c.Titre))
                .ForMember(cDTO => cDTO.Description, opt => opt.MapFrom(c => c.Description));
        }
    }
}
