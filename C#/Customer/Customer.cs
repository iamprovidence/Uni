using System;
using System.Collections.Generic;

/*
 * Customer:order[], promotionalPrograms[]
 * startOrder()(почати нове замовлення),
 * buy(product p, amount)(добавити до цього замовлення), 
 * commitorder (завершити замовлення)
 */

namespace ConsoleApplication
{
    class Customer
    {
        List<OrderLine> stuff;
        List<string> checks;
        List<IPromotionalProgram> discountList;

        public List<IPromotionalProgram> AllDiscount
        {
            get
            {
                if(discountList.Count == 0)
                {
                    return null;
                }
                else
                {
                    return discountList;
                }
            }
        }
        public List<string> GetAllChecks
        {
            get { return checks; }
        }

        Random randomizer;

        public Customer()
        {
            randomizer = new Random();
            stuff = new List<OrderLine>();
            checks = new List<string>();
            discountList = new List<IPromotionalProgram>();
        }

        public void IsNewAction(object o, ActionArg arg)
        {
            if(!discountList.Contains(arg.discount))
            {
                discountList.Add(arg.discount);
            }
        }

        public Customer VisitShop(Shop shop)
        {
            for (int i = 0; i < randomizer.Next(1, 15); ++i)
            {
                shop.SaveOrder(PutInBucket(shop.ShowGoods()));
            }
            stuff.Add(shop.BuyAll());
            return this;
        }

        public Customer VisitMarket(Market market)
        {
            for(int i = 0; i < market.Shops.Length; ++i)
            {
                VisitShop(market.Shops[i]);
            }
            checks = market.GetAChecks(stuff, AllDiscount);
            return this;
        }

        public Order PutInBucket(Product p)
        {
            return new Order(p, randomizer.Next(1, 5));
        }

        public Customer ShowChecks()
        {
            foreach(string check in checks)
            {
                Console.WriteLine(check + Environment.NewLine);
            }
            return this;
        }
    }
}