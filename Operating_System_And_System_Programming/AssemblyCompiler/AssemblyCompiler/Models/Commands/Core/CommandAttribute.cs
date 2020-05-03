using System;

namespace AssemblyCompiler.Models.Commands.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class CommandAttribute : Attribute
    {
        public string CommandId { get; private set; }

        public CommandAttribute(string id)
        {
            this.CommandId = id;
        }
    }
}
