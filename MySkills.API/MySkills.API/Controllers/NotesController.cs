
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MySkills.Core.Interfaces.Services;
using System.Net;
using Microsoft.AspNetCore.Http;
using MySkills.Core.Entities;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace MySkills.API.Controllers
{
    
    public class NotesController : BaseController
    {
        private readonly IMyService _service;
        private readonly ILogger _logger;

        public NotesController(IMyService service, ILogger<NotesController> logger)
        {
            _service = service;
            _logger = logger;
        }


        // GET api/notes/getall
        [HttpGet]
        /* public async Task<ActionResult<NotesListViewModel>> GetAll()
         {
             return Ok(await Mediator.Send(new GetNotesListQuery()));
         }*/
        public ActionResult<IEnumerable<Notes>> GetNotes([FromQuery] int level)
        {
            _logger.LogInformation("Hellow");
            var res = _service.GetNotes();
            return new JsonResult(res);
        }
    }
}
