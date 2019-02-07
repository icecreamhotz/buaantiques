using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using Dapper;

namespace Project2016App
{
    /// <summary>
    /// Interaction logic for Historysell.xaml
    /// </summary>
    public partial class Historysell : Window
    {
        List<String> listcode = new List<string>();

        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui;");

        public Historysell()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, RoutedEventArgs e)
        {
            DateTime date = DateTime.Now;
            var startDate = new DateTime(date.Year, date.Month,1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("th-TH");
            datePick1.Text = startDate.ToShortDateString();
            datePick2.Text = endDate.ToShortDateString();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            cbkBill.IsChecked = false;
            SearchBill.IsEnabled = false;

            dataGrid.Columns[6].Visibility = Visibility.Visible;
            dataGrid.Columns[7].Visibility = Visibility.Visible;
            dataGrid.Columns[8].Visibility = Visibility.Visible;
            dataGrid.Columns[9].Visibility = Visibility.Visible;
            dataGrid.Columns[10].Visibility = Visibility.Visible;
            dataGrid.Columns[11].Visibility = Visibility.Visible;
            dataGrid.Columns[12].Visibility = Visibility.Visible;

            dataGrid.Columns[0].Width = 100;
            dataGrid.Columns[1].Width = 100;
            dataGrid.Columns[2].Width = 100;
            dataGrid.Columns[3].Width = 100;
            dataGrid.Columns[4].Width = 100;
            dataGrid.Columns[5].Width = 100;

            receiptInfo.Header = "รหัสสินค้า";
            receiptPrice.Header = "ชื่อสินค้า";

            dateColumn.Binding = new Binding("sellDate") { StringFormat = "dd/MM/yyyy" };
            codeColumn.Binding = new Binding("docID");
            receiptInfo.Binding = new Binding("sellCode");
            receiptPrice.Binding = new Binding("sellName");

            con.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT selltoday.*,typeproduct.typepName FROM selltoday left join typeproduct on selltoday.typepID=typeproduct.typepID WHERE sellDate between ('" + Convert.ToDateTime(datePick1.Text).ToString("yyyy-MM-dd") + "') AND ('" + Convert.ToDateTime(datePick2.Text).ToString("yyyy-MM-dd") + "')", con);
            DataSet dt = new DataSet();
            adp.Fill(dt);
            dataGrid.ItemsSource = dt.Tables[0].DefaultView;
            dataGrid.CanUserAddRows = false;
            con.Close();
        }

        private void Check_Bill(object sender, RoutedEventArgs e)
        {
            if (cbkBill.IsChecked == true)
            {
                Search.IsEnabled = false;
                dataGrid.Columns[6].Visibility = Visibility.Collapsed;
                dataGrid.Columns[7].Visibility = Visibility.Collapsed;
                dataGrid.Columns[8].Visibility = Visibility.Collapsed;
                dataGrid.Columns[9].Visibility = Visibility.Collapsed;
                dataGrid.Columns[10].Visibility = Visibility.Collapsed;
                dataGrid.Columns[11].Visibility = Visibility.Collapsed;
                dataGrid.Columns[12].Visibility = Visibility.Collapsed;

                dataGrid.Columns[0].Width = 200;
                dataGrid.Columns[1].Width = 200;
                dataGrid.Columns[2].Width = 200;
                dataGrid.Columns[3].Width = 200;
                dataGrid.Columns[4].Width = 200;
                dataGrid.Columns[5].Width = 200;

                receiptInfo.Header = "หมายเหตุ";
                receiptPrice.Header = "เงินที่จ่าย";

                dateColumn.Binding = new Binding("receiptDate") { StringFormat = "dd/MM/yyyy" };
                codeColumn.Binding = new Binding("receiptCode");
                receiptInfo.Binding = new Binding("receiptInfo");
                receiptPrice.Binding = new Binding("receiptPriceall");

                con.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM receiptsell WHERE receiptDate between ('" + Convert.ToDateTime(datePick1.Text).ToString("yyyy-MM-dd") + "') AND ('" + Convert.ToDateTime(datePick2.Text).ToString("yyyy-MM-dd") + "')", con);
                DataSet dt = new DataSet();
                adp.Fill(dt);
                dataGrid.ItemsSource = dt.Tables[0].DefaultView;
                dataGrid.CanUserAddRows = false;
                con.Close();
            }
            else
            {
                Search.IsEnabled = true;
                SearchBill.IsEnabled = false;
            }
        }

        private void SearchBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                dataGrid.Columns[6].Visibility = Visibility.Collapsed;
                dataGrid.Columns[7].Visibility = Visibility.Collapsed;
                dataGrid.Columns[8].Visibility = Visibility.Collapsed;
                dataGrid.Columns[9].Visibility = Visibility.Collapsed;
                dataGrid.Columns[10].Visibility = Visibility.Collapsed;
                dataGrid.Columns[11].Visibility = Visibility.Collapsed;
                dataGrid.Columns[12].Visibility = Visibility.Collapsed;

                dataGrid.Columns[0].Width = 200;
                dataGrid.Columns[1].Width = 200;
                dataGrid.Columns[2].Width = 200;
                dataGrid.Columns[3].Width = 200;
                dataGrid.Columns[4].Width = 200;
                dataGrid.Columns[5].Width = 200;

                receiptInfo.Header = "หมายเหตุ";
                receiptPrice.Header = "เงินที่จ่าย";

                dateColumn.Binding = new Binding("receiptDate") { StringFormat = "dd/MM/yyyy" };
                codeColumn.Binding = new Binding("receiptCode");
                receiptInfo.Binding = new Binding("receiptInfo");
                receiptPrice.Binding = new Binding("receiptPriceall");

                string getSql = "SELECT receiptCode FROM receiptsell";

                con.Open();
                MySqlCommand cmd = new MySqlCommand(getSql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listcode.Add(reader[0].ToString());
                }
                con.Close();

                if (!listcode.Contains(SearchBill.Text))
                {
                    MessageBox.Show("กรุณาค้นหาสินค้าใหม่ครับไม่พบสินค้า!!!");
                    return;
                }
                else
                {
                    con.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM receiptsell WHERE (receiptDate BETWEEN '" + Convert.ToDateTime(datePick1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datePick2.Text).ToString("yyyy-MM-dd") + "') AND (receiptCode='" + SearchBill.Text + "')", con);
                    DataSet dt = new DataSet();
                    adapter.Fill(dt);
                    dataGrid.ItemsSource = dt.Tables[0].DefaultView;
                    dataGrid.CanUserAddRows = false;
                    con.Close();
                }
            }
            else
            {
                return;
            }
        }

        private void Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGrid.SelectedItem;

            string showid = (dataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;

            using (IDbConnection db = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui;"))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                string query = @"SELECT selltoday.*,typeproduct.typepName,receiptsell.receiptPriceall FROM selltoday 
                left join typeproduct on selltoday.typepID=typeproduct.typepID 
                left join receiptsell on selltoday.docID=receiptsell.receiptCode
                WHERE selltoday.docID='" + showid + "'";
                List<Selldetails> list = db.Query<Selldetails>(query, commandType: CommandType.Text).ToList();
                using (frmPrintsell frm = new frmPrintsell(list))
                {
                    frm.ShowDialog();
                }
            }
        }
    }
}
