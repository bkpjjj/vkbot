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
            //long[] users = { (long)message.UserId };
            //User user = vkApi.Users.Get( users ).First();
            

            return $"Да. {message.Text}";
        }
    }
}
