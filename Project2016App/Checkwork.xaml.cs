using MySql.Data.MySqlClient;
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
using System.Data;
using System.Threading;
using System.Globalization;

namespace Project2016App
{
    /// <summary>
    /// Interaction logic for Checkwork.xaml
    /// </summary>
    public partial class Checkwork : Window
    {

        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui");
        CheckBox cbk1,cbk2,cbk3,cbk4;
        int paytoday;
        string status = "";
        string showname, showid, showlastname,showinfo="";

        public Checkwork()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, RoutedEventArgs e)
        {
            DateTime timenow = DateTime.Now;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH");
            dateTimepicker.Text = timenow.ToShortDateString();

            comboBox.SelectedIndex = 0;

            con.Open();
            string sql = "select employee.idEmp,employee.nameEmp,employee.LastnameEmp,checkwork.checkInfo from employee left join checkwork on employee.idEmp=checkwork.checkInfo";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);

            dataGrid.ItemsSource = ds.Tables[0].DefaultView;
            dataGrid.CanUserAddRows = false;

            con.Close();
        }

        private void AfterChange(object sender, TextChangedEventArgs e)
        {
            if (comboBox.Text == "รหัสพนักงาน")
            {
                MySqlDataAdapter adt = new MySqlDataAdapter("SELECT idEmp,nameEmp FROM employee WHERE idEmp LIKE '" + textBox.Text + "'", con);
                DataSet ds = new DataSet();
                adt.Fill(ds);
                dataGrid.ItemsSource = ds.Tables[0].DefaultView;
                dataGrid.CanUserAddRows = false;
            }
            else if (comboBox.Text == "ชื่อพนักงาน")
            {
                MySqlDataAdapter adt = new MySqlDataAdapter("SELECT idEmp,nameEmp FROM employee WHERE nameEmp LIKE '" + textBox.Text + "'", con);
                DataSet ds = new DataSet();
                adt.Fill(ds);
                dataGrid.ItemsSource = ds.Tables[0].DefaultView;
                dataGrid.CanUserAddRows = false;
            }

        }

        private void AfterChoose(object sender, EventArgs e)
        {
            if (comboBox.Text == "แสดงทั้งหมด")
            {
                textBox.IsEnabled = false;
                textBox.Text = "";
                MySqlDataAdapter adt = new MySqlDataAdapter("SELECT idEmp,nameEmp,LastnameEmp FROM employee", con);
                DataSet dt = new DataSet();
                adt.Fill(dt);
                dataGrid.ItemsSource = dt.Tables[0].DefaultView;
                dataGrid.CanUserAddRows = false;
            }
            else
            {
                textBox.IsEnabled = true;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.SelectedIndex = 0;
            // เช็ค Checkbox ว่ามีหลายช่องไหม
            for (int i = 0; i < dataGrid.Items.Count; i++)
            {
                object item = dataGrid.Items[i];
                cbk1 = (dataGrid.SelectedCells[3].Column.GetCellContent(item) as CheckBox);
                cbk2 = (dataGrid.SelectedCells[4].Column.GetCellContent(item) as CheckBox);
                cbk3 = (dataGrid.SelectedCells[5].Column.GetCellContent(item) as CheckBox);
                cbk4 = (dataGrid.SelectedCells[6].Column.GetCellContent(item) as CheckBox);

                if (cbk1.IsChecked == true && cbk2.IsChecked == true ||
                    cbk1.IsChecked == true && cbk3.IsChecked == true ||
                    cbk1.IsChecked == true && cbk4.IsChecked == true ||
                    cbk2.IsChecked == true && cbk3.IsChecked == true ||
                    cbk2.IsChecked == true && cbk4.IsChecked == true ||
                    cbk3.IsChecked == true && cbk3.IsChecked == true ||
                    cbk3.IsChecked == true && cbk4.IsChecked == true)
                {
                    MessageBox.Show("กรุณาเลือกสถานะเช็คเข้าทำงานแค่ช่องเดียวเท่านั้น!!!", "คำเตือน");
                    return;
                }

                if(cbk1.IsChecked==false && cbk2.IsChecked == false && cbk3.IsChecked == false && cbk4.IsChecked == false)
                {
                    MessageBox.Show("คุณเช็คสถานะไม่ครบ!!!", "คำเตือน");
                    return;
                }

            } //ปิด Loop เช็ค

            if (dateTimepicker.SelectedDate == null)
              {
                  MessageBox.Show("กรุณาใส่วันที่ด้วยครับ");
                  return;
              }

              con.Open();
              string readersql1 = "select checkDate from checkwork WHERE checkDate='" + Convert.ToDateTime(dateTimepicker.Text).ToString("yyyy-MM-dd") + "'";
              MySqlCommand commandnaja = new MySqlCommand(readersql1, con);
              MySqlDataReader readdata = commandnaja.ExecuteReader();

              while (readdata.Read())
              {
                  string datecheck = Convert.ToDateTime(readdata["checkDate"]).ToString("dd/MM/yyyy");

                  var myDate = DateTime.Parse(datecheck);
                  var newDate = myDate.AddYears(-543);
                  datecheck = newDate.ToShortDateString();

                  if (datecheck == dateTimepicker.Text)
                  {
                      MessageBox.Show("คุณบันทึกการเข้าทำงานวันนี้ไปแล้ว กรุณาแก้ไขหรือลบก่อนครับ!!!");
                      con.Close();
                      return;
                  }
              }
              con.Close();

              MessageBoxResult result = MessageBox.Show("คุณต้องการจะบันทึกหรือไม่", "บันทึกเรียบแล้วร้อย", MessageBoxButton.YesNo, MessageBoxImage.Question);

              if (result != MessageBoxResult.Yes)
              {
                  return;
              }
              else
              {
                  MessageBox.Show("บันทึกข้อมูลสำเร็จแล้ว!!");

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
                                  showid = (dataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                                  showname = (dataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                                  showlastname = (dataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                                  cbk1 = (dataGrid.SelectedCells[3].Column.GetCellContent(item) as CheckBox);
                                  cbk2 = (dataGrid.SelectedCells[4].Column.GetCellContent(item) as CheckBox);
                                  cbk3 = (dataGrid.SelectedCells[5].Column.GetCellContent(item) as CheckBox);
                                  cbk4 = (dataGrid.SelectedCells[6].Column.GetCellContent(item) as CheckBox);
                                  showinfo = (dataGrid.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;   

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


                                  cmd.CommandText= @"INSERT INTO checkwork (checkDate,checkID,checkName,checkLastname,checkStatus,checkPay,checkInfo,saveInfo) VALUES (@Date,@ID,@NAME,@LASTNAME,@STATUS,@PAY,@INFO,@INFOSAVE)";
                                  cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(dateTimepicker.Text).ToString("yyyy/MM/dd"));
                                  cmd.Parameters.AddWithValue("@ID", showid);
                                  cmd.Parameters.AddWithValue("@NAME" , showname);
                                  cmd.Parameters.AddWithValue("@LASTNAME", showlastname);
                                  cmd.Parameters.AddWithValue("@STATUS", status);
                                  cmd.Parameters.AddWithValue("@PAY", paytoday);
                                  cmd.Parameters.AddWithValue("@INFO", showinfo);
                                  cmd.Parameters.AddWithValue("@INFOSAVE", DateTime.Now);
                                  cmd.ExecuteNonQuery();
                                  cmd.Parameters.Clear();

                                  cbk1.IsChecked = false;
                                  cbk2.IsChecked = false;
                                  cbk3.IsChecked = false;
                                  cbk4.IsChecked = false;

                              } //ปิด Event Loop
                          }

                          con.Close();
                      }
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message);
                  }
              } //ปิด if else ในการแสดง MessageResult Yes no
        }// ปิด Event การกด Click 

    }
}
