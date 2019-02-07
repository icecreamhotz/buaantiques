using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Project2016App
{
    public partial class frmPrint : Form
    {

        List<OrderDetails> _list;   

        public frmPrint(List<OrderDetails> list)
        {
            InitializeComponent();
            _list = list;
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("th-TH");
            rptOrder1.SetDataSource(_list);
            crystalReportViewer1.ReportSource = rptOrder1;
            crystalReportViewer1.Refresh();
        }
    }
}
