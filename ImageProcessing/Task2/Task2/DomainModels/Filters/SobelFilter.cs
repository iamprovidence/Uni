namespace Task2.DomainModels.Filters
{
    class SobelFilter : Abstract.OperatorFilterBase
    {
        public override string Name => "Sobel";
        
        protected override int[,] GetHorizontalFilterMatrix()
        {
            return new int[,]
            {
                { +1, +0, -1 },
                { +2, +0, -2 },
                { +1, +0, -1 }
            };
        }

        protected override int[,] GetVerticalFilterMatrix()
        {
            return new int[,]
            {
                { -1, -2, -1 },
                { +0, +0, +0 },
                { +1, +2, +1 }
            };
        }
    }
}
