/*     
 * Ipromotionalprogram: calculateDiscount(order o) double
 *  *EveryFifth: percent
 *  *TotalSum: > num
 *  *DiscountonExpensiveProduct: > 1000grn знижка на один товар
 */
namespace ConsoleApplication
{
    public interface IPromotionalProgram
    {
        int CalculateDiscount(OrderLine order);
    }
    public class EveryFifth : IPromotionalProgram
    {
        public int CalculateDiscount(OrderLine order)
        {
            int discount = 0;
            for (int i = 0; i < order.Line.Count; ++i)
            {
                discount += (order.Line[i].product.price * 5) / 100;
            }
            return discount;
        }
    }
    public class TotalSumDiscount : IPromotionalProgram
    {
        public int CalculateDiscount(OrderLine order)
        {
            int averageSum = 0;
            for (int i = 0; i < order.Line.Count; ++i)
            {
                averageSum += order.Line[i].product.price;
            }
            averageSum /= order.Line.Count;
            return (averageSum * 15) / 100;
        }
    }
    public class ExpensiveProductDiscount : IPromotionalProgram
    {
        public int CalculateDiscount(OrderLine order)
        {
            int maxIndex = 0;
            for (int i = 1; i < order.Line.Count; ++i)
            {
                if(order.Line[maxIndex].product.price < order.Line[i].product.price)
                {
                    maxIndex = i;
                }
            }
            return (order.Line[maxIndex].product.price * 30) / 100;
        }
    }
    public class AmountOfBought : IPromotionalProgram
    {
        public int CalculateDiscount(OrderLine order)
        {
            int discount = 0;
            for (int i = 0; i < order.Line.Count; ++i)
            {
                discount += order.Line[i].amount;
            }
            return discount - 5;
        }
    }
    public static class GetPromotionalProgram
    {
        public static IPromotionalProgram[] arrProgram { get; private set; }
        public enum Name{ EveryFifth, TotalSumDiscount, ExpensiveProductDiscount, AmountOfBought }

        static GetPromotionalProgram()
        {
            arrProgram = new IPromotionalProgram[]
            {
                new EveryFifth(),
                new TotalSumDiscount(),
                new ExpensiveProductDiscount(),
                new AmountOfBought()
            };
        }
    }
}