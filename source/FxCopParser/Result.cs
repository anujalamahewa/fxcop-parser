using System.Collections.Generic;
using System.Xml.Linq;

namespace FxCopParser
{
    public class Result
    {
        public int NumberOfTotalIssues { get; set; }
        public int NumberOfCriticalErrors { get; set; }
        public int NumberOfErrors { get; set; }
        public int NumberOfCriticalWarnings { get; set; }
        public int NumberOfWarnings { get; set; }
        public List<ResultItem> ItemList { get; set; }
        public List<XElement> Issues { get; set; }
        public XDocument Document { get; set; }
        public string FileName { get; set; }
    }
}
