using AssemblyCompiler.Models.Commands.Core;

using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace AssemblyCompiler.Models
{
    public class VirtualMachine
    {
        private readonly IDictionary<string, CommandBase> commands;

        public VirtualMachine()
        {
            IDictionary<string, RegisterInfo> registers = InitializeRegisters();
            this.commands = LoadCommands(typeof(CommandBase).Assembly, registers);
        }

        private IDictionary<string, RegisterInfo> InitializeRegisters()
        {
            return new[]
            {
                new RegisterInfo ("AL", "0", "000"), new RegisterInfo ("AX", "1", "000"),
                new RegisterInfo ("CL", "0", "001"), new RegisterInfo ("CX", "1", "001"),
                new RegisterInfo ("DL", "0", "010"), new RegisterInfo ("DX", "1", "010"),
                new RegisterInfo ("BL", "0", "011"), new RegisterInfo ("BX", "1", "011"),

                new RegisterInfo ("AH", "0", "100"), new RegisterInfo ("SP", "1", "100"),
                new RegisterInfo ("CH", "0", "101"), new RegisterInfo ("BP", "1", "101"),
                new RegisterInfo ("DH", "0", "110"), new RegisterInfo ("SI", "1", "110"),
                new RegisterInfo ("BH", "0", "111"), new RegisterInfo ("DI", "1", "111"),
            }
            .ToDictionary(k => k.Name.ToUpper(), v => v);
        }

        private IDictionary<string, CommandBase> LoadCommands(Assembly assembly, IDictionary<string, RegisterInfo> registers)
        {
            return (
                from t in assembly.GetTypes()
                let attributes = t.GetCustomAttributes(typeof(CommandAttribute), inherit: true)
                where attributes != null && attributes.Length > 0
                select new { Attribute = attributes.Cast<CommandAttribute>().Single(), Type = t })
                .ToDictionary(
                    k => k.Attribute.CommandId.ToUpper(), 
                    v => Activator.CreateInstance(v.Type, new object[] { registers }) as CommandBase);
        }

        public string[] Translate(string[] lines)
        {
            return lines.Select(TryTranslateLine).ToArray();
        }

        private string TryTranslateLine(string line, int index)
        {
            string normallizedLine = line.Trim();
            string commandName = GetCommandName(normallizedLine);

            if (!commands.ContainsKey(commandName)) throw new InvalidOperationException($"Current command ({commandName}) is not supported");

            try
            {
                return commands[commandName].Parse(line);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error at line {index + 1}", ex);
            }
        }

        private string GetCommandName(string line)
        {
            return line.Split().First().ToUpper();
        }
    }
}
