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
            this.comboBoxFields = new System.Windows.Forms.ComboBox();
            this.comboBoxRefreshTimeUnit = new System.Windows.Forms.ComboBox();
            this.labelField = new System.Windows.Forms.Label();
            this.groupBoxConnections = new System.Windows.Forms.GroupBox();
            this.groupBoxProperties = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonColor = new System.Windows.Forms.Button();
            this.textBoxTransparency = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarTransparency = new System.Windows.Forms.TrackBar();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRefreshTime)).BeginInit();
            this.groupBoxConnections.SuspendLayout();
            this.groupBoxProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTransparency)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(284, 313);
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
            this.checkBoxDateLabel.Location = new System.Drawing.Point(19, 99);
            this.checkBoxDateLabel.Name = "checkBoxDateLabel";
            this.checkBoxDateLabel.Size = new System.Drawing.Size(102, 17);
            this.checkBoxDateLabel.TabIndex = 1;
            this.checkBoxDateLabel.Text = "Show date label";
            this.checkBoxDateLabel.UseVisualStyleBackColor = true;
            // 
            // labelChannel
            // 
            this.labelChannel.AutoSize = true;
            this.labelChannel.Location = new System.Drawing.Point(16, 21);
            this.labelChannel.Name = "labelChannel";
            this.labelChannel.Size = new System.Drawing.Size(46, 13);
            this.labelChannel.TabIndex = 2;
            this.labelChannel.Text = "Channel";
            // 
            // labelApi
            // 
            this.labelApi.AutoSize = true;
            this.labelApi.Location = new System.Drawing.Point(16, 48);
            this.labelApi.Name = "labelApi";
            this.labelApi.Size = new System.Drawing.Size(46, 13);
            this.labelApi.TabIndex = 3;
            this.labelApi.Text = "Api_Key";
            // 
            // textBoxChannel
            // 
            this.textBoxChannel.Location = new System.Drawing.Point(88, 19);
            this.textBoxChannel.Name = "textBoxChannel";
            this.textBoxChannel.Size = new System.Drawing.Size(259, 20);
            this.textBoxChannel.TabIndex = 4;
            this.textBoxChannel.TextChanged += new System.EventHandler(this.textBoxChannel_TextChanged);
            // 
            // textBoxApi
            // 
            this.textBoxApi.Location = new System.Drawing.Point(88, 45);
            this.textBoxApi.Name = "textBoxApi";
            this.textBoxApi.Size = new System.Drawing.Size(259, 20);
            this.textBoxApi.TabIndex = 5;
            this.textBoxApi.TextChanged += new System.EventHandler(this.textBoxChannel_TextChanged);
            // 
            // trackBarRefreshTime
            // 
            this.trackBarRefreshTime.Location = new System.Drawing.Point(88, 98);
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
            this.labelRefresh.Location = new System.Drawing.Point(16, 101);
            this.labelRefresh.Name = "labelRefresh";
            this.labelRefresh.Size = new System.Drawing.Size(66, 13);
            this.labelRefresh.TabIndex = 7;
            this.labelRefresh.Text = "Refresh time";
            // 
            // textBoxRefreshTime
            // 
            this.textBoxRefreshTime.Location = new System.Drawing.Point(239, 98);
            this.textBoxRefreshTime.Name = "textBoxRefreshTime";
            this.textBoxRefreshTime.Size = new System.Drawing.Size(59, 20);
            this.textBoxRefreshTime.TabIndex = 8;
            // 
            // comboBoxFields
            // 
            this.comboBoxFields.FormattingEnabled = true;
            this.comboBoxFields.Location = new System.Drawing.Point(88, 71);
            this.comboBoxFields.Name = "comboBoxFields";
            this.comboBoxFields.Size = new System.Drawing.Size(138, 21);
            this.comboBoxFields.TabIndex = 9;
            // 
            // comboBoxRefreshTimeUnit
            // 
            this.comboBoxRefreshTimeUnit.FormattingEnabled = true;
            this.comboBoxRefreshTimeUnit.Items.AddRange(new object[] {
            "s",
            "m",
            "h"});
            this.comboBoxRefreshTimeUnit.Location = new System.Drawing.Point(304, 98);
            this.comboBoxRefreshTimeUnit.Name = "comboBoxRefreshTimeUnit";
            this.comboBoxRefreshTimeUnit.Size = new System.Drawing.Size(43, 21);
            this.comboBoxRefreshTimeUnit.TabIndex = 10;
            // 
            // labelField
            // 
            this.labelField.AutoSize = true;
            this.labelField.Location = new System.Drawing.Point(16, 74);
            this.labelField.Name = "labelField";
            this.labelField.Size = new System.Drawing.Size(29, 13);
            this.labelField.TabIndex = 11;
            this.labelField.Text = "Field";
            // 
            // groupBoxConnections
            // 
            this.groupBoxConnections.Controls.Add(this.textBoxChannel);
            this.groupBoxConnections.Controls.Add(this.comboBoxRefreshTimeUnit);
            this.groupBoxConnections.Controls.Add(this.textBoxRefreshTime);
            this.groupBoxConnections.Controls.Add(this.labelField);
            this.groupBoxConnections.Controls.Add(this.labelRefresh);
            this.groupBoxConnections.Controls.Add(this.labelChannel);
            this.groupBoxConnections.Controls.Add(this.trackBarRefreshTime);
            this.groupBoxConnections.Controls.Add(this.labelApi);
            this.groupBoxConnections.Controls.Add(this.comboBoxFields);
            this.groupBoxConnections.Controls.Add(this.textBoxApi);
            this.groupBoxConnections.Location = new System.Drawing.Point(12, 12);
            this.groupBoxConnections.Name = "groupBoxConnections";
            this.groupBoxConnections.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBoxConnections.Size = new System.Drawing.Size(365, 148);
            this.groupBoxConnections.TabIndex = 12;
            this.groupBoxConnections.TabStop = false;
            this.groupBoxConnections.Text = "Connection";
            // 
            // groupBoxProperties
            // 
            this.groupBoxProperties.Controls.Add(this.label2);
            this.groupBoxProperties.Controls.Add(this.buttonColor);
            this.groupBoxProperties.Controls.Add(this.textBoxTransparency);
            this.groupBoxProperties.Controls.Add(this.checkBoxDateLabel);
            this.groupBoxProperties.Controls.Add(this.label1);
            this.groupBoxProperties.Controls.Add(this.trackBarTransparency);
            this.groupBoxProperties.Location = new System.Drawing.Point(12, 166);
            this.groupBoxProperties.Name = "groupBoxProperties";
            this.groupBoxProperties.Size = new System.Drawing.Size(365, 131);
            this.groupBoxProperties.TabIndex = 13;
            this.groupBoxProperties.TabStop = false;
            this.groupBoxProperties.Text = "Widget Properties";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Color";
            // 
            // buttonColor
            // 
            this.buttonColor.Location = new System.Drawing.Point(88, 70);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(23, 23);
            this.buttonColor.TabIndex = 15;
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // textBoxTransparency
            // 
            this.textBoxTransparency.Location = new System.Drawing.Point(239, 19);
            this.textBoxTransparency.Name = "textBoxTransparency";
            this.textBoxTransparency.Size = new System.Drawing.Size(59, 20);
            this.textBoxTransparency.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Transparency";
            // 
            // trackBarTransparency
            // 
            this.trackBarTransparency.Location = new System.Drawing.Point(88, 19);
            this.trackBarTransparency.Maximum = 100;
            this.trackBarTransparency.Minimum = 1;
            this.trackBarTransparency.Name = "trackBarTransparency";
            this.trackBarTransparency.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBarTransparency.Size = new System.Drawing.Size(145, 45);
            this.trackBarTransparency.TabIndex = 12;
            this.trackBarTransparency.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarTransparency.Value = 1;
            this.trackBarTransparency.ValueChanged += new System.EventHandler(this.trackBarTransparency_ValueChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 358);
            this.Controls.Add(this.groupBoxProperties);
            this.Controls.Add(this.groupBoxConnections);
            this.Controls.Add(this.buttonSave);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_LoadAsync);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRefreshTime)).EndInit();
            this.groupBoxConnections.ResumeLayout(false);
            this.groupBoxConnections.PerformLayout();
            this.groupBoxProperties.ResumeLayout(false);
            this.groupBoxProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTransparency)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.ComboBox comboBoxFields;
        private System.Windows.Forms.ComboBox comboBoxRefreshTimeUnit;
        private System.Windows.Forms.Label labelField;
        private System.Windows.Forms.GroupBox groupBoxConnections;
        private System.Windows.Forms.GroupBox groupBoxProperties;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.TextBox textBoxTransparency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarTransparency;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}