using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class ActionArg: EventArgs
    {
        public int discountLeft { get; private set; }
        public IPromotionalProgram discount { get; private set; }

        public ActionArg(int discountLeft, IPromotionalProgram pr)
        {
            this.discountLeft = discountLeft;
            discount = pr;
        }
    }
    public class Shop
    {
        Random randomizer;

        static int number;
        string name;
        OrderLine formAnOrder;
        int goodsAmount;
        Product[] goods;

        static Shop()
        {
            number = 0;
        }

        public Shop()
        {
            name = "Shop" + number;
            ++number;

            string[] goodsName = { "milk", "cheese", "bread", "water", "oil", "drug", "pizza", "fruit", "vegetable", "flower", "ice", "lemon"};
            randomizer = new Random();
            goodsAmount = randomizer.Next(2, 15);
            goods = new Product[goodsAmount];
            for(int i = 0; i < goodsAmount; ++i)
            {
                goods[i] = new Product(goodsName[randomizer.Next(0, goodsName.Length)], randomizer.Next(4,125));
            }

            formAnOrder = new OrderLine();
        }
        public Product ShowGoods()
        {
            return goods[randomizer.Next(0, goodsAmount)];
        }
        public void SaveOrder(Order order)
        {
            formAnOrder.Order = order;
        }
        public OrderLine BuyAll()
        {
            return formAnOrder;
        }
    }
    public class Market
    {
        Shop[] arrShop;
        IPromotionalProgram[] arrProgram;
        int discountAmount;
        bool isActionGoing;
        Random rand;

        public Shop[] Shops{get {return arrShop;} }

        public Market(int amountOfShop)
        {
            isActionGoing = false;
            discountAmount = 0;
            arrShop = new Shop[amountOfShop];
            for(int i = 0; i < amountOfShop; ++i)
            {
                arrShop[i] = new Shop();
            }
            //arrProgram = new IPromotionalProgram[3] {new EveryFifth(), new TotalSumDiscount(), new ExpensiveProductDiscount() };
            arrProgram = GetPromotionalProgram.arrProgram;
            rand = new Random();
        }

        public List<string> GetAChecks(List<OrderLine> stuff, List<IPromotionalProgram> discount = null)
        {
            List<string> checks = new List<string>();
            for (int i = 0; i < stuff.Count; ++i)
            {
                checks.Add(stuff[i].printCheck(discount));
            }
            return checks;
        }

        public event EventHandler<ActionArg> Action;

        public Market StartAction(int discountAmount)
        {
            if (!isActionGoing)
            {
                this.discountAmount = discountAmount;
                isActionGoing = true;
            }
            else
            {
                this.discountAmount += discountAmount;
            }
            return this;
        }
        public Market ContinueAction()
        {
            if(isActionGoing)
            {
                int followers = Action.GetInvocationList().Length;
                discountAmount -= followers;
                if (discountAmount >= 0)
                {
                    Action?.Invoke(this, new ActionArg(this.discountAmount, arrProgram[rand.Next(0, arrProgram.Length)]));
                }
                else
                {
                    // дати акційні знижки тільки тим хто підписався першим
                    Delegate[] arr = Action.GetInvocationList();
                    for (int i = 0; i < followers + this.discountAmount; ++i) 
                    {
                       (( EventHandler<ActionArg> )arr[i])(this, new ActionArg(this.discountAmount, arrProgram[rand.Next(0, arrProgram.Length)]));
                    }
                    discountAmount = 0;
                    isActionGoing = false;
                }
            }
            return this;
        }
        public Market CloseAction()
        {
            discountAmount = 0;
            isActionGoing = false;
            return this;
        }
    }
}