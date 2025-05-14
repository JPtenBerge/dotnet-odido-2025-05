using System.Collections;

namespace GenericDemo;

internal class Program
{
    static void Main(string[] args)
    {
        // array: iterable   fixed-size
        //var myArray = new int[4];
        //myArray[14] = 34;


        //List<int> // array
        //LinkedList<int>

        // before generics
        //var list = new ArrayList(); // please don't use this
        //list.Add(4);
        //list.Add(8);
        //list.Add(15);
        //list.Add(16);
        //list.Add("qwertyui");

        //foreach (var item in list)
        //{
        //    var number = (int)item;
        //    Console.WriteLine(number * 4);
        //}

        // with generics
        new List<string>();
        new List<bool>();
        new List<Program>();
        new List<List<int>>();


        //new Dictionary<int, Game>


        var genericList = new List<int>();
        genericList.Add(4);
        genericList.Add(8);
        genericList.Add(15);
        genericList.Add(16);
        //genericList.Add("qwertyui");

        foreach (var item in genericList)
        {
            Console.WriteLine(item * 4);
        }


        var myList = new MyList<int, short>();

        var myList2 = new MyList<string, short>();

        //var myList3 = new MyList<Program, short>();
        //myList.Set();
    }
}
