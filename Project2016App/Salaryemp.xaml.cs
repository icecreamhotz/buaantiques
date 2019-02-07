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
    /// Interaction logic for Salaryemp.xaml
    /// </summary>
    public partial class Salaryemp : Window
    {

        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui;");
        DateTime dat = DateTime.Now;

        public Salaryemp()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, RoutedEventArgs e)
        {
            var startMonth = new DateTime(dat.Year, dat.Month, 1);
            var endMonth = startMonth.AddMonths(1).AddDays(-1);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("th-TH");
            datePicker1.Text = startMonth.ToShortDateString();
            datePicker2.Text = endMonth.ToShortDateString();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string[] lnwza = datePicker1.Text.Split('/');

            con.Open();
            MySqlDataAdapter adpsearch = new MySqlDataAdapter("SELECT * FROM salary WHERE (sMonth BETWEEN '" + Convert.ToDateTime(datePicker1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datePicker2.Text).ToString("yyyy-MM-dd") + "')", con);
            DataSet dt = new DataSet();
            adpsearch.Fill(dt);
            dataGrid.ItemsSource = dt.Tables[0].DefaultView;
            columnDate.Binding = new Binding("sMonth") { StringFormat = "d MMMMM " + lnwza[2] , ConverterCulture= Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("th-TH")};
            dataGrid.CanUserAddRows = false;
            con.Close();
        }
    }
}
