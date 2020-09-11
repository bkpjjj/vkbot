using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VkNet.Model;

namespace Vkbot.ASP.Source
{
    public class DefaultMessage : BindingMessage
    {
        public override string Do(Message message)
        {
            return "Да";
        }
    }
}
