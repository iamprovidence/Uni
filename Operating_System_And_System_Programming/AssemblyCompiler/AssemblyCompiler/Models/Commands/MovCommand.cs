using System.Collections.Generic;

namespace AssemblyCompiler.Models.Commands
{
    [Core.Command("MOV")]
    public class MovCommand : Core.CommandBase
    {
        private static readonly string TEMPLATE = "1000 001{0} {1} {2} {3}";

        public MovCommand(IDictionary<string, RegisterInfo> registers)
            : base(registers) { }

        public override string Parse(string line)
        {
            string mod = "11"; // always register

            string[] operands = SplitOperands(line);
            if (operands.Length != 3) throw new System.InvalidOperationException("Wrong operands amount for 'MOV' command");

            IOperand firstOperand = ParseOperand(operands[1]);
            IOperand secondOperand = ParseOperand(operands[2]);

            return string.Format(TEMPLATE, 0, mod, firstOperand.Bits, secondOperand.Bits);
        }
    }
}
