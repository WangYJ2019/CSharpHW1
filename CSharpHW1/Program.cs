using System;
using AccountsClass;
using AccountsClass.Extension;

namespace AccountMain
{
    class Program
    {
        static void Main(string[] args)
        {
            //=====
            //DateTime dt1 = DateTime.Now;
            //DateTime dt2 = new DateTime(2019,06,18,7,10,0);
            //Console.WriteLine(dt1.ToString());
            //Console.WriteLine(dt2.ToString());
            //DateTime dt3 = Convert.ToDateTime("2017-7-14 1:12:16");

            //Console.WriteLine(dt3.ToShortDateString().ToString());
            //Console.WriteLine(dt3.ToLongDateString().ToString());
            //Console.WriteLine(dt3.ToShortTimeString().ToString());
            //Console.WriteLine(dt3.ToLongTimeString().ToString());
            Account a1 = new Account();

            for (int i = 0; i < 8; i++)
            {
                AccountItem accountItemTmp = new AccountItem($"Income{i}", Category.Income, new Money(100));
                AccountItem accountItemTmp2 = new AccountItem($"Expend{i}", Category.Spending, new Money(Math.Exp(i)));
                //Console.WriteLine(accountItemTmp.ToString());
                //Console.WriteLine(accountItemTmp2.ToString());
                a1.AddAccountItem(accountItemTmp);
                a1.AddAccountItem(accountItemTmp2);
            }
            DateTime time0 = new DateTime(2019, 06, 18);
            Money aIncome = a1.TotalIncome(time0);
            Money aExpend = a1.TotalExpenditure(time0);
            Money aRevenue = a1.TotalRevenue(time0);

            Console.WriteLine($"Income is {aIncome.ToString()}");
            Console.WriteLine($"Expenditure is {aExpend.ToString()}");
            Console.WriteLine($"Total Revenue is {aRevenue.ToString()}");

            foreach (var a in a1.Display(time0))
            {
                Console.WriteLine(a.ToString());
            }

            Console.WriteLine($"===================================");

            Money aIncome2 = a1.TotalIncome2(time0);
            Money aExpend2 = a1.TotalExpenditure2(time0);

            Console.WriteLine($"Income is {aIncome2.ToString()}");
            Console.WriteLine($"Expenditure is {aExpend2.ToString()}");

        }
    }
}
