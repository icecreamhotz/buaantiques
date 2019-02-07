
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
using System.Threading;
using System.Globalization;

namespace Project2016App
{
    /// <summary>
    /// Interaction logic for Statistic.xaml
    /// </summary>
    public partial class Statistic : Window
    {

        List<string> getName = new List<string>();
        List<string> getTotal = new List<string>();
        List<string> getNameSell = new List<string>();
        List<string> getTotalSell = new List<string>();
        
        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui;");

        public Statistic()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH");
            DateTime datenow = DateTime.Now;
            var startDate=new DateTime(datenow.Year,datenow.Month,1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            datePicker1.Text = startDate.ToShortDateString();
            datePicker2.Text = endDate.ToShortDateString();
            datePicker1Sell.Text = startDate.ToShortDateString();
            datePicker2Sell.Text = endDate.ToShortDateString();
        }

        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()+1).ToString();
        }

        private void SearchProductBuy_Click(object sender, RoutedEventArgs e)
        {
            if (datePicker1.Text == "" || datePicker2.Text=="")
            {
                MessageBox.Show("กรุณาเลือกวันที่ก่อนครับ!!!");
                return;
            }

            getName.Clear();
            getTotal.Clear();

            /// ตั้งค่าตัวอักษร กิโลกรัม 
            Typenubbuy1.Text = "กิโลกรัม";
            Typenubbuy2.Text = "กิโลกรัม";
            Typenubbuy3.Text = "กิโลกรัม";
            Typenubbuy4.Text = "กิโลกรัม";
            Typenubbuy5.Text = "กิโลกรัม";
            ///

            string getSql = @"SELECT buytoday.buyName,SUM(buyTotalall),typeproduct.typepName FROM buytoday left join typeproduct on buytoday.typepID=typeproduct.typepID
            WHERE (buyDate BETWEEN '" + Convert.ToDateTime(datePicker1.Text).ToString("yyyy-MM-dd")+"' AND '"+Convert.ToDateTime(datePicker2.Text).ToString("yyyy-MM-dd")+ "') GROUP BY buyName ORDER BY SUM(buyTotalall) DESC LIMIT 5 ";
            dgTotalall.Binding = new Binding("SUM(buyTotalall)");
            con.Open();
            MySqlCommand cmd = new MySqlCommand(getSql, con);
            MySqlDataAdapter adpter = new MySqlDataAdapter(getSql,con);
            DataSet dt = new DataSet();
            adpter.Fill(dt);
            dataGrid.ItemsSource = dt.Tables[0].DefaultView;
            dataGrid.CanUserAddRows = false;
            
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                getName.Add(reader["buyName"].ToString());
                getTotal.Add(reader["SUM(buyTotalall)"].ToString());
            }
            con.Close();

            // เงื่อนไข list 
            if(getName.Count == 4)
            {
                pShow1.Text = getName[0];
                pShow2.Text = getName[1];
                pShow3.Text = getName[2];
                pShow4.Text = getName[3];
                pShow5.Text = "ไม่มี";
            }else if (getName.Count == 3)
            {
                pShow1.Text = getName[0];
                pShow2.Text = getName[1];
                pShow3.Text = getName[2];
                pShow4.Text = "ไม่มี";
                pShow5.Text = "ไม่มี";
            } else if (getName.Count == 2)
            {
                pShow1.Text = getName[0];
                pShow2.Text = getName[1];
                pShow3.Text = "ไม่มี";
                pShow4.Text = "ไม่มี";
                pShow5.Text = "ไม่มี";
            }else if (getName.Count == 1)
            {
                pShow1.Text = getName[0];
                pShow2.Text = "ไม่มี";
                pShow3.Text = "ไม่มี";
                pShow4.Text = "ไม่มี";
                pShow5.Text = "ไม่มี";
            }else if (getName.Count == 5)
            {
                pShow1.Text = getName[0];
                pShow2.Text = getName[1];
                pShow3.Text = getName[2];
                pShow4.Text = getName[3];
                pShow5.Text = getName[4];
            }
            // เช็คยอดสินค้า
            if (getTotal.Count == 4)
            {
                tShow1.Text = getName[0];
                tShow2.Text = getName[1];
                tShow3.Text = getName[2];
                tShow4.Text = getName[3];
                tShow5.Text = "ไม่มี";
            }
            else if (getTotal.Count == 3)
            {
                tShow1.Text = getTotal[0];
                tShow2.Text = getTotal[1];
                tShow3.Text = getTotal[2];
                tShow4.Text = "ไม่มี";
                tShow5.Text = "ไม่มี";
            }
            else if (getTotal.Count == 2)
            {
                tShow1.Text = getTotal[0];
                tShow2.Text = getTotal[1];
                tShow3.Text = "ไม่มี";
                tShow4.Text = "ไม่มี";
                tShow5.Text = "ไม่มี";
            }
            else if (getTotal.Count == 1)
            {
                tShow1.Text = getTotal[0];
                tShow2.Text = "ไม่มี";
                tShow3.Text = "ไม่มี";
                tShow4.Text = "ไม่มี";
                tShow5.Text = "ไม่มี";
            }
            else if (getTotal.Count == 5)
            {
                tShow1.Text = getTotal[0];
                tShow2.Text = getTotal[1];
                tShow3.Text = getTotal[2];
                tShow4.Text = getTotal[3];
                tShow5.Text = getTotal[4];
            }
            // ปิดเงื่อนไข list

        }

        private void rdbCustom_Checked(object sender, RoutedEventArgs e)
        {
            if (rdbCustom.IsChecked == true)
            {
                datePicker1.IsEnabled = true;
                datePicker2.IsEnabled = true;
            }
        }

        private void rdbMonth_Checked(object sender, RoutedEventArgs e)
        {
            if (rdbMonth.IsChecked == true)
            {
                datePicker1.IsEnabled = false;
                datePicker2.IsEnabled = false;

                DateTime setDate = DateTime.Now;
                var startYear = new DateTime(setDate.Year, setDate.Month, 1);
                var endYear = startYear.AddMonths(1).AddDays(-1);
                datePicker1.Text = startYear.ToShortDateString();
                datePicker2.Text = endYear.ToShortDateString();
            }
        }

        private void rdbYear_Checked(object sender, RoutedEventArgs e)
        {
            if (rdbYear.IsChecked == true)
            {
                datePicker1.IsEnabled = false;
                datePicker2.IsEnabled = false;

                DateTime setDate = DateTime.Now;
                var startYear = new DateTime(setDate.Year, 1, 1);
                var endYear = new DateTime(setDate.Year, 12, 31);
                datePicker1.Text = startYear.ToShortDateString();
                datePicker2.Text = endYear.ToShortDateString();
            }
        }

        private void SearchProductSell_Click(object sender, RoutedEventArgs e)
        {
            if(datePicker1Sell.Text=="" || datePicker2Sell.Text =="")
            {
                MessageBox.Show("กรุณากรอกวันที่ก่อนครับ!!!");
                return;
            }

            getNameSell.Clear();
            getTotalSell.Clear();

            /// ตั้งค่าตัวอักษร กิโลกรัม 
            Typenubsell1.Text = "กิโลกรัม";
            Typenubsell2.Text = "กิโลกรัม";
            Typenubsell3.Text = "กิโลกรัม";
            Typenubsell4.Text = "กิโลกรัม";
            Typenubsell5.Text = "กิโลกรัม";
            ///
           
            string getSql2 = @"SELECT selltoday.sellName,SUM(sellTotalall),typeproduct.typepName FROM selltoday left join typeproduct on selltoday.typepID=typeproduct.typepID
            WHERE (sellDate BETWEEN'"+Convert.ToDateTime(datePicker1Sell.Text).ToString("yyyy-MM-dd")+"' AND '"+Convert.ToDateTime(datePicker2Sell.Text).ToString("yyyy-MM-dd")+"') GROUP BY sellName ORDER BY SUM(sellTotalall) DESC LIMIT 5 ";
            dg2Totalall.Binding = new Binding("SUM(sellTotalall)");
            con.Open();
            MySqlDataAdapter adpter = new MySqlDataAdapter(getSql2, con);
            DataSet dt = new DataSet();
            adpter.Fill(dt);
            dataGrid2.ItemsSource = dt.Tables[0].DefaultView;
            dataGrid2.CanUserAddRows = false;

            MySqlCommand cmd = new MySqlCommand(getSql2, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                getNameSell.Add(reader["sellName"].ToString());
                getTotalSell.Add(reader["SUM(sellTotalall)"].ToString());
            }
            con.Close();

            /// ปิด if else listอาเรย์ของ ชื่อรายการขาย
            if (getNameSell.Count == 1)
            {
                sShow1.Text = getNameSell[0].ToString();
                sShow2.Text = "ไม่มี";
                sShow3.Text = "ไม่มี";
                sShow4.Text = "ไม่มี";
                sShow5.Text = "ไม่มี";
            }else if (getNameSell.Count == 2)
            {
                sShow1.Text = getNameSell[0].ToString();
                sShow2.Text = getNameSell[1].ToString();
                sShow3.Text = "ไม่มี";
                sShow4.Text = "ไม่มี";
                sShow5.Text = "ไม่มี";
            }else if (getNameSell.Count == 3)
            {
                sShow1.Text = getNameSell[0].ToString();
                sShow2.Text = getNameSell[1].ToString();
                sShow3.Text = getNameSell[2].ToString();
                sShow4.Text = "ไม่มี";
                sShow5.Text = "ไม่มี";
            }else if (getNameSell.Count == 4)
            {
                sShow1.Text = getNameSell[0].ToString();
                sShow2.Text = getNameSell[1].ToString();
                sShow3.Text = getNameSell[2].ToString();
                sShow4.Text = getNameSell[3].ToString();
                sShow5.Text = "ไม่มี";
            }else if (getNameSell.Count == 5)
            {
                sShow1.Text = getNameSell[0].ToString();
                sShow2.Text = getNameSell[1].ToString();
                sShow3.Text = getNameSell[2].ToString();
                sShow4.Text = getNameSell[3].ToString();
                sShow5.Text = getNameSell[4].ToString();
            }

            /// ปิด if else listอาเรย์ของ ชื่อรายการขาย

            // เปิด ifelse list อาเรย์ของจำนวนขาย
            if (getTotalSell.Count == 1)
            {
                tShow_Sell1.Text = getTotalSell[0].ToString();
                tShow_Sell2.Text = "ไม่มี";
                tShow_Sell3.Text = "ไม่มี";
                tShow_Sell4.Text = "ไม่มี";
                tShow_Sell5.Text = "ไม่มี";
            }
            else if (getTotalSell.Count == 2)
            {
                tShow_Sell1.Text = getTotalSell[0].ToString();
                tShow_Sell2.Text = getTotalSell[1].ToString();
                tShow_Sell3.Text = "ไม่มี";
                tShow_Sell4.Text = "ไม่มี";
                tShow_Sell5.Text = "ไม่มี";
            }
            else if (getTotalSell.Count == 3)
            {
                tShow_Sell1.Text = getTotalSell[0].ToString();
                tShow_Sell2.Text = getTotalSell[1].ToString();
                tShow_Sell3.Text = getTotalSell[2].ToString();
                tShow_Sell4.Text = "ไม่มี";
                tShow_Sell5.Text = "ไม่มี";
            }
            else if (getTotalSell.Count == 4)
            {
                tShow_Sell1.Text = getTotalSell[0].ToString();
                tShow_Sell2.Text = getTotalSell[1].ToString();
                tShow_Sell3.Text = getTotalSell[2].ToString();
                tShow_Sell4.Text = getTotalSell[3].ToString();
                tShow_Sell5.Text = "ไม่มี";
            }
            else if (getTotalSell.Count == 5)
            {
                tShow_Sell1.Text = getTotalSell[0].ToString();
                tShow_Sell2.Text = getTotalSell[1].ToString();
                tShow_Sell3.Text = getTotalSell[2].ToString();
                tShow_Sell4.Text = getTotalSell[3].ToString();
                tShow_Sell5.Text = getTotalSell[4].ToString();
            }
            // ปิดการตั้งค่า if else จำนวนอาเรย์จำนวนกิโล
        }

        private void rdbCustom_Sell_Checked(object sender, RoutedEventArgs e)
        {
            if (rdbCustom_Sell.IsChecked == true)
            {
                datePicker1Sell.IsEnabled = true;
                datePicker2Sell.IsEnabled = true;
            }
        }

        private void rdbMonth_Sell_Checked(object sender, RoutedEventArgs e)
        {
            if (rdbMonth_Sell.IsChecked == true)
            {
                DateTime datenow = DateTime.Now;
                var startMonth = new DateTime(datenow.Year, datenow.Month, 1);
                var endMonth = startMonth.AddMonths(1).AddDays(-1);
                datePicker1Sell.Text = startMonth.ToShortDateString();
                datePicker2Sell.Text = endMonth.ToShortDateString();
            }
        }

        private void rdbYear_Sell_Checked(object sender, RoutedEventArgs e)
        {
            if (rdbYear_Sell.IsChecked == true)
            {
                DateTime timenow = DateTime.Now;
                var startYear = new DateTime(timenow.Year, 1, 1);
                var endYear = new DateTime(timenow.Year, 12, 31);
                datePicker1Sell.Text = startYear.ToShortDateString();
                datePicker2Sell.Text = endYear.ToShortDateString();
            }
        }

    }
}
