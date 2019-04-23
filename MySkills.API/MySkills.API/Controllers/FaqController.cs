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
    public class FaqController : ControllerBase
    {
        private readonly IFaqService _faqService;
        private readonly ILogger _logger;
        // private readonly ILog _logger4net = LogManager.GetLogger(typeof(NotesController));

        public FaqController(IFaqService faqService, ILogger<NotesController> logger)
        {
            _faqService = faqService;
            _logger = logger;
            //_logger4net = logger4net;
        }


        // GET api/notes/getall
        [HttpGet]
        public ActionResult<IEnumerable<Faq>> GetAll()
        {
            var res = _faqService.GetFaqs();
            _logger.LogInformation("===> les notes Recu : {@res} date : {Created}", res, DateTime.Now);
            return new JsonResult(res);
        }


    }
}
