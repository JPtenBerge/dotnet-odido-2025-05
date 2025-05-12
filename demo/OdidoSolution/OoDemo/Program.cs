namespace OoDemo;

internal class Program
{
    static void Main(string[] args)
    {
        var jp = new Human();
        jp.Age = 12345;
        jp.FullName = "qq";


        Console.WriteLine($"JP is {jp.Age} years old");
    }
}
