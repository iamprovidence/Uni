namespace AssemblyCompiler.Models
{
    public class NumericOperand : IOperand
    {
        public string Index => "1";

        public string Bits { get; private set; }

        public NumericOperand(string operand)
        {
            int value;
            try
            {
                value = int.Parse(operand);
            }
            catch (System.FormatException)
            {
                throw new System.InvalidCastException($"Can not convert '{operand}' to number");
            }

            Bits = System.Convert.ToString(value, 2);
        }
    }
}
