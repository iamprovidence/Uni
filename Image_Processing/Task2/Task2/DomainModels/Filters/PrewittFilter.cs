namespace Task2.DomainModels.Filters
{
    class PrewittFilter : Abstract.OperatorFilterBase
    {
        public override string Name => "Prewitt";

        protected override int[,] GetHorizontalFilterMatrix()
        {
            return new int[,]
            {
                { +1, +0, -1 },
                { +1, +0, -1 },
                { +1, +0, -1 }
            };
        }

        protected override int[,] GetVerticalFilterMatrix()
        {
            return new int[,]
            {
                { -1, -1, -1 },
                { +0, +0, +0 },
                { +1, +1, +1 }
            };
        }
    }
}
