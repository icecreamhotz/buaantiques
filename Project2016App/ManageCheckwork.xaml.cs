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
    /// Interaction logic for ManageCheckwork.xaml
    /// </summary>
    public partial class ManageCheckwork : Window
    {

        public ManageCheckwork()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("th-TH");
            datePick1.Text = DateTime.Today.ToShortDateString();
            datePick2.Text = DateTime.Today.ToShortDateString();
        }

        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui;");

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            con.Open();

            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from checkwork WHERE checkDate between '" + Convert.ToDateTime(datePick1.Text).ToString("yyyy/MM/dd") + "' and '" + Convert.ToDateTime(datePick2.Text).ToString("yyyy/MM/dd") + "'", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGrid.ItemsSource = ds.Tables[0].DefaultView;
            dataGrid.CanUserAddRows = false;
            con.Close();
        }

        private void bt_Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("คุณต้องการลบข้อมูลที่เช็คหรือไม่", "ลบข้อมูลนี้แล้ว", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                for (int i = 0; i < dataGrid.Items.Count; i++)
                {
                    DataGridRow item = (DataGridRow)this.dataGrid.ItemContainerGenerator.ContainerFromItem(dataGrid.Items[i]);
                    CheckBox cbkdel = (CheckBox)GetVisualChild<CheckBox>(item);

                    if (cbkdel.IsChecked.Value)
                    {            
                        object itemz = dataGrid.Items[i];
                        string showid = (dataGrid.SelectedCells[9].Column.GetCellContent(itemz) as TextBlock).Text;
                        con.Open();
                        string sql = "DELETE from checkwork where checkworkID='" + showid + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                MessageBox.Show("ลบเรียบร้อยแล้ว!!!");
                this.Close();
                ManageCheckwork go = new ManageCheckwork();
                go.Show();
            }

        } //ปิด Event Delete

        private void AfterTextChange(object sender, TextChangedEventArgs e)
        {
            con.Open();
            if (Searchname.Text == "")
            {
                MySqlDataAdapter adaper = new MySqlDataAdapter("select * from checkwork WHERE checkDate between '" + Convert.ToDateTime(datePick1.Text).ToString("yyyy/MM/dd") + "' and '" + Convert.ToDateTime(datePick2.Text).ToString("yyyy/MM/dd") + "'", con);
                DataSet dt = new DataSet();
                adaper.Fill(dt);
                dataGrid.ItemsSource = dt.Tables[0].DefaultView;
                dataGrid.CanUserAddRows = false;
            }
            else
            {
                MySqlDataAdapter adt = new MySqlDataAdapter("select * from checkwork WHERE (checkDate BETWEEN '" + Convert.ToDateTime(datePick1.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(datePick2.Text).ToString("yyyy-MM-dd") + "') AND (checkName='" + Searchname.Text + "')", con);
                DataSet ds = new DataSet();
                adt.Fill(ds);
                dataGrid.ItemsSource = ds.Tables[0].DefaultView;
                dataGrid.CanUserAddRows = false;
            }
            con.Close();
        }

        private void EditClick_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            EditCheckwork go = new EditCheckwork();
            go.Show();
        }

        static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }

    }
}
