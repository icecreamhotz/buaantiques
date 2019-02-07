using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Project2016App
{
    /// <summary>
    /// Interaction logic for CalcuateSalary.xaml
    /// </summary>
    public partial class CalcuateSalary : Window
    {

        string showid,showlastname,datecheck, showname;
        int countrow, countloop = -1, value,getvalue;

        public CalcuateSalary()
        {
            InitializeComponent();

            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("th-TH");
            datePick1.Text = startDate.ToShortDateString();
            datePick2.Text = endDate.ToShortDateString();
        }

        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui;");

        private void AfterTextChange(object sender, TextChangedEventArgs e)
        {
            if (rdb1.IsChecked == false && rdb2.IsChecked == false && rdb3.IsChecked == false)
            {
                if (!string.IsNullOrWhiteSpace(Searchbox.Text))
                {
                    con.Open();
                    MySqlDataAdapter adt = new MySqlDataAdapter("select * from checkwork WHERE (checkDate BETWEEN '" + Convert.ToDateTime(datePick1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datePick2.Text).ToString("yyyy-MM-dd") + "') AND (checkName ='" + Searchbox.Text + "')", con);
                    DataSet ds2 = new DataSet();
                    adt.Fill(ds2);
                    dataGrid.ItemsSource = ds2.Tables[0].DefaultView;
                    dataGrid.CanUserAddRows = false;
                    con.Close();
                }
                else
                {
                    con.Open();
                    DataSet ds1 = new DataSet();
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select * from checkwork WHERE checkDate BETWEEN ('" + Convert.ToDateTime(datePick1.Text).ToString("yyyy-MM-dd") + "') AND ('" + Convert.ToDateTime(datePick2.Text).ToString("yyyy-MM-dd") + "')", con);
                    adapter.Fill(ds1);
                    dataGrid.ItemsSource = ds1.Tables[0].DefaultView;
                    dataGrid.CanUserAddRows = false;
                    con.Close();
                }
            }

            rdb1_Click();
            rdb2_Click();
            rdb3_Click();
        }

        private void Click_Rdb1(object sender, RoutedEventArgs e)
        {
            rdb1_Click();
        }

        private void Click_rdb2(object sender, RoutedEventArgs e)
        {
            rdb2_Click();
        }

        private void Click_rbd3(object sender, RoutedEventArgs e)
        {
            rdb3_Click();
        }

        private void rdb1_Click()
        {
            if (rdb1.IsChecked == true)
            {
                if (!string.IsNullOrWhiteSpace(Searchbox.Text))
                {
                    con.Open();
                    MySqlDataAdapter adt = new MySqlDataAdapter("select * from checkwork WHERE (checkDate BETWEEN '" + Convert.ToDateTime(datePick1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datePick2.Text).ToString("yyyy-MM-dd") + "') AND (checkName ='" + Searchbox.Text + "' AND checkStatus ='มาปกติ')", con);
                    DataSet ds2 = new DataSet();
                    adt.Fill(ds2);
                    dataGrid.ItemsSource = ds2.Tables[0].DefaultView;
                    dataGrid.CanUserAddRows = false;
                    con.Close();
                }
                else
                {
                    con.Open();
                    DataSet ds1 = new DataSet();
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select * from checkwork WHERE checkDate BETWEEN ('" + Convert.ToDateTime(datePick1.Text).ToString("yyyy-MM-dd") + "') AND ('" + Convert.ToDateTime(datePick2.Text).ToString("yyyy-MM-dd") + "') AND (checkStatus='มาปกติ')", con);
                    adapter.Fill(ds1);
                    dataGrid.ItemsSource = ds1.Tables[0].DefaultView;
                    dataGrid.CanUserAddRows = false;
                    con.Close();
                }
            }
        }

        private void rdb2_Click()
        {
            if (rdb2.IsChecked == true)
            {
                if (!string.IsNullOrWhiteSpace(Searchbox.Text))
                {
                    con.Open();
                    MySqlDataAdapter adt = new MySqlDataAdapter("select * from checkwork WHERE (checkDate BETWEEN '" + Convert.ToDateTime(datePick1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datePick2.Text).ToString("yyyy-MM-dd") + "') AND (checkName ='" + Searchbox.Text + "' AND checkStatus ='มาครึ่งวันเช้า' OR checkStatus='มาครึ่งวันหลัง')", con);
                    DataSet ds2 = new DataSet();
                    adt.Fill(ds2);
                    dataGrid.ItemsSource = ds2.Tables[0].DefaultView;
                    dataGrid.CanUserAddRows = false;
                    con.Close();
                }
                else
                {
                    con.Open();
                    DataSet ds1 = new DataSet();
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select * from checkwork WHERE checkDate BETWEEN ('" + Convert.ToDateTime(datePick1.Text).ToString("yyyy-MM-dd") + "') AND ('" + Convert.ToDateTime(datePick2.Text).ToString("yyyy-MM-dd") + "') AND (checkStatus='มาครึ่งวันเช้า' OR checkStatus='มาครึ่งวันหลัง')", con);
                    adapter.Fill(ds1);
                    dataGrid.ItemsSource = ds1.Tables[0].DefaultView;
                    dataGrid.CanUserAddRows = false;
                    con.Close();
                }
            }
        }

        private void rdb3_Click()
        {
            if (rdb3.IsChecked == true)
            {
                if (!string.IsNullOrWhiteSpace(Searchbox.Text))
                {
                    con.Open();
                    MySqlDataAdapter adt = new MySqlDataAdapter("select * from checkwork WHERE (checkDate BETWEEN '" + Convert.ToDateTime(datePick1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datePick2.Text).ToString("yyyy-MM-dd") + "') AND (checkName ='" + Searchbox.Text + "' AND checkStatus ='ขาด')", con);
                    DataSet ds2 = new DataSet();
                    adt.Fill(ds2);
                    dataGrid.ItemsSource = ds2.Tables[0].DefaultView;
                    dataGrid.CanUserAddRows = false;
                    con.Close();
                }
                else
                {
                    con.Open();
                    DataSet ds1 = new DataSet();
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select * from checkwork WHERE checkDate BETWEEN ('" + Convert.ToDateTime(datePick1.Text).ToString("yyyy-MM-dd") + "') AND ('" + Convert.ToDateTime(datePick2.Text).ToString("yyyy-MM-dd") + "') AND (checkStatus='ขาด')", con);
                    adapter.Fill(ds1);
                    dataGrid.ItemsSource = ds1.Tables[0].DefaultView;
                    dataGrid.CanUserAddRows = false;
                    con.Close();
                }
            }
        }

        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void Search_Clickz(object sender, RoutedEventArgs e)
        {
            if (datePick1.Text == "" || datePick2.Text == "")
            {
                MessageBox.Show("กรุณากรอกวันที่ด้วยครับ");
            }

            if (Searchbox.Text == "")
            {
                con.Open();
                DataSet ds1 = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter("select * from checkwork WHERE checkDate BETWEEN ('" + Convert.ToDateTime(datePick1.Text).ToString("yyyy-MM-dd") + "') AND ('" + Convert.ToDateTime(datePick2.Text).ToString("yyyy-MM-dd") + "')", con);
                adapter.Fill(ds1);
                dataGrid.ItemsSource = ds1.Tables[0].DefaultView;
                dataGrid.CanUserAddRows = false;
                con.Close();
            }
        }


        private void InsertSalary_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.SelectedIndex = 0;

            con.Open();
            string readersql1 = "select sMonth from salary WHERE sMonth='" + Convert.ToDateTime(datePick2.Text).ToString("yyyy-MM-dd") + "'";
            MySqlCommand commandnaja = new MySqlCommand(readersql1, con);
            MySqlDataReader readdata = commandnaja.ExecuteReader();

            while (readdata.Read())
            {
                datecheck = Convert.ToDateTime(readdata["sMonth"]).ToString("dd/MM/yyyy");

                var myDate = DateTime.Parse(datecheck);
                var newDate = myDate.AddYears(-543);
                datecheck = newDate.ToShortDateString();
            }
            con.Close();

            if (datePick2.Text == datecheck)
            {
                MessageBoxResult result1 = MessageBox.Show("คุณมีข้อมูลนี้อยู่แล้วต้องการแก้ไขหรือไม่?", "รอคำยืนยัน", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result1 != MessageBoxResult.Yes)
                {
                    return;
                }
                else
                {
                    for (int i = 0; i < dataGrid.Items.Count; i++)
                    {

                        object item = dataGrid.Items[i];
                        showid = (dataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                        showname = (dataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                        showlastname = (dataGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;

                        con.Open();
                        string readersql2 = "select * from checkwork WHERE (checkDate BETWEEN '" + Convert.ToDateTime(datePick1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datePick2.Text).ToString("yyyy-MM-dd") + "') AND (checkID='" + showid + "')";
                        MySqlCommand commandna = new MySqlCommand(readersql2, con);
                        MySqlDataReader readerdata = commandna.ExecuteReader();

                        while (readerdata.Read())
                        {
                            value += Convert.ToInt32(readerdata["checkPay"]);
                            getvalue = value;
                        }
                        value = 0;
                        con.Close();

                        con.Open();
                        MySqlCommand cmd2 = new MySqlCommand();
                        cmd2.Connection = con;
                        cmd2.CommandText = @"UPDATE salary SET sMonth='" + Convert.ToDateTime(datePick2.Text).ToString("yyyy-MM-dd") + "',empID='" + showid + "',sName='" + showname + "',sLastname='" + showlastname + "',sSalary='" + getvalue + "',sSave=now() WHERE (sMonth='" + Convert.ToDateTime(datePick2.Text).ToString("yyyy-MM-dd") + "') AND (empID='" + showid + "')";
                        cmd2.ExecuteNonQuery();
                        con.Close();
                    }
                    MessageBox.Show("แก้ไขเรียบร้อยแล้ว!!!", "เรียบร้อย");
                    CalcuateSalary go = new CalcuateSalary();
                    this.Close();
                    go.Show();
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("คุณต้องการบันทึกใช่ไหม?", "รอคำยืนยัน", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result != MessageBoxResult.Yes)
                {
                    return;
                }
                else
                {
                    using (MySqlCommand cmd1 = new MySqlCommand("SELECT COUNT(*) FROM employee", con))
                    {
                        con.Open();
                        countrow = Convert.ToInt32(cmd1.ExecuteScalar());
                        con.Close();
                    }

                    for (int i = 0; i < dataGrid.Items.Count; i++)
                    {

                        object item = dataGrid.Items[i];
                        showid = (dataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                        showname = (dataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                        showlastname = (dataGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;

                        con.Open();
                        string readersql2 = "select * from checkwork WHERE (checkDate BETWEEN '" + Convert.ToDateTime(datePick1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datePick2.Text).ToString("yyyy-MM-dd") + "') AND (checkID='" + showid + "')";
                        MySqlCommand commandna = new MySqlCommand(readersql2, con);
                        MySqlDataReader readerdata = commandna.ExecuteReader();

                        while (readerdata.Read())
                        {
                            value += Convert.ToInt32(readerdata["checkPay"]);
                            getvalue = value;
                        }
                        value = 0;
                        con.Close();

                        countloop += 1;

                        if (countloop == countrow)
                        {
                            break;
                        }

                        con.Open();
                        MySqlCommand cmd2 = new MySqlCommand();
                        cmd2.Connection = con;
                        cmd2.CommandText = @"INSERT INTO salary (sMonth,empID,sName,sLastname,sSalary,sSave) VALUES (@Date,@ID,@NAME,@LASTNAME,@SALARY,now())";
                        cmd2.Parameters.AddWithValue("@Date", Convert.ToDateTime(datePick2.Text).ToString("yyyy-MM-dd"));
                        cmd2.Parameters.AddWithValue("@ID", showid);
                        cmd2.Parameters.AddWithValue("@NAME", showname);
                        cmd2.Parameters.AddWithValue("@LASTNAME", showlastname);
                        cmd2.Parameters.AddWithValue("@SALARY", getvalue);
                        cmd2.ExecuteNonQuery();
                        cmd2.Parameters.Clear();
                        con.Close();
                    }
                    MessageBox.Show("บันทึกเรียบร้อยแล้ว");
                    CalcuateSalary go = new CalcuateSalary();
                    this.Close();
                    go.Show();
                }
            }
        }
    }
}
