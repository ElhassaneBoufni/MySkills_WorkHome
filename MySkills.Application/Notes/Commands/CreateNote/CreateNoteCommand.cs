using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MySkills.Domain.Entities;
using MySkills.Persistence;

namespace MySkills.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest<int>
    {
        public int NoteId { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
    }
}
