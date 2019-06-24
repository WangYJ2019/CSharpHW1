using System;

namespace AccountsClass
{
    public class AccountItem
    {
        public Category category;

        public string Name
        {
            get;
        }
        public Money Amount
        {
            get; set;
        }
        public DateTime OccurTime
        {
            get;
        }
        //=====Content and Note=====
        public string Content
        {
            get; set;
        }
        public string Note
        {
            get; set;
        }

        //===== constructor =====
        public AccountItem(string name, string category, Money amount) : this(name, ConvertStringToCategory(category), amount, "Content...", "Note...", DateTime.Now) { }
        public AccountItem(string name, string category, Money amount, DateTime occurTime) : this(name, ConvertStringToCategory(category), amount, "Content...", "Note...", occurTime) { }

        public AccountItem(string name, Category category, Money amount) : this(name, category, amount, "Content...", "Note...", DateTime.Now) { }
        public AccountItem(string name, Category category, Money amount, DateTime occurTime) : this(name, category, amount, "Content...", "Note...", occurTime) { }
        public AccountItem(string name, Category category, Money amount, string content, string note, DateTime occurTime)
        {
            this.Name = name;
            this.Amount = amount;
            this.category = category;
            this.OccurTime = occurTime;
            this.Content = content;
            this.Note = note;
        }
        //---override method ToString()---
        public override string ToString()
        {
            return $"{Name} || {category} - {Amount.ToString()} || {Content} | {Note} || {OccurTime.ToShortDateString()}";
        }

        //----Revise 20190621----
        public bool IsIncome()
        {
            return this.category == Category.Income;
        }
        public bool IsSpending()
        {
            return this.category == Category.Spending;
        }
        public bool IsSameMonthOfSameYear(DateTime target)
        {
            return this.OccurTime.Month == target.Month && this.OccurTime.Year == target.Year;
        }

        public static Category ConvertStringToCategory(string str)
        {
            if ( "INCOME".Equals(str.ToUpper()) ) return Category.Income;
            if ( "SPENDING".Equals(str.ToUpper()) ) return Category.Spending;
            throw new Exception("Input string error!");
        }
    }
}
