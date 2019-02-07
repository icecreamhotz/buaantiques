using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2016App
{
    public partial class frmPrintDecided : Form
    {

        List<DecidedDetails> _list;

        public frmPrintDecided(List<DecidedDetails> list)
        {
            InitializeComponent();
            _list = list;
        }

        private void frmPrintDecided_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("th-TH");
            rptDecided1.SetDataSource(_list);
            crystalReportViewer1.ReportSource = rptDecided1;
            crystalReportViewer1.Refresh();
        }
    }
}
