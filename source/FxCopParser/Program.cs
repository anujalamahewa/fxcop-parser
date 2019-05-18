using System;

namespace FxCopParser
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var fileName = args[0];

                var results = new Results();
                Parser parser = new Parser();
                parser.Parse(fileName, results);

                // logic
                if (results.NumberOfCriticalErrors > 0 || results.NumberOfErrors > 0)
                {
                    Console.WriteLine("FxCop Errors found !");
                    Environment.Exit(1);
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Environment.Exit(1);
            }
        }
    }
}
