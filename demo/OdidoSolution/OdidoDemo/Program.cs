using System.Text;

namespace OdidoDemo
{
    public enum HttpStatusCodes
    {
        Unauthenticated,
        NotFound
    }

    public struct Location
    {
        public decimal latitude;
        decimal longitude;
        decimal accuracy;
    }

    public class RefLocation
    {
        public decimal latitude;
    }

    public class Program
    {
        // tuples: Tuple (class reference type) - ValueTuple 

        // [access modifier] [static?] [returnvalue] [name]([parameters])
        public static (int, string) GiveValue() // method        / function
        {
            return (42, "hi there!");
        }


        public static void Main(string[] args) // the startup point of our application
        {
            StringStuff();

            //DateTime

            //int hugeNumber = 887756;
            //string hugeString = "123";
            //byte smallNumber = (byte) hugeString;


            //Console.WriteLine("small number: " + smallNumber);




            //(int thatNumber, string thatString) = GiveValue();

            //Console.WriteLine("give value method call: " + thatNumber);


            // [datatype] [name] = [value];
            //int myNumber = 42;

            //int myOtherNumber = myNumber; // copying its value
            //myOtherNumber = 999;

            string? bla = string.Empty;
            string? bla2 = ""; // reference type
            string? bla4 = null;


            int? optionalInteger = null;
            if (optionalInteger.HasValue)
            {
                //optionalInteger.Value
            }

            optionalInteger = 343;


            //Console.WriteLine("my number: " + myNumber + "/" + myOtherNumber);

            ////myNumber = myNumber * 2;
            //RefLocation myLocation = new RefLocation { latitude = 12.34M };
            //RefLocation myOtherLocation = myLocation; // copying the memory address
            //myOtherLocation.latitude = 99.9M;
            //Console.WriteLine("myloc: " + myLocation.latitude + "/" + myOtherLocation.latitude);


            //HttpStatusCodes myStatusCode = HttpStatusCodes.Unauthenticated;

            //string myText = "qwertyu";

            //float first = 0.3f;
            //float second = 0.2f;
            //float result = first - second;

            //char uni = 'q';

            //Console.WriteLine("Floating errors: " + uni);
        }

        public static void AboutVar()
        {
            int someNumber = 42;
            string someText = "something";

            var something = GiveMoreValue();

            //var customers;

            // low-level outside-of-.NET objects that don't have typical interfaces
            // - COM objects
            // - REFLECTION  <== necessary evil

            //dynamic bla = null;
            //bla.DoWhatever(14, 28, "hi", "whaaat");
        }

        public static int GiveMoreValue()
        {
            return 42;
        }

        public static void StringStuff()
        {
            var text = "my text here ❌👀✅🛫⚠️🍗⚡";
            text += "whatever";


            Console.WriteLine(text.EndsWith("here"));
            Console.WriteLine(text.StartsWith("here"));

            Console.WriteLine("text: " + text + " qq");
            Console.WriteLine($"text: {text}"); // string interpolation
            Console.WriteLine(@"c:\users\adminsitrator");
            Console.WriteLine($@"c:\users\adminsitrator {text}");

            //Console.WriteLine($"""
            //    Hi there!

            //    This is multiline {text}
            //    """);

            Console.WriteLine("Length: " + text.Length);
            Console.WriteLine("Count: " + text.Count());

            foreach (var character in text)
            {
                Console.WriteLine($"char: {character}");
            }
            Console.WriteLine($"char #12: {text[3]}");

            var price = 123.456789;
            Console.WriteLine(price.ToString("N2"));



            //const int MaxRegions = 5;
            //const string CompanyName = "TeleCo";

            //MaxRegions = 278443;


        }
    }
}

