using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySkills.Core.Interfaces.Services;
using MySkills.Core.Entities;

namespace MySkills.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AspNetUsersController : ControllerBase
    {
        private readonly IAspNetUsersService _aspNetUsersService;
        private readonly ILogger _logger;

        public AspNetUsersController(IAspNetUsersService aspNetUsersService, ILogger<NotesController> logger)
        {
            _aspNetUsersService = aspNetUsersService;
            _logger = logger;

        }
            [HttpGet]
        
        public ActionResult<IEnumerable<AspNetUsers>> GetAll()
        {

            var res = _aspNetUsersService.GetAspNetUsers();

            _logger.LogInformation("===> les notes Recu : {@res} date : {Created}", res, DateTime.Now);
            return new JsonResult(res);
        }




    }
}
