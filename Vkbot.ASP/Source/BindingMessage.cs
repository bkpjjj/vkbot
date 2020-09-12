using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Model;

namespace Vkbot.ASP.Source
{
    public abstract class BindingMessage
    {
        public static BindingMessage Default { get; set; } = new DefaultMessage();
        public abstract string Do(IVkApi vkApi,Message message);
    }
}
