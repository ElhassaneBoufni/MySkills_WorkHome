using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySkills.Core.Entities;
using MySkills.Core.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace MySkills.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompEtCertifController : ControllerBase
    {
        private readonly ICompEtCertifService _service;
        private readonly ILogger _logger;

        public CompEtCertifController(ICompEtCertifService service, ILogger<CompEtCertifController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Skills> GetTechno()
        {
            var res = _service.GetTechno();
            return res;
        }

        [HttpGet]
        public IEnumerable<Skills> GetSkills([FromQuery] int ParentId)
        {
            _logger.LogInformation("====> {p.ID} <=====", ParentId);
            var res = _service.GetSkills(ParentId);
            return res;
        }

        [HttpGet]
        public IEnumerable<Skills> GetUserSkills([FromQuery] string appUserID)
        {
            _logger.LogInformation("====> {appUserID} <=====", appUserID);
            var res = _service.GetUserSkills(appUserID);
            return res;
        }
    }
}