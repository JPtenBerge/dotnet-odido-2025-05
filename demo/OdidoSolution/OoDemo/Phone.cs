using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OoDemo;

// Shift+F2

class Phone
{
    public string Brand { get; init; }
    public string Type { get; set; }
    public decimal Dimensions { get; set; } = 65M;

    // generated if you don't include a constructor yourself
    //Phone() { }

    // constructor overloading
    internal Phone(string brand, string type)
    {
        Brand = brand;
        Type = type;
    }

    internal Phone(string brand, string type, decimal dimensions) : this(brand, type)
    {
        Dimensions = dimensions;
    }
}
