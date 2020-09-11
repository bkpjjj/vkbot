using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Vkbot.ASP.Models;

namespace Vkbot.ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotController : ControllerBase
    {
        #region Services

        public BotController(ILogger<BotController> logger,IConfiguration configuration)
        {
            Log = logger;
            Config = configuration;

            Log.LogInformation("Services Inited");
        }

        public ILogger<BotController> Log { get; }
        public IConfiguration Config { get; }

        #endregion

        #region Methods
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Vkbot is alive!");
        } 
        [HttpPost("callback")]
        public IActionResult CallBack(object json)
        {
            Log.LogInformation($"Callback with data:{json}");
            CallbackModel data = JsonConvert.DeserializeObject<CallbackModel>(json.ToString());
            if (data.Type == "confirmation")
                return Ok(Config["VkApi:Confirmation"]);

            if (data.Type == "new_message")
                Log.Log(LogLevel.Information, "New message!");

            return Ok("ok");
        }
        #endregion
    }
}
