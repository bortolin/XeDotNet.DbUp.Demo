using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XeDotNet.BeerShop.Model
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
    }
}
