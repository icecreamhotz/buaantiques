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

namespace Project2016App
{
    /// <summary>
    /// Interaction logic for Searchname.xaml
    /// </summary>
    public partial class Searchname : Window
    {

        public string sendID { get; set; }
        public string sendName { get; set; }
        public string sendLname { get; set; }
        public string sendAddress { get; set; }
        public string sendCard { get; set; }
        public string sendPlate { get; set; }
        public string sendTel { get; set; }

        public Searchname()
        {
            InitializeComponent();

            con.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM customer",con);
            DataSet dt = new DataSet();
            adapter.Fill(dt);
            dataGrid.ItemsSource = dt.Tables[0].DefaultView;
            dataGrid.CanUserAddRows = false;
            con.Close();
        }

        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui;");

        private void AfterTextChange(object sender, TextChangedEventArgs e)
        {
            con.Open();
            MySqlDataAdapter adt = new MySqlDataAdapter("SELECT * FROM customer WHERE cusName LIKE'%"+SearchBox.Text+"%'", con);
            DataSet dt = new DataSet();
            adt.Fill(dt);
            dataGrid.ItemsSource = dt.Tables[0].DefaultView;
            dataGrid.CanUserAddRows = false;
            con.Close();
        }

        private void DoubleClick(object sender, MouseButtonEventArgs e)
        {
            object item = dataGrid.SelectedItem;
            Buytoday go = new Buytoday();

            sendID = (dataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            sendName = (dataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            sendLname = (dataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            sendAddress = (dataGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            sendCard = (dataGrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
            sendPlate = (dataGrid.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
            sendTel = (dataGrid.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
            this.Close();
        }

    }
}
