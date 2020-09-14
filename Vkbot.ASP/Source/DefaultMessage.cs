using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Model;

namespace Vkbot.ASP.Source
{
    public class DefaultMessage : BindingMessage
    {
        public override string Do(IVkApi vkApi,Message message)
        {
            if (message.PeerId == 302383860)
                return message.Text.Replace("Кирилл","Артур",true, null);
            return $"Да. {message.Text}";
        }
    }
}
