
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MySkills.Application.Notes.Queries.GetNotesList;
using MySkills.Application.Notes.Commands.CreateNote;

using System.Net;
using Microsoft.AspNetCore.Http;

namespace MySkills.WebUI.Controllers
{
    
    public class NotesController : BaseController
    {
        // GET api/customers
        [HttpGet]
        public async Task<ActionResult<NotesListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetNotesListQuery()));
        }
    }
}
