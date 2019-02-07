using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
using Dapper;

namespace Project2016App
{
    /// <summary>
    /// Interaction logic for ReportDecided.xaml
    /// </summary>
    public partial class ReportDecided : Window
    {

        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui");

        public ReportDecided()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH");
            DateTime datenow = DateTime.Now;
            var startDate = new DateTime(datenow.Year, datenow.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            datePick1.Text = startDate.ToShortDateString();
            datePick2.Text = endDate.ToShortDateString();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(datePick1.Text) || string.IsNullOrWhiteSpace(datePick2.Text))
            {
                MessageBox.Show("กรุณาเลือกวันที่ต้องการค้นหา!!!", "คำเตือน");
                return;
            }

            string selectsql = @"SELECT stockhistory.*,stock.stockID,product.proCode,product.proName,typeunit.typenameUnit,typeproduct.typepName FROM stockhistory
            left join stock on stockhistory.stockID=stock.stockID
            left join product on stock.proID=product.proID
            left join typeproduct on product.typepID=typeproduct.typepID
            left join typeunit on product.typeunitID=typeunit.typeunitID
            WHERE (stockhisDate BETWEEN '" + Convert.ToDateTime(datePick1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datePick2.Text).ToString("yyyy-MM-dd") + "')";

            con.Open();
            MySqlDataAdapter adpsql = new MySqlDataAdapter(selectsql, con);
            DataSet dtsql = new DataSet();
            adpsql.Fill(dtsql);
            dataGrid.ItemsSource = dtsql.Tables[0].DefaultView;
            dataGrid.CanUserAddRows = false;
            con.Close();
        }

        private void bt_Print_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGrid.SelectedItem;

            string showdate = (dataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

            using(IDbConnection db =new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui"))
            {

                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                    string getsql = @"SELECT stockhistory.*,stock.stockID,product.proCode,product.proName,typeunit.typenameUnit,typeproduct.typepName FROM stockhistory
                    left join stock on stockhistory.stockID=stock.stockID
                    left join product on stock.proID=product.proID
                    left join typeproduct on product.typepID=typeproduct.typepID
                    left join typeunit on product.typeunitID=typeunit.typeunitID
                    WHERE stockhisDate='" + Convert.ToDateTime(showdate).ToString("yyyy-MM-dd") + "'";
                    List<DecidedDetails> list = db.Query<DecidedDetails>(getsql, commandType: CommandType.Text).ToList();
                    using (frmPrintDecided frm=new frmPrintDecided(list))
                    {
                        frm.ShowDialog();
                    }
                }

            }

        }

        private void bt_Edit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
