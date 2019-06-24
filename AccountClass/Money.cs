using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsClass
{
    public class Money
    {
        public double faceValue;
        public Currency currency;
        //-----constructor-----
        public Money() : this(0, Currency.RMB) { }
        public Money(double faceValue) : this(faceValue, Currency.RMB) { }
        public Money(double faceValue, Currency currency)
        {
            this.faceValue = faceValue;
            this.currency = currency;
        }

        //-----overload of the method-----
        public static Money operator +(Money money1, Money money2)
        {
            if (money1.currency != money2.currency)
            {
                //写日志文件的时候需要详细的信息，有利于排查问题
                throw new Exception($"Money1 {money1} is different from money2 {money2}!");
            }
            return new Money(money1.faceValue + money2.faceValue, money1.currency);
        }

        public static Money operator -(Money money1, Money money2)
        {
            if (money1.currency != money2.currency)
            {
                throw new Exception($"Money1 {money1} is different from money2 {money2}!");
            }
            return new Money(money1.faceValue - money2.faceValue, money1.currency);
        }

        public override string ToString()
        {
            string str0 = string.Format("{0:g8}", this.faceValue);
            return $"{str0} {this.currency}";
        }
    }
}
