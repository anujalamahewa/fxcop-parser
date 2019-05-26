using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace FxCopParser
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                if (args.Length != 1)
                {
                    Console.WriteLine("FxCop xml not found!");
                    Environment.Exit(1);
                }

                var results = new Result
                {
                    FileName = args[0],
                    ItemList = new List<ResultItem>(),
                    Issues = new List<XElement>()
                };

                var parser = new Parser();
                parser.Parse(results);

                // logic
                if (results.NumberOfCriticalErrors > 0 || results.NumberOfErrors > 0)
                {
                    ConsolePrint(results);
                    Environment.Exit(1);
                }
                else
                {
                    ConsolePrint(results);
                    Environment.Exit(0);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Environment.Exit(1);
            }
        }

        private static void ConsolePrint(Result results)
        {
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            Console.WriteLine("");
            Console.WriteLine("         S U M M A R Y   ");
            Console.WriteLine("");
            Console.WriteLine("Critical Errors   : " + results.NumberOfCriticalErrors);
            Console.WriteLine("Errors            : " + results.NumberOfErrors);
            Console.WriteLine("Critical Warnings : " + results.NumberOfCriticalWarnings);
            Console.WriteLine("Warnings          : " + results.NumberOfWarnings);
            Console.WriteLine("");
            Console.WriteLine("Total Issues      : " + results.NumberOfTotalIssues);
            Console.WriteLine("");
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
        }
    }
}
