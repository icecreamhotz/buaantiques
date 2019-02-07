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

    public partial class EditProduct : Window
    {
        public string getCode {
            get
            {
                return txtCode.Text;
            }
        }
        public string getName
        {
            get
            {
                return txtName.Text;
            }
        }
        public string getMessage
        {
            get
            {
                return txtMessage.Text;
            }
        }
        public string getUnit
        {
            get
            {
                return txtUnit.Text;
            }
        }
        public string getDelete
        {
            get
            {
                return txtDelete.Text;
            }
        }
        public string getAllTotal
        {
            get
            {
                return txtTotal.Text;
            }
        }
        public string getPrice
        {
            get
            {
                return txtPrice.Text;
            }
        }
        public string getTotalprice
        {
            get
            {
                return txtTotalPrice.Text;
            }
        }
        public string getType
        {
            get
            {
                return txtType.Text;
            }
        }
        public string getNote
        {
            get
            {
                return txtNote.Text;
            }
        }

        double Total = 0.0,  Price = 0.0, Priceall= 0.0 , Deletetotal=0.0;

        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=1147;database=projectgui");

        public EditProduct()
        {
            InitializeComponent();

            txtName.IsEnabled = false;
            dataGrid.IsEnabled = false;
            txtTotal.IsEnabled = false;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AfterTextChange(object sender, TextChangedEventArgs e)
        {
            if (SearchProduct.Text == "")
            {
                dataGrid.IsEnabled = false;
                con.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM product", con);
                DataSet dt = new DataSet();
                adp.Fill(dt);
                dataGrid.ItemsSource = dt.Tables[0].DefaultView;
                dataGrid.CanUserAddRows = false;
                con.Close();
            }
            else
            {
                dataGrid.IsEnabled = true;
                con.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM product WHERE proName='"+SearchProduct.Text+"' OR proID='"+SearchProduct.Text+"'", con);
                DataSet dt = new DataSet();
                adp.Fill(dt);
                dataGrid.ItemsSource = dt.Tables[0].DefaultView;
                dataGrid.CanUserAddRows = false;
                con.Close();
            }
        }

        private void DoubleClickDatagrid(object sender, MouseButtonEventArgs e)
        {
            object item = dataGrid.SelectedItem;
            txtCode.Text = (dataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            txtName.Text = (dataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            txtPrice.Text = (dataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            txtType.Text = (dataGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;

            Priceall = Total * Price;
            txtTotalPrice.Text = Priceall.ToString();
            SearchProduct.Text = "";
        }

        private void UnitEnterTotal(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }
            else
            {
                e.Handled = true;
            }

            if (txtDelete.Text == "" || txtPrice.Text == ""|| txtUnit.Text == "")
            {
                txtUnit.Text = "0";
                txtDelete.Text = "0";
                Total = Double.Parse(txtUnit.Text);
                Price = Double.Parse(txtPrice.Text);
                Deletetotal = Double.Parse(txtDelete.Text);
                Deletetotal = 0.0;
                txtTotal.Text = txtUnit.Text;
                Priceall = Price * Total;
                txtTotalPrice.Text = Priceall.ToString();
                return;
            }
            else
            {
                string[] parts = txtUnit.Text.Split('+');
                Total = 0.0;

                for (int i = 0; i < parts.Length; i++)
                {
                    if (parts[i] == "" || parts[i] == " ")
                    {
                        parts[i] = "0.0";
                    }
                    else
                    {
                        Total += Double.Parse(parts[i]);
                        Total -= Deletetotal;
                    }
                }
                Price = Double.Parse(txtPrice.Text);
                txtTotal.Text = Total.ToString();
                Priceall = Price * Total;
                txtTotalPrice.Text = Priceall.ToString();
                Total += Deletetotal;
            }
        }


        private void AfterEnterDelete(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }
            else
            {
                e.Handled = true;
            }

            if (txtPrice.Text.Length == 0 || txtDelete.Text.Length == 0 || txtUnit.Text.Length == 0)
            {
                return;
            }
            else
            {
                Total = Double.Parse(txtUnit.Text);
                Deletetotal = Double.Parse(txtDelete.Text);
                Price = Double.Parse(txtPrice.Text);
                Total -= Deletetotal;
                txtTotal.Text = Total.ToString();

                Priceall = Total * Price;
                txtTotalPrice.Text = Priceall.ToString();
                Total += Deletetotal;
            }
        }

        private void UnitInput(object sender, KeyEventArgs e)
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

        private void AfterInputDelete(object sender, KeyEventArgs e)
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
                case Key.Decimal:
                    break;
                default:
                    e.Handled = true;
                    break;
            }
        }

    }
}
