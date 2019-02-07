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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project2016App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();  
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM login WHERE Username='" + txtUsername.Text + "' AND Password='" + txtPassword.Password + "'";

            MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }
            if (count== 1)
            {
                this.Hide();
                Management go = new Management(txtUsername.Text);
                go.Show();
                MessageBox.Show("เข้าสู่ระบบสำเร็จ!!!","ยินดีต้อนรับ");
            }
            else
            {
                MessageBox.Show("กรุณากรอกผู้ใช้งานหรือรหัสผ่านอีกครั้ง!!!","ผิดพลาด");
            }
            con.Close();
        }
    }
}
