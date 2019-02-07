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
using System.IO;
using System.Threading;

namespace Project2016App
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Window
    {

        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui;");
        string getAccCode, getStatus;

        public Account()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, RoutedEventArgs e)
         {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("th-TH");
            datePicker1.Text = DateTime.Now.ToShortDateString();
            txtaccCode.IsEnabled = false;
         }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchAccount go = new SearchAccount();
            go.sendAcc = txtaccCode.Text;
            go.sendItem = showtxtaccItem.Text;
            go.sendStatus = showtxtaccStatus.Text;
            go.ShowDialog();

            txtaccCode.Text = go.sendAcc;
            showtxtaccItem.Text = go.sendItem;
            showtxtaccStatus.Text = go.sendStatus;

            if (showtxtaccStatus.Text == "รายรับ")
            {
                txtPay.IsEnabled = false;
                txtRub.IsEnabled = true;
            }

            if (showtxtaccStatus.Text == "รายจ่าย")
            {
                txtPay.IsEnabled = true;
                txtRub.IsEnabled = false;
            }

        }

        private void btInsert_Click(object sender, RoutedEventArgs e)
        {
            if (showtxtaccStatus.Text == "รายรับ")
            {
                if (string.IsNullOrEmpty(showtxtaccItem.Text) || string.IsNullOrEmpty(txtItem1.Text) || string.IsNullOrEmpty(txtRub.Text))
                {
                    MessageBox.Show("คุณกรอกข้อมูลไม่ครบ!!!", "ผิดพลาด");
                    return;
                }
            }

            if (showtxtaccStatus.Text == "รายจ่าย")
            {
                if (string.IsNullOrEmpty(showtxtaccItem.Text) || string.IsNullOrEmpty(txtItem1.Text) || string.IsNullOrEmpty(txtPay.Text))
                {
                    MessageBox.Show("คุณกรอกข้อมูลไม่ครบ!!!", "ผิดพลาด");
                    return;
                }
            }

            GetDataFromsql();

            string insertsql = "INSERT INTO income(incomeDate,typeledgerID,ledgerID,incomeInfo1,incomeGet,incomePay) VALUES (@incDate,@typeledgerCode,@ledgerID,@incomeinfo1,@incomeget,@incomepay)";
            MySqlCommand cmd = new MySqlCommand(insertsql, con);
            cmd.Parameters.AddWithValue("@incDate", Convert.ToDateTime(datePicker1.Text).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@typeledgerCode", getAccCode);
            cmd.Parameters.AddWithValue("@ledgerID", getStatus);
            cmd.Parameters.AddWithValue("@incomeinfo1", txtItem1.Text);
            cmd.Parameters.AddWithValue("@incomeget", txtRub.Text);
            cmd.Parameters.AddWithValue("@incomepay", txtPay.Text);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");

            ClearData();
        }

        private void GetDataFromsql()
        {
            con.Open();
            MySqlCommand cmdcode = new MySqlCommand("SELECT typeledgerID FROM typeledger WHERE typeledgerCode='" + txtaccCode.Text + "'", con);
            MySqlDataReader readcode = cmdcode.ExecuteReader();
            while (readcode.Read())
            {
                getAccCode = readcode.GetString(readcode.GetOrdinal("typeledgerID"));
            }
            con.Close();

            con.Open();
            MySqlCommand cmdID = new MySqlCommand("SELECT ledgerID FROM ledger WHERE ledgerName='" + showtxtaccStatus.Text + "'", con);
            MySqlDataReader readID = cmdID.ExecuteReader();
            while (readID.Read())
            {
                getStatus = readID.GetString(readID.GetOrdinal("ledgerID"));
            }
            con.Close();
        }

        private void ClearData()
        {
            txtaccCode.Text = "";
            txtItem1.Text = "";
            txtPay.Text = "";
            txtRub.Text = "";
            showtxtaccItem.Text = "";
            showtxtaccStatus.Text = "";
        }

        private void PressTxtAccCode(object sender, KeyEventArgs e)
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
                case Key.Decimal:
                    break;
                default:
                    e.Handled = true;
                    break;
            }
        }
        
    }
}
