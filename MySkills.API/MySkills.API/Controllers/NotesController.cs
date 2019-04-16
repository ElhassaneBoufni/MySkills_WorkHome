
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MySkills.Core.Interfaces.Services;
using System.Net;
using Microsoft.AspNetCore.Http;
using MySkills.Core.Entities;
using System.Collections.Generic;

namespace MySkills.API.Controllers
{
    
    public class NotesController : BaseController
    {
        private IMyService _service;

        public NotesController(IMyService service)
        {
            _service = service;
        }


        // GET api/notes/getall
        [HttpGet]
        /* public async Task<ActionResult<NotesListViewModel>> GetAll()
         {
             return Ok(await Mediator.Send(new GetNotesListQuery()));
         }*/
        public ActionResult<IEnumerable<Notes>> GetNotes([FromQuery] int level)
        {
            var res = _service.GetNotes();
            return new JsonResult(res);
        }
    }
}
