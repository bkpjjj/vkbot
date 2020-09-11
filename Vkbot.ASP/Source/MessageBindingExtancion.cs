using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Vkbot.ASP.Source
{
    public static class MessageBindingExtancion
    {
        public static IApplicationBuilder UseCommandBinding(this IApplicationBuilder app)
        {
            var mp = app.ApplicationServices.GetService(typeof(MessageProcessing)) as MessageProcessing;
            var commandClasses = Assembly.GetExecutingAssembly().ExportedTypes.Where(x => x.IsClass && x.BaseType == typeof(BindingMessage));

            foreach (Type @class in commandClasses)
            {
                var atrs = @class.GetCustomAttributes<BotCommandAttribute>();

                if(atrs.Count() > 0)
                {
                    foreach (var atr in atrs)
                    {
                        BindingMessage msg = Activator.CreateInstance(@class) as BindingMessage;
                        mp.AddBinding(atr.CommandString, msg);
                    }
                }
            }

            return app;
        }
    }
}
