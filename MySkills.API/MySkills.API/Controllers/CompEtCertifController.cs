using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySkills.Core.Entities;
using MySkills.Core.Interfaces.Services;
using Microsoft.Extensions.Logging;
using MySkills.Core.DTO;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTechno()
        {
            var res = _service.GetTechno();
            if (res.Count() > 0)
                return Ok(res);
            else
                return NotFound();
        }

        [HttpGet]
        public IEnumerable<SkillsDTO> GetSkills([FromQuery] int ParentId, string appUserId, bool? islvl3)
        {
            _logger.LogInformation("====> {p.ID} <=====", ParentId);
            var res = _service.GetSkills(ParentId, appUserId, islvl3);
            return res;
        }

        [HttpGet]
        public IEnumerable<SkillsDTO> GetUserSkills([FromQuery] string appUserID)
        {
            _logger.LogInformation("====> {appUserID} <=====", appUserID);
            var res = _service.GetUserSkills(appUserID);
            return res;
        }

        [HttpPost]
        public IActionResult PostSkills([FromBody] SkillsDTO userSkill)
        {
            if (ModelState.IsValid && userSkill.ApplicationUserId != null)
            {
                _logger.LogWarning("====> {appUserID} <=====", userSkill.ApplicationUserId);

                try
                {
                    _service.PostUserSkill(userSkill);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erreur d'insertion : ");
                }
                return Ok(userSkill.SkillId);
            }
            else
            {
                return new JsonResult(BadRequest(ModelState));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserSkill(int id)
        {
            _logger.LogWarning("====> ID : {id} <=====", id);
            return Ok(id);
        }
    }
}