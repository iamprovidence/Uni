namespace Task2.DomainModels.Filters
{
    class RobertsFilter : Abstract.OperatorFilterBase
    {
        public override string Name => "Roberts";
        
        protected override int[,] GetHorizontalFilterMatrix()
        {
            return new int[,]
            {
                { +0, -1 },
                { +1, -0 }
            };
        }

        protected override int[,] GetVerticalFilterMatrix()
        {
            return new int[,]
            {
                { -1, +0 },
                { +0, +1 }
            };
        }
    }
}
