
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MySkills.Application.Notes.Queries.GetNotesList;
using MySkills.Application.Notes.Commands.CreateNote;
using MySkills.Application.Skills.Queries;

using System.Net;
using Microsoft.AspNetCore.Http;

namespace MySkills.API.Controllers
{
    
    public class NotesController : BaseController
    {
        // GET api/notes/getall
        [HttpGet]
        public async Task<ActionResult<NotesListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetNotesListQuery()));
        }
         public async Task<ActionResult<SkillsListViewModel>> Skills([FromQuery] int level)
        {
            var res = await Mediator.Send(new GetSkillsListQuery{ Level = level });
            return new JsonResult(res);
        }
    }
}
