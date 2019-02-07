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
    public partial class frmPrintsell : Form
    {

        List<Selldetails> _list;

        public frmPrintsell(List<Selldetails> list)
        {
            InitializeComponent();
            _list = list;
        }

        private void frmPrintsell_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("th-TH");
            rptSell1.SetDataSource(_list);
            crystalReportViewer1.ReportSource = rptSell1;
            crystalReportViewer1.Refresh();
        }
    }
}
