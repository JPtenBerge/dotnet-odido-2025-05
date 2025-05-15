using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


// reflection


//var types = Assembly.GetExecutingAssembly().GetTypes();
//foreach (var type in types)
//{
//    type.GetMethods().First().Invoke();
//}


namespace Shared.Entities
{
    //[InternalsVisibleTo("GenericDemo.dll")]
    internal class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}

namespace Shared.Blabla
{
    internal class Product
    {
        public decimal Price { get; set; }
    }
}