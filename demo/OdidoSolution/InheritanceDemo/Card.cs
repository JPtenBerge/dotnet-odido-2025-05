using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    class Card(int credit)
    {
        public int Credit { get; protected set; } = credit;

        public virtual void Pay(decimal amount)
        {
            // C#   banker's rounding
            Credit -= Convert.ToInt32(amount);
        }
    }
}
