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
    /// Interaction logic for Typeaccount.xaml
    /// </summary>
    public partial class Typeledger : Window
    {

        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui");
        string getLedgerCode, getLedgername, getLedgerID,gettypeLedgerCode;
        string strNameledger;
        int showCode;

        public Typeledger()
        {
            InitializeComponent();
        }

        private void Form_load(object sender, RoutedEventArgs e)
        {
            ShowTextcode();
            txtAcc.IsEnabled = false;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SearchAccount go = new SearchAccount();
            go.sendAcc = txtAcc.Text;
            go.sendItem = txtItem.Text;
            go.sendStatus = typeComboBox.Text;
            go.ShowDialog();

            txtAcc.Text = go.sendAcc;
            txtItem.Text = go.sendItem;
            typeComboBox.SelectedItem = go.sendStatus;
        }

        private void btAddledger_Click(object sender, RoutedEventArgs e)
        {
            checkNameLedger();

            if (txtLedger.Text == strNameledger)
            {
                MessageBox.Show("คุณมีข้อมูลนี้แล้วครับ!!!");
            }
            else
            {
                string addledger = "INSERT INTO ledger (ledgerName) VALUES (@Ledger)";
                MySqlCommand cmdadd = new MySqlCommand(addledger, con);
                cmdadd.Parameters.AddWithValue("@Ledger", txtLedger.Text);
                cmdadd.Connection.Open();
                cmdadd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("บันทึกเรียบร้อยแล้ว!!!");
                txtLedger.Text = "";
            }
        }

        private void checkNameLedger()
        {
            con.Open();
            string checksql = "SELECT ledgerName FROM ledger WHERE ledgername='" + txtLedger.Text + "'" ;
            MySqlCommand cmdcheck = new MySqlCommand(checksql, con);
            MySqlDataReader readercheck = cmdcheck.ExecuteReader();
            while (readercheck.Read())
            {
                strNameledger = readercheck.GetString(readercheck.GetOrdinal("ledgerName"));
            }
            con.Close();
        }

        private void ComBoboxLedgerLoad(object sender, RoutedEventArgs e)
        {
            con.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT ledgerName FROM ledger", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach(DataRow row in dt.Rows)
            {
                string getdata = string.Format("{0}", row.ItemArray[0]);
                typeComboBox.Items.Add(getdata);
                typeComboBox.SelectedIndex = 0;
            }
            con.Close();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtAcc.Text == "" || txtItem.Text == "" || typeComboBox.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ!!!");
                return;
            }

            getData();

            if(txtAcc.Text== gettypeLedgerCode)
            {
                MessageBoxResult result = MessageBox.Show("คุณมีข้อมูลนี้แล้วต้องการจะแก้ไขไหม ???", "แก้ไขเรียบร้อยแล้ว!!!", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result != MessageBoxResult.Yes)
                {
                    return;
                }
                else
                {
                    MySqlCommand cmdinsert = new MySqlCommand("UPDATE typeledger SET typeledgerCode='"+txtAcc.Text+"',typeledgerName='"+txtItem.Text+"',ledgerID='"+getLedgerID+"'", con);
                    cmdinsert.Connection.Open();
                    cmdinsert.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้วครับ!!!");
                    txtItem.Text = "";
                    typeComboBox.SelectedIndex = 0;
                    ShowTextcode();
                }
            }

            else  
            
            if (txtItem.Text == getLedgername)
            {
                MessageBox.Show("คุณมีข้อมูลนี้แล้ว!!!");
                return;
            }
            else
            {
                MySqlCommand cmdinsert = new MySqlCommand("INSERT INTO typeledger (typeledgerCode,typeledgerName,ledgerID) VALUES (@Code,@Name,@ledgerID)", con);
                cmdinsert.Parameters.AddWithValue("@Code",txtAcc.Text);
                cmdinsert.Parameters.AddWithValue("@Name", txtItem.Text);
                cmdinsert.Parameters.AddWithValue("@ledgerID", getLedgerID);
                cmdinsert.Connection.Open();
                cmdinsert.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้วครับ!!!");
                txtItem.Text = "";
                typeComboBox.SelectedIndex = 0;
                ShowTextcode();
            }
        }

        private void ShowTextcode()
        {
            con.Open();
            MySqlCommand cmdset = new MySqlCommand("SELECT typeledgerCode FROM typeledger", con);
            MySqlDataReader reader = cmdset.ExecuteReader();
            txtAcc.Text = "001";
            while (reader.Read())
            {
                getLedgerCode = reader["typeledgerCode"].ToString();
                if (getLedgerCode != "")
                {
                    showCode = Convert.ToInt32(getLedgerCode);
                    showCode += 1;
                    txtAcc.Text = showCode.ToString("000");
                }
            }
            con.Close();
        }

        private void getData()
        {
            con.Open();
            MySqlCommand cmdledger = new MySqlCommand("SELECT ledgerID FROM ledger WHERE ledgerName='"+ typeComboBox.SelectedItem +"'", con);
            MySqlDataReader readerledger = cmdledger.ExecuteReader();
            while (readerledger.Read())
            {
                getLedgerID = readerledger.GetString(readerledger.GetOrdinal("ledgerID"));
            }
            con.Close();

            con.Open();
            MySqlCommand cmdtypeledger = new MySqlCommand("SELECT typeledgerName,typeledgerCode FROM typeledger WHERE (typeledgerName='" + txtItem.Text + "') OR (typeledgerCode='" + txtAcc.Text + "')", con);
            MySqlDataReader readertypeledger = cmdtypeledger.ExecuteReader();
            while (readertypeledger.Read())
            {
                getLedgername = readertypeledger.GetString(readertypeledger.GetOrdinal("typeledgerName"));
                gettypeLedgerCode = readertypeledger.GetString(readertypeledger.GetOrdinal("typeledgerCode"));
            }
            con.Close();
        }

    }
}
