using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    class GoldCard(int credit, decimal discount) : Card(credit)
    {
        public override void Pay(decimal amount)
        {
            var discountAmount = amount / 100M * discount;
            var amountWithDiscountApplied = amount - discountAmount;

            Credit -= 123;

            //base.Pay(amountWithDiscountApplied);
        }
    }
}
