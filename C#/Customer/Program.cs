using System;

namespace ConsoleApplication
{
    /*
     * фірма продає товар
     * замовник робить якесь замовлення, купує декілька продуктів.
     * кожний покупець може бути учасником декількох програм знижок або жодної
     * загальна знижка рахується, як найбільша знижка, яку можна отримати з програм
     * змоделювати декілька замовлень покупця і вивести чеки для кожного замовлення
     */
    class MainEntryPoint
    {
        static void Main()
        {
            const int AMOUNT_OF_CUSTOMER = 4;
            Customer[] arrCustomer = new Customer[AMOUNT_OF_CUSTOMER];
            for (int i = 0; i < AMOUNT_OF_CUSTOMER; ++i) 
            {
                arrCustomer[i] = new Customer();
            }
            Market market = new Market(10);





            Console.WriteLine("1 CUSTOMER WITH NO ACTION" + Environment.NewLine);
            arrCustomer[0].VisitMarket(market).ShowChecks();
            Console.ReadKey();
            Console.Clear();




            Console.WriteLine("2 CUSTOMER WITH ACTION AND NO ACTION" + Environment.NewLine);
            market.Action += arrCustomer[1].IsNewAction;
            market.Action += arrCustomer[2].IsNewAction;
            market.StartAction(1).ContinueAction();
            arrCustomer[1].VisitMarket(market).ShowChecks();
            Console.ReadKey();
            Console.Clear();

            arrCustomer[2].VisitMarket(market).ShowChecks();
            market.Action -= arrCustomer[1].IsNewAction;
            market.Action -= arrCustomer[2].IsNewAction;
            Console.ReadKey();
            Console.Clear();




            Console.WriteLine("1 CUSTOMER WITH ALL KIND OF ACTION" + Environment.NewLine);
            market.Action += arrCustomer[3].IsNewAction;
            market.StartAction(10);
            for(int i = 0; i < 10; ++i)
            {
                market.ContinueAction();
            }
            arrCustomer[3].VisitMarket(market).ShowChecks();
            market.Action -= arrCustomer[3].IsNewAction;
            Console.ReadKey();
        }
    }
}