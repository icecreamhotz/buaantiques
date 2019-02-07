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
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Product : Window
    {

        MySqlConnection con=new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui;");
        string strShowid, strShowtypeproduct;
        string checknameType;

        public Product()
        {
            InitializeComponent();
        }

        private void showDatainDatagrid()
        {
            con.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM typeproduct",con);
            DataSet dt = new DataSet();
            adp.Fill(dt);
            dataGrid.ItemsSource = dt.Tables[0].DefaultView;
            dataGrid.CanUserAddRows = false;
            con.Close();
        }

        private void Form_Load(object sender, RoutedEventArgs e)
        {
            showDatainDatagrid();
        }

        private void DataGridCellClick(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                object item = dataGrid.SelectedItem;

                strShowid = (dataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                strShowtypeproduct = (dataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;

                showID.Text = strShowid;
                txtTypeproduct.Text = strShowtypeproduct;
            }
            else
            {
                dataGrid.SelectedIndex = -1;
                return;
            }
        }

        private void SavetoDB_Click(object sender, RoutedEventArgs e)
        {
            if (txtTypeproduct.Text == "")
            {
                MessageBox.Show("ขออภัยคุณกรอกข้อมูลไม่ครบ!!!");
                return;
            }

            ChecktypeProduct();
            if (txtTypeproduct.Text == checknameType)
            {
                MessageBox.Show("ข้อมูลนี้มีแล้วคุณต้องทำการลบข้อมูลเก่าออกก่อนครับ!!!");
                return;
            }
            else
            {
                string savetodb = "INSERT INTO typeproduct (typepName) VALUES (@typepName)";
                MySqlCommand savecmd = new MySqlCommand(savetodb, con);
                savecmd.Parameters.AddWithValue("@typepName", txtTypeproduct.Text);
                savecmd.Connection.Open();
                savecmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว!!!");
                showID.Text = "";
                txtTypeproduct.Text = "";
                showDatainDatagrid(); // method show ข้อมูลใน datagrid
            }
        }

        private void EdittoDB_Click(object sender, RoutedEventArgs e)
        {        
            if (showID.Text == "")
            {
                MessageBox.Show("กรุณาเลือกข้อมูลที่ต้องการแก้ไข!!!");
                return;
            }

            ChecktypeProduct();
            if (txtTypeproduct.Text == checknameType)
            {
                MessageBox.Show("ข้อมูลนี้มีแล้วคุณต้องทำการลบข้อมูลเก่าออกก่อนครับ!!!");
                return;
            }
            else
            {
                string edittodb = "UPDATE typeproduct SET typepName='" + txtTypeproduct.Text + "' WHERE typepID='" + showID.Text + "'";
                MySqlCommand editcmd = new MySqlCommand(edittodb, con);
                editcmd.Connection.Open();
                editcmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("อัพเดทเรียบร้อยแล้วครับ!!!");
                showID.Text = "";
                txtTypeproduct.Text = "";
                showDatainDatagrid(); // method show ข้อมูลใน datagrid
            }
        }

        private void DeleteFromDB_Click(object sender, RoutedEventArgs e)
        {
            if (showID.Text == "")
            {
                MessageBox.Show("ขออภัยกรุณาเลือกรายการที่ต้องการลบ!!!");
                return;
            }

            MessageBoxResult result = MessageBox.Show("กรุณายืนยันการลบ!!!", "ลบเรียบร้อยแล้ว", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            else
            {
                string deletefromdb = "DELETE FROM typeproduct WHERE typepID='" + showID.Text + "'";
                MySqlCommand deletecmd = new MySqlCommand(deletefromdb, con);
                deletecmd.Connection.Open();
                deletecmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ลบข้อมูลสำเร็จ!!!");
                showID.Text = "";
                txtTypeproduct.Text = "";
                showDatainDatagrid(); // method show ข้อมูลใน datagrid
            }
        }

        private void ChecktypeProduct()
        {
            con.Open();
            string checkfromdb="SELECT typepName FROM typeproduct WHERE typepName='"+txtTypeproduct.Text+"'";
            MySqlCommand checkdbcmd = new MySqlCommand(checkfromdb,con);
            MySqlDataReader reader = checkdbcmd.ExecuteReader();

            while (reader.Read())
            {
                checknameType = reader.GetString(reader.GetOrdinal("typepName"));
            }
            con.Close();   
        }

        private void ClearData_Click(object sender, RoutedEventArgs e)
        {
            txtTypeproduct.Text = "";
        }

    }
}
