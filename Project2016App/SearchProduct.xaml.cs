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
using System.Data;
using MySql.Data.MySqlClient;
using System.Xaml;

namespace Project2016App
{
    /// <summary>
    /// Interaction logic for SearchProduct.xaml
    /// </summary>
    public partial class SearchProduct : Window
    {
        public string sendCount { get; set; }
        public string sendCode { get; set; }
        public string sendName { get; set; }
        public string sendPricebuy { get; set; }
        public string sendPricesell { get; set; }
        public string sendUnit { get; set; }

        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui;");

        public SearchProduct()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, RoutedEventArgs e)
        {

            con.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT product.*,typeproduct.typepName,typeunit.typenameUnit FROM product left join typeproduct on product.typepID=typeproduct.typepID left join typeunit on product.typeunitID=typeunit.typeunitID ORDER BY product.proID", con);
            DataSet dt = new DataSet();
            adapter.Fill(dt);
            dataGrid.ItemsSource = dt.Tables[0].DefaultView;
            dataGrid.CanUserAddRows = false;
            con.Close();

            if (sendCount == "1")
            {
                dataGrid.Columns[3].CellStyle = (Style)XamlServices.Parse("<Style xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"  xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" TargetType=\"{x:Type DataGridCell}\"> <Setter Property=\"Background\" Value=\"Black\"></Setter></Style>");
            }
            else
            {
                dataGrid.Columns[2].CellStyle = (Style)XamlServices.Parse("<Style xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"  xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" TargetType=\"{x:Type DataGridCell}\"> <Setter Property=\"Background\" Value=\"Black\"></Setter></Style>");
            }
        }

        private void AfterTextChange(object sender, TextChangedEventArgs e)
        {
            if (SearchBox.Text == "")
            {
                con.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter("SELECT product.*,typeproduct.typepName,typeunit.typenameUnit FROM product left join typeproduct on product.typepID=typeproduct.typepID left join typeunit on product.typeunitID=typeunit.typeunitID ORDER BY product.proID", con);
                DataSet dt = new DataSet();
                adp.Fill(dt);
                dataGrid.ItemsSource = dt.Tables[0].DefaultView;
                dataGrid.CanUserAddRows = false;
                con.Close();
            }
            else
            {
                con.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter("SELECT product.*,typeproduct.typepName,typeunit.typenameUnit FROM product left join typeproduct on product.typepID=typeproduct.typepID left join typeunit on product.typeunitID=typeunit.typeunitID WHERE product.proName LIKE '%"+SearchBox.Text+"%'", con);
                DataSet dt = new DataSet();
                adp.Fill(dt);
                dataGrid.ItemsSource = dt.Tables[0].DefaultView;
                con.Close();
            }

        }

        private void DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Buytoday go = new Buytoday();
            object item = dataGrid.SelectedItem;

            sendCode = (dataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            sendName = (dataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            sendPricebuy = (dataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            sendPricesell = (dataGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            sendUnit = (dataGrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;

            this.Close();
        }
    }
}
