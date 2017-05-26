using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using XeDotNet.BeerShop.Model;

namespace XeDotNet.BeerShop.WebApp.DataAccess
{
    public class BeerDatabase:DbContext
    {

        public BeerDatabase(string connection):base(connection)
        {
            
        }

        public DbSet<Beer> Beers { get; set; }

    }

}
