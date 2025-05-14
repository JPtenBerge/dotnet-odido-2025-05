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

            // inline method - lambda       "arrow function"

            new List<int>().Where(n => n > 20);

            // Predicate must return boolean
            // Func<string,        bool>
            //      ^-- paramater  ^-- return value
            // Predicate<string> == Func<string, bool>
            // Action<string>   

            //Predicate<string> firstLetterFilterMethod = product => product.StartsWith("L");
            FilterProducts(delegate(string p, int n)
            {
                return p.StartsWith("L");
            });

            FilterProducts((p, n) => p.StartsWith("L"));
        }

        delegate bool MyPredicate(string product, int number);

        // this already exists in .NET - .Where()
        static void FilterProducts(MyPredicate filterMethod)
        {
            foreach (var product in products)
            {
                if (filterMethod.Invoke(product, 42))
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
