namespace Task2.DomainModels.Filters
{
    class LaplacianFilter : Abstract.OperatorFilterBase
    {
        public override string Name => "Laplacian";

        protected override int[,] GetHorizontalFilterMatrix()
        {
            return new int[,]
            { 
                { -1, -1, -1 },
                { -1, +8, -1 },
                { -1, -1, -1 },
            };
        }

        protected override int[,] GetVerticalFilterMatrix()
        {
            return new int[,]
            { 
                { -1, -1, -1 },
                { -1, +8, -1 },
                { -1, -1, -1 },
            };
        }
    }
}
