using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Fundamentals
{
    public class OrderCalculator
    {
        public int TotalAmountNet { get; set; }

        public int TaxRatio { get; set; }

        public int Calculate()
        {
            return TotalAmountNet + (TotalAmountNet * TaxRatio / 100);
        }
    }
}
