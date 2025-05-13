namespace OoDemo;

internal class Program
{
    static void Main(string[] args)
    {
        var jp = new Human();
        jp.Age = 35;
        //jp.FullName = "qq";

        Console.WriteLine($"JP is {jp.Age} years old");

        var myPhone = new Phone("OnePlus", "11");
        //myPhone.Dimensions = 6.5M;

        var myPhone2 = new Phone(type: "11", brand: "OnePlus")
        {
            Dimensions = 6.5M
        };
        //myPhone2.Brand = "qqq";

        var myPhone3 = new Phone(type: "11", brand: "OnePlus", dimensions: 6.5M);
        //myPhone3.TurnOn();
        //myPhone3.battery.GetRemainingLife();
            

        Console.WriteLine($"brand: {myPhone3.Brand}");


        //new PhoneBla().

    }



}
