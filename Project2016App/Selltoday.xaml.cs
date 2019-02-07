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
using System.Threading;

namespace Project2016App
{
    /// <summary>
    /// Interaction logic for Selltoday.xaml
    /// </summary>
    public partial class Selltoday : Window
    {
        System.Collections.ObjectModel.ObservableCollection<DataBuytoday> oc = new System.Collections.ObjectModel.ObservableCollection<DataBuytoday>();

        double intSum = 0.0, dTotal = 0.0, pTotal = 0.0, plTotal = 0.0, Totald = 0.0, LastTotal = 0.0;
        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui");

        double getTotal = 0.0;
        double getStockTotal, Totalall;
        int count = -1, Docid, id, calcusID;
        string getTypeid, getproID, getcusID, checkplate;
        int varcusID;

        public Selltoday()
        {
            InitializeComponent();

            txtInfototal.IsEnabled = false;
            txtSubtotal.IsEnabled = false;

            con.Open();
            string value = "SELECT docID FROM selltoday";
            MySqlCommand cmd = new MySqlCommand(value, con);
            MySqlDataReader rd = cmd.ExecuteReader();

            ShowBill.Text = "S000000000";
            while (rd.Read())
            {
                string Billid = rd["docID"].ToString();
                if (Billid != "")
                {
                    string varBill = Billid.Substring(1);
                    Docid = Convert.ToInt32(varBill);
                    id = Docid+1;
                    ShowBill.Text = "S" + id.ToString("000000000");
                }
            }
            con.Close();

            DateTime TheDate = DateTime.Now;
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("th-TH");
            txtDate.Text = TheDate.ToLongDateString();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Searchname go = new Searchname();
            go.sendID = txtID.Text;
            go.sendName = txtName.Text;
            go.sendLname = txtLname.Text;
            go.sendAddress = txtAddress.Text;
            go.sendCard = txtCard.Text;
            go.sendPlate = txtPlate.Text;
            go.sendTel = txtTel.Text;
            go.ShowDialog();

            txtID.Text = go.sendID;
            txtName.Text = go.sendName;
            txtLname.Text = go.sendLname;
            txtAddress.Text = go.sendAddress;
            txtCard.Text = go.sendCard;
            txtPlate.Text = go.sendPlate;
            txtTel.Text = go.sendTel;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SearchProduct gogo = new SearchProduct();
            gogo.sendCount = "2";
            gogo.sendCode = txtProductid.Text;
            gogo.sendName = txtNameproduct.Text;
            gogo.sendPricesell = txtPrice.Text;
            gogo.sendUnit = txtUnit.Text;
            gogo.ShowDialog();

            txtProductid.Text = gogo.sendCode;
            txtNameproduct.Text = gogo.sendName;
            txtPrice.Text = gogo.sendPricesell;
            txtUnit.Text = gogo.sendUnit;

            double totalcal, pricecall, price;
            if (txtTotal.Text == "" || txttotalPrice.Text == "")
            {
                return;
            }
            else
            {
                totalcal = Double.Parse(txtTotal.Text);
                price = Double.Parse(txtPrice.Text);
                pricecall = totalcal * price;
                txttotalPrice.Text = pricecall.ToString();
            }
        }

        private void AfterEnter(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }
            else
            {
                e.Handled = true;
            }

            if (txtPrice.Text == "")
            {
                return;
            }

            string[] parts = txtTotal.Text.Split('+');
            intSum = 0.0;

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] == "" || parts[i] == " ")
                {
                    parts[i] = "0.0";
                }
                else
                {
                    intSum += Double.Parse(parts[i]);
                    intSum -= dTotal;
                }
            }
            txtSubtotal.Text = intSum.ToString();

            pTotal = Double.Parse(txtPrice.Text);
            plTotal = intSum * pTotal;
            txttotalPrice.Text = plTotal.ToString();

            txtInfototal.Text = txtTotal.Text;
            txtTotal.Text = intSum.ToString();

            intSum += dTotal;
            txtContainer.Text = "0";
        }

        private void AfterEnterTotal(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }
            else
            {
                e.Handled = true;
            }

            if (txtContainer.Text == "" || txtPrice.Text == "")
            {
                return;
            }

            dTotal = Double.Parse(txtContainer.Text);
            pTotal = Double.Parse(txtPrice.Text);

            intSum -= dTotal; // จำนวน ลบ ที่หัก
            txtSubtotal.Text = intSum.ToString();
            intSum += dTotal; // จำนวน + ที่หัก เพือสมดุล

            Totald = (intSum - dTotal); // จำนวน - กับที่หัก
            plTotal = Totald * pTotal; // ราคารวม
            txttotalPrice.Text = plTotal.ToString();
            intSum = Totald; // ยอดรวม
            intSum += dTotal; // จำนวน + ที่หัก เพือสมดุล

        }

        private void AddData_Click(object sender, RoutedEventArgs e)
        {
            if (txtContainer.Text == "" || txtMessage.Text == "")
            {
                txtContainer.Text = "0";
                txtMessage.Text = "ไม่มี";
            }

            if (txtProductid.Text == "" || txtNameproduct.Text == "" || txtTotal.Text == "" || txtContainer.Text == ""
                || txtTotal.Text == "" || txtInfototal.Text == "" || txtPrice.Text == "" || txttotalPrice.Text == "" )
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ","คำเตือน");
                return;
            }

            dataGrid.Items.Add(new DataBuytoday() { Code = txtProductid.Text, Name = txtNameproduct.Text, Ptotal = txtTotal.Text, Dtotal = txtContainer.Text, Atotal = intSum.ToString(), Mtotal = txtInfototal.Text, Price = txtPrice.Text, Typenub = txtUnit.Text, Tprice = txttotalPrice.Text, Note = txtMessage.Text });
            this.DataContext = dataGrid;

            LastTotal += plTotal;
            TotalLast.Text = LastTotal.ToString();

            txtProductid.Text = "";
            txtNameproduct.Text = "";
            txtPrice.Text = "";
            txtUnit.Text = "";
            txtTotal.Text = "";
            txtContainer.Text = "";
            txtSubtotal.Text = "";
            txtInfototal.Text = "";
            txttotalPrice.Text = "";
            txtMessage.Text = "";

            dataGrid.SelectedIndex = 0;
        }

        private void DeleteRow(object sender, RoutedEventArgs e)
        {
            var selectItem = dataGrid.SelectedItem;
            if (selectItem != null)
            {
                dataGrid.Items.Remove(selectItem);
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                DataBuytoday item = (DataBuytoday)dataGrid.SelectedItem;

                // หักลบเงินหลังจากไปอีกหน้า
                TotalLast.Text = item.Tprice;
                plTotal = Double.Parse(TotalLast.Text);
                LastTotal -= plTotal;
                TotalLast.Text = LastTotal.ToString();
                ///

                EditProduct go = new EditProduct();

                go.txtCode.Text = item.Code;
                go.txtUnit.Text = item.Ptotal;
                go.txtTotal.Text = item.Atotal;
                go.txtType.Text = item.Typenub;
                go.txtNote.Text = item.Mtotal;
                go.txtMessage.Text = item.Note;
                go.txtName.Text = item.Name;
                go.txtDelete.Text = item.Dtotal;
                go.txtPrice.Text = item.Price;
                go.txtTotalPrice.Text = item.Tprice;
                go.ShowDialog();

                item.Code = go.getCode;
                item.Name = go.getName;
                item.Ptotal = go.getUnit;
                item.Dtotal = go.getDelete;
                item.Atotal = go.getAllTotal;
                item.Price = go.getPrice;
                item.Typenub = go.getType;
                item.Tprice = go.getTotalprice;
                item.Note = go.getMessage;
                item.Mtotal = go.getNote;

                // คำนวณเงินที่ได้จากการแก้ไขมาแล้ว
                plTotal = Double.Parse(go.txtTotalPrice.Text);
                LastTotal += plTotal;
                TotalLast.Text = LastTotal.ToString();
                //

                dataGrid.Items.Refresh();
            }
        }

        private void SavetoDatabase(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtLname.Text) || string.IsNullOrWhiteSpace(txtPlate.Text) || !txtCard.IsMaskCompleted || !txtTel.IsMaskCompleted)
            {
                System.Windows.MessageBox.Show("กรุณากรอกข้อมูลให้ครบ (ชื่อ,นามสกุล,ป้ายทะเบียน,เลขบัตรประชาชน สำคัญ)");
                return;
            }

            MessageBoxResult result = System.Windows.MessageBox.Show("คุณต้องการจะบันทึกจริงๆใช่ไหม", "รอคำยืนยัน", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            else
            {
                con.Open();
                string strcheck = "SELECT cusPlate FROM customer WHERE cusPlate='" + txtPlate.Text + "'";
                MySqlCommand cmdcheck = new MySqlCommand(strcheck, con);
                MySqlDataReader readcheck = cmdcheck.ExecuteReader();
                while (readcheck.Read())
                {
                    checkplate = readcheck.GetString(readcheck.GetOrdinal("cusPlate"));
                }
                con.Close();

                if (txtPlate.Text == checkplate)
                {
                    if (string.IsNullOrWhiteSpace(txtID.Text))
                    {
                        System.Windows.MessageBox.Show("คุณบันทึกป้ายทะเบียนนี้แล้ว กรุณาแก้ไขหรือลบ!!!", "คำเตือน");
                        return;
                    }
                    else
                    {
                        calcusID = 1;
                        Insert2DB();
                    }
                }

                if (txtPlate.Text != checkplate)
                {
                    if (string.IsNullOrWhiteSpace(txtID.Text))
                    {
                        calcusID = 2;
                        con.Close();
                        string insertsql = "INSERT INTO customer (cusName,cusLname,cusPlate,cusCard,cusTel) VALUES (@Name,@Lname,@Plate,@cusCard,@cusTel)";
                        MySqlCommand cmdinsert = new MySqlCommand(insertsql, con);
                        cmdinsert.Parameters.AddWithValue("@Name", txtName.Text);
                        cmdinsert.Parameters.AddWithValue("@Lname", txtLname.Text);
                        cmdinsert.Parameters.AddWithValue("@Plate", txtPlate.Text);
                        cmdinsert.Parameters.AddWithValue("@cusCard", txtCard.Text);
                        cmdinsert.Parameters.AddWithValue("@cusTel", txtTel.Text);
                        cmdinsert.Connection.Open();
                        cmdinsert.ExecuteNonQuery();
                        con.Close();

                        //ดึงค่า ID ของ Customer
                        con.Open();
                        string strgetID = "SELECT cusID FROM customer";
                        MySqlCommand cmdgetID = new MySqlCommand(strgetID, con);
                        MySqlDataReader readgetID = cmdgetID.ExecuteReader();
                        while (readgetID.Read())
                        {
                            getcusID = readgetID["cusID"].ToString();
                            varcusID = Convert.ToInt32(getcusID);
                        }
                        con.Close();
                        //

                        Insert2DB();
                    }
                }

            }
        }

        private void Insert2DB()
        {
            try
            {
                using (con)
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = con;

                        for (int i = 0; i < dataGrid.Items.Count; i++)
                        {
                            count += 1;

                            object item = dataGrid.Items[i];

                            string showidProduct = (dataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                            string shownameProduct = (dataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                            string showtotalProduct = (dataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                            string showdeleteProduct = (dataGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                            string showallTotal = (dataGrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                            string showPrice = (dataGrid.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                            string showType = (dataGrid.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
                            string showPriceall = (dataGrid.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
                            string showNote = (dataGrid.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text;

                            con.Open();
                            string sqlproID = "SELECT proID FROM product WHERE proCode='" + showidProduct + "'";
                            MySqlCommand cmdproID = new MySqlCommand(sqlproID, con);
                            MySqlDataReader readproID = cmdproID.ExecuteReader();

                            while (readproID.Read())
                            {
                                getproID = readproID["proID"].ToString();
                            }
                            con.Close();

                            con.Open();
                            string getValue = "SELECT stockTotal FROM stock WHERE proID='" + getproID + "'";
                            MySqlCommand getCommand = new MySqlCommand(getValue, con);
                            MySqlDataReader getReader = getCommand.ExecuteReader();

                            getTotal = Double.Parse(showallTotal);
                            while (getReader.Read())
                            {
                                getStockTotal = Convert.ToDouble(getReader["stockTotal"]);
                                Totalall = getStockTotal - getTotal;
                            }
                            con.Close();

                            con.Open();
                            MySqlCommand cmdgettype = new MySqlCommand("SELECT typepID FROM typeproduct WHERE typepName='" + showType + "'", con);
                            MySqlDataReader readtype = cmdgettype.ExecuteReader();
                            while (readtype.Read())
                            {
                                getTypeid = readtype.GetString(readtype.GetOrdinal("typepID"));
                            }
                            con.Close();

                            if (count >= 1)
                            {
                                con.Open();
                                cmd.CommandText = @"INSERT INTO selltoday(docID,sellDate,cusID,cusName,cusLastname,cusPlate,sellCode,sellName,sellTotal,sellDtotal,sellTotalall,sellPrice,typepID,sellAllprice,sellInfo) 
                                                        VALUES (@Bill,@DATE,@cusID,@nameCus,@lastnameCus,@plateCus,@buyCode,@buyName,@buyTotal,@buyDtotal,@buyTotalall,@buyPrice,@buyType,@buyAllprice,@buyInfo);     
                                                        UPDATE stock SET stockTotal='" + Totalall + "' WHERE proID='" + getproID + "'";
                                cmd.Parameters.AddWithValue("@Bill", ShowBill.Text);
                                cmd.Parameters.AddWithValue("@DATE", Convert.ToDateTime(txtDate.Text).ToString("yyyy/MM/dd"));
                                cmd.Parameters.AddWithValue("@nameCus", txtName.Text);
                                cmd.Parameters.AddWithValue("@lastnameCus", txtLname.Text);
                                cmd.Parameters.AddWithValue("@plateCus", txtPlate.Text);
                                cmd.Parameters.AddWithValue("@buyCode", showidProduct);
                                cmd.Parameters.AddWithValue("@buyName", shownameProduct);
                                cmd.Parameters.AddWithValue("@buyTotal", showtotalProduct);
                                cmd.Parameters.AddWithValue("@buyDtotal", showdeleteProduct);
                                cmd.Parameters.AddWithValue("@buyTotalall", showallTotal);
                                cmd.Parameters.AddWithValue("@buyPrice", showPrice);
                                cmd.Parameters.AddWithValue("@buyType", getTypeid);
                                cmd.Parameters.AddWithValue("@buyAllprice", showPriceall);
                                cmd.Parameters.AddWithValue("@buyInfo", showNote);
                                if (calcusID == 1)
                                {
                                    cmd.Parameters.AddWithValue("@cusID", txtID.Text);
                                }
                                else if (calcusID == 2)
                                {
                                    cmd.Parameters.AddWithValue("@cusID", varcusID);
                                }
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                                con.Close();
                            }
                            else
                            {
                                con.Open();
                                cmd.CommandText = @"INSERT INTO selltoday(docID,sellDate,cusID,cusName,cusLastname,cusPlate,sellCode,sellName,sellTotal,sellDtotal,sellTotalall,sellPrice,typepID,sellAllprice,sellInfo) 
                                                        VALUES (@Bill,@DATE,@cusID,@nameCus,@lastnameCus,@plateCus,@buyCode,@buyName,@buyTotal,@buyDtotal,@buyTotalall,@buyPrice,@buyType,@buyAllprice,@buyInfo);
                                                        INSERT INTO receiptsell(receiptDate,receiptCode,cusID,cusName,cusLastname,cusPlate,receiptInfo,receiptPriceall) VALUES(@DATE,@Bill,@cusID,@nameCus,@lastnameCus,@plateCus,@buyInfo,@buyAllprice);
                                                        UPDATE stock SET stockTotal='" + Totalall + "' WHERE proID='" + getproID + "'";
                                cmd.Parameters.AddWithValue("@Bill", ShowBill.Text);
                                cmd.Parameters.AddWithValue("@DATE", Convert.ToDateTime(txtDate.Text).ToString("yyyy/MM/dd"));
                                cmd.Parameters.AddWithValue("@nameCus", txtName.Text);
                                cmd.Parameters.AddWithValue("@lastnameCus", txtLname.Text);
                                cmd.Parameters.AddWithValue("@plateCus", txtPlate.Text);
                                cmd.Parameters.AddWithValue("@buyCode", showidProduct);
                                cmd.Parameters.AddWithValue("@buyName", shownameProduct);
                                cmd.Parameters.AddWithValue("@buyTotal", showtotalProduct);
                                cmd.Parameters.AddWithValue("@buyDtotal", showdeleteProduct);
                                cmd.Parameters.AddWithValue("@buyTotalall", showallTotal);
                                cmd.Parameters.AddWithValue("@buyPrice", showPrice);
                                cmd.Parameters.AddWithValue("@buyType", getTypeid);
                                cmd.Parameters.AddWithValue("@buyAllprice", showPriceall);
                                cmd.Parameters.AddWithValue("@buyInfo", showNote);
                                if (calcusID == 1)
                                {
                                    cmd.Parameters.AddWithValue("@cusID", txtID.Text);
                                }
                                else if (calcusID == 2)
                                {
                                    cmd.Parameters.AddWithValue("@cusID", varcusID);
                                }
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                                con.Close();
                            }
                        }// ปิด LOOP    
                    } // ปิด Using
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("บันทึกเรียบร้อยแล้ว", "สำเร็จ");
            Selltoday go = new Selltoday();
            this.Close();
            go.Show();
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            Historysell go = new Historysell();
            go.Show();
        }

        public class DataBuytoday
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public string Ptotal { get; set; }
            public string Dtotal { get; set; }
            public string Atotal { get; set; }
            public string Mtotal { get; set; }
            public string Price { get; set; }
            public string Typenub { get; set; }
            public string Tprice { get; set; }
            public string Note { get; set; }
        }

        private void AfterPressContain(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D0:
                case Key.D1:
                case Key.D2:
                case Key.D3:
                case Key.D4:
                case Key.D5:
                case Key.D6:
                case Key.D7:
                case Key.D8:
                case Key.D9:
                case Key.NumLock:
                case Key.NumPad0:
                case Key.NumPad1:
                case Key.NumPad2:
                case Key.NumPad3:
                case Key.NumPad4:
                case Key.NumPad5:
                case Key.NumPad6:
                case Key.NumPad7:
                case Key.NumPad8:
                case Key.NumPad9:
                    break;
                default:
                    e.Handled = true;
                    break;
            }
        }

        private void AfterPress(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D0:
                case Key.D1:
                case Key.D2:
                case Key.D3:
                case Key.D4:
                case Key.D5:
                case Key.D6:
                case Key.D7:
                case Key.D8:
                case Key.D9:
                case Key.NumLock:
                case Key.NumPad0:
                case Key.NumPad1:
                case Key.NumPad2:
                case Key.NumPad3:
                case Key.NumPad4:
                case Key.NumPad5:
                case Key.NumPad6:
                case Key.NumPad7:
                case Key.NumPad8:
                case Key.NumPad9:
                case Key.Add:
                case Key.Decimal:
                    break;
                default:
                    e.Handled = true;
                    break;
            }
        }

    }
}
