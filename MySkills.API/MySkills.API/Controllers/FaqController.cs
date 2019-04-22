using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySkills.API.Controllers
{
    [Route("api/Faq")]
    [ApiController]
    public class FaqController : ControllerBase
    {
        /* private readonly IFaq blFaq;

        public FaqController(IFaq faq)
        {
            this.blFaq = faq;
        }

        [HttpGet]
        public IEnumerable<Faq> Get()
        {
            var faqs = blFaq.GetFaqs();
            return faqs;
        }
        */
    }
}
