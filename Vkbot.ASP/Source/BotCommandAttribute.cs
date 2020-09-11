using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vkbot.ASP.Source
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    sealed class BotCommandAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string command;

        // This is a positional argument
        public BotCommandAttribute(string command)
        {
            this.command = command;
        }

        public string CommandString
        {
            get { return command; }
        }

        // This is a named argument
        public int NamedInt { get; set; }
    }
}
