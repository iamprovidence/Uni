using System.Collections.Generic;
using System.Text;
/*
 * Product:title, price
 * Order:product, Amount
 * OrderLine:list<>OrderLinem printCheck
 */

/*
 * чек:
 *  продукт: кількість: ціна:
 *  продукт: кількість: ціна:
 *  . . . . . . . . . . . . .
 *  загальна ціна:
 *  Знижка: розмір знижки, назва знижки
 *  priceToPay: ціна із знижкою
 */
namespace ConsoleApplication
{
    public struct Product
    {
        public string title { get; private set; }
        public int price { get; private set; }

        public Product(string t, int p)
        {
            title = t;
            price = p;
        }
    }
    public struct Order
    {
        public Product product { get; private set; }
        public int amount { get; private set; }

        public Order(Product p, int a)
        {
            product = p;
            amount = a;
        }
        public override string ToString()
        {
            return string.Format("Product {0}, amount {1}, price {2}", product.title, amount, product.price);
        }
    }
    public class OrderLine
    {
        private List<Order> line;

        public Order Order { set { line.Add(value); } }
        public List<Order> Line { get { return line; } }

        public OrderLine()
        {
            line = new List<Order>();
        }

        public string printCheck(List<IPromotionalProgram> discount = null)
        {
            int totalSum = 0;
            StringBuilder check = new StringBuilder("Check\n");

            for(int i = 0; i < line.Count; ++i)
            {
                check.AppendLine(line[i].ToString());
                totalSum += line[i].product.price * line[i].amount;
            }
            check.AppendFormat("Total price {0}", totalSum);

            if(discount != null)
            {
                int indexOfHigherDiscount = 0;
                int discountSum = discount[indexOfHigherDiscount].CalculateDiscount(this);
                for (int i = 1; i < discount.Count; ++i) 
                {
                    int discountInThisIteration = discount[i].CalculateDiscount(this);
                    if (discountSum < discountInThisIteration)
                    {
                        discountSum = discountInThisIteration;
                        indexOfHigherDiscount = i;
                    }
                }
                check.AppendFormat("\nDiscount: {1}, {0}\n", discountSum , discount[indexOfHigherDiscount].GetType().Name);
                check.AppendFormat("Price: {0}", totalSum - discountSum);
            }

            return check.ToString();
        }
    }
}