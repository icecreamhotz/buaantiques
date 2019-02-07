using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatFriends.ThaiBahtText;

namespace Project2016App
{
    public class OrderDetails
    {
        public DateTime buyDate { get; set; }
        public string docID { get; set; }
        public int cusID { get; set; }
        public string cusName { get; set; }
        public string cusLastname { get; set; }
        public string cusPlate { get; set; }
        public string buyCode { get; set; }
        public string buyName { get; set; }
        public decimal buyTotal { get; set; }
        public decimal buyDtotal { get; set; }
        public decimal buyTotalall { get; set; }
        public decimal buyPrice { get; set; }
        public string typepName { get; set; }
        public decimal buyAllprice { get; set; }
        public decimal receiptPriceall { get; set; }
        public string buyInfo { get; set; }
        public decimal Total
        {
            get
            {
                return buyAllprice;
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
                return "("+showtotal+")";
            }
        }
    }
}
