using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo;

sealed class RegularCard(int credit) : Card(credit)
{
    public override void Pay(decimal amount)
    {
        Console.WriteLine($"Card credit before payment: {Credit}");

        // C#   banker's rounding
        Credit -= Convert.ToInt32(amount);

        Console.WriteLine($"Card credit after payment: {Credit}");
    }
}

// at least 1 class that is sealed
// - String
//class MyOwnString : String
//{
//}
