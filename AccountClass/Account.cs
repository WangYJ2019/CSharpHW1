using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsClass
{
    public class Account
    {
        private List<AccountItem> accountItemList = new List<AccountItem>();
        
        public void AddAccountItem(AccountItem accountItem) //修改为Add，名称不需要
        {
            if (accountItem != null) accountItemList.Add(accountItem);       //if 允许输入null，进行判断--公有的方法，别人
        }
        public bool RemoveAccountItem(string name, Category category)
        {
            foreach (var accountItem in accountItemList)
            {
                if ( accountItem.Name.Equals(name) && accountItem.category == category) 
                {
                    accountItemList.Remove(accountItem);       //if 允许输入null，进行判断--公有的方法，别人
                    return true;
                }
            }
            return false;
        }
        //==================================================
        //----- Income and Expenditure -----
        public Money TotalExpenditure(DateTime time)
        {
            Money money=new Money(0.0);
            foreach (var accountItem in accountItemList)
            {
                if (accountItem.IsSpending() && accountItem.IsSameMonthOfSameYear(time) )
                //比较月份信息，要有年、月和类别信息; 利用函数，重复代码能够规避一定要规避。
                {
                    money = accountItem.Amount + money;
                }
            }
            return money;
        }

        public Money TotalIncome(DateTime time)
        {
            Money money = new Money(0.0);
            foreach (var accountItem in accountItemList)
            {
                if (accountItem.IsIncome() && accountItem.IsSameMonthOfSameYear(time))
                {
                    money = accountItem.Amount + money;
                }
            }
            return money;
        }

        public Money TotalRevenue(DateTime time)
        {
            return TotalIncome(time) - TotalExpenditure(time);
        }
        //----- using delegation method -----
        public Money TotalIncome2(DateTime time)
        {
            return Calculate(time, Category.Income, Matches);
        }
        public Money TotalExpenditure2(DateTime time)
        {
            return Calculate(time, Category.Spending, Matches);
        }
        public Money TotalRevenue2(DateTime time)
        {
            return TotalIncome2(time) - TotalExpenditure2(time);
        }
        //==================================================
        //----- IEnumerable Display-----
        public IEnumerable<AccountItem> Display(DateTime time)
        {
            foreach (var accountItem in accountItemList)
            {
                if (accountItem.IsSameMonthOfSameYear(time))
                {
                    yield return accountItem;
                }
            }
        }
        //==================================================
        public Money Calculate(DateTime dateTime, Category category, Matches matches) //Filter => Match
        {
            Money money = new Money(0);
            foreach (var accountItem in this.accountItemList)
            {
                if ( matches.Invoke(accountItem, dateTime, category) )
                {
                    money = accountItem.Amount + money;
                }
            }
            return money;
        }
        //---------------------------
        // Matches 能否用 Predicate 函数来完成？
        public static bool Matches(AccountItem accountItem,DateTime dateTime, Category category)
        {
            return accountItem.IsSameMonthOfSameYear(dateTime)
                && accountItem.category == category;
        }
    }
    public delegate bool Matches(AccountItem accountItem, DateTime dateTime, Category category);

}
