using DbUp;
using DbUp.Engine.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using log4net.Layout;
using log4net.Appender;

namespace XeDotNet.BeerShop.DbUpConsole
{
    class Program
    {
        

        static int Main(string[] args)
        {

            var connectionString = "Server=.\\SQL2016;Database=BeerShop;Trusted_Connection=True;";

            //Create database if not exist
            EnsureDatabase.For.SqlDatabase(connectionString);

            //Configure DbUp
            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()      
                    .Build();

            //Test if database need to be upgraded
            if (!upgrader.IsUpgradeRequired())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Database already updated");
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return 0;
            }

            //Perform database upgrade
            var result = upgrader.PerformUpgrade();

            //Verify errors
            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            //Database OK
            #region Success

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();

#if DEBUG
            Console.ReadLine();
#endif
            return 0;
            #endregion

        }

    }

    //public class MyLogger : IUpgradeLog
    //{

    //    private static readonly ILog log = LogManager.GetLogger(typeof(MyLogger));

    //    public MyLogger()
    //    {
    //        var layout = new PatternLayout("%-4timestamp [%thread] %-5level %logger %ndc - %message%newline");
    //        var appender = new RollingFileAppender
    //        {
    //            File = "DbUpMigration.log",
    //            Layout = layout
    //        };
    //        layout.ActivateOptions();
    //        appender.ActivateOptions();
    //        BasicConfigurator.Configure(appender);
    //    }

    //    public void WriteError(string format, params object[] args)
    //    {
    //        log.ErrorFormat(format,args);
    //    }

    //    public void WriteInformation(string format, params object[] args)
    //    {
    //        log.InfoFormat(format,args);
    //    }

    //    public void WriteWarning(string format, params object[] args)
    //    {
    //        log.WarnFormat(format, args);
    //    }
    //}

    //public class MyProcessor : DbUp.Engine.IScriptPreprocessor
    //{
    //    public string Process(string contents)
    //    {
    //        return contents.Insert(0, "SET LANGUAGE us_english;");
    //    }
    //}

}
