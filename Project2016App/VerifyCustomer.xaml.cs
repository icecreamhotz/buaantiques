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
    /// Interaction logic for VerifyCustomer.xaml
    /// </summary>
    public partial class VerifyCustomer : Window
    {

        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui;");
        string cusName, cusLname, cusCard, cusTel, cusAddress, cusRoad, cusMoo, PROVINCE_NAME, AMPHUR_NAME, DISTRICT_NAME, cusPostcode, cusUsername, cusPassword, cusMail, cusPlate;

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("แก้ไขสำเร็จ!!!");
        }

        string cusID,cusStatus;

        public VerifyCustomer()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, RoutedEventArgs e)
        {
            con.Open();
            MySqlDataAdapter adpshow = new MySqlDataAdapter(@"SELECT customer.*,provinces.PROVINCE_NAME,amphures.AMPHUR_NAME,districts.DISTRICT_NAME FROM customer
            left join provinces on customer.PROVINCE_ID=provinces.PROVINCE_ID
            left join amphures on customer.AMPHUR_ID=amphures.AMPHUR_ID
            left join districts on customer.DISTRICT_ID=districts.DISTRICT_ID", con);
            DataSet dtshow = new DataSet();
            adpshow.Fill(dtshow);
            dataGrid.ItemsSource = dtshow.Tables[0].DefaultView;
            dataGrid.CanUserAddRows = false;
            con.Close();
        }

        private void SelectDataGridChange(object sender, SelectionChangedEventArgs e)
        {
            object item = dataGrid.SelectedItem;
            cusName = (dataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            cusLname = (dataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            cusCard = (dataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            cusTel = (dataGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            cusAddress = (dataGrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
            cusRoad = (dataGrid.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
            cusMoo = (dataGrid.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
            PROVINCE_NAME = (dataGrid.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
            AMPHUR_NAME = (dataGrid.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text;
            DISTRICT_NAME = (dataGrid.SelectedCells[9].Column.GetCellContent(item) as TextBlock).Text;
            cusPostcode = (dataGrid.SelectedCells[10].Column.GetCellContent(item) as TextBlock).Text;
            cusUsername = (dataGrid.SelectedCells[11].Column.GetCellContent(item) as TextBlock).Text;
            cusPassword = (dataGrid.SelectedCells[12].Column.GetCellContent(item) as TextBlock).Text;
            cusMail = (dataGrid.SelectedCells[13].Column.GetCellContent(item) as TextBlock).Text;
            cusPlate = (dataGrid.SelectedCells[14].Column.GetCellContent(item) as TextBlock).Text;
            cusID = (dataGrid.SelectedCells[15].Column.GetCellContent(item) as TextBlock).Text;
            cusStatus = (dataGrid.SelectedCells[16].Column.GetCellContent(item) as TextBlock).Text;

            txtName.Text = cusName;
            txtLastname.Text = cusLname;
            txtTel.Text = cusTel;
            txtCard.Text = cusCard;
            txtRoad.Text = cusRoad;
            txtMoo.Text = cusMoo;
            txtAddress.Text = cusAddress;
            txtZipcode.Text = cusPostcode;
            txtUsername.Text = cusUsername;
            txtPassword.Text = cusPassword;
            txtMail.Text = cusMail;
            txtPlate.Text = cusPlate;
            txtProvince.Text = PROVINCE_NAME;
            txtAmphur.Text = AMPHUR_NAME;
            txtDistrict.Text = DISTRICT_NAME;

            if (cusStatus == "1")
            {
                showStatus.Text = "สถานะ : รอการยืนยันตน";
                showStatus.Foreground = Brushes.Red;
            }

            if (cusStatus == "2")
            {
                showStatus.Text = "สถานะ : ยืนยันตนแล้ว";
                showStatus.Foreground = Brushes.Green;
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (cusID == (""))
            {
                MessageBox.Show("กรุณาเลือกข้อมูลที่ต้องการลบ !!!", "คำเตือน");
                return;
            }
            else
            {

                MessageBoxResult result = MessageBox.Show("คุณต้องการลบข้อมูลนี้หรือไม่", "แจ้งเตือน", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    string sql = "delete from customer where cusID='" + cusID + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    this.Close();
                    InfoEmployee go = new InfoEmployee();
                    go.Show();
                    go.Close();
                }

            }
        }

        private void Verify_Click(object sender, RoutedEventArgs e)
        {
            MySqlCommand cmdupdate = new MySqlCommand("UPDATE customer SET cusStatus='2' WHERE cusID='" + cusID + "'", con);
            cmdupdate.Connection.Open();
            cmdupdate.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("ยืนยันตนสำเร็จ!!!", "สำเร็จ");

            VerifyCustomer go = new VerifyCustomer();
            go.Show();
            this.Close();
        }

    }
}
