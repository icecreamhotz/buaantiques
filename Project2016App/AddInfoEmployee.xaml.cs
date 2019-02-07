using MySql.Data.MySqlClient;
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
using System.IO;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Data;
using Xceed.Wpf.Toolkit;

namespace Project2016App
{
    /// <summary>
    /// Interaction logic for AddInfoEmployee.xaml
    /// </summary>
    public partial class AddInfoEmployee : Window
    {

        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui;charset=utf8;");
        string Sex = "",Getidprovice,Getidamphur,Getiddistricts;
        int i;

        public AddInfoEmployee()
        {
            InitializeComponent();
            cbAmphur.IsEnabled = false;
            cbDistrict.IsEnabled = false;
            showPicUrl.IsEnabled = false;
        }

        private void ChooseFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog opf = new Microsoft.Win32.OpenFileDialog();

            opf.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            Nullable<bool> result = opf.ShowDialog();

            if (result == true)
            {
                image1.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(opf.FileName));
                showPicUrl.Text = opf.FileName;
            }
        }

        private void ClickMale(object sender, RoutedEventArgs e)
        {
            Sex = "เพศชาย";
            cbkFemale.IsChecked = false;
        }

        private void ClickFemale(object sender, RoutedEventArgs e)
        {
            Sex = "เพศหญิง";
            cbkMale.IsChecked = false;
        }

        private void AfterOpenProvince(object sender, EventArgs e)
        {
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
            cbProvince.SelectedIndex = 0;
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
                cbAmphur.SelectedIndex = 0;
            }
            con.Close();

            con.Open();
            string showcb = "SELECT amphures.AMPHUR_NAME,provinces.PROVINCE_ID FROM amphures left join provinces on amphures.PROVINCE_ID=provinces.PROVINCE_ID WHERE amphures.PROVINCE_ID='"+ Getidprovice + "'";
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
            cbAmphur.IsEnabled = true;
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
            string showcb = "SELECT districts.DISTRICT_NAME,amphures.AMPHUR_ID,amphures.PROVINCE_ID FROM districts left join amphures on districts.AMPHUR_ID=amphures.AMPHUR_ID WHERE (districts.AMPHUR_ID='" + Getidamphur+"') AND (districts.PROVINCE_ID='"+Getidprovice+"')";
            MySqlDataAdapter adp = new MySqlDataAdapter(showcb, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                string getdata1 = string.Format("{0}", row.ItemArray[0]);
                cbDistrict.Items.Add(getdata1);
            }
            con.Close();
            cbDistrict.IsEnabled = true;
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

        private void Savetodb_Click(object sender, RoutedEventArgs e)
        {
            if (image1 != null)
            {
                if (string.IsNullOrEmpty(txtName.Text) ||
                 string.IsNullOrEmpty(txtLastname.Text) ||
                 !txtTel.IsMaskCompleted ||
                 !txtCard.IsMaskCompleted ||
                 string.IsNullOrEmpty(txtAddress.Text) ||
                 string.IsNullOrEmpty(cbProvince.Text) ||
                 string.IsNullOrEmpty(cbAmphur.Text) ||
                 string.IsNullOrEmpty(cbDistrict.Text) ||
                 string.IsNullOrEmpty(txtZipcode.Text) ||
                 Sex == "" ||
                 image1.Source == null)
                {
                    System.Windows.MessageBox.Show("กรุณาตรวจสอบข้อมูลที่ท่านกรอกด้วยครับ ข้อมูลไม่ครบ!!!");
                    image1.Source = null;
                    showPicUrl.Text = "";
                    return;
                }
            }

            string constring = "host=localhost;user=root;password=1147;database=projectgui;charset=utf8;";
            string sql = "INSERT INTO employee(nameEmp,lastnameEmp,telEmp,idcardEmp,sexEmp,addressEmp,roadEmp,mooEmp,PROVINCE_ID,AMPHUR_ID,DISTRICT_ID,zipcodeEmp,picEmp) VALUES('" + txtName.Text + "','" + txtLastname.Text + "','" + txtTel.Text + "','" + txtCard.Text + "','" + Sex + "','" + txtAddress.Text + "','"+txtRoad.Text+"','"+txtMoo.Text+"', '"+Getidprovice+"','"+Getidamphur+"','"+Getiddistricts+"','"+txtZipcode.Text+"',@IMG)";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(sql, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                byte[] imageBt = null;
                FileStream fstream = new FileStream(showPicUrl.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imageBt = br.ReadBytes((int)fstream.Length);

                cmdDataBase.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                myReader = cmdDataBase.ExecuteReader();
                System.Windows.Forms.MessageBox.Show("บันทึกสำเร็จ!!!");
                ClearDataAll();
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("กรุณาใส่รูปภาพด้วยครับ!!!");
            }
        }

        private void Cleardata_Click(object sender, RoutedEventArgs e)
        {
            ClearDataAll();
        }

        private void ClearDataAll()
        {
            txtName.Text = "";
            txtLastname.Text = "";
            txtTel.Text = string.Empty;
            txtCard.Text = string.Empty;
            txtZipcode.Text = "";
            txtAddress.Text = "";
            showPicUrl.Text = "";
            cbProvince.Items.Clear();
            cbAmphur.Items.Clear();
            cbDistrict.Items.Clear();
            cbkMale.IsChecked = false;
            cbkMale.IsChecked = false;
            image1.Source = null;
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