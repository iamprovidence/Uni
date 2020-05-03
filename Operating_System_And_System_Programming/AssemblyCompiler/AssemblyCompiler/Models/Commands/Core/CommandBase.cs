using System.Collections.Generic;

namespace AssemblyCompiler.Models.Commands.Core
{
    public abstract class CommandBase
    {
        protected readonly IDictionary<string, RegisterInfo> registers;

        public CommandBase(IDictionary<string, RegisterInfo> registers)
        {
            this.registers = registers;
        }

        protected string[] SplitOperands(string line)
        {
            return line.Split(new char[] { ' ', ',' }, System.StringSplitOptions.RemoveEmptyEntries);
        }

        public abstract string Parse(string line);

        public IOperand ParseOperand(string operand)
        {
            string operandUpper = operand.ToUpper();
            if (registers.ContainsKey(operandUpper)) return registers[operandUpper];

            return new NumericOperand(operand);
        }
    }
}
