using DbUp.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using XeDotNet.BeerShop.Model;

namespace XeDotNet.BeerShop.DbUpConsole.Scripts
{
    public class Migration_0005 : IScript
    {
        public string ProvideScript(Func<IDbCommand> dbCommandFactory)
        {
            var cnn = dbCommandFactory().Connection;

            for (int i = 0; i < 100; i++)
            {
                var beer = new Beer()
                {
                    Name = "Beer " + i.ToString(),
                    Size = i.ToString() + "CL",
                    Price = i
                };

                cnn.Insert<Beer>(beer);
            }

            return "PRINT 'Migration_0005 - OK'";
        }
    }
}
