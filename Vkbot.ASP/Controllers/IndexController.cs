using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vkbot.ASP.Controllers
{
    [Route("/")]
    [Route("[controller]")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        [HttpGet]
        public RedirectResult Redirect()
        {
            return Redirect("/api/bot");
        }
    }
}
