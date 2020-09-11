using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VkNet.Model;

namespace Vkbot.ASP.Source
{
    public class MessageProcessing
    {
        private Dictionary<string,BindingMessage> bindings;

        public MessageProcessing()
        {
            bindings = new Dictionary<string, BindingMessage>();
        }

        public void AddBinding(string command,BindingMessage message)
        {
            if(!bindings.ContainsKey(command))
                bindings.Add(command, message);
        }

        public string ProcessMessage(Message message)
        {
            bindings.TryGetValue(message.Text,out BindingMessage bind);

            return (bind ?? BindingMessage.Default).Do(message);
        }
    }
}
