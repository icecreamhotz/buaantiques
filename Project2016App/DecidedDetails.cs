using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2016App
{
    public class DecidedDetails
    {
        public DateTime stockhisDate { get; set; }
        public string procode { get; set; }
        public string proName { get; set; }
        public decimal stockTotalold { get; set; }
        public decimal stockTotalnew { get; set; }
        public decimal stockTotallast { get; set; }
        public decimal stocksellPrice { get; set; }
        public decimal stockTotalprice { get; set; }
        public string typenameUnit { get; set; }
        public string typepName { get; set; }
        public string stockhisInfo { get; set; }
        public decimal stockhisMoney { get; set; }

        public decimal Total
        {
            get
            {
                return stockhisMoney;
            }
        }
    }
}
