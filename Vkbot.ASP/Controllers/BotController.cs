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
using Vkbot.ASP.Source;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace Vkbot.ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotController : ControllerBase
    {
        #region Services

        public BotController(ILogger<BotController> logger,IConfiguration configuration,MessageProcessing messageProcessing,IVkApi vkApi)
        {
            Log = logger;
            Config = configuration;
            CommandBinding = messageProcessing;
            Vk = vkApi;
            Log.LogInformation("Services Inited");
        }

        public ILogger<BotController> Log { get; }
        public IConfiguration Config { get; }
        public MessageProcessing CommandBinding { get; }
        public IVkApi Vk { get; }

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
            CallbackModel data = JsonConvert.DeserializeObject<CallbackModel>(json.ToString());
            Log.LogInformation($"Callback with data:{data}");
            if (data.Type == "confirmation")
                return Ok(Config["VkApi:Confirmation"]);

            if (data.Type == "message_new")
            {
                Message message = Message.FromJson(new VkResponse(data.Object));
                Log.LogInformation($"Messasge is:{message}");
                Log.LogInformation($"UserID is :{message.PeerId}");
                User user = Vk.Users.Get(new [] { (long)message.PeerId }).First();
                Log.LogInformation($"User is:{user.LastName} {user.FirstName}");
                var responce = CommandBinding.ProcessMessage(Vk,message);
                Vk.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams() { PeerId = message.PeerId,Message = responce,RandomId = new DateTime().Millisecond });             
            }

            return Ok("ok");
        }
        #endregion
    }
}
