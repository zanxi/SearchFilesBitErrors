using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SearchWindowsForms.Presenter;

namespace SearchWindowsForms
{
    public partial class Report : Form, IViewStatistics
    {
        public Report()
        {
            InitializeComponent();
            btnSave.Click += (sender, args) => Invoke(Save);
        }

        public new void Show()
        {
            ShowDialog();            
        }

        public string fileName { get { return " "; } }
        public event Action Save;

        public void Invoke(Action action)
        {
            if (action != null) action();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            string te = File.ReadAllText(ProjectSearchCompareFiles.Util.fn);
            richTextBoxReportStatisticsSearch.Text = te;            
        }

        private void richTextBoxReportStatisticsSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
