
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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _service;
        private readonly ILogger _logger;
       // private readonly ILog _logger4net = LogManager.GetLogger(typeof(NotesController));

        public NotesController(INotesService service, ILogger<NotesController> logger)
        {
            _service = service;
            _logger = logger;
            //_logger4net = logger4net;
        }


        // GET api/notes/getall
        [HttpGet]
        /* public async Task<ActionResult<NotesListViewModel>> GetAll()
         {
             return Ok(await Mediator.Send(new GetNotesListQuery()));
         }*/
        public ActionResult<IEnumerable<Notes>> GetAll()
        {
            _logger.LogInformation("Hello logging world");
            _logger.LogWarning("_logger: LogWarning");
            _logger.LogError("_logger: LogError");
            _logger.LogCritical("_logger: LogCritical");
            // _logger4net.Info("Hello logging world from log 4 net");
            var res = _service.GetNotes();
            return new JsonResult(res);
        }
    }
}
