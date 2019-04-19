using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySkills.BL.Contracts;
using MySkills.DomainModel;

namespace MySkills.API.Controllers
{
    [Route("api/Profil")]
    [ApiController]
    public class ProfilController : ControllerBase
    {

        private readonly IProfil blProfil;

        public ProfilController(IProfil profil)
        {
            this.blProfil = profil;
        }
        [HttpGet]
        public IEnumerable<Profil> Get()
        {
            var profils = blProfil.GetProfils();
            return profils;
        }
    }
}