namespace SearchWindowsForms
{
    partial class SearchFile 
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnReport = new System.Windows.Forms.Button();
            this._bClearAll = new System.Windows.Forms.Button();
            this._bClear = new System.Windows.Forms.Button();
            this._lSearchResult = new System.Windows.Forms.Label();
            this._cbRecurs = new System.Windows.Forms.CheckBox();
            this._lSearchPath = new System.Windows.Forms.Label();
            this._lSearchFileName = new System.Windows.Forms.Label();
            this._bFind = new System.Windows.Forms.Button();
            this._bView = new System.Windows.Forms.Button();
            this._tbView = new System.Windows.Forms.TextBox();
            this._tbFile = new System.Windows.Forms.TextBox();
            this._fBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtNumFolder = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this._sampleProgressDialog = new Ookii.Dialogs.WinForms.ProgressDialog(this.components);

            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_Bytes = new System.Windows.Forms.CheckBox();
            this.checkBox_Hash = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFileCompare = new System.Windows.Forms.TextBox();
            this.richTextBoxSearch = new System.Windows.Forms.RichTextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.labelMaxSizeFile = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this._lbAnser = new System.Windows.Forms.ListBox();
            this.buttonTreeIndikator = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(70, 599);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(179, 44);
            this.btnReport.TabIndex = 2;
            this.btnReport.Text = "Посмотреть статистику";
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // _bClearAll
            // 
            this._bClearAll.Location = new System.Drawing.Point(123, 504);
            this._bClearAll.Name = "_bClearAll";
            this._bClearAll.Size = new System.Drawing.Size(124, 23);
            this._bClearAll.TabIndex = 22;
            this._bClearAll.Text = "Очистить все";
            this._bClearAll.UseVisualStyleBackColor = true;
            this._bClearAll.Click += new System.EventHandler(this._bClearAll_Click);
            // 
            // _bClear
            // 
            this._bClear.Location = new System.Drawing.Point(123, 474);
            this._bClear.Name = "_bClear";
            this._bClear.Size = new System.Drawing.Size(124, 23);
            this._bClear.TabIndex = 21;
            this._bClear.Text = "Очистить результаты";
            this._bClear.UseVisualStyleBackColor = true;
            this._bClear.Click += new System.EventHandler(this._bClear_Click_1);
            // 
            // _lSearchResult
            // 
            this._lSearchResult.AutoSize = true;
            this._lSearchResult.Location = new System.Drawing.Point(125, 447);
            this._lSearchResult.Name = "_lSearchResult";
            this._lSearchResult.Size = new System.Drawing.Size(109, 13);
            this._lSearchResult.TabIndex = 20;
            this._lSearchResult.Text = "Результаты поиска:";
            // 
            // _cbRecurs
            // 
            this._cbRecurs.AutoSize = true;
            this._cbRecurs.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._cbRecurs.Checked = true;
            this._cbRecurs.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cbRecurs.Location = new System.Drawing.Point(119, 120);
            this._cbRecurs.Name = "_cbRecurs";
            this._cbRecurs.Size = new System.Drawing.Size(128, 17);
            this._cbRecurs.TabIndex = 19;
            this._cbRecurs.Text = "Искать в подпапках";
            this._cbRecurs.UseVisualStyleBackColor = true;
            // 
            // _lSearchPath
            // 
            this._lSearchPath.AutoSize = true;
            this._lSearchPath.Location = new System.Drawing.Point(120, 93);
            this._lSearchPath.Name = "_lSearchPath";
            this._lSearchPath.Size = new System.Drawing.Size(66, 13);
            this._lSearchPath.TabIndex = 18;
            this._lSearchPath.Text = "Где искать:";
            // 
            // _lSearchFileName
            // 
            this._lSearchFileName.AutoSize = true;
            this._lSearchFileName.Location = new System.Drawing.Point(112, 62);
            this._lSearchFileName.Name = "_lSearchFileName";
            this._lSearchFileName.Size = new System.Drawing.Size(137, 13);
            this._lSearchFileName.TabIndex = 17;
            this._lSearchFileName.Text = "маска файла для поиска:";
            // 
            // _bFind
            // 
            this._bFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._bFind.Location = new System.Drawing.Point(253, 116);
            this._bFind.Name = "_bFind";
            this._bFind.Size = new System.Drawing.Size(741, 23);
            this._bFind.TabIndex = 15;
            this._bFind.Text = "Искать!";
            this._bFind.UseVisualStyleBackColor = true;
            this._bFind.Click += new System.EventHandler(this._bFind_Click);
            // 
            // _bView
            // 
            this._bView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._bView.Location = new System.Drawing.Point(1000, 87);
            this._bView.Name = "_bView";
            this._bView.Size = new System.Drawing.Size(81, 23);
            this._bView.TabIndex = 14;
            this._bView.Text = "Обзор...";
            this._bView.UseVisualStyleBackColor = true;
            this._bView.Click += new System.EventHandler(this._bView_Click);
            // 
            // _tbView
            // 
            this._tbView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tbView.Location = new System.Drawing.Point(253, 90);
            this._tbView.Name = "_tbView";
            this._tbView.Size = new System.Drawing.Size(741, 20);
            this._tbView.TabIndex = 13;
            // 
            // _tbFile
            // 
            this._tbFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tbFile.Location = new System.Drawing.Point(253, 59);
            this._tbFile.Name = "_tbFile";
            this._tbFile.Size = new System.Drawing.Size(829, 20);
            this._tbFile.TabIndex = 12;
            this._tbFile.Text = "*.dll*";
            // 
            // txtNumFolder
            // 
            this.txtNumFolder.Location = new System.Drawing.Point(123, 533);
            this.txtNumFolder.Name = "txtNumFolder";
            this.txtNumFolder.Size = new System.Drawing.Size(124, 20);
            this.txtNumFolder.TabIndex = 23;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(252, 185);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(837, 20);
            this.textBox1.TabIndex = 24;
            this.textBox1.Text = "dos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Искать текст в файлах";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "алгоритм сравнения";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(253, 12);
            this.progressBar1.Maximum = 100000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(837, 27);
            this.progressBar1.TabIndex = 30;

            // 
            // _sampleProgressDialog
            // 
            this._sampleProgressDialog.Description = "Processing...";
            this._sampleProgressDialog.ShowTimeRemaining = true;
            this._sampleProgressDialog.Text = "This is a sample progress dialog...";
            this._sampleProgressDialog.WindowTitle = "Progress dialog sample";
            this._sampleProgressDialog.DoWork += new System.ComponentModel.DoWorkEventHandler(this._sampleProgressDialog_DoWork);


            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(115, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Состояние поиска";
            // 
            // checkBox_Bytes
            // 
            this.checkBox_Bytes.AutoSize = true;
            this.checkBox_Bytes.Location = new System.Drawing.Point(125, 295);
            this.checkBox_Bytes.Name = "checkBox_Bytes";
            this.checkBox_Bytes.Size = new System.Drawing.Size(78, 17);
            this.checkBox_Bytes.TabIndex = 32;
            this.checkBox_Bytes.Text = "по байтам";
            this.checkBox_Bytes.UseVisualStyleBackColor = true;
            // 
            // checkBox_Hash
            // 
            this.checkBox_Hash.AutoSize = true;
            this.checkBox_Hash.Location = new System.Drawing.Point(125, 318);
            this.checkBox_Hash.Name = "checkBox_Hash";
            this.checkBox_Hash.Size = new System.Drawing.Size(85, 17);
            this.checkBox_Hash.TabIndex = 33;
            this.checkBox_Hash.Text = "hash-сумма";
            this.checkBox_Hash.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(68, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "выбрать файл для сравнения";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFileCompare
            // 
            this.txtFileCompare.Location = new System.Drawing.Point(253, 156);
            this.txtFileCompare.Name = "txtFileCompare";
            this.txtFileCompare.Size = new System.Drawing.Size(837, 20);
            this.txtFileCompare.TabIndex = 35;
            // 
            // richTextBoxSearch
            // 
            this.richTextBoxSearch.Location = new System.Drawing.Point(253, 212);
            this.richTextBoxSearch.Name = "richTextBoxSearch";
            this.richTextBoxSearch.Size = new System.Drawing.Size(836, 48);
            this.richTextBoxSearch.TabIndex = 36;
            this.richTextBoxSearch.Text = "";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(30, 377);
            this.trackBar1.Maximum = 100000;
            this.trackBar1.Minimum = 10;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(204, 45);
            this.trackBar1.SmallChange = 10;
            this.trackBar1.TabIndex = 37;
            this.trackBar1.Value = 100;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 350);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "максимальный размер файлов";
            // 
            // labelMaxSizeFile
            // 
            this.labelMaxSizeFile.AutoSize = true;
            this.labelMaxSizeFile.Location = new System.Drawing.Point(128, 425);
            this.labelMaxSizeFile.Name = "labelMaxSizeFile";
            this.labelMaxSizeFile.Size = new System.Drawing.Size(85, 13);
            this.labelMaxSizeFile.TabIndex = 39;
            this.labelMaxSizeFile.Text = "labelMaxSizeFile";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // _lbAnser
            // 
            this._lbAnser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lbAnser.FormattingEnabled = true;
            this._lbAnser.Location = new System.Drawing.Point(253, 266);
            this._lbAnser.Name = "_lbAnser";
            this._lbAnser.Size = new System.Drawing.Size(829, 472);
            this._lbAnser.TabIndex = 16;
            // 
            // buttonTreeIndikator
            // 
            this.buttonTreeIndikator.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonTreeIndikator.ForeColor = System.Drawing.Color.Red;
            this.buttonTreeIndikator.Location = new System.Drawing.Point(1001, 115);
            this.buttonTreeIndikator.Name = "buttonTreeIndikator";
            this.buttonTreeIndikator.Size = new System.Drawing.Size(81, 23);
            this.buttonTreeIndikator.TabIndex = 40;
            this.buttonTreeIndikator.Text = "tree";
            this.buttonTreeIndikator.UseVisualStyleBackColor = false;
            this.buttonTreeIndikator.Click += new System.EventHandler(this.buttonTreeIndikator_Click);
            // 
            // SearchFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 741);
            this.Controls.Add(this.buttonTreeIndikator);
            this.Controls.Add(this.labelMaxSizeFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.richTextBoxSearch);
            this.Controls.Add(this.txtFileCompare);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox_Hash);
            this.Controls.Add(this.checkBox_Bytes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtNumFolder);
            this.Controls.Add(this._bClearAll);
            this.Controls.Add(this._bClear);
            this.Controls.Add(this._lSearchResult);
            this.Controls.Add(this._cbRecurs);
            this.Controls.Add(this._lSearchPath);
            this.Controls.Add(this._lSearchFileName);
            this.Controls.Add(this._lbAnser);
            this.Controls.Add(this._bFind);
            this.Controls.Add(this._bView);
            this.Controls.Add(this._tbView);
            this.Controls.Add(this._tbFile);
            this.Controls.Add(this.btnReport);
            this.Name = "SearchFile";
            this.Text = "Поиск файлов(учет битовых дефектов)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button _bClearAll;
        private System.Windows.Forms.Button _bClear;
        private System.Windows.Forms.Label _lSearchResult;
        private System.Windows.Forms.CheckBox _cbRecurs;
        private System.Windows.Forms.Label _lSearchPath;
        private System.Windows.Forms.Label _lSearchFileName;
        private System.Windows.Forms.Button _bFind;
        private System.Windows.Forms.Button _bView;
        private System.Windows.Forms.TextBox _tbView;
        private System.Windows.Forms.TextBox _tbFile;
        private System.Windows.Forms.FolderBrowserDialog _fBrowserDialog;
        private System.Windows.Forms.TextBox txtNumFolder;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox_Bytes;
        private System.Windows.Forms.CheckBox checkBox_Hash;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFileCompare;
        private System.Windows.Forms.RichTextBox richTextBoxSearch;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelMaxSizeFile;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox _lbAnser;
        private System.Windows.Forms.Button buttonTreeIndikator;

        private Ookii.Dialogs.WinForms.ProgressDialog _sampleProgressDialog;
    }
}

