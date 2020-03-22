using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SearchWindowsForms.Model;
using SearchWindowsForms.Presenter;
using ProjectSearchCompareFiles;
using System.Threading;

namespace SearchWindowsForms
{
    public partial class SearchFile : Ookii.Dialogs.WinForms.ExtendedForm, IMainView
    {
        private readonly ApplicationContext _context;        
        MonitorSearch ms=null;
        MonitorCompareFiles mc=null;

        public SearchFile(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
            btnReport.Click += (sender, args) => Invoke(ViewReportCommand);
        }

        public new void Show()
        { 
            _context.MainForm = this;
            base.ShowDialog();
        }
        public void SetData(string fileName) { }
        public event Action ViewReportCommand;
        private void Invoke(Action action) { if (action != null) action(); }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            buttonTreeIndikator.BackColor = Color.Red;
            DynamicProgressBar(progressBar1.Maximum);
            mc = new MonitorCompareFiles();
            File.WriteAllText(ProjectSearchCompareFiles.Util.fn, "<table>"+ "\n<records>"+ "\n</records>"+"\n</table>");            
        }

        // инфо в прогресбар
        private void DynamicProgressBar(int value)
        {
            progressBar1.Value = value;            
            using (Graphics gr = progressBar1.CreateGraphics())
            {
                gr.DrawString("works " + value.ToString() + " files",
                    SystemFonts.DefaultFont,
                    Brushes.Black,
                    new PointF(progressBar1.Width / 2 - (gr.MeasureString("works "+ value.ToString() + " files",
                        SystemFonts.DefaultFont).Width / 2.0F),
                    progressBar1.Height / 2 - (gr.MeasureString("works " + value.ToString() + " files",
                        SystemFonts.DefaultFont).Height / 2.0F)));
            }
        }
        
        // искать
        private void _bFind_Click(object sender, EventArgs e)
        {

            if (this._tbView.Text == string.Empty || txtFileCompare.Text == string.Empty)
            {
                MessageBox.Show("Не выбрали папку для поиска");
                return;
            }            
            InfoSearch isearch = new InfoSearch();
            isearch.Filecompare = txtFileCompare.Text;
            isearch.FilecompareSize = GetFileSize(txtFileCompare.Text);
            isearch.FlagSearchInSubFolders = this._cbRecurs.Checked;
            isearch.Maskfile = _tbFile.Text;
            isearch.Foldersearch = _tbView.Text;
            isearch.Textsearchinfile = richTextBoxSearch.Text;
            isearch.algorithm = (byte)((checkBox_Bytes.Checked || checkBox_Hash.Checked)?0:1);
            isearch.MaxSizeSearch = trackBar1.Value;

            buttonTreeIndikator.BackColor = Color.Red;
            progressBar1.Value = 0; 
            timer1.Enabled = true; // запустить таймер обновления статистики
            timer1.Interval = 1000;
            buttonTreeIndikator.BackColor = Color.Red;

            ms = new MonitorSearch(isearch);
            while(ms.GetReady())
            {
                Thread.Sleep(500);
                continue;
            }
            buttonTreeIndikator.BackColor = Color.Green;                        
            progressBar1.Maximum = ms.qe_path.Count;
            progressBar1.Value = progressBar1.Maximum;
            mc.SetTasks(ms.qe_path);
        }

        // выбрать папку
        private void _bView_Click(object sender, EventArgs e)
        {
            this._fBrowserDialog.SelectedPath = @"D:\_V2020_\_Rabota_2020__\_Lanit____\data__\";
            if (this._fBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this._tbView.Text = this._fBrowserDialog.SelectedPath;
            }
        }

        // очистить результаты поиска
        private void _bClear_Click(object sender, EventArgs e)
        {
            this._lbAnser.Items.Clear();
            this.txtNumFolder.Text = "";
            txtFileCompare.Text = "";
        }

        
        // обработка нажатия по кнопке "очистить все"        
        private void _bClearAll_Click(object sender, EventArgs e)
        {
            this._tbFile.Text = "";
            this._tbView.Text = "";
            this.txtNumFolder.Text = "";
            txtFileCompare.Text = "";
            this._lbAnser.Items.Clear();
        }
        
        // выбрать файл
        private void button1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"D:\_V2020_\_Rabota_2020__\_Lanit____\data__\";
                
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {                    
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            txtFileCompare.Text = filePath;            
        }

        private void _bClear_Click_1(object sender, EventArgs e)
        {
            try
            {
                _lbAnser.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {            
            labelMaxSizeFile.Text = (trackBar1.Value).ToString() + "; byte";
        }
        
        public long GetFileSize(string file1)
        {
            using (var fs1 = new FileStream(file1, FileMode.Open)) return fs1.Length;            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {            
            DynamicProgressBar(mc.works.Count);//progressBar1.Value += progressBar1.Maximum / 100);
            TimerLogger();
            if (ms.GetReady())
            {
                buttonTreeIndikator.BackColor = Color.Red;
            }
            else buttonTreeIndikator.BackColor = Color.Green;
            if (mc.works.Count == 0)
            {
                btnReport.Enabled = true;
                _bFind.Enabled = true;
            }
            else
            {
                btnReport.Enabled = false;
                _bFind.Enabled = false;
            }
        }

        void TimerLogger()
        {   
            {
                for (int i = Util.messageLine.Count-1; i>=0; i--)                
                {
                    _lbAnser.Items.Add(Util.messageLine[i]);
                }                
                Util.messageLine.Clear();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mc.StopAll();
            Thread.Sleep(1000);
        }

        private void buttonTreeIndikator_Click(object sender, EventArgs e)
        {
            ShowProgressDialog();
        }

        private void ShowProgressDialog()
        {
            if (_sampleProgressDialog.IsBusy)
                MessageBox.Show(this, "The progress dialog is already displayed.", "Progress dialog sample");
            else
                _sampleProgressDialog.Show(this); // Show a modeless dialog; this is the recommended mode of operation for a progress dialog.
        }

        private void _sampleProgressDialog_DoWork(object sender, DoWorkEventArgs e)
        {
            // Implement the operation that the progress bar is showing progress of here, same as you would do with a background worker.
            for (int x = 0; x <= 100; ++x)
            {
                Thread.Sleep(500);
                // Periodically check CancellationPending and abort the operation if required.
                if (_sampleProgressDialog.CancellationPending)
                    return;
                // ReportProgress can also modify the main text and description; pass null to leave them unchanged.
                // If _sampleProgressDialog.ShowTimeRemaining is set to true, the time will automatically be calculated based on
                // the frequency of the calls to ReportProgress.
                _sampleProgressDialog.ReportProgress(x, null, string.Format(System.Globalization.CultureInfo.CurrentCulture, "Processing: {0}%", x));
            }
        }
    }
}
