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
    /// Interaction logic for Stock.xaml
    /// </summary>
    public partial class Stock : Window
    {

        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui");

        public Stock()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, RoutedEventArgs e)
        {
            con.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter(@"SELECT stock.*,
            product.proCode,product.proName,product.proPricebuy,product.proPricesell,
            typeunit.typenameUnit,typeproduct.typepName FROM stock 
            left join typeunit on stock.typeunitID=typeunit.typeunitID 
            left join typeproduct on stock.typepID=typeproduct.typepID 
            left join product on stock.proID=product.proID
            ORDER BY  stock.stockID", con);
            DataSet dt = new DataSet();
            adp.Fill(dt);
            dataGrid.ItemsSource = dt.Tables[0].DefaultView;
            dataGrid.CanUserAddRows = false;
            con.Close();
        }

        private void AllSearch_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter(@"SELECT stock.*,
            product.proCode,product.proName,product.proPricebuy,product.proPricesell,
            typeunit.typenameUnit,typeproduct.typepName FROM stock 
            left join typeunit on stock.typeunitID=typeunit.typeunitID 
            left join typeproduct on stock.typepID=typeproduct.typepID 
            left join product on stock.proID=product.proID
            ORDER BY  stock.stockID", con);
            DataSet dt = new DataSet();
            adapter.Fill(dt);
            dataGrid.ItemsSource = dt.Tables[0].DefaultView;
            dataGrid.CanUserAddRows = false;
            con.Close();
        }

        private void PressEnterSearch(object sender, KeyEventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT proName from product WHERE (proName LIKE @Text)", con);
            cmd.Parameters.AddWithValue("@Text", "%" + txtSearch.Text + "%");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                con.Close();
                MySqlDataAdapter adapter = new MySqlDataAdapter(@"SELECT stock.*,
                product.proCode, product.proName, product.proPricebuy, product.proPricesell,
                typeunit.typenameUnit, typeproduct.typepName FROM stock
                left join typeunit on stock.typeunitID = typeunit.typeunitID
                left join typeproduct on stock.typepID = typeproduct.typepID
                left join product on stock.proID = product.proID
                WHERE (product.proName LIKE '%"+txtSearch.Text+"%')", con);
                DataSet dt = new DataSet();
                adapter.Fill(dt);
                dataGrid.ItemsSource = dt.Tables[0].DefaultView;
                dataGrid.CanUserAddRows = false;
                con.Close();
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูลใกล้เคียง!!!");
            }
            con.Close();
        }
    }
}
