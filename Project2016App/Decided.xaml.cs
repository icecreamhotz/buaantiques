using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;

namespace Project2016App
{
    /// <summary>
    /// Interaction logic for Decided.xaml
    /// </summary>
    public partial class Decided : Window
    {

        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui;");

        double Totalbuy = 0.0, Totalsell = 0.0, LastTotalbuyandSell = 0.0, Pricesell = 0.0, Stocksell = 0.0, Totalall = 0.0, Priceall = 0.0, Balance = 0.0, BalanceLast = 0.0, BalanceTotal = 0.0;
        double dbPay = 0.0, getTotalall = 0.0, dbCost = 0.0, moneyHisstock = 0.0;

        string showstockID, status;

        public Decided()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, RoutedEventArgs e)
        {
            DateTime setdate = DateTime.Now;
            var startDate = new DateTime(setdate.Year, setdate.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            datePicker1.Text = startDate.ToShortDateString();
            datePicker2.Text = endDate.ToShortDateString();

            string showstock = "SELECT stock.*,product.proCode,product.proName,product.proPricesell FROM stock left join product on stock.proId=product.proID";
            MySqlDataAdapter adpstock = new MySqlDataAdapter(showstock, con);
            DataSet dtstock = new DataSet();
            adpstock.Fill(dtstock);
            dgStock.ItemsSource = dtstock.Tables[0].DefaultView;
            dgStock.CanUserAddRows = false;
            con.Close();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            string showbuy = "SELECT buyDate,buyCode,buyName,buyPrice,SUM(buyTotalall),SUM(buyAllprice) FROM buytoday WHERE (buyDate BETWEEN'" + Convert.ToDateTime(datePicker1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datePicker2.Text).ToString("yyyy-MM-dd") + "') GROUP BY buyName ORDER BY SUM(buyTotalall),SUM(buyAllprice) DESC";
            MySqlDataAdapter adpbuy = new MySqlDataAdapter(showbuy, con);
            DataSet dtbuy = new DataSet();
            adpbuy.Fill(dtbuy);
            dgBuy.ItemsSource = dtbuy.Tables[0].DefaultView;
            dgBuy.CanUserAddRows = false;

            MySqlCommand cmdbuy = new MySqlCommand(showbuy, con);
            MySqlDataReader readbuy = cmdbuy.ExecuteReader();
            while (readbuy.Read())
            {
                Totalbuy += Convert.ToDouble(readbuy["SUM(buyAllprice)"]);
            }
            con.Close();
            lbBuy.Content = ("- ราคาที่ซื้อทั้งหมดจากการค้นหา : " + Totalbuy);

            con.Open();
            string showsell = "SELECT sellDate,sellCode,sellName,sellPrice,SUM(sellTotalall),SUM(sellAllprice) FROM selltoday WHERE (sellDate BETWEEN'" + Convert.ToDateTime(datePicker1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datePicker2.Text).ToString("yyyy-MM-dd") + "') GROUP BY sellName ORDER BY SUM(sellTotalall),SUM(sellAllprice) DESC";
            MySqlDataAdapter adpsell = new MySqlDataAdapter(showsell, con);
            DataSet dtsell = new DataSet();
            adpsell.Fill(dtsell);
            dgSell.ItemsSource = dtsell.Tables[0].DefaultView;
            dgSell.CanUserAddRows = false;

            MySqlCommand cmdsell = new MySqlCommand(showsell, con);
            MySqlDataReader readsell = cmdsell.ExecuteReader();
            while (readsell.Read())
            {
                Totalsell += Convert.ToDouble(readsell["SUM(sellAllprice)"]);
            }
            con.Close();

            LastTotalbuyandSell = Totalbuy - Totalsell;

            lbSell.Content = ("- ราคาที่ขายทั้งหมดจากการค้นหา : " + Totalsell + " บาท");
            lbCost.Content = ("- ต้นทุนการซื้อหักลบการขาย : " + LastTotalbuyandSell + " บาท");

            Totalbuy = 0.0;
            Totalsell = 0.0;
        }

        private void btAccept_Click(object sender, RoutedEventArgs e)
        {
            dgStock.SelectedIndex = 0;

            for (int i = 0; i < dgStock.Items.Count; i++)
            {
                object item = dgStock.Items[i];

                string dbPricesell = (dgStock.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                string dbTotalsell = (dgStock.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                string dbStockAmount = (dgStock.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;

                if (string.IsNullOrEmpty(dbStockAmount))
                {
                    dbStockAmount = "0";
                }

                double getTotalsell = Convert.ToDouble(dbTotalsell);
                double getStockAmount = Convert.ToDouble(dbStockAmount);

                if (getStockAmount > getTotalsell)
                {
                    MessageBox.Show("กรุณาตรวจสอบ!!! คุณกรอกเกินจำนวนที่มี", "ผิดพลาด");
                    Priceall = 0.0;
                    BalanceTotal = 0.0;
                    return;
                }

                Pricesell = Convert.ToDouble(dbPricesell);
                Stocksell = Convert.ToDouble(dbStockAmount);
                Totalall = Pricesell * Stocksell;
                Priceall += Totalall;

                Balance = getTotalsell - getStockAmount;
                BalanceLast = Balance * Pricesell;
                BalanceTotal += BalanceLast;
            }

            lbStock.Content = ("- ราคาจากการขายในสต๊อคที่คุณเลือก : " + Priceall + " บาท");
            lbStockBalance.Content = ("- ราคาจากการขายในสต๊อคที่คุณไม่เลือก : " + BalanceTotal + " บาท");
            getTotalall = Priceall; // ตัวแปรเก็บค่าของ ราคาจากการขายในสต๊อคที่เลือก
            Priceall = 0.0;
            BalanceTotal = 0.0;
        }

        private void PressEnterTxtPay(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }
            else
            {
                CalculateLast();
            }
        }

        private void btCalStock_Click(object sender, RoutedEventArgs e)
        {
            CalculateLast();
        }

        private void btAcceptStock_Click(object sender, RoutedEventArgs e)
        {
            dgStock.SelectedIndex = 0;

            if (dbCost == 0.0)
            {
                MessageBox.Show("ผิดพลาด ระบบไม่พบราคาที่จะขายกรุณากรอกข้อมูลใหมอีกครั้ง!!!", "ผิดพลาด");
                return;
            }

            MessageBoxResult result = MessageBox.Show("คุณต้องการจะบันทึกการส่งครั้งนี้ ?", "ยืนยัน", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            else
            {

                //เงื่อนไข กำไร - ขาดทุน
                if (getTotalall > dbCost)
                {
                    status = "กำไร";
                    moneyHisstock = getTotalall - dbCost; // หาราคาส่งของทั้งหมด
                }
                else
                {
                    status = "ขาดทุน";
                    moneyHisstock = dbCost - getTotalall; // หาราคาส่งของทั้งหมด
                }
                //

                for (int i = 0; i < dgStock.Items.Count; i++)
                {
                    object item = dgStock.Items[i];

                    string getCode = (dgStock.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    string getsellPrice = (dgStock.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                    string getTotalold = (dgStock.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                    string getTotalnew = (dgStock.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;

                    if (string.IsNullOrWhiteSpace(getTotalnew))
                    {
                        getTotalnew = "0.0";
                    }

                    con.Open();
                    string getstockID = "SELECT stock.stockID FROM stock inner join product on stock.proID=product.proID WHERE product.proCode='" + getCode + "'";
                    MySqlCommand cmdgetID = new MySqlCommand(getstockID, con);
                    MySqlDataReader readgetID = cmdgetID.ExecuteReader();
                    while (readgetID.Read())
                    {
                        showstockID = readgetID["stockID"].ToString();
                    }
                    con.Close();

                    string intstockhis = @"INSERT INTO stockhistory (stockID,stockhisDate,stockTotalold,stockTotalnew,stockTotallast,stocksellPrice,stockTotalprice,stockhisInfo,stockhisMoney) 
                VALUE (@stockID,@stockhisDate,@stockTotalold,@stockTotalnew,@stockTotallast,@stocksellPrice,@stockTotalprice,@stockhisInfo,@stockhisMoney)";
                    MySqlCommand cmdstockhis = new MySqlCommand(intstockhis, con);
                    cmdstockhis.Parameters.AddWithValue("@stockID", showstockID);
                    cmdstockhis.Parameters.AddWithValue("@stockhisDate", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmdstockhis.Parameters.AddWithValue("@stockTotalold", getTotalold);
                    cmdstockhis.Parameters.AddWithValue("@stockTotalnew", getTotalnew);
                    cmdstockhis.Parameters.AddWithValue("@stockTotallast", (Convert.ToDouble(getTotalold) - Convert.ToDouble(getTotalnew)));
                    cmdstockhis.Parameters.AddWithValue("@stocksellPrice", getsellPrice);
                    cmdstockhis.Parameters.AddWithValue("@stockTotalprice", (Convert.ToDouble(getsellPrice) * Convert.ToDouble(getTotalnew)));
                    cmdstockhis.Parameters.AddWithValue("@stockhisInfo", status);
                    cmdstockhis.Parameters.AddWithValue("@stockhisMoney", moneyHisstock);
                    cmdstockhis.Connection.Open();
                    cmdstockhis.ExecuteNonQuery();
                    con.Close();

                    string udpstockhis = "UPDATE stock SET stockTotal='" + (Convert.ToDouble(getTotalold) - Convert.ToDouble(getTotalnew)) + "' WHERE stockID='" + showstockID + "'";
                    MySqlCommand cmdudpstockhis = new MySqlCommand(udpstockhis, con);
                    cmdudpstockhis.Connection.Open();
                    cmdudpstockhis.ExecuteNonQuery();
                    con.Close();
                }// ปิด loopfor
                MessageBox.Show("บันทึกประวัติการส่งสินค้าเรียบร้อยแล้ว!!!", "สำเร็จ");
            }// ปิด else ในการตอบคำถามบันทึก
        }

        private void PressTxtPay(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D0:
                case Key.D1:
                case Key.D2:
                case Key.D3:
                case Key.D4:
                case Key.D5:
                case Key.D6:
                case Key.D7:
                case Key.D8:
                case Key.D9:
                case Key.NumLock:
                case Key.NumPad0:
                case Key.NumPad1:
                case Key.NumPad2:
                case Key.NumPad3:
                case Key.NumPad4:
                case Key.NumPad5:
                case Key.NumPad6:
                case Key.NumPad7:
                case Key.NumPad8:
                case Key.NumPad9:
                case Key.Add:
                case Key.Decimal:
                    break;
                default:
                    e.Handled = true;
                    break;
            }
        }

        private void CalculateLast()
        {
            string[] strPay = txtPay.Text.Split('+');

            for (int i = 0; i < strPay.Length; i++)
            {

                if (string.IsNullOrEmpty(strPay[i]))
                {
                    strPay[i] = "0.0";
                }
                else
                {
                    dbPay += Convert.ToDouble(strPay[i]);
                }

            }

            dbCost = 0.0;
            dbCost = LastTotalbuyandSell + dbPay; // เพื่อคำนวณของ ขายสต๊อค กับ ค่าใช้จ่ายในการขาย

            lbPaytotal.Content = ("- ค่าใช้จ่ายทั้งหมด : " + dbPay + " บาท");
            lbPayandCost.Content = ("- ค่าใช้จ่ายทั้งหมด (ต้นทุกหลังหักลบการขาย+ค่าใช้จ่าย) : " + (LastTotalbuyandSell + dbPay) + " บาท"); // ((Totalbuy - Totalsell) + dbPay) นำต้นทุนการหักจากซื้อขายมาลบก่อนแล้วนำมาบวกกับ จำนวนค่าใช้จ่าย

            lbCostshow.Content = ("- ต้นทุนของคุณ : " + LastTotalbuyandSell + " บาท");
            lbStockShow.Content = ("- ขายสต๊อครอบนี้ทั้งหมด : " + getTotalall + " บาท");
            lbPayShow.Content = ("- ค่าใช้จ่ายในการขายรอบนี้ : " + dbCost + " บาท");

            if (getTotalall > dbCost)
            {
                lbInfo.Content = ("- ดังนั้น คุณ ได้กำไร เป็นจำนวน : " + (getTotalall - dbCost) + " บาท");
                lbInfo.Foreground = Brushes.Green;
            }
            else
            {
                lbInfo.Content = ("- ดังนั้น คุณ ขาดทุน เป็นจำนวน : " + (dbCost - getTotalall) + " บาท");
                lbInfo.Foreground = Brushes.Red;
            }
            dbPay = 0.0;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != "." && IsNumber(e.Text) == false)
            {
                e.Handled = true;
            }
            else if (e.Text == ".")
            {
                if (((TextBox)sender).Text.IndexOf(e.Text) > -1)
                {
                    e.Handled = true;
                }
            }
        }
        private bool IsNumber(string Text)
        {
            int output;
            return int.TryParse(Text, out output);
        }

    }
}
