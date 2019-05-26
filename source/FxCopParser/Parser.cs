using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FxCopParser
{
    public class Parser
    {
        public void Parse(Result result)
        {
            result.Document = XDocument.Load(result.FileName);
            GetIssueCount(result);
        }

        private void GetIssueCount(Result result)
        {
            IEnumerable<XElement> issues =
                from item in result.Document.Descendants("Issue")
                select item;

            result.NumberOfTotalIssues = issues.Count();
            result.Issues = issues.ToList();

            //---------------------------------------------------------------

            IEnumerable<XElement> criticalErrors =
                from item in result.Issues
                where (string)item.Attribute("Level") == "CriticalError"
                select item;

            result.NumberOfCriticalErrors = criticalErrors.Count();

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Critical Errors   : " + result.NumberOfCriticalErrors);
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");

            Print(criticalErrors);

            //---------------------------------------------------------------

            IEnumerable<XElement> errors =
                           from item in issues
                           where (string)item.Attribute("Level") == "Error"
                           select item;

            result.NumberOfErrors = errors.Count();

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Errors            : " + result.NumberOfErrors);
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");

            Print(errors);

            //---------------------------------------------------------------

            IEnumerable<XElement> criticalWarnings =
                           from item in issues
                           where (string)item.Attribute("Level") == "CriticalWarning"
                           select item;

            result.NumberOfCriticalWarnings = criticalWarnings.Count();

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Critical Warnings : " + result.NumberOfCriticalWarnings);
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");

            Print(criticalWarnings);

            //---------------------------------------------------------------

            IEnumerable<XElement> warnings =
                           from item in issues
                           where (string)item.Attribute("Level") == "Warning"
                           select item;

            result.NumberOfWarnings = warnings.Count();

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Warnings          : " + result.NumberOfWarnings);
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");

            Print(warnings);

        }

        private void Print(IEnumerable<XElement> issues)
        {
            foreach (var item in issues)
            {
                Console.WriteLine("");
                Console.WriteLine(item);
                Console.WriteLine("");
            }
        }

    }
}
