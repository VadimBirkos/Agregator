using System.Collections.Generic;
using CommonInterface; 
namespace Testing
{
    class Program
    {
        static void DisplayInExcel(IEnumerable<MenuItem> items)
        {
          
        }

        static void Main(string[] args)
        { 
            var list = new List<MenuItem>()
            {
                new MenuItem("Relax", "relax.by"),
                new MenuItem("onliner", "Onliner.by"),
                new MenuItem("Виктория", "victoria.by")
            };

        }
}
}
