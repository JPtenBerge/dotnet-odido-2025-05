using System.Diagnostics.Metrics;

namespace DelegateDemo
{
    internal class Program
    {
        static string[] products = new string[]
        {
            "Mouse",
            "Phone",
            "Laptop",
            "Glass",
            "Tea",
            "Keyboard",
            "Chord",
            "Lamp"
        };


        static void Main(string[] args)
        {
            //FilterProductsStartingWith("l");

            Predicate<string> firstLetterFilterMethod = delegate (string product)
            {
                Console.WriteLine($"filter method - checking whether {product} begint with L");
                return product.StartsWith("L");
            };
            FilterProducts(firstLetterFilterMethod);
        }

        // this already exists in .NET - .Where()
        static void FilterProducts(Predicate<string> filterMethod)
        {
            foreach (var product in products)
            {
                if (filterMethod.Invoke(product))
                {
                    Console.WriteLine($"Product {product}");
                }
            }
        }


        static void FilterProductsStartingWith(string letter)
        {
            foreach(var product in products)
            {
                if (product.StartsWith(letter, StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine($"Product {product} starts with an {letter}");
                }
            }
        }
    }
}
