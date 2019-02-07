using System;
using System.Windows;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading;
using System.Xaml;
using System.Globalization;
using System.Collections.Generic;

namespace Project2016App
{
    /// <summary>
    /// Interaction logic for CheckIncome.xaml
    /// </summary>
    public partial class CheckIncome : Window
    {

        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui;");
        int i;
        double getRub, getPay,totalIncome,totalEtc,showRub,showPay;
        string getcalculate = "" , getorder = "" ;
        string strTypename,strRub, strPay;

        public CheckIncome()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH");
            DateTime fmDate = DateTime.Now;
            var endDate = new DateTime(fmDate.Year, fmDate.Month, 30);
            datepicker1.Text = fmDate.ToShortDateString();
            datepicker2.Text = endDate.ToShortDateString();
            CheckIsenable();
        }

        private void rbtGet_Click(object sender, RoutedEventArgs e)
        {
            CheckboxClick();
        }

        private void rbtPay_Click(object sender, RoutedEventArgs e)
        {
            CheckboxClick();
        }

        private void rbtShowAll(object sender, RoutedEventArgs e)
        {
            CheckboxClick();
        }

        private void cbkRub_Click(object sender, RoutedEventArgs e)
        {
            CheckIsenable();

            if (cbkRub.IsChecked == true)
            {
                cbkPay.IsChecked = false;
                txtSearchrub.IsEnabled = true;
                txtMoneyrub.IsEnabled = true;
            }
            else
            {
                CheckIsenable();
            }
        }

        private void cbkPay_Click(object sender, RoutedEventArgs e)
        {
            CheckIsenable();

            if (cbkPay.IsChecked == true)
            {
                cbkRub.IsChecked = false;
                txtSearchpay.IsEnabled = true;
                txtMoneypay.IsEnabled = true;
            }
            else
            {
                CheckIsenable();
            }
        }

        private void CheckboxClick()
        {
            if (rbtGet.IsChecked == true)
            {
                con.Open();
                MySqlDataAdapter adpget = new MySqlDataAdapter("SELECT income.*,typeledger.typeledgerName,ledger.ledgerName FROM income left join typeledger on income.typeledgerID=typeledger.typeledgerID left join ledger on income.ledgerID=ledger.ledgerID WHERE ledger.ledgerName='รายรับ'", con);
                DataSet dtget = new DataSet();
                adpget.Fill(dtget);
                dataGrid.ItemsSource = dtget.Tables[0].DefaultView;
                dataGrid.CanUserAddRows = false;
                con.Close();
            }

            if (rbtPay.IsChecked == true)
            {
                con.Open();
                MySqlDataAdapter adppay = new MySqlDataAdapter("SELECT income.*,typeledger.typeledgerName,ledger.ledgerName FROM income left join typeledger on income.typeledgerID=typeledger.typeledgerID left join ledger on income.ledgerID=ledger.ledgerID WHERE ledger.ledgerName='รายจ่าย'", con);
                DataSet dtpay = new DataSet();
                adppay.Fill(dtpay);
                dataGrid.ItemsSource = dtpay.Tables[0].DefaultView;
                dataGrid.CanUserAddRows = false;
                con.Close();
            }

            if (rbtShowall.IsChecked == true)
            {
                con.Open();
                MySqlDataAdapter adpshowall = new MySqlDataAdapter("SELECT income.*,typeledger.typeledgerName,ledger.ledgerName FROM income left join typeledger on income.typeledgerID=typeledger.typeledgerID left join ledger on income.ledgerID=ledger.ledgerID ORDER BY income.incomeID", con);
                DataSet dtshowall = new DataSet();
                adpshowall.Fill(dtshowall);
                dataGrid.ItemsSource = dtshowall.Tables[0].DefaultView;
                dataGrid.CanUserAddRows = false;
                con.Close();
            }
        }

        private void CheckIsenable()
        {
            txtSearchrub.IsEnabled = false;
            txtSearchpay.IsEnabled = false;
            txtMoneyrub.IsEnabled = false;
            txtMoneypay.IsEnabled = false;
            rbtGet.IsChecked = false;
            rbtPay.IsChecked = false;
            rbtShowall.IsChecked = false;
        }

        private void PressEnterSearchRub(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }
            else
            {
                if (datepicker1.Text == "" || datepicker2.Text == "")
                {
                    MessageBox.Show("กรุณากรอกวันที่!!!");
                    return;
                }
                else
                {
                    i = 1;
                }
            }
            MySqlCommand();
            CalculatefromSql();
            CheckCalculatefromsql();
            EtcRubandPay();
        }

        private void PressEnterSearchMoneyRub(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }
            else
            {
                if (datepicker1.Text == "" || datepicker2.Text == "")
                {
                    MessageBox.Show("กรุณากรอกวันที่!!!");
                    return;
                }
                else
                {
                    i = 1;
                }
            }
            MySqlCommand();
            CalculatefromSql();
            CheckCalculatefromsql();
            EtcRubandPay();
        }

        private void PressEnterPay(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }
            else
            {
                if(datepicker1.Text=="" || datepicker2.Text == "")
                {
                    MessageBox.Show("กรุณากรอกวันที่!!!");
                    return;
                }
                i = 2;
            }
            MySqlCommand();
            CalculatefromSql();
            CheckCalculatefromsql();
            EtcRubandPay();
        }

        private void PressEnterMoneyPay(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }
            else
            {
                if (datepicker1.Text == "" || datepicker2.Text == "")
                {
                    MessageBox.Show("กรุณากรอกวันที่!!!");
                    return;
                }
                i = 2;
            }
            MySqlCommand();
            CalculatefromSql();
            CheckCalculatefromsql();
            EtcRubandPay();
        }

        private void CheckCalculatefromsql()
        {
            if (i == 1)
            {
                if (getRub > getPay || getRub < getPay)
                {
                    totalIncome = getRub - getPay;

                    lbRub.Content = ("ระยะเวลาที่ค้นหาคุณมีรายรับทั้งหมด : " + getRub + "บาท");
                    lbShoworderRub.Content = ("รายรับที่สูงสุดคือ : " + strTypename + "    จำนวนรับ : " + strRub);
                    showRub = getRub;
                    getRub = 0;
                    getPay = 0;

                    totalIncome = 0;
                }
              
            }

            if (i == 2)
            {
                if (getRub < getPay || getRub > getPay)
                {
                    totalIncome = getPay - getRub;
                    
                    lbPay.Content = ("ระยะเวลาที่ค้นหาคุณมีรายจ่ายทั้งหมด : " + getPay + "บาท");
                    lbShoworderPay.Content = ("รายจ่ายที่สูงที่สุดคือ :   " + strTypename + "    จำนวนจ่าย : " + strPay);
                    showPay = getPay;
                    getRub = 0;
                    getPay = 0;

                    totalIncome = 0;
                }
            }

        }

        private void EtcRubandPay()
        {
            if (getRub == 0)
            {
                etcRub.Content = ("รายรับทั้งหมด :   " + showRub + "  บาท");
            }

            if (getPay == 0)
            {
                etcPay.Content = ("รายจ่ายทั้งหมด :   " + showPay + "  บาท");
            }

            if (getRub == 0 && getPay == 0)
            {
                if (showRub > showPay)
                {
                    totalEtc = showRub - showPay;
                    etcInfo.Content = ("คุณมีรายรับมากกว่ารายจ่าย :   " + totalEtc + "  บาท");
                    totalEtc = 0;
                }

                if (getPay > getRub)
                {
                    totalEtc = getPay - getRub;
                    etcInfo.Content = ("คุณมีรายจ่ายมากกว่ารายรับ :   " + totalEtc + "  บาท");
                    totalEtc = 0;
                }
            }

        }

        private void StringSQL()
        {

            if (i == 1)
            {
                if (txtSearchrub.Text != "" && txtMoneyrub.Text != "")
                {
                    getcalculate = @"SELECT income.*,typeledger.typeledgerName FROM income left join typeledger on income.typeledgerID=typeledger.typeledgerID 
                    WHERE (incomeDate BETWEEN '" + Convert.ToDateTime(datepicker1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datepicker2.Text).ToString("yyyy-MM-dd") + "') AND (typeledgerName LIKE '%" + txtSearchrub.Text + "%' AND incomeGet >= '" + Convert.ToDouble(txtMoneyrub.Text) + "')";

                    getorder = @"SELECT income.*,typeledger.typeledgerName FROM income left join typeledger on income.typeledgerID=typeledger.typeledgerID 
                    WHERE (incomeDate BETWEEN '" + Convert.ToDateTime(datepicker1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datepicker2.Text).ToString("yyyy-MM-dd") + "') AND (typeledgerName LIKE '%" + txtSearchrub.Text + "%' AND incomeGet >= '" + Convert.ToDouble(txtMoneyrub.Text) + "') ORDER BY incomeGet DESC LIMIT 1";
                }

                if (txtMoneyrub.Text != "")
                {
                    if (txtSearchrub.Text == "")
                    {
                        getcalculate = @"SELECT income.*,typeledger.typeledgerName FROM income left join typeledger on income.typeledgerID=typeledger.typeledgerID 
                    WHERE (incomeDate BETWEEN '" + Convert.ToDateTime(datepicker1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datepicker2.Text).ToString("yyyy-MM-dd") + "') AND (incomeGet >= '" + Convert.ToDouble(txtMoneyrub.Text) + "')";

                        getorder = @"SELECT income.*,typeledger.typeledgerName FROM income left join typeledger on income.typeledgerID=typeledger.typeledgerID 
                    WHERE (incomeDate BETWEEN '" + Convert.ToDateTime(datepicker1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datepicker2.Text).ToString("yyyy-MM-dd") + "') AND (incomeGet >= '" + Convert.ToDouble(txtMoneyrub.Text) + "') ORDER BY incomeGet DESC LIMIT 1";
                    }
                }

                if (txtSearchrub.Text != "")
                {
                    if (txtMoneyrub.Text == "")
                    {
                        getcalculate = @"SELECT income.*,typeledger.typeledgerName FROM income left join typeledger on income.typeledgerID=typeledger.typeledgerID 
                     WHERE (incomeDate BETWEEN '" + Convert.ToDateTime(datepicker1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datepicker2.Text).ToString("yyyy-MM-dd") + "') AND (typeledgerName LIKE '%" + txtSearchrub.Text + "%')";

                        getorder = @"SELECT income.*,typeledger.typeledgerName FROM income left join typeledger on income.typeledgerID=typeledger.typeledgerID 
                    WHERE (incomeDate BETWEEN '" + Convert.ToDateTime(datepicker1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datepicker2.Text).ToString("yyyy-MM-dd") + "') AND (typeledgerName LIKE '%" + txtSearchrub.Text + "%') ORDER BY incomeGet DESC LIMIT 1";
                    }
                }
            }

            if(i == 2)
            {
                if (txtSearchpay.Text != "" && txtMoneypay.Text != "")
                {
                    getcalculate = @"SELECT income.*,typeledger.typeledgerName FROM income left join typeledger on income.typeledgerID=typeledger.typeledgerID 
                    WHERE (incomeDate BETWEEN '" + Convert.ToDateTime(datepicker1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datepicker2.Text).ToString("yyyy-MM-dd") + "') AND (typeledgerName LIKE '%" + txtSearchpay.Text + "%' AND incomePay >= '" + Convert.ToDouble(txtMoneypay.Text) + "')";

                    getorder = @"SELECT income.*,typeledger.typeledgerName FROM income left join typeledger on income.typeledgerID=typeledger.typeledgerID 
                    WHERE (incomeDate BETWEEN '" + Convert.ToDateTime(datepicker1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datepicker2.Text).ToString("yyyy-MM-dd") + "') AND (typeledgerName LIKE '%" + txtSearchpay.Text + "%' AND incomePay >= '" + Convert.ToDouble(txtMoneypay.Text) + "') ORDER BY  incomePay DESC LIMIT 1";
                }

                if (txtMoneypay.Text != "")
                {
                    if (txtSearchpay.Text == "")
                    {
                        getcalculate = @"SELECT income.*,typeledger.typeledgerName FROM income left join typeledger on income.typeledgerID=typeledger.typeledgerID 
                    WHERE (incomeDate BETWEEN '" + Convert.ToDateTime(datepicker1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datepicker2.Text).ToString("yyyy-MM-dd") + "') AND (incomePay >= '" + Convert.ToDouble(txtMoneypay.Text) + "')";

                        getorder = @"SELECT income.*,typeledger.typeledgerName FROM income left join typeledger on income.typeledgerID=typeledger.typeledgerID 
                    WHERE (incomeDate BETWEEN '" + Convert.ToDateTime(datepicker1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datepicker2.Text).ToString("yyyy-MM-dd") + "') AND (incomePay >= '" + Convert.ToDouble(txtMoneypay.Text) + "') ORDER BY  incomePay DESC LIMIT 1";
                    }
                }

                if (txtSearchpay.Text != "")
                {
                    if (txtMoneypay.Text == "")
                    {
                        getcalculate = @"SELECT income.*,typeledger.typeledgerName FROM income left join typeledger on income.typeledgerID=typeledger.typeledgerID 
                     WHERE (incomeDate BETWEEN '" + Convert.ToDateTime(datepicker1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datepicker2.Text).ToString("yyyy-MM-dd") + "') AND (typeledgerName LIKE '%" + txtSearchpay.Text + "%')";

                        getorder = @"SELECT income.*,typeledger.typeledgerName FROM income left join typeledger on income.typeledgerID=typeledger.typeledgerID 
                    WHERE (incomeDate BETWEEN '" + Convert.ToDateTime(datepicker1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datepicker2.Text).ToString("yyyy-MM-dd") + "') AND (typeledgerName LIKE '%" + txtSearchpay.Text + "%') ORDER BY  incomePay DESC LIMIT 1";
                    }
                }
            }

        }

        private void MySqlCommand()
        {

            if (i == 1)
            {
                con.Open();
                MySqlDataAdapter adprub = new MySqlDataAdapter(@"SELECT income.*,typeledger.typeledgerName,ledger.ledgerName FROM income left join typeledger on income.typeledgerID=typeledger.typeledgerID left join ledger on income.ledgerID=ledger.ledgerID 
                    WHERE (incomeDate BETWEEN '" + Convert.ToDateTime(datepicker1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datepicker2.Text).ToString("yyyy-MM-dd") + "') AND (typeledger.typeledgerName LIKE '%" + txtSearchrub.Text + "%') AND (incomeGet >= '" + txtMoneyrub.Text + "')", con);
                DataSet dtrub = new DataSet();
                adprub.Fill(dtrub);
                dataGrid.ItemsSource = dtrub.Tables[0].DefaultView;
                dataGrid.CanUserAddRows = false;
                con.Close();
            }


            if (i == 2)
            {
                con.Open();
                MySqlDataAdapter adppay = new MySqlDataAdapter(@"SELECT income.*,typeledger.typeledgerName,ledger.ledgerName FROM income left join typeledger on income.typeledgerID=typeledger.typeledgerID left join ledger on income.ledgerID=ledger.ledgerID 
                    WHERE (incomeDate BETWEEN '" + Convert.ToDateTime(datepicker1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datepicker2.Text).ToString("yyyy-MM-dd") + "') AND (typeledger.typeledgerName LIKE '%" + txtSearchpay.Text + "%') AND (incomePay >= '" + txtMoneypay.Text + "')", con);
                DataSet dtpay = new DataSet();
                adppay.Fill(dtpay);
                dataGrid.ItemsSource = dtpay.Tables[0].DefaultView;
                dataGrid.CanUserAddRows = false;
                con.Close();
            }

        }

        private void CalculatefromSql()
        {
            StringSQL();
            con.Open();
            MySqlCommand cmdcalculate = new MySqlCommand(getcalculate, con);
            MySqlDataReader readcal = cmdcalculate.ExecuteReader();
            while (readcal.Read())
            {
                getRub += Convert.ToDouble(readcal["incomeGet"]);
                getPay += Convert.ToDouble(readcal["incomePay"]);
            }
            con.Close();

            con.Open();
            MySqlCommand cmdorder = new MySqlCommand(getorder, con);
            MySqlDataReader readorder = cmdorder.ExecuteReader();
            while (readorder.Read())
            {
                strTypename = readorder["typeledgerName"].ToString();
                strRub = readorder["incomeGet"].ToString();
                strPay = readorder["incomePay"].ToString();
            }
            con.Close();
        }

    }
}
