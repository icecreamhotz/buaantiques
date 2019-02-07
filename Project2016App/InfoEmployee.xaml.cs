    using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.IO;

namespace Project2016App
{
    /// <summary>
    /// Interaction logic for InfoEmployee.xaml
    /// </summary>
    public partial class InfoEmployee : Window
    {

        string Showname = "", Showlastname = "", Showtel = "", Showidcard = "", Showaddress = "", Showroad = "", Showmoo = "", Showprovince = "", Showamphur = "", Showdistrict = "", Showzipcode = "", ShowidEmp = "";
        string Sex = "", Checksex = "";
        string Getidprovice, Getidamphur, Getiddistricts;

        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui");

        public InfoEmployee()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, RoutedEventArgs e)
        {
            con.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT employee.*,provinces.PROVINCE_NAME,amphures.AMPHUR_NAME,districts.DISTRICT_NAME FROM employee left join provinces ON employee.PROVINCE_ID=provinces.PROVINCE_ID  left join amphures ON employee.AMPHUR_ID=amphures.AMPHUR_ID  left join districts ON employee.DISTRICT_ID=districts.DISTRICT_ID ORDER BY employee.idEmp", con);
            DataSet dt = new DataSet();
            adp.Fill(dt);
            dataGrid.ItemsSource = dt.Tables[0].DefaultView;
            dataGrid.CanUserAddRows = false;
            con.Close();

            rbtMale.IsChecked = false;
            rbtFemale.IsChecked = false;
            cbProvince.IsEnabled = false;
            cbAmphur.IsEnabled = false;
            cbDistrict.IsEnabled = false;
        }

        private void Load_CbProvince(object sender, RoutedEventArgs e)
        {
            con.Open();
            string showcb = "SELECT PROVINCE_NAME FROM provinces ORDER BY PROVINCE_ID";
            MySqlDataAdapter adp = new MySqlDataAdapter(showcb, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                string getdata1 = string.Format("{0}", row.ItemArray[0]);
                cbProvince.Items.Add(getdata1);
            }
            con.Close();
        }

        private void Load_CbAmphur(object sender, RoutedEventArgs e)
        {
            con.Open();
            string showcb = "SELECT AMPHUR_NAME FROM amphures ORDER BY AMPHUR_ID";
            MySqlDataAdapter adp = new MySqlDataAdapter(showcb, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                string getdata1 = string.Format("{0}", row.ItemArray[0]);
                cbAmphur.Items.Add(getdata1);
            }
            con.Close();
        }

        private void Load_cbDistrict(object sender, RoutedEventArgs e)
        {
            con.Open();
            string showcb = "SELECT DISTRICT_NAME FROM districts ORDER BY DISTRICT_ID";
            MySqlDataAdapter adp = new MySqlDataAdapter(showcb, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                string getdata1 = string.Format("{0}", row.ItemArray[0]);
                cbDistrict.Items.Add(getdata1);
            }
            con.Close();
        }

        private void MaleCheck(object sender, RoutedEventArgs e)
        {
            Sex = "เพศชาย";
            if (cbkMale.IsChecked == true)
            {
                cbkFemale.IsChecked = false;
            }
            if (cbkMale.IsChecked == true)
            {
                cbkMale.IsChecked = true;
            }
        }

        private void FemaleCheck(object sender, RoutedEventArgs e)
        {
            Sex = "เพศหญิง";
            if (cbkFemale.IsChecked == true)
            {
                cbkMale.IsChecked = false;
            }
            if (cbkFemale.IsChecked == true)
            {
                cbkFemale.IsChecked = true;
            }
        }

        private void Choose_File(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog opf = new Microsoft.Win32.OpenFileDialog();

            opf.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            Nullable<bool> result = opf.ShowDialog();

            if (result == true)
            {
                image1.Source = new BitmapImage(new Uri(opf.FileName));
                ShowpicUrl.Text = opf.FileName;
            }
        }

        private void DataGridCellClick(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                cbProvince.IsEnabled = true;
                cbAmphur.IsEnabled = true;
                cbDistrict.IsEnabled = true;

                object item = dataGrid.SelectedItem;
                Showname = (dataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                Showlastname = (dataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                Showtel = (dataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                Showidcard = (dataGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                Sex = (dataGrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                Showaddress = (dataGrid.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                Showroad = (dataGrid.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
                Showmoo = (dataGrid.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
                Showprovince = (dataGrid.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text;
                Showamphur = (dataGrid.SelectedCells[9].Column.GetCellContent(item) as TextBlock).Text;
                Showdistrict = (dataGrid.SelectedCells[10].Column.GetCellContent(item) as TextBlock).Text;
                Showzipcode = (dataGrid.SelectedCells[11].Column.GetCellContent(item) as TextBlock).Text;
                ShowidEmp = (dataGrid.SelectedCells[12].Column.GetCellContent(item) as TextBlock).Text;


                txtName.Text = Showname;
                txtLastname.Text = Showlastname;
                txtTel.Text = Showtel;
                txtCard.Text = Showidcard;
                txtRoad.Text = Showroad;
                txtMoo.Text = Showmoo;
                txtAddress.Text = Showaddress;
                txtZipcode.Text = Showzipcode;
                cbProvince.SelectedItem = Showprovince;
                cbAmphur.SelectedItem = Showamphur;
                cbDistrict.SelectedItem = Showdistrict;

                if (Sex == "เพศชาย")
                {
                    cbkMale.IsChecked = true;
                }
                else
                {
                    cbkFemale.IsChecked = true;
                }

                string constring = "host=localhost;user=root;password=1147;database=projectgui";
                string Query = "SELECT picEmp from employee WHERE nameEmp='" + Showname + "'";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();

                    while (myReader.Read())
                    {

                        byte[] imgg = (byte[])(myReader["picEmp"]);
                        if (imgg == null)
                        {
                            image1.Source = null;
                        }
                        else
                        {
                            MemoryStream mstream = new MemoryStream(imgg);
                            var bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.StreamSource = mstream;
                            bitmap.CacheOption = BitmapCacheOption.OnLoad;
                            bitmap.EndInit();
                            image1.Source = bitmap;
                        }
                    }
                    conDataBase.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AfterOpenProvince(object sender, EventArgs e)
        {
            cbProvince.Items.Clear();
            con.Open();
            string showcb = "SELECT PROVINCE_NAME FROM PROVINCES ORDER BY PROVINCE_ID";
            MySqlDataAdapter adp = new MySqlDataAdapter(showcb, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                string getdata1 = string.Format("{0}", row.ItemArray[0]);
                cbProvince.Items.Add(getdata1);
            }
            cbProvince.SelectedItem = Showprovince;
            cbAmphur.Items.Clear();
            con.Close();
        }

        private void AfterClosedProvince(object sender, EventArgs e) //หลังจาก combobox จังหวัดปิดลง
        {
            con.Open();
            string showid = "SELECT PROVINCE_ID FROM provinces WHERE PROVINCE_NAME='" + cbProvince.SelectedItem + "'";
            MySqlCommand cmd = new MySqlCommand(showid, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Getidprovice = reader.GetString(reader.GetOrdinal("PROVINCE_ID"));
            }
            con.Close();

            con.Open();
            string showcb = "SELECT amphures.AMPHUR_NAME,provinces.PROVINCE_ID FROM amphures left join provinces on amphures.PROVINCE_ID=provinces.PROVINCE_ID WHERE amphures.PROVINCE_ID='" + Getidprovice + "'";
            MySqlDataAdapter adp = new MySqlDataAdapter(showcb, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                string getdata1 = string.Format("{0}", row.ItemArray[0]);
                cbAmphur.Items.Add(getdata1);
            }
            con.Close();
        }

        private void AfterAmphurOpen(object sender, EventArgs e)
        {
            cbAmphur.Items.Clear();
            con.Open();
            string showid = "SELECT PROVINCE_ID FROM provinces WHERE PROVINCE_NAME='" + cbProvince.Text + "'";
            MySqlCommand cmd = new MySqlCommand(showid, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Getidprovice = reader.GetString(reader.GetOrdinal("PROVINCE_ID"));
            }
            con.Close();

            con.Open();
            string showcb = "SELECT amphures.AMPHUR_NAME,provinces.PROVINCE_ID FROM amphures left join provinces on amphures.PROVINCE_ID=provinces.PROVINCE_ID WHERE amphures.PROVINCE_ID='" + Getidprovice + "'";
            MySqlDataAdapter adp = new MySqlDataAdapter(showcb, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                string getdata1 = string.Format("{0}", row.ItemArray[0]);
                cbAmphur.Items.Add(getdata1);
            }
            con.Close();
            cbDistrict.Items.Clear();
        }

        private void AfterAmphurClosed(object sender, EventArgs e)
        {
            con.Open();
            string showid = "SELECT AMPHUR_ID FROM amphures WHERE AMPHUR_NAME='" + cbAmphur.SelectedItem + "'";
            MySqlCommand cmd = new MySqlCommand(showid, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Getidamphur = reader.GetString(reader.GetOrdinal("AMPHUR_ID"));
            }
            con.Close();

            con.Open();
            string showcb = "SELECT districts.DISTRICT_NAME,amphures.AMPHUR_ID,amphures.PROVINCE_ID FROM districts left join amphures on districts.AMPHUR_ID=amphures.AMPHUR_ID WHERE (districts.AMPHUR_ID='" + Getidamphur + "') AND (districts.PROVINCE_ID='" + Getidprovice + "')";
            MySqlDataAdapter adp = new MySqlDataAdapter(showcb, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                string getdata1 = string.Format("{0}", row.ItemArray[0]);
                cbDistrict.Items.Add(getdata1);
            }
            con.Close();
        }

        private void AfterdistrictOpen(object sender, EventArgs e)
        {
            cbDistrict.Items.Clear();
            con.Open();
            string showid = "SELECT AMPHUR_ID FROM amphures WHERE AMPHUR_NAME='" + cbAmphur.SelectedItem + "'";
            MySqlCommand cmd = new MySqlCommand(showid, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Getidamphur = reader.GetString(reader.GetOrdinal("AMPHUR_ID"));
            }
            con.Close();

            con.Open();
            string showcb = "SELECT districts.DISTRICT_NAME,amphures.AMPHUR_ID,amphures.PROVINCE_ID FROM districts left join amphures on districts.AMPHUR_ID=amphures.AMPHUR_ID WHERE (districts.AMPHUR_ID='" + Getidamphur + "') AND (districts.PROVINCE_ID='" + Getidprovice + "')";
            MySqlDataAdapter adp = new MySqlDataAdapter(showcb, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                string getdata1 = string.Format("{0}", row.ItemArray[0]);
                cbDistrict.Items.Add(getdata1);
            }
            con.Close();
        }

        private void AfterdistrcitsClosed(object sender, EventArgs e)
        {
            con.Open();
            string showid = "SELECT DISTRICT_ID FROM districts WHERE DISTRICT_NAME='" + cbDistrict.SelectedItem + "'";
            MySqlCommand cmd = new MySqlCommand(showid, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Getiddistricts = reader.GetString(reader.GetOrdinal("DISTRICT_ID"));
            }
            con.Close();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            string showidprovince = "SELECT PROVINCE_ID FROM provinces WHERE PROVINCE_NAME='" + cbProvince.SelectedItem + "'";
            MySqlCommand cmd1 = new MySqlCommand(showidprovince, con);
            MySqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                Getidprovice = reader1.GetString(reader1.GetOrdinal("PROVINCE_ID"));
            }
            con.Close();

            con.Open();
            string showidamphur = "SELECT AMPHUR_ID FROM amphures WHERE AMPHUR_NAME='" + cbAmphur.SelectedItem + "'";
            MySqlCommand cmd2 = new MySqlCommand(showidamphur, con);
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                Getidamphur = reader2.GetString(reader2.GetOrdinal("AMPHUR_ID"));
            }
            con.Close();

            con.Open();
            string showiddistrict = "SELECT DISTRICT_ID FROM districts WHERE DISTRICT_NAME='" + cbDistrict.SelectedItem + "'";
            MySqlCommand cmd3 = new MySqlCommand(showiddistrict, con);
            MySqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                Getiddistricts = reader3.GetString(reader3.GetOrdinal("DISTRICT_ID"));
            }
            con.Close();

            if (Showname == ("") | Showlastname == ("") | !txtTel.IsMaskCompleted | !txtCard.IsMaskCompleted | Showaddress == ("") | Showzipcode == (""))
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ (ถนน และ หมู่ ไม่จำเป็น)!!!");
                return;
            }
            else
            {

                string sql = "update employee set nameEmp='" + this.txtName.Text +
                    "',lastnameEmp='" + this.txtLastname.Text +
                    "',telEmp='" + this.txtTel.Text +
                    "',idcardEmp='" + this.txtCard.Text +
                    "',sexEmp='" + Sex +
                    "',addressEmp='" + this.txtAddress.Text +
                    "',roadEmp='" + this.txtRoad.Text +
                    "',mooEmp='" + this.txtMoo.Text +
                    "',PROVINCE_ID='" + Getidprovice +
                    "',AMPHUR_ID='" + Getidamphur +
                    "',DISTRICT_ID='" + Getiddistricts +
                    "',zipcodeEmp='" + this.txtZipcode.Text+
                    "',picEmp=@IMG where idEmp='" + this.ShowidEmp + "'";
                MySqlCommand cmdDataBase = new MySqlCommand(sql, con);
                MySqlDataReader myReader;
                try
                {
                    byte[] imageBt = null;
                    FileStream fstream = new FileStream(ShowpicUrl.Text, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fstream);
                    imageBt = br.ReadBytes((int)fstream.Length);

                    cmdDataBase.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                    cmdDataBase.Connection.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    System.Windows.Forms.MessageBox.Show("แก้ไขสำเร็จ!!!", "สำเร็จ");
                    con.Close();

                    this.Close();
                    InfoEmployee go = new InfoEmployee();
                    go.Show();
                }
                catch (Exception ex)
                {
                    string sql2 = "update employee set nameEmp='" + this.txtName.Text +
                     "',lastnameEmp='" + this.txtLastname.Text +
                     "',telEmp='" + this.txtTel.Text +
                     "',idcardEmp='" + this.txtCard.Text +
                     "',sexEmp='" + Sex +
                     "',addressEmp='" + this.txtAddress.Text +
                     "',roadEmp='" + this.txtRoad.Text +
                     "',mooEmp='" + this.txtMoo.Text +
                     "',PROVINCE_ID='" + Getidprovice +
                     "',AMPHUR_ID='" + Getidamphur +
                     "',DISTRICT_ID='" + Getiddistricts +
                     "',zipcodeEmp='" + this.txtZipcode.Text +
                     "' where idEmp='" + this.ShowidEmp + "'";
                     MySqlCommand cmdDataBase2 = new MySqlCommand(sql2, con);
                    cmdDataBase2.Connection.Open();
                    cmdDataBase2.ExecuteNonQuery();
                    System.Windows.Forms.MessageBox.Show("แก้ไขสำเร็จ!!!", "สำเร็จ");
                    con.Close();

                    this.Close();
                    InfoEmployee go = new InfoEmployee();
                    go.Show();
                }

            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            if (ShowidEmp == (""))
            {
                MessageBox.Show("กรุณาเลือกข้อมูลที่ต้องการลบ !!!","คำเตือน");
                return;
            }
            else
            {

                MessageBoxResult result = MessageBox.Show("คุณต้องการลบข้อมูลนี้หรือไม่", "แจ้งเตือน", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    string sql = "delete from employee where idEmp='" + ShowidEmp + "'";
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

        } // ปิด method Delete_Click

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("กรุณากรอกข้อมูลก่อนค้นหา!!!", "ล้มเหลว");
                return;
            }
            else
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT employee.*,provinces.PROVINCE_NAME FROM employee left join provinces on employee.PROVINCE_ID=provinces.PROVINCE_ID WHERE (nameEmp LIKE @strSearch) OR (idcardEmp LIKE @strSearch) OR (sexEmp LIKE @strSearch) OR (PROVINCE_NAME LIKE @strSearch)", con);
                cmd.Parameters.AddWithValue("@strSearch", "%" + txtSearch.Text + "%");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (cbkSearchname.IsChecked == true)
                    {
                        con.Close();
                        MySqlDataAdapter adpname = new MySqlDataAdapter("SELECT employee.*,provinces.PROVINCE_NAME,amphures.AMPHUR_NAME,districts.DISTRICT_NAME FROM employee left join provinces on employee.PROVINCE_ID=provinces.PROVINCE_ID left join amphures on employee.AMPHUR_ID=amphures.AMPHUR_ID left join districts on employee.DISTRICT_ID=districts.DISTRICT_ID WHERE (nameEmp LIKE '%" + txtSearch.Text + "%')", con);
                        DataSet dtname = new DataSet();
                        adpname.Fill(dtname);
                        dataGrid.ItemsSource = dtname.Tables[0].DefaultView;
                        dataGrid.CanUserAddRows = false;
                        con.Close();
                    }

                    if (cbkSearchidcard.IsChecked == true)
                    {
                        con.Close();
                        MySqlDataAdapter adpidcard = new MySqlDataAdapter("SELECT employee.*,provinces.PROVINCE_NAME,amphures.AMPHUR_NAME,districts.DISTRICT_NAME FROM employee left join provinces on employee.PROVINCE_ID=provinces.PROVINCE_ID left join amphures on employee.AMPHUR_ID=amphures.AMPHUR_ID left join districts on employee.DISTRICT_ID=districts.DISTRICT_ID WHERE (idcardEmp LIKE '%" + txtSearch.Text + "%')", con);
                        DataSet dtidcard = new DataSet();
                        adpidcard.Fill(dtidcard);
                        dataGrid.ItemsSource = dtidcard.Tables[0].DefaultView;
                        dataGrid.CanUserAddRows = false;
                        con.Close();
                    }

                    if (cbkSearchsex.IsChecked == true)
                    {
                        if (Checksex == "เพศชาย")
                        {
                            con.Close();
                            MySqlDataAdapter adpidcard = new MySqlDataAdapter("SELECT employee.*,provinces.PROVINCE_NAME,amphures.AMPHUR_NAME,districts.DISTRICT_NAME FROM employee left join provinces on employee.PROVINCE_ID=provinces.PROVINCE_ID left join amphures on employee.AMPHUR_ID=amphures.AMPHUR_ID left join districts on employee.DISTRICT_ID=districts.DISTRICT_ID WHERE (sexEmp LIKE '%" + txtSearch.Text + "%')", con);
                            DataSet dtidcard = new DataSet();
                            adpidcard.Fill(dtidcard);
                            dataGrid.ItemsSource = dtidcard.Tables[0].DefaultView;
                            dataGrid.CanUserAddRows = false;
                            con.Close();
                        }
                        else
                        {
                            con.Close();
                            MySqlDataAdapter adpidcard = new MySqlDataAdapter("SELECT employee.*,provinces.PROVINCE_NAME,amphures.AMPHUR_NAME,districts.DISTRICT_NAME FROM employee left join provinces on employee.PROVINCE_ID=provinces.PROVINCE_ID left join amphures on employee.AMPHUR_ID=amphures.AMPHUR_ID left join districts on employee.DISTRICT_ID=districts.DISTRICT_ID WHERE (sexEmp LIKE '%" + txtSearch.Text + "%')", con);
                            DataSet dtidcard = new DataSet();
                            adpidcard.Fill(dtidcard);
                            dataGrid.ItemsSource = dtidcard.Tables[0].DefaultView;
                            dataGrid.CanUserAddRows = false;
                            con.Close();
                        }
                    }

                    if (cbkSearchprovince.IsChecked == true)
                    {
                        con.Close();
                        MySqlDataAdapter adpidcard = new MySqlDataAdapter("SELECT employee.*,provinces.PROVINCE_NAME,amphures.AMPHUR_NAME,districts.DISTRICT_NAME FROM employee left join provinces on employee.PROVINCE_ID=provinces.PROVINCE_ID left join amphures on employee.AMPHUR_ID=amphures.AMPHUR_ID left join districts on employee.DISTRICT_ID=districts.DISTRICT_ID WHERE (provinces.PROVINCE_NAME LIKE '%" + txtSearch.Text + "%')", con);
                        DataSet dtidcard = new DataSet();
                        adpidcard.Fill(dtidcard);
                        dataGrid.ItemsSource = dtidcard.Tables[0].DefaultView;
                        dataGrid.CanUserAddRows = false;
                        con.Close();
                    }

                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูลนี้!!!", "ล้มเหลว");
                }
                con.Close();
            }
        }

        private void cbkSearchname_Checked(object sender, RoutedEventArgs e)
        {
            if (cbkSearchname.IsChecked == true)
            {
                cbkSearchidcard.IsChecked = false;
                cbkSearchprovince.IsChecked = false;
                cbkSearchsex.IsChecked = false;
                cbkSearchAll.IsChecked = false;
                rbtMale.IsEnabled = false;
                rbtFemale.IsEnabled = false;
                rbtMale.IsChecked = false;
                rbtFemale.IsChecked = false;
                txtSearch.IsEnabled = true;
            }
        }

                private void cbkSearchidcard_Checked(object sender, RoutedEventArgs e)
        {
            if (cbkSearchidcard.IsChecked == true)
            {
                cbkSearchname.IsChecked = false;
                cbkSearchprovince.IsChecked = false;
                cbkSearchsex.IsChecked = false;
                cbkSearchAll.IsChecked = false;
                rbtMale.IsEnabled = false;
                rbtFemale.IsEnabled = false;
                rbtMale.IsChecked = false;
                rbtFemale.IsChecked = false;
                txtSearch.IsEnabled = true;
            }
        }

        private void cbkSearchsex_Checked(object sender, RoutedEventArgs e)
        {
            if (cbkSearchsex.IsChecked == true)
            {
                cbkSearchname.IsChecked = false;
                cbkSearchprovince.IsChecked = false;
                cbkSearchidcard.IsChecked = false;
                cbkSearchAll.IsChecked = false;
                rbtFemale.IsEnabled = true;
                rbtMale.IsEnabled = true;
                txtSearch.IsEnabled = false;
            }
        }

        private void rbtMale_Checked(object sender, RoutedEventArgs e)
        {
            if (rbtMale.IsChecked == true)
            {
                Checksex = "เพศชาย";
                txtSearch.Text = Checksex;
                txtSearch.IsEnabled = false;
                rbtFemale.IsChecked = false;
            }
        }

        private void rbtFemale_Checked(object sender, RoutedEventArgs e)
        {
            if (rbtFemale.IsChecked == true)
            {
                Checksex = "เพศหญิง";
                txtSearch.Text = Checksex;
                txtSearch.IsEnabled = false;
                rbtMale.IsChecked = false;
            }
        }

        private void cbkSearchprovince_Checked(object sender, RoutedEventArgs e)
        {
            if (cbkSearchprovince.IsChecked == true)
            {
                cbkSearchidcard.IsChecked = false;
                cbkSearchname.IsChecked = false;
                cbkSearchsex.IsChecked = false;
                cbkSearchAll.IsChecked = false;
                rbtMale.IsEnabled = false;
                rbtFemale.IsEnabled = false;
                rbtMale.IsChecked = false;
                rbtFemale.IsChecked = false;
                txtSearch.IsEnabled = true;
            }
        }

        private void cbkSearchAll_Checked(object sender, RoutedEventArgs e)
        {
            if (cbkSearchAll.IsChecked == true)
            {
                cbkSearchidcard.IsChecked = false;
                cbkSearchname.IsChecked = false;
                cbkSearchsex.IsChecked = false;
                cbkSearchprovince.IsChecked = false;
                rbtMale.IsEnabled = false;
                rbtFemale.IsEnabled = false;
                rbtMale.IsChecked = false;
                rbtFemale.IsChecked = false;
                txtSearch.IsEnabled = false;


                con.Close();
                MySqlDataAdapter adpall = new MySqlDataAdapter("SELECT employee.*,provinces.PROVINCE_NAME,amphures.AMPHUR_NAME,districts.DISTRICT_NAME FROM employee left join provinces on employee.PROVINCE_ID=provinces.PROVINCE_ID left join amphures on employee.AMPHUR_ID=amphures.AMPHUR_ID left join districts on employee.DISTRICT_ID=districts.DISTRICT_ID ORDER BY employee.idEmp", con);
                DataSet dtall = new DataSet();
                adpall.Fill(dtall);
                dataGrid.ItemsSource = dtall.Tables[0].DefaultView;
                dataGrid.CanUserAddRows = false;
                con.Close();
            }
        }

        private void Insertinfo_Click(object sender, RoutedEventArgs e)
        {
            AddInfoEmployee go = new AddInfoEmployee();
            go.Show();
            this.Close();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != "." && IsNumber(e.Text) == false)
            {
                e.Handled = true;
            }
            else if (e.Text == ".")
            {
                if (((TextBox)sender).Text.IndexOf(e.Text) > -1)
                {
                    e.Handled = true;
                }
            }
        }
        private bool IsNumber(string Text)
        {
            int output;
            return int.TryParse(Text, out output);
        }

    }
}
