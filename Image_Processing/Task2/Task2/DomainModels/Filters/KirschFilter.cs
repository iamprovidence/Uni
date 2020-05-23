namespace Task2.DomainModels.Filters
{
    class KirschFilter : Abstract.OperatorFilterBase
    {
        public override string Name => "Kirsch";

        protected override int[,] GetHorizontalFilterMatrix()
        {
            return new int[,]
            { 
                { +5, +5, +5 },
                { -3, +0, -3 },
                { -3, -3, -3 },
            };
        }

        protected override int[,] GetVerticalFilterMatrix()
        {
            return new int[,]
            { 
                { +5, -3, -3 },
                { +5, +0, -3 },
                { +5, -3, -3 },
            };
        }
    }
}
