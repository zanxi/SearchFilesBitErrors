namespace SearchWindowsForms
{
    partial class Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {            
            this.btnSave = new System.Windows.Forms.Button();
            this.richTextBoxReportStatisticsSearch = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(227, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(146, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // richTextBoxReportStatisticsSearch
            // 
            this.richTextBoxReportStatisticsSearch.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxReportStatisticsSearch.Name = "richTextBoxReportStatisticsSearch";
            this.richTextBoxReportStatisticsSearch.Size = new System.Drawing.Size(1284, 637);
            this.richTextBoxReportStatisticsSearch.TabIndex = 2;
            this.richTextBoxReportStatisticsSearch.Text = "";
            this.richTextBoxReportStatisticsSearch.TextChanged += new System.EventHandler(this.richTextBoxReportStatisticsSearch_TextChanged);
            // 
            // ChangeUsernameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 661);
            this.Controls.Add(this.richTextBoxReportStatisticsSearch);
            this.Controls.Add(this.btnSave);                        
            this.Text = "Статистика поиска";
            this.Load += new System.EventHandler(this.Report_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox richTextBoxReportStatisticsSearch;
    }
}