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
                optionalInteger.Value
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
    }
}

