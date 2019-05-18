using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FxCopParser
{
    public class Parser
    {
        public void Parse(string fileName, Results results)
        {
            XDocument doc = XDocument.Load(fileName);
            var issues = GetAllIssues(doc);

            results.NumberOfIssues = issues.Count;

            var criticalErrors = GetCriticalErrors(issues);
            var errors = GetErrors(issues);
            var criticalWarnings = GetCriticalWarnings(issues);
            var warnings = GetWarnings(issues);

            results.NumberOfCriticalErrors = criticalErrors.Count;
            results.NumberOfErrors = errors.Count;
            results.NumberOfCriticalWarnings = criticalWarnings.Count;
            results.NumberOfWarnings = warnings.Count;
        }

        private List<XElement> GetAllIssues(XDocument doc)
        {
            IEnumerable<XElement> issues =
                from el in doc.Descendants("Issue")
                select el;

            return issues.ToList();
        }

        private List<XElement> GetCriticalErrors(List<XElement> issues)
        {
            IEnumerable<XElement> errors =
                from el in issues
                where (string)el.Attribute("Level") == "CriticalError"
                select el;

            return errors.ToList();
        }

        private List<XElement> GetErrors(List<XElement> issues)
        {
            IEnumerable<XElement> errors =
                from el in issues
                where (string)el.Attribute("Level") == "Error"
                select el;

            return errors.ToList();
        }

        private List<XElement> GetCriticalWarnings(List<XElement> issues)
        {
            IEnumerable<XElement> warn =
                from el in issues
                where (string)el.Attribute("Level") == "CriticalWarning"
                select el;

            return warn.ToList();
        }

        private List<XElement> GetWarnings(List<XElement> issues)
        {
            IEnumerable<XElement> warn =
                from el in issues
                where (string)el.Attribute("Level") == "Warning"
                select el;

            return warn.ToList();
        }
    }
}
