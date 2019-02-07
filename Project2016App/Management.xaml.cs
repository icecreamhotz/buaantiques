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

namespace Project2016App
{
    /// <summary>
    /// Interaction logic for Management.xaml
    /// </summary>
    public partial class Management : Window
    {
        public Management(string text)
        {
            InitializeComponent();
            Showname.Content = "ยินดีต้อนรับคุณ : " + text;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            InfoEmployee go = new InfoEmployee();
            go.Show();
        }

        private void Verify_Click(object sender, RoutedEventArgs e)
        {
            VerifyCustomer go = new VerifyCustomer();
            go.Show();
        }

        private void MenuItem2_Click(object sender, RoutedEventArgs e)
        {
            Checkwork go = new Checkwork();
            go.Show();
        }

        private void MenuItem3_Click(object sender,RoutedEventArgs e)
        {
            ManageCheckwork go = new ManageCheckwork();
            go.Show();
        }


        private void MenuItem4_Click(object sender, RoutedEventArgs e)
        {
            CalcuateSalary go = new CalcuateSalary();
            go.Show();
        }

        private void MenuItem5_Click(object sender, RoutedEventArgs e)
        {
            Salaryemp go = new Salaryemp();
            go.Show();
        }


        private void Buytoday_Click(object sender, RoutedEventArgs e)
        {
            Buytoday go = new Buytoday();
            go.Show();
        }

        private void CatProduct_Click(object sender, RoutedEventArgs e)
        {
            Product go = new Product();
            go.Show();
        }


        private void TypeProduct_Click(object sender, RoutedEventArgs e)
        {
            TypeProduct go = new TypeProduct();
            go.Show();
        }

        private void ProductandPrice_Click(object sender, RoutedEventArgs e)
        {
            ProductandPrice go = new ProductandPrice();
            go.Show();
        }   

        private void Stock_Click(object sender, RoutedEventArgs e)
        {
            Stock go = new Stock();
            go.Show();
        }

        private void Selltoday_Click(object sender, RoutedEventArgs e)
        {
            Selltoday go = new Selltoday();
            go.Show();
        }

        private void Statistic_Click(object sender, RoutedEventArgs e)
        {
            Statistic go = new Statistic();
            go.Show();
        }

        private void AccCode_Click(object sender, RoutedEventArgs e)
        {
            Typeledger go = new Typeledger();
            go.Show();
        }

        private void InsertAccount_Click(object sender, RoutedEventArgs e)
        {
            Account go = new Account();
            go.Show();
        }

        private void Checkincome_Click(object sender, RoutedEventArgs e)
        {
            CheckIncome go = new CheckIncome();
            go.Show();
        }

        private void Decided_Click(object sender, RoutedEventArgs e)
        {
            Decided go = new Decided();
            go.Show();
        }
        
        private void ReportDecided_Click(object sender, RoutedEventArgs e)
        {
            ReportDecided go = new ReportDecided();
            go.Show();
        }
    }
}
