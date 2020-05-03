namespace AssemblyCompiler.Models
{
    public class RegisterInfo : IOperand
    {
        public string Name { get; private set; }
        public string Index { get; private set; }
        public string Bits { get; private set; }

        public RegisterInfo(string name, string index, string bits)
        {
            Name = name;
            Index = index;
            Bits = bits;
        }
    }
}
