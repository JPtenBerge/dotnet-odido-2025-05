using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    abstract class Card(int credit)
    {
        public int Credit { get; protected set; } = credit;

        public abstract void Pay(decimal amount);

        public virtual void OtherMethodThatCanAlsoBeOverriden()
        {

        }
    }
}
