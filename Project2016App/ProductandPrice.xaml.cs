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
    /// Interaction logic for ProductandPrice.xaml
    /// </summary>
    public partial class ProductandPrice : Window
    {

        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui;");
        string getIDtype, getIDunit, getproID;
        string strShowCode, strShowname, strShowPricebuy, strShowPricesell, strShowtype, strShowUnit;
        string getShowCode;
        string checknameType, checkidType, checkPricebuy, checkPricesell;
        int showCode;
        double pricebuy , pricesell;

        public ProductandPrice()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, RoutedEventArgs e)
        {
            ShowdatainDataGrid();
            txtpCode.IsEnabled = false;

            con.Open();
            string showcb = "SELECT typepName FROM typeproduct ORDER BY typepID";
            MySqlDataAdapter adp = new MySqlDataAdapter(showcb,con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach(DataRow row in dt.Rows)
            {
                string getdata1 = string.Format("{0}", row.ItemArray[0]);
                cbType.Items.Add(getdata1);
            }
            con.Close();

            con.Open();
            string showcb2 = "SELECT typenameUnit FROM typeunit ORDER BY typeunitID";
            MySqlDataAdapter adp2 = new MySqlDataAdapter(showcb2, con);
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);
            foreach (DataRow row in dt2.Rows)
            {
                string getdata2 = string.Format("{0}", row.ItemArray[0]);
                cbUnit.Items.Add(getdata2);
            }
            con.Close();

            con.Open();
            string getproCode = "SELECT proCode FROM product";
            MySqlCommand cmd = new MySqlCommand(getproCode,con);
            MySqlDataReader reader = cmd.ExecuteReader();
            txtpCode.Text = "001";
            while (reader.Read())
            {
                getShowCode = reader["proCode"].ToString();
                if (getShowCode != "")
                {
                    showCode = Convert.ToInt32(getShowCode);
                    showCode += 1;
                    txtpCode.Text = showCode.ToString("000");
                }
            }
            con.Close();
        }

        private void ShowdatainDataGrid()
        {
            con.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT product.*,typeproduct.typepName,typeunit.typenameUnit FROM product left join typeproduct on product.typepID=typeproduct.typepID left join typeunit on product.typeunitID=typeunit.typeunitID ORDER BY product.proID", con);
            DataSet dt = new DataSet();
            adp.Fill(dt);
            dataGrid.ItemsSource = dt.Tables[0].DefaultView;
            dataGrid.CanUserAddRows = false;
            con.Close();
        }

        private void getDatafromDB()
        {
            con.Open();
            string getsql = "SELECT typepID FROM typeproduct WHERE typepName='" + cbType.SelectedItem + "'";
            MySqlCommand getcmd1 = new MySqlCommand(getsql, con);
            MySqlDataReader reader1 = getcmd1.ExecuteReader();
            while (reader1.Read())
            {
                getIDtype = reader1.GetString(reader1.GetOrdinal("typepID"));
            }
            con.Close();

            con.Open();
            string getsql2 = "SELECT typeunitID FROM typeunit WHERE typenameUnit='" + cbUnit.SelectedItem + "'";
            MySqlCommand getcmd2 = new MySqlCommand(getsql2, con);
            MySqlDataReader reader2 = getcmd2.ExecuteReader();
            while (reader2.Read())
            {
                getIDunit = reader2.GetString(reader2.GetOrdinal("typeunitID"));
            }
            con.Close();

            con.Open();
            string getsql3 = "SELECT proID FROM product WHERE proCode='" + txtpCode.Text + "'";
            MySqlCommand getcmd3 = new MySqlCommand(getsql3, con);
            MySqlDataReader reader3 = getcmd3.ExecuteReader();
            while (reader3.Read())
            {
                getproID = reader3.GetString(reader3.GetOrdinal("proID"));
            }
            con.Close();
        }

        private void DataGridCellClick(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                object item = dataGrid.SelectedItem;

                strShowCode = (dataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                strShowname = (dataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                strShowPricebuy = (dataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                strShowPricesell = (dataGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                strShowtype = (dataGrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                strShowUnit = (dataGrid.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                

                txtpCode.Text = strShowCode;
                txtpName.Text = strShowname;
                txtpBuy.Text = strShowPricebuy;
                txtpSell.Text = strShowPricesell;
                cbType.SelectedItem = strShowtype;
                cbUnit.SelectedItem = strShowUnit;
            }
            else
            {
                dataGrid.SelectedIndex = -1;
                return;
            }
        }

        private void SavetoDB_Click(object sender, RoutedEventArgs e)
        {

            pricebuy = Convert.ToDouble(txtpBuy.Text);
            pricesell = Convert.ToDouble(txtpSell.Text);

            if (txtpBuy.Text == "" || txtpCode.Text == "" || txtpName.Text == "" || txtpSell.Text == "" || cbType.SelectedItem == null || cbUnit.SelectedItem == null)
            {
                MessageBox.Show("กรุณาากรอกข้อมูลให้ครบ!!!");
                return;
            }

            getDatafromDB();
            checkNameproDuct();

            if (pricebuy>=pricesell)
            {
                MessageBox.Show("กรุณากรอกราคารับซื้อให้น้อยกว่าราคาขาย");
                return;
            }

            if (txtpName.Text == checknameType || txtpCode.Text == checkidType)
            {
                MessageBox.Show("คุณมีข้อมูลนี้อยู่แล้วกรุณาลบหรือทำการแก้ไขแทน!!!");
                return;
            }
            else
            {
                using (con)
                {
                    using (MySqlCommand savecmd = new MySqlCommand())
                    {
                        savecmd.Connection = con;

                        con.Open();
                        savecmd.CommandText = @"INSERT INTO product (proCode,proName,proPricebuy,proPricesell,typepID,typeunitID,proNow) VALUES (@proCode,@proName,@proPricebuy,@proPricesell,@typeID,@typeunitID,now());
                                                    INSERT INTO stock (proID,typepID,typeunitID,stockTotal) VALUES (LAST_INSERT_ID(),@typeID,@typeunitID,@typeTotal)";
                        savecmd.Parameters.AddWithValue("@proCode", txtpCode.Text);
                        savecmd.Parameters.AddWithValue("@proName", txtpName.Text);
                        savecmd.Parameters.AddWithValue("@proPricebuy", txtpBuy.Text);
                        savecmd.Parameters.AddWithValue("@proPricesell", txtpSell.Text);
                        savecmd.Parameters.AddWithValue("@typeID", getIDtype);
                        savecmd.Parameters.AddWithValue("@typeunitID", getIDunit);
                        savecmd.Parameters.AddWithValue("@typeTotal", 0);
                        savecmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว!!!");
                        ShowdatainDataGrid();
                        ClearTextbox();

                        con.Open();
                        string getproCode = "SELECT proCode FROM product";
                        MySqlCommand cmd = new MySqlCommand(getproCode, con);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        txtpCode.Text = "001";
                        while (reader.Read())
                        {
                            getShowCode = reader["proCode"].ToString();
                            if (getShowCode != "")
                            {
                                showCode = Convert.ToInt32(getShowCode);
                                showCode += 1;
                                txtpCode.Text = showCode.ToString("000");
                            }
                        }
                        con.Close();
                    }
                }
            }
        }

        private void EdittoDB_Click(object sender, RoutedEventArgs e)
        {
            if (txtpBuy.Text == "" || txtpCode.Text == "" || txtpName.Text == "" || txtpSell.Text == "" || cbType.SelectedItem == null || cbUnit.SelectedItem == null)
            {
                MessageBox.Show("กรุณาากรอกข้อมูลให้ครบ!!!");
                return;
            }

            getDatafromDB();
            checkNameproDuct();

            pricebuy = Convert.ToDouble(txtpBuy.Text);
            pricesell = Convert.ToDouble(txtpSell.Text);

            if (txtpCode.Text == "")
            {
                MessageBox.Show("กรุณาเลือกข้อมูลที่ต้องการแก้ไข!!!");
            }

            if (pricebuy >= pricesell)
            {
                MessageBox.Show("คุณกรอกราคาซื้อมากกว่าราคาขาย!!!");
                return;
            }

            if (txtpName.Text == checknameType)
            {
                if (txtpBuy.Text == checkPricebuy && txtpSell.Text == checkPricesell)
                {
                    MessageBox.Show("ราคาพวกนี้ถูกบันทึกแล้ว!!!");
                    return;
                }
                if (txtpBuy.Text != checkPricebuy || txtpSell.Text != checkPricesell)
                {
                    using (con)
                    {
                        using (MySqlCommand cmdedit = new MySqlCommand())
                        {
                            cmdedit.Connection = con;

                            con.Open();
                            cmdedit.CommandText = @"UPDATE product SET proCode='" + txtpCode.Text + "',proName='" + txtpName.Text + "',proPricebuy='" + txtpBuy.Text + "',proPricesell='" + txtpSell.Text + "',typepID='" + getIDtype + "',typeunitID='" + getIDunit + "',proNow=now() WHERE proCode='" + txtpCode.Text + "'";
                            cmdedit.ExecuteNonQuery();
                            con.Close();

                            con.Open();
                            cmdedit.CommandText = @"UPDATE stock SET proID='" + getproID + "',typepID='" + getIDtype + "',typeunitID='" + getIDunit + "' WHERE proID='" + getproID + "'";
                            cmdedit.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("อัพเดทเรียบร้อยแล้วครับ!!!");
                            ShowdatainDataGrid();
                            ClearTextbox();
                        }
                    }
                }
            MessageBox.Show("คุณมีชื่อสินค้านี้แล้ว!!!");
            return;
            }
        }


        private void DeleteFromDB_Click(object sender, RoutedEventArgs e)
        {
            if (txtpBuy.Text == "" || txtpCode.Text == "" || txtpName.Text == "" || txtpSell.Text == "" || cbType.SelectedItem == null || cbUnit.SelectedItem == null)
            {
                MessageBox.Show("กรุณาเลือกข้อมูลที่ต้องการลบ");
                return;
            }
            MessageBoxResult result = MessageBox.Show("กรุณายืนยันการลบ!!!", "ลบเรียบร้อยแล้ว", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            else
            {
                using (con)
                {
                    using(MySqlCommand deletefromdb=new MySqlCommand())
                    {
                        deletefromdb.Connection = con;

                        con.Open();
                        deletefromdb.CommandText = @"DELETE FROM product WHERE proCode='" + txtpCode.Text + "'";
                        deletefromdb.ExecuteNonQuery();
                        con.Close();

                        con.Open();
                        deletefromdb.CommandText = @"DELETE FROM stock WHERE proID='" + getproID + "'";
                        deletefromdb.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("ลบข้อมูลสำเร็จ!!!");
                        ShowdatainDataGrid(); // method show ข้อมูลใน datagrid
                        ClearTextbox();

                        // คืน ID
                        con.Open();
                        string getproCode = "SELECT proCode FROM product";
                        MySqlCommand cmd = new MySqlCommand(getproCode, con);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        txtpCode.Text = "001";
                        while (reader.Read())
                        {
                            getShowCode = reader["proCode"].ToString();
                            if (getShowCode != "")
                            {
                                showCode = Convert.ToInt32(getShowCode);
                                showCode += 1;
                                txtpCode.Text = showCode.ToString("000");
                            }
                        }
                        con.Close();
                        // ปิด
                    }
                }
            }
        }

        private void checkNameproDuct()
        {
            con.Open();
            string checkfromdb = "SELECT proCode,proName,proPricebuy,proPricesell FROM product WHERE (proCode='" + txtpCode.Text + "') OR (proName='"+txtpName.Text+ "') OR (proPricebuy='" + txtpBuy.Text + "') OR (proPricesell='" + txtpSell.Text + "')";
            MySqlCommand checkdbcmd = new MySqlCommand(checkfromdb, con);
            MySqlDataReader reader = checkdbcmd.ExecuteReader();

            while (reader.Read())
            {
                checknameType = reader["proName"].ToString();
                checkidType = reader["proCode"].ToString();
                checkPricebuy = reader["proPricebuy"].ToString();
                checkPricesell = reader["proPricesell"].ToString();
            }
            con.Close();
        }

        private void ClearTextbox()
        {
            txtpBuy.Text = "";
            txtpName.Text = "";
            txtpSell.Text = "";
            cbUnit.Text = "";
            cbType.Text = "";
        }

        private void ClearData_Click(object sender, RoutedEventArgs e)
        {
            ClearTextbox();
        }

    }
}
