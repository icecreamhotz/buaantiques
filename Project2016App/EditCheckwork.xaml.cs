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
    /// Interaction logic for EditCheckwork.xaml
    /// </summary>
    public partial class EditCheckwork : Window
    {

        CheckBox cbk1, cbk2, cbk3, cbk4;
        int paytoday;
        string sql,showname,showinfo,showid,showstatus,showcheckworkid,status,showlastname;

        public EditCheckwork()
        {
            InitializeComponent();

            DateTime now = DateTime.Now;
            var StartDate = new DateTime(now.Year, now.Month, 1);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("th-TH");
            datePick1.Text = StartDate.ToShortDateString();
        }

        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui;");

        private void AfterTextChange(object sender, TextChangedEventArgs e)
        {
            con.Open();
            if (Searchname.Text == "")
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM checkwork WHERE checkDate ='" + Convert.ToDateTime(datePick1.Text).ToString("yyyy-MM-dd") + "'", con);
                DataSet dt = new DataSet();
                adapter.Fill(dt);
                dataGrid.ItemsSource = dt.Tables[0].DefaultView;
                dataGrid.CanUserAddRows = false;
            }
            else
            {
                MySqlDataAdapter adt = new MySqlDataAdapter("select * from checkwork WHERE (checkDate ='" + Convert.ToDateTime(datePick1.Text).ToString("yyyy-MM-dd") + "') AND (checkName='" + Searchname.Text + "')", con);
                DataSet ds = new DataSet();
                adt.Fill(ds);
                dataGrid.ItemsSource = ds.Tables[0].DefaultView;
                dataGrid.CanUserAddRows = false;
            }
            con.Close();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            MySqlDataAdapter adt = new MySqlDataAdapter("SELECT * FROM checkwork WHERE checkDate ='" + Convert.ToDateTime(datePick1.Text).ToString("yyyy-MM-dd") + "'", con);
            DataSet ds = new DataSet();
            adt.Fill(ds);
            dataGrid.ItemsSource = ds.Tables[0].DefaultView;
            dataGrid.CanUserAddRows = false;
            con.Close();
        }

        private void bt_Edit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("คุณต้องการจะแก้ไขหรือไม่", "บันทึกเรียบแล้วร้อย", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            else
            {
                MessageBox.Show("แก้ไขข้อมูลสำเร็จแล้ว!!");
                try
                {
                    using (MySqlConnection conn = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui"))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            cmd.Connection = conn;
                            conn.Open();

                            for (int i = 0; i < dataGrid.Items.Count; i++)
                            {

                                object item = dataGrid.Items[i];
                                showid = (dataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                                showname = (dataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                                showlastname = (dataGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                                showstatus = (dataGrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                                cbk1 = (dataGrid.SelectedCells[5].Column.GetCellContent(item) as CheckBox);
                                cbk2 = (dataGrid.SelectedCells[6].Column.GetCellContent(item) as CheckBox);
                                cbk3 = (dataGrid.SelectedCells[7].Column.GetCellContent(item) as CheckBox);
                                cbk4 = (dataGrid.SelectedCells[8].Column.GetCellContent(item) as CheckBox);
                                showinfo = (dataGrid.SelectedCells[9].Column.GetCellContent(item) as TextBlock).Text;
                                showcheckworkid = (dataGrid.SelectedCells[10].Column.GetCellContent(item) as TextBlock).Text;

                                if (cbk1.IsChecked == true)
                                {
                                    paytoday = 250;
                                    status = "มาปกติ";
                                }

                                if (cbk2.IsChecked == true)
                                {
                                    paytoday = 180;
                                    status = "มาครึ่งวันเช้า";
                                }

                                if (cbk3.IsChecked == true)
                                {
                                    paytoday = 180;
                                    status = "มาครึ่งวันหลัง";
                                }

                                if (cbk4.IsChecked == true)
                                {
                                    paytoday = 0;
                                    status = "ขาด";
                                }

                                sql = "update checkwork set checkDate='" + Convert.ToDateTime(datePick1.Text).ToString("yyyy/MM/dd") + "',checkID='" + showid + "',checkName='" + showname + "',checkLastname='"+showlastname+"',checkStatus='" + status + "',checkPay='" + paytoday + "',checkInfo='" + showinfo + "',saveInfo=now() WHERE checkworkID='" + showcheckworkid + "'";

                                cmd.CommandText = sql;
                                cmd.ExecuteNonQuery();

                            } //ปิด Event Loop
                        }
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } //ปิด if else ในการแสดง MessageResult Yes no
        }
    }
}
