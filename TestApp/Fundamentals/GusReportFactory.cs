using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Fundamentals
{
    public abstract class Report
    {
        public string Name { get; set; }
    }

    // Działalność fizyczna
    public class SoleTraderReport : Report
    {

    }

    // Osobowość prawna
    public class LegalPersonality : Report
    {

    }

    public class ReportFactory
    {
        public static Report Create(string type)
        {
            if (string.IsNullOrEmpty(type))
                throw new ArgumentNullException();

            // P, LP, LF -> Osobowość prawna
            // F -> Działalność fizyczna
            // nieznany -> NotSupportedException

            switch(type)
            {
                case "P":
                case "LP":
                case "LF":
                    return new LegalPersonality();
                case "F": return new SoleTraderReport();

                default:
                    throw new NotSupportedException();
            }
        }
    }

}
