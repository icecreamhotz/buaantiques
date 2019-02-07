using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatFriends.ThaiBahtText;

namespace Project2016App
{
    public class Selldetails
    {
        public DateTime sellDate { get; set; }
        public string docID { get; set; }
        public int cusID { get; set; }
        public string cusName { get; set; }
        public string cusLastname { get; set; }
        public string cusPlate { get; set; }
        public string sellCode { get; set; }
        public string sellName { get; set; }
        public decimal sellTotal { get; set; }
        public decimal sellDtotal { get; set; }
        public decimal sellTotalall { get; set; }
        public decimal sellPrice { get; set; }
        public string typepName { get; set; }
        public decimal sellAllprice { get; set; }
        public string sellInfo { get; set; }
        public decimal receiptPriceall { get; set; }
        public decimal Total
        {
            get
            {
                return sellAllprice;
            }
        }

        public decimal Total2
        {
            get
            {
                return receiptPriceall;
            }
        }

        public string Thaibath
        {
            get
            {
                decimal settotal = Convert.ToDecimal(Total2);
                string showtotal = settotal.ThaiBahtText();
                return "(" + showtotal + ")";
            }
        }
    }
}
