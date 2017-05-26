using DbUp.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XeDotNet.BeerShop.DbUpConsole.Scripts
{
    public class Migration_0004 : IScript
    {
        public string ProvideScript(Func<IDbCommand> dbCommandFactory)
        {
            var script = @"INSERT INTO [dbo].[Beers] VALUES('BINK BLOND','33CL',1.96969696969697)
                           INSERT INTO [dbo].[Beers] VALUES('BINK BRUNE','33CL',1.96969696969697)
                           INSERT INTO [dbo].[Beers] VALUES('BLOESEM','33CL',2.04545454545455)";

            return script;
        }
    }
}
