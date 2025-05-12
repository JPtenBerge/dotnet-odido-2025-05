using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoDemo;

class Human
{
    private int _age; // stores the actual value "backing field"
    public int MyProperty { get; set; }

    private string _firstName = "JP";
    private string _surname = "tB";

    // => delegate  "arrow function"

    public string FullName => $"{_firstName} {_surname}";

    //public string FullName
    //{
    //    get
    //    {
    //        return $"{_firstName} {_surname}";
    //    }
    //}


    public int Age
    {
        get { return _age; }
        set
        {
            if (value > 150)
            {
                throw new ArgumentException("value");
            }

            _age = value;
        }
    }


    //public int GetAge()
    //{
    //    return _age;
    //}

    //public void SetAge(int newAge)
    //{
    //    if (newAge > 150)
    //    {
    //        throw new ArgumentException("newAge");
    //    }

    //    _age = newAge;
    //}
}
