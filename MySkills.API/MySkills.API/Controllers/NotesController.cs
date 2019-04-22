
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MySkills.Core.Interfaces.Services;
using System.Net;
using Microsoft.AspNetCore.Http;
using MySkills.Core.Entities;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;

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
        public ActionResult<IEnumerable<Notes>> GetAll()
        {
            _logger.LogDebug("Hello loggDebug");
            _logger.LogInformation("Hello loggInfo");
            _logger.LogWarning("Hello LogWarning");
            _logger.LogError("Hello LogError");
            _logger.LogCritical("Hello LogCritical");

            var res = _service.GetNotes();
            _logger.LogInformation("===> les notes Recu : {@res} date : {Created}", res, DateTime.Now);
            return new JsonResult(res);
        }
    }
}
