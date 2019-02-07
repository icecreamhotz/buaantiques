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
    /// Interaction logic for SearchAccount.xaml
    /// </summary>
    public partial class SearchAccount : Window
    {

        public string sendAcc { get; set; }
        public string sendItem { get; set; }
        public string sendStatus { get; set; }

        public SearchAccount()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui;");

        private void DoubleClick(object sender, MouseButtonEventArgs e)
        {
            object item = dataGrid.SelectedItem;

            Typeledger go = new Typeledger();
            sendAcc = (dataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            sendItem = (dataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            sendStatus = (dataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            this.Close();
        }


        private void cbkInfo_Checked(object sender, RoutedEventArgs e)
        {
            if (cbkInfo.IsChecked == true)
            {
                cbkCode.IsChecked = false;
            }
        }

        private void cbkCode_Checked(object sender, RoutedEventArgs e)
        {
            if (cbkCode.IsChecked == true)
            {
                cbkInfo.IsChecked = false;
            }
        }

        private void PressEnterSearchTB(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }
            else
            {
                if (cbkInfo.IsChecked == true)
                {
                    con.Open();
                    MySqlDataAdapter adpter = new MySqlDataAdapter("SELECT typeledger.*,ledger.ledgerName FROM typeledger left join ledger on typeledger.ledgerID=ledger.ledgerID WHERE typeledgerName LIKE '%" + txtSearch.Text + "%'", con);
                    DataSet dt = new DataSet();
                    adpter.Fill(dt);
                    dataGrid.ItemsSource = dt.Tables[0].DefaultView;
                    dataGrid.CanUserAddRows = false;
                    con.Close();
                }
                if (cbkCode.IsChecked == true)
                {
                    con.Open();
                    MySqlDataAdapter adpter = new MySqlDataAdapter("SELECT typeledger.*,ledger.ledgerName FROM typeledger left join ledger on typeledger.ledgerID=ledger.ledgerID  WHERE typeledgerCode LIKE '%" + txtSearch.Text + "%'", con);
                    DataSet dt = new DataSet();
                    adpter.Fill(dt);
                    dataGrid.ItemsSource = dt.Tables[0].DefaultView;
                    dataGrid.CanUserAddRows = false;
                    con.Close();
                }
            }
        }

    }
}
