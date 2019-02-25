namespace TempetarureWidget
{
    partial class Settings
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkBoxDateLabel = new System.Windows.Forms.CheckBox();
            this.labelChannel = new System.Windows.Forms.Label();
            this.labelApi = new System.Windows.Forms.Label();
            this.textBoxChannel = new System.Windows.Forms.TextBox();
            this.textBoxApi = new System.Windows.Forms.TextBox();
            this.trackBarRefreshTime = new System.Windows.Forms.TrackBar();
            this.labelRefresh = new System.Windows.Forms.Label();
            this.textBoxRefreshTime = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.labelField = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRefreshTime)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(453, 155);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // checkBoxDateLabel
            // 
            this.checkBoxDateLabel.AutoSize = true;
            this.checkBoxDateLabel.Location = new System.Drawing.Point(358, 43);
            this.checkBoxDateLabel.Name = "checkBoxDateLabel";
            this.checkBoxDateLabel.Size = new System.Drawing.Size(102, 17);
            this.checkBoxDateLabel.TabIndex = 1;
            this.checkBoxDateLabel.Text = "Show date label";
            this.checkBoxDateLabel.UseVisualStyleBackColor = true;
            // 
            // labelChannel
            // 
            this.labelChannel.AutoSize = true;
            this.labelChannel.Location = new System.Drawing.Point(14, 16);
            this.labelChannel.Name = "labelChannel";
            this.labelChannel.Size = new System.Drawing.Size(46, 13);
            this.labelChannel.TabIndex = 2;
            this.labelChannel.Text = "Channel";
            // 
            // labelApi
            // 
            this.labelApi.AutoSize = true;
            this.labelApi.Location = new System.Drawing.Point(14, 43);
            this.labelApi.Name = "labelApi";
            this.labelApi.Size = new System.Drawing.Size(46, 13);
            this.labelApi.TabIndex = 3;
            this.labelApi.Text = "Api_Key";
            // 
            // textBoxChannel
            // 
            this.textBoxChannel.Location = new System.Drawing.Point(89, 12);
            this.textBoxChannel.Name = "textBoxChannel";
            this.textBoxChannel.Size = new System.Drawing.Size(260, 20);
            this.textBoxChannel.TabIndex = 4;
            // 
            // textBoxApi
            // 
            this.textBoxApi.Location = new System.Drawing.Point(89, 40);
            this.textBoxApi.Name = "textBoxApi";
            this.textBoxApi.Size = new System.Drawing.Size(260, 20);
            this.textBoxApi.TabIndex = 5;
            // 
            // trackBarRefreshTime
            // 
            this.trackBarRefreshTime.Location = new System.Drawing.Point(89, 66);
            this.trackBarRefreshTime.Maximum = 100;
            this.trackBarRefreshTime.Minimum = 1;
            this.trackBarRefreshTime.Name = "trackBarRefreshTime";
            this.trackBarRefreshTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBarRefreshTime.Size = new System.Drawing.Size(145, 45);
            this.trackBarRefreshTime.TabIndex = 6;
            this.trackBarRefreshTime.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarRefreshTime.Value = 1;
            this.trackBarRefreshTime.ValueChanged += new System.EventHandler(this.trackBarRefreshTime_ValueChanged);
            // 
            // labelRefresh
            // 
            this.labelRefresh.AutoSize = true;
            this.labelRefresh.Location = new System.Drawing.Point(14, 69);
            this.labelRefresh.Name = "labelRefresh";
            this.labelRefresh.Size = new System.Drawing.Size(66, 13);
            this.labelRefresh.TabIndex = 7;
            this.labelRefresh.Text = "Refresh time";
            // 
            // textBoxRefreshTime
            // 
            this.textBoxRefreshTime.Location = new System.Drawing.Point(241, 67);
            this.textBoxRefreshTime.Name = "textBoxRefreshTime";
            this.textBoxRefreshTime.Size = new System.Drawing.Size(59, 20);
            this.textBoxRefreshTime.TabIndex = 8;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(390, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "s",
            "m",
            "h"});
            this.comboBox2.Location = new System.Drawing.Point(306, 66);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(43, 21);
            this.comboBox2.TabIndex = 10;
            // 
            // labelField
            // 
            this.labelField.AutoSize = true;
            this.labelField.Location = new System.Drawing.Point(355, 16);
            this.labelField.Name = "labelField";
            this.labelField.Size = new System.Drawing.Size(29, 13);
            this.labelField.TabIndex = 11;
            this.labelField.Text = "Field";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 190);
            this.Controls.Add(this.labelField);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBoxRefreshTime);
            this.Controls.Add(this.labelRefresh);
            this.Controls.Add(this.trackBarRefreshTime);
            this.Controls.Add(this.textBoxApi);
            this.Controls.Add(this.textBoxChannel);
            this.Controls.Add(this.labelApi);
            this.Controls.Add(this.labelChannel);
            this.Controls.Add(this.checkBoxDateLabel);
            this.Controls.Add(this.buttonSave);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRefreshTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkBoxDateLabel;
        private System.Windows.Forms.Label labelChannel;
        private System.Windows.Forms.Label labelApi;
        private System.Windows.Forms.TextBox textBoxChannel;
        private System.Windows.Forms.TextBox textBoxApi;
        private System.Windows.Forms.TrackBar trackBarRefreshTime;
        private System.Windows.Forms.Label labelRefresh;
        private System.Windows.Forms.TextBox textBoxRefreshTime;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label labelField;
    }
}