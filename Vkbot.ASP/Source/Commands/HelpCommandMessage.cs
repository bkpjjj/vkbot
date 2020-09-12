using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Model;

namespace Vkbot.ASP.Source
{
    [BotCommand("/info")]
    [BotCommand("/help")]
    public class HelpCommandMessage : BindingMessage
    {
        public override string Do(IVkApi vkApi,Message message)
        {
            return "Это тестовый бот написаный на C# ASP.NET CORE!";
        }
    }
}
