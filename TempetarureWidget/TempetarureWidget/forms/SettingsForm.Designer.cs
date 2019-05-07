namespace TempetarureWidget
{
    partial class SettingsForm
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
            this.checkBoxPublicChannel = new System.Windows.Forms.CheckBox();
            this.comboBoxTimezone = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxProperties = new System.Windows.Forms.GroupBox();
            this.checkBoxShowName = new System.Windows.Forms.CheckBox();
            this.checkBoxCheckForUpdate = new System.Windows.Forms.CheckBox();
            this.checkBoxRunWithWindows = new System.Windows.Forms.CheckBox();
            this.groupBoxChannelName = new System.Windows.Forms.GroupBox();
            this.checkBoxFieldName = new System.Windows.Forms.CheckBox();
            this.checkBoxChannelName = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDownDateSize = new System.Windows.Forms.NumericUpDown();
            this.labelDateSize = new System.Windows.Forms.Label();
            this.groupBoxDeegrees = new System.Windows.Forms.GroupBox();
            this.textBoxUserUnits = new System.Windows.Forms.TextBox();
            this.radioButtonUserUnit = new System.Windows.Forms.RadioButton();
            this.radioButtonCelsiusUnit = new System.Windows.Forms.RadioButton();
            this.radioButtonFahrentheitUnit = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonTextColor = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownTemperatureSize = new System.Windows.Forms.NumericUpDown();
            this.labelTempratureSize = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonBackColor = new System.Windows.Forms.Button();
            this.textBoxTransparency = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarTransparency = new System.Windows.Forms.TrackBar();
            this.colorDialogBackground = new System.Windows.Forms.ColorDialog();
            this.colorDialogText = new System.Windows.Forms.ColorDialog();
            this.buttonRemoveWidget = new System.Windows.Forms.Button();
            this.buttonExpand = new System.Windows.Forms.Button();
            this.chartUC = new TempetarureWidget.forms.ChartUc();
            this.widgetUC = new TempetarureWidget.forms.WidgetUC();
            this.groupBoxChart = new System.Windows.Forms.GroupBox();
            this.labelDateFormat = new System.Windows.Forms.Label();
            this.textBoxDateFormat = new System.Windows.Forms.TextBox();
            this.checkBoxAverage = new System.Windows.Forms.CheckBox();
            this.checkBoxMedian = new System.Windows.Forms.CheckBox();
            this.checkBoxTitleY = new System.Windows.Forms.CheckBox();
            this.checBoxTitleX = new System.Windows.Forms.CheckBox();
            this.textBoxTitleY = new System.Windows.Forms.TextBox();
            this.textBoxTitleX = new System.Windows.Forms.TextBox();
            this.numericUpDownAverage = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMedian = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownNumberPoints = new System.Windows.Forms.NumericUpDown();
            this.labelchartPointsNumber = new System.Windows.Forms.Label();
            this.numericUpDownLineWidth = new System.Windows.Forms.NumericUpDown();
            this.labelchartLineWidth = new System.Windows.Forms.Label();
            this.buttonLineColor = new System.Windows.Forms.Button();
            this.labelchartLineColor = new System.Windows.Forms.Label();
            this.checkBoxChartVisable = new System.Windows.Forms.CheckBox();
            this.colorDialogChartLine = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRefreshTime)).BeginInit();
            this.groupBoxConnections.SuspendLayout();
            this.groupBoxProperties.SuspendLayout();
            this.groupBoxChannelName.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDateSize)).BeginInit();
            this.groupBoxDeegrees.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTemperatureSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTransparency)).BeginInit();
            this.groupBoxChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMedian)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(213, 629);
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
            this.checkBoxDateLabel.Location = new System.Drawing.Point(19, 164);
            this.checkBoxDateLabel.Name = "checkBoxDateLabel";
            this.checkBoxDateLabel.Size = new System.Drawing.Size(102, 17);
            this.checkBoxDateLabel.TabIndex = 1;
            this.checkBoxDateLabel.Text = "Show date label";
            this.checkBoxDateLabel.UseVisualStyleBackColor = true;
            this.checkBoxDateLabel.CheckedChanged += new System.EventHandler(this.checkBoxDateLabel_CheckedChanged);
            // 
            // labelChannel
            // 
            this.labelChannel.AutoSize = true;
            this.labelChannel.Location = new System.Drawing.Point(16, 31);
            this.labelChannel.Name = "labelChannel";
            this.labelChannel.Size = new System.Drawing.Size(46, 13);
            this.labelChannel.TabIndex = 2;
            this.labelChannel.Text = "Channel";
            // 
            // labelApi
            // 
            this.labelApi.AutoSize = true;
            this.labelApi.Location = new System.Drawing.Point(16, 58);
            this.labelApi.Name = "labelApi";
            this.labelApi.Size = new System.Drawing.Size(46, 13);
            this.labelApi.TabIndex = 3;
            this.labelApi.Text = "Api_Key";
            // 
            // textBoxChannel
            // 
            this.textBoxChannel.Location = new System.Drawing.Point(88, 29);
            this.textBoxChannel.Name = "textBoxChannel";
            this.textBoxChannel.Size = new System.Drawing.Size(196, 20);
            this.textBoxChannel.TabIndex = 4;
            // 
            // textBoxApi
            // 
            this.textBoxApi.Location = new System.Drawing.Point(88, 55);
            this.textBoxApi.Name = "textBoxApi";
            this.textBoxApi.Size = new System.Drawing.Size(259, 20);
            this.textBoxApi.TabIndex = 5;
            // 
            // trackBarRefreshTime
            // 
            this.trackBarRefreshTime.AutoSize = false;
            this.trackBarRefreshTime.Location = new System.Drawing.Point(88, 135);
            this.trackBarRefreshTime.Maximum = 100;
            this.trackBarRefreshTime.Minimum = 1;
            this.trackBarRefreshTime.Name = "trackBarRefreshTime";
            this.trackBarRefreshTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBarRefreshTime.Size = new System.Drawing.Size(145, 21);
            this.trackBarRefreshTime.TabIndex = 6;
            this.trackBarRefreshTime.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarRefreshTime.Value = 1;
            this.trackBarRefreshTime.ValueChanged += new System.EventHandler(this.trackBarRefreshTime_ValueChanged);
            // 
            // labelRefresh
            // 
            this.labelRefresh.AutoSize = true;
            this.labelRefresh.Location = new System.Drawing.Point(16, 139);
            this.labelRefresh.Name = "labelRefresh";
            this.labelRefresh.Size = new System.Drawing.Size(66, 13);
            this.labelRefresh.TabIndex = 7;
            this.labelRefresh.Text = "Refresh time";
            // 
            // textBoxRefreshTime
            // 
            this.textBoxRefreshTime.Location = new System.Drawing.Point(239, 136);
            this.textBoxRefreshTime.Name = "textBoxRefreshTime";
            this.textBoxRefreshTime.Size = new System.Drawing.Size(59, 20);
            this.textBoxRefreshTime.TabIndex = 8;
            this.textBoxRefreshTime.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxRefreshTime_Validating);
            // 
            // comboBoxFields
            // 
            this.comboBoxFields.Location = new System.Drawing.Point(88, 81);
            this.comboBoxFields.Name = "comboBoxFields";
            this.comboBoxFields.Size = new System.Drawing.Size(259, 21);
            this.comboBoxFields.TabIndex = 9;
            this.comboBoxFields.Validated += new System.EventHandler(this.comboBoxFields_Validated);
            // 
            // comboBoxRefreshTimeUnit
            // 
            this.comboBoxRefreshTimeUnit.FormattingEnabled = true;
            this.comboBoxRefreshTimeUnit.Items.AddRange(new object[] {
            "s",
            "m",
            "h"});
            this.comboBoxRefreshTimeUnit.Location = new System.Drawing.Point(304, 135);
            this.comboBoxRefreshTimeUnit.Name = "comboBoxRefreshTimeUnit";
            this.comboBoxRefreshTimeUnit.Size = new System.Drawing.Size(43, 21);
            this.comboBoxRefreshTimeUnit.TabIndex = 10;
            // 
            // labelField
            // 
            this.labelField.AutoSize = true;
            this.labelField.Location = new System.Drawing.Point(16, 84);
            this.labelField.Name = "labelField";
            this.labelField.Size = new System.Drawing.Size(29, 13);
            this.labelField.TabIndex = 11;
            this.labelField.Text = "Field";
            // 
            // groupBoxConnections
            // 
            this.groupBoxConnections.Controls.Add(this.trackBarRefreshTime);
            this.groupBoxConnections.Controls.Add(this.checkBoxPublicChannel);
            this.groupBoxConnections.Controls.Add(this.comboBoxTimezone);
            this.groupBoxConnections.Controls.Add(this.label4);
            this.groupBoxConnections.Controls.Add(this.textBoxChannel);
            this.groupBoxConnections.Controls.Add(this.comboBoxRefreshTimeUnit);
            this.groupBoxConnections.Controls.Add(this.textBoxRefreshTime);
            this.groupBoxConnections.Controls.Add(this.labelField);
            this.groupBoxConnections.Controls.Add(this.labelRefresh);
            this.groupBoxConnections.Controls.Add(this.labelChannel);
            this.groupBoxConnections.Controls.Add(this.labelApi);
            this.groupBoxConnections.Controls.Add(this.comboBoxFields);
            this.groupBoxConnections.Controls.Add(this.textBoxApi);
            this.groupBoxConnections.Location = new System.Drawing.Point(12, 12);
            this.groupBoxConnections.Name = "groupBoxConnections";
            this.groupBoxConnections.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBoxConnections.Size = new System.Drawing.Size(365, 167);
            this.groupBoxConnections.TabIndex = 12;
            this.groupBoxConnections.TabStop = false;
            this.groupBoxConnections.Text = "Connection";
            // 
            // checkBoxPublicChannel
            // 
            this.checkBoxPublicChannel.AutoSize = true;
            this.checkBoxPublicChannel.Location = new System.Drawing.Point(292, 30);
            this.checkBoxPublicChannel.Name = "checkBoxPublicChannel";
            this.checkBoxPublicChannel.Size = new System.Drawing.Size(55, 17);
            this.checkBoxPublicChannel.TabIndex = 14;
            this.checkBoxPublicChannel.Text = "Public";
            this.checkBoxPublicChannel.UseVisualStyleBackColor = true;
            this.checkBoxPublicChannel.CheckedChanged += new System.EventHandler(this.checkBoxPublicChannel_CheckedChanged);
            // 
            // comboBoxTimezone
            // 
            this.comboBoxTimezone.FormattingEnabled = true;
            this.comboBoxTimezone.Items.AddRange(new object[] {
            "Africa/Algiers",
            "Africa/Cairo",
            "Africa/Casablanca",
            "Africa/Harare",
            "Africa/Johannesburg",
            "Africa/Monrovia",
            "Africa/Nairobi",
            "America/Argentina/Buenos_Aires",
            "America/Bogota",
            "America/Caracas",
            "America/Chicago",
            "America/Chihuahua",
            "America/Denver",
            "America/Godthab",
            "America/Guatemala",
            "America/Guyana",
            "America/Halifax",
            "America/Indiana/Indianapolis",
            "America/Juneau",
            "America/La_Paz",
            "America/Lima",
            "America/Los_Angeles",
            "America/Mazatlan",
            "America/Mexico_City",
            "America/Monterrey",
            "America/Montevideo",
            "America/New_York",
            "America/Phoenix",
            "America/Regina",
            "America/Santiago",
            "America/Sao_Paulo",
            "America/St_Johns",
            "America/Tijuana",
            "Asia/Almaty",
            "Asia/Baghdad",
            "Asia/Baku",
            "Asia/Bangkok",
            "Asia/Chongqing",
            "Asia/Colombo",
            "Asia/Dhaka",
            "Asia/Hong_Kong",
            "Asia/Irkutsk",
            "Asia/Jakarta",
            "Asia/Jerusalem",
            "Asia/Kabul",
            "Asia/Kamchatka",
            "Asia/Karachi",
            "Asia/Kathmandu",
            "Asia/Kolkata",
            "Asia/Krasnoyarsk",
            "Asia/Kuala_Lumpur",
            "Asia/Kuwait",
            "Asia/Magadan",
            "Asia/Muscat",
            "Asia/Novosibirsk",
            "Asia/Rangoon",
            "Asia/Riyadh",
            "Asia/Seoul",
            "Asia/Shanghai",
            "Asia/Singapore",
            "Asia/Taipei",
            "Asia/Tashkent",
            "Asia/Tbilisi",
            "Asia/Tehran",
            "Asia/Tokyo",
            "Asia/Ulaanbaatar",
            "Asia/Urumqi",
            "Asia/Vladivostok",
            "Asia/Yakutsk",
            "Asia/Yekaterinburg",
            "Asia/Yerevan",
            "Atlantic/Azores",
            "Atlantic/Cape_Verde",
            "Atlantic/South_Georgia",
            "Australia/Adelaide",
            "Australia/Brisbane",
            "Australia/Darwin",
            "Australia/Hobart",
            "Australia/Melbourne",
            "Australia/Perth",
            "Australia/Sydney",
            "Etc/UTC",
            "Europe/Amsterdam",
            "Europe/Athens",
            "Europe/Belgrade",
            "Europe/Berlin",
            "Europe/Bratislava",
            "Europe/Brussels",
            "Europe/Bucharest",
            "Europe/Budapest",
            "Europe/Copenhagen",
            "Europe/Dublin",
            "Europe/Helsinki",
            "Europe/Istanbul",
            "Europe/Kiev",
            "Europe/Lisbon",
            "Europe/Ljubljana",
            "Europe/London",
            "Europe/Madrid",
            "Europe/Minsk",
            "Europe/Moscow",
            "Europe/Paris",
            "Europe/Prague",
            "Europe/Riga",
            "Europe/Rome",
            "Europe/Sarajevo",
            "Europe/Skopje",
            "Europe/Sofia",
            "Europe/Stockholm",
            "Europe/Tallinn",
            "Europe/Vienna",
            "Europe/Vilnius",
            "Europe/Warsaw",
            "Europe/Zagreb",
            "Pacific/Apia",
            "Pacific/Auckland",
            "Pacific/Chatham",
            "Pacific/Fakaofo",
            "Pacific/Fiji",
            "Pacific/Guadalcanal",
            "Pacific/Guam",
            "Pacific/Honolulu",
            "Pacific/Majuro",
            "Pacific/Midway",
            "Pacific/Noumea",
            "Pacific/Pago_Pago",
            "Pacific/Port_Moresby",
            "Pacific/Tongatapu"});
            this.comboBoxTimezone.Location = new System.Drawing.Point(88, 108);
            this.comboBoxTimezone.Name = "comboBoxTimezone";
            this.comboBoxTimezone.Size = new System.Drawing.Size(259, 21);
            this.comboBoxTimezone.Sorted = true;
            this.comboBoxTimezone.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Timezone";
            // 
            // groupBoxProperties
            // 
            this.groupBoxProperties.Controls.Add(this.checkBoxShowName);
            this.groupBoxProperties.Controls.Add(this.checkBoxCheckForUpdate);
            this.groupBoxProperties.Controls.Add(this.checkBoxRunWithWindows);
            this.groupBoxProperties.Controls.Add(this.groupBoxChannelName);
            this.groupBoxProperties.Controls.Add(this.groupBox2);
            this.groupBoxProperties.Controls.Add(this.groupBoxDeegrees);
            this.groupBoxProperties.Controls.Add(this.label3);
            this.groupBoxProperties.Controls.Add(this.buttonTextColor);
            this.groupBoxProperties.Controls.Add(this.groupBox1);
            this.groupBoxProperties.Controls.Add(this.label2);
            this.groupBoxProperties.Controls.Add(this.buttonBackColor);
            this.groupBoxProperties.Controls.Add(this.textBoxTransparency);
            this.groupBoxProperties.Controls.Add(this.label1);
            this.groupBoxProperties.Controls.Add(this.trackBarTransparency);
            this.groupBoxProperties.Controls.Add(this.checkBoxDateLabel);
            this.groupBoxProperties.Location = new System.Drawing.Point(12, 185);
            this.groupBoxProperties.Name = "groupBoxProperties";
            this.groupBoxProperties.Size = new System.Drawing.Size(365, 304);
            this.groupBoxProperties.TabIndex = 13;
            this.groupBoxProperties.TabStop = false;
            this.groupBoxProperties.Text = "Widget Properties";
            // 
            // checkBoxShowName
            // 
            this.checkBoxShowName.AutoSize = true;
            this.checkBoxShowName.Location = new System.Drawing.Point(19, 187);
            this.checkBoxShowName.Name = "checkBoxShowName";
            this.checkBoxShowName.Size = new System.Drawing.Size(94, 17);
            this.checkBoxShowName.TabIndex = 24;
            this.checkBoxShowName.Text = "Channel name";
            this.checkBoxShowName.UseVisualStyleBackColor = true;
            this.checkBoxShowName.CheckStateChanged += new System.EventHandler(this.checkBoxShowChannelName_CheckStateChanged);
            // 
            // checkBoxCheckForUpdate
            // 
            this.checkBoxCheckForUpdate.AutoSize = true;
            this.checkBoxCheckForUpdate.Enabled = false;
            this.checkBoxCheckForUpdate.Location = new System.Drawing.Point(19, 279);
            this.checkBoxCheckForUpdate.Name = "checkBoxCheckForUpdate";
            this.checkBoxCheckForUpdate.Size = new System.Drawing.Size(108, 17);
            this.checkBoxCheckForUpdate.TabIndex = 26;
            this.checkBoxCheckForUpdate.Text = "Check for update";
            this.checkBoxCheckForUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxCheckForUpdate.UseVisualStyleBackColor = true;
            // 
            // checkBoxRunWithWindows
            // 
            this.checkBoxRunWithWindows.AutoSize = true;
            this.checkBoxRunWithWindows.Location = new System.Drawing.Point(19, 256);
            this.checkBoxRunWithWindows.Name = "checkBoxRunWithWindows";
            this.checkBoxRunWithWindows.Size = new System.Drawing.Size(112, 17);
            this.checkBoxRunWithWindows.TabIndex = 25;
            this.checkBoxRunWithWindows.Text = "Run with windows";
            this.checkBoxRunWithWindows.UseVisualStyleBackColor = true;
            // 
            // groupBoxChannelName
            // 
            this.groupBoxChannelName.Controls.Add(this.checkBoxFieldName);
            this.groupBoxChannelName.Controls.Add(this.checkBoxChannelName);
            this.groupBoxChannelName.Location = new System.Drawing.Point(13, 190);
            this.groupBoxChannelName.Name = "groupBoxChannelName";
            this.groupBoxChannelName.Size = new System.Drawing.Size(130, 63);
            this.groupBoxChannelName.TabIndex = 14;
            this.groupBoxChannelName.TabStop = false;
            // 
            // checkBoxFieldName
            // 
            this.checkBoxFieldName.AutoSize = true;
            this.checkBoxFieldName.Checked = true;
            this.checkBoxFieldName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFieldName.Location = new System.Drawing.Point(6, 42);
            this.checkBoxFieldName.Name = "checkBoxFieldName";
            this.checkBoxFieldName.Size = new System.Drawing.Size(104, 17);
            this.checkBoxFieldName.TabIndex = 1;
            this.checkBoxFieldName.Text = "Show field name";
            this.checkBoxFieldName.UseVisualStyleBackColor = true;
            this.checkBoxFieldName.CheckedChanged += new System.EventHandler(this.checkBoxFieldName_CheckedChanged);
            // 
            // checkBoxChannelName
            // 
            this.checkBoxChannelName.AutoSize = true;
            this.checkBoxChannelName.Checked = true;
            this.checkBoxChannelName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxChannelName.Location = new System.Drawing.Point(6, 19);
            this.checkBoxChannelName.Name = "checkBoxChannelName";
            this.checkBoxChannelName.Size = new System.Drawing.Size(123, 17);
            this.checkBoxChannelName.TabIndex = 0;
            this.checkBoxChannelName.Text = "Show channel name";
            this.checkBoxChannelName.UseVisualStyleBackColor = true;
            this.checkBoxChannelName.CheckedChanged += new System.EventHandler(this.checkBoxChannelName_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDownDateSize);
            this.groupBox2.Controls.Add(this.labelDateSize);
            this.groupBox2.Location = new System.Drawing.Point(173, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(186, 124);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date and name size";
            // 
            // numericUpDownDateSize
            // 
            this.numericUpDownDateSize.Location = new System.Drawing.Point(125, 26);
            this.numericUpDownDateSize.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericUpDownDateSize.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownDateSize.Name = "numericUpDownDateSize";
            this.numericUpDownDateSize.Size = new System.Drawing.Size(55, 20);
            this.numericUpDownDateSize.TabIndex = 1;
            this.numericUpDownDateSize.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownDateSize.ValueChanged += new System.EventHandler(this.numericUpDownDateSize_ValueChanged);
            // 
            // labelDateSize
            // 
            this.labelDateSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 80F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDateSize.Location = new System.Drawing.Point(3, 26);
            this.labelDateSize.Margin = new System.Windows.Forms.Padding(0);
            this.labelDateSize.Name = "labelDateSize";
            this.labelDateSize.Size = new System.Drawing.Size(181, 95);
            this.labelDateSize.TabIndex = 0;
            this.labelDateSize.Text = "Aa";
            this.labelDateSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxDeegrees
            // 
            this.groupBoxDeegrees.Controls.Add(this.textBoxUserUnits);
            this.groupBoxDeegrees.Controls.Add(this.radioButtonUserUnit);
            this.groupBoxDeegrees.Controls.Add(this.radioButtonCelsiusUnit);
            this.groupBoxDeegrees.Controls.Add(this.radioButtonFahrentheitUnit);
            this.groupBoxDeegrees.Location = new System.Drawing.Point(13, 108);
            this.groupBoxDeegrees.Name = "groupBoxDeegrees";
            this.groupBoxDeegrees.Size = new System.Drawing.Size(148, 50);
            this.groupBoxDeegrees.TabIndex = 23;
            this.groupBoxDeegrees.TabStop = false;
            this.groupBoxDeegrees.Text = "Units";
            // 
            // textBoxUserUnits
            // 
            this.textBoxUserUnits.Enabled = false;
            this.textBoxUserUnits.Location = new System.Drawing.Point(106, 28);
            this.textBoxUserUnits.Name = "textBoxUserUnits";
            this.textBoxUserUnits.Size = new System.Drawing.Size(36, 20);
            this.textBoxUserUnits.TabIndex = 3;
            this.textBoxUserUnits.Text = "%";
            this.textBoxUserUnits.TextChanged += new System.EventHandler(this.textBoxUserUnits_TextChanged);
            // 
            // radioButtonUserUnit
            // 
            this.radioButtonUserUnit.AutoSize = true;
            this.radioButtonUserUnit.Location = new System.Drawing.Point(89, 31);
            this.radioButtonUserUnit.Name = "radioButtonUserUnit";
            this.radioButtonUserUnit.Size = new System.Drawing.Size(14, 13);
            this.radioButtonUserUnit.TabIndex = 2;
            this.radioButtonUserUnit.TabStop = true;
            this.radioButtonUserUnit.UseVisualStyleBackColor = true;
            this.radioButtonUserUnit.CheckedChanged += new System.EventHandler(this.radioButtonUserUnit_CheckedChanged);
            // 
            // radioButtonCelsiusUnit
            // 
            this.radioButtonCelsiusUnit.AutoSize = true;
            this.radioButtonCelsiusUnit.Checked = true;
            this.radioButtonCelsiusUnit.Location = new System.Drawing.Point(47, 29);
            this.radioButtonCelsiusUnit.Name = "radioButtonCelsiusUnit";
            this.radioButtonCelsiusUnit.Size = new System.Drawing.Size(36, 17);
            this.radioButtonCelsiusUnit.TabIndex = 1;
            this.radioButtonCelsiusUnit.TabStop = true;
            this.radioButtonCelsiusUnit.Text = "°C";
            this.radioButtonCelsiusUnit.UseVisualStyleBackColor = true;
            this.radioButtonCelsiusUnit.CheckedChanged += new System.EventHandler(this.radioButtonCelsiusUnit_CheckedChanged);
            // 
            // radioButtonFahrentheitUnit
            // 
            this.radioButtonFahrentheitUnit.AutoSize = true;
            this.radioButtonFahrentheitUnit.Location = new System.Drawing.Point(6, 29);
            this.radioButtonFahrentheitUnit.Name = "radioButtonFahrentheitUnit";
            this.radioButtonFahrentheitUnit.Size = new System.Drawing.Size(35, 17);
            this.radioButtonFahrentheitUnit.TabIndex = 0;
            this.radioButtonFahrentheitUnit.Text = "°F";
            this.radioButtonFahrentheitUnit.UseVisualStyleBackColor = true;
            this.radioButtonFahrentheitUnit.CheckedChanged += new System.EventHandler(this.radioButtonFahrentheitUnit_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Text color";
            // 
            // buttonTextColor
            // 
            this.buttonTextColor.Location = new System.Drawing.Point(113, 79);
            this.buttonTextColor.Name = "buttonTextColor";
            this.buttonTextColor.Size = new System.Drawing.Size(23, 23);
            this.buttonTextColor.TabIndex = 21;
            this.buttonTextColor.UseVisualStyleBackColor = true;
            this.buttonTextColor.Click += new System.EventHandler(this.buttonTextColor_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownTemperatureSize);
            this.groupBox1.Controls.Add(this.labelTempratureSize);
            this.groupBox1.Location = new System.Drawing.Point(173, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 124);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Temperature size";
            // 
            // numericUpDownTemperatureSize
            // 
            this.numericUpDownTemperatureSize.Location = new System.Drawing.Point(125, 26);
            this.numericUpDownTemperatureSize.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownTemperatureSize.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericUpDownTemperatureSize.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownTemperatureSize.Name = "numericUpDownTemperatureSize";
            this.numericUpDownTemperatureSize.Size = new System.Drawing.Size(55, 20);
            this.numericUpDownTemperatureSize.TabIndex = 1;
            this.numericUpDownTemperatureSize.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownTemperatureSize.ValueChanged += new System.EventHandler(this.numericUpDownTemperatureSize_ValueChanged);
            // 
            // labelTempratureSize
            // 
            this.labelTempratureSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 80F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTempratureSize.Location = new System.Drawing.Point(3, 26);
            this.labelTempratureSize.Margin = new System.Windows.Forms.Padding(0);
            this.labelTempratureSize.Name = "labelTempratureSize";
            this.labelTempratureSize.Size = new System.Drawing.Size(181, 95);
            this.labelTempratureSize.TabIndex = 0;
            this.labelTempratureSize.Text = "Aa";
            this.labelTempratureSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Background color";
            // 
            // buttonBackColor
            // 
            this.buttonBackColor.Location = new System.Drawing.Point(113, 50);
            this.buttonBackColor.Name = "buttonBackColor";
            this.buttonBackColor.Size = new System.Drawing.Size(23, 23);
            this.buttonBackColor.TabIndex = 15;
            this.buttonBackColor.UseVisualStyleBackColor = true;
            this.buttonBackColor.Click += new System.EventHandler(this.buttonBackColor_Click);
            // 
            // textBoxTransparency
            // 
            this.textBoxTransparency.Location = new System.Drawing.Point(239, 21);
            this.textBoxTransparency.Name = "textBoxTransparency";
            this.textBoxTransparency.Size = new System.Drawing.Size(59, 20);
            this.textBoxTransparency.TabIndex = 14;
            this.textBoxTransparency.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxTransparency_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Transparency";
            // 
            // trackBarTransparency
            // 
            this.trackBarTransparency.AutoSize = false;
            this.trackBarTransparency.Location = new System.Drawing.Point(88, 21);
            this.trackBarTransparency.Maximum = 100;
            this.trackBarTransparency.Minimum = 10;
            this.trackBarTransparency.Name = "trackBarTransparency";
            this.trackBarTransparency.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBarTransparency.Size = new System.Drawing.Size(145, 20);
            this.trackBarTransparency.TabIndex = 12;
            this.trackBarTransparency.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarTransparency.Value = 10;
            this.trackBarTransparency.ValueChanged += new System.EventHandler(this.trackBarTransparency_ValueChanged);
            // 
            // buttonRemoveWidget
            // 
            this.buttonRemoveWidget.Location = new System.Drawing.Point(110, 629);
            this.buttonRemoveWidget.Name = "buttonRemoveWidget";
            this.buttonRemoveWidget.Size = new System.Drawing.Size(97, 23);
            this.buttonRemoveWidget.TabIndex = 14;
            this.buttonRemoveWidget.Text = "Remove Widget";
            this.buttonRemoveWidget.UseVisualStyleBackColor = true;
            this.buttonRemoveWidget.Click += new System.EventHandler(this.buttonRemoveWidget_Click);
            // 
            // buttonExpand
            // 
            this.buttonExpand.Location = new System.Drawing.Point(294, 629);
            this.buttonExpand.Name = "buttonExpand";
            this.buttonExpand.Size = new System.Drawing.Size(83, 23);
            this.buttonExpand.TabIndex = 15;
            this.buttonExpand.Text = "Preview >>";
            this.buttonExpand.UseVisualStyleBackColor = true;
            this.buttonExpand.Click += new System.EventHandler(this.buttonExpand_Click);
            // 
            // chartUC
            // 
            this.chartUC.Location = new System.Drawing.Point(400, 125);
            this.chartUC.Name = "chartUC";
            this.chartUC.Size = new System.Drawing.Size(249, 125);
            this.chartUC.TabIndex = 17;
            // 
            // widgetUC
            // 
            this.widgetUC.BackColor = System.Drawing.SystemColors.ControlDark;
            this.widgetUC.Location = new System.Drawing.Point(400, 12);
            this.widgetUC.Name = "widgetUC";
            this.widgetUC.Size = new System.Drawing.Size(249, 113);
            this.widgetUC.TabIndex = 16;
            // 
            // groupBoxChart
            // 
            this.groupBoxChart.Controls.Add(this.labelDateFormat);
            this.groupBoxChart.Controls.Add(this.textBoxDateFormat);
            this.groupBoxChart.Controls.Add(this.checkBoxAverage);
            this.groupBoxChart.Controls.Add(this.checkBoxMedian);
            this.groupBoxChart.Controls.Add(this.checkBoxTitleY);
            this.groupBoxChart.Controls.Add(this.checBoxTitleX);
            this.groupBoxChart.Controls.Add(this.textBoxTitleY);
            this.groupBoxChart.Controls.Add(this.textBoxTitleX);
            this.groupBoxChart.Controls.Add(this.numericUpDownAverage);
            this.groupBoxChart.Controls.Add(this.numericUpDownMedian);
            this.groupBoxChart.Controls.Add(this.numericUpDownNumberPoints);
            this.groupBoxChart.Controls.Add(this.labelchartPointsNumber);
            this.groupBoxChart.Controls.Add(this.numericUpDownLineWidth);
            this.groupBoxChart.Controls.Add(this.labelchartLineWidth);
            this.groupBoxChart.Controls.Add(this.buttonLineColor);
            this.groupBoxChart.Controls.Add(this.labelchartLineColor);
            this.groupBoxChart.Enabled = false;
            this.groupBoxChart.Location = new System.Drawing.Point(12, 495);
            this.groupBoxChart.Name = "groupBoxChart";
            this.groupBoxChart.Size = new System.Drawing.Size(365, 128);
            this.groupBoxChart.TabIndex = 18;
            this.groupBoxChart.TabStop = false;
            // 
            // labelDateFormat
            // 
            this.labelDateFormat.AutoSize = true;
            this.labelDateFormat.Location = new System.Drawing.Point(16, 75);
            this.labelDateFormat.Name = "labelDateFormat";
            this.labelDateFormat.Size = new System.Drawing.Size(62, 13);
            this.labelDateFormat.TabIndex = 46;
            this.labelDateFormat.Text = "Date format";
            // 
            // textBoxDateFormat
            // 
            this.textBoxDateFormat.Location = new System.Drawing.Point(90, 72);
            this.textBoxDateFormat.Name = "textBoxDateFormat";
            this.textBoxDateFormat.Size = new System.Drawing.Size(126, 20);
            this.textBoxDateFormat.TabIndex = 45;
            this.textBoxDateFormat.Text = "yyyy.dd.MM HH:mm";
            this.textBoxDateFormat.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxDateFormat_Validating);
            // 
            // checkBoxAverage
            // 
            this.checkBoxAverage.AutoSize = true;
            this.checkBoxAverage.Location = new System.Drawing.Point(225, 99);
            this.checkBoxAverage.Name = "checkBoxAverage";
            this.checkBoxAverage.Size = new System.Drawing.Size(66, 17);
            this.checkBoxAverage.TabIndex = 44;
            this.checkBoxAverage.Text = "Average";
            this.checkBoxAverage.UseVisualStyleBackColor = true;
            this.checkBoxAverage.CheckedChanged += new System.EventHandler(this.checkBoxAverage_CheckedChanged);
            // 
            // checkBoxMedian
            // 
            this.checkBoxMedian.AutoSize = true;
            this.checkBoxMedian.Location = new System.Drawing.Point(225, 75);
            this.checkBoxMedian.Name = "checkBoxMedian";
            this.checkBoxMedian.Size = new System.Drawing.Size(61, 17);
            this.checkBoxMedian.TabIndex = 43;
            this.checkBoxMedian.Text = "Median";
            this.checkBoxMedian.UseVisualStyleBackColor = true;
            this.checkBoxMedian.CheckedChanged += new System.EventHandler(this.checkBoxMedian_CheckedChanged);
            // 
            // checkBoxTitleY
            // 
            this.checkBoxTitleY.AutoSize = true;
            this.checkBoxTitleY.Location = new System.Drawing.Point(19, 48);
            this.checkBoxTitleY.Name = "checkBoxTitleY";
            this.checkBoxTitleY.Size = new System.Drawing.Size(56, 17);
            this.checkBoxTitleY.TabIndex = 40;
            this.checkBoxTitleY.Text = "Title Y";
            this.checkBoxTitleY.UseVisualStyleBackColor = true;
            this.checkBoxTitleY.CheckedChanged += new System.EventHandler(this.checkBoxTitleY_CheckedChanged);
            // 
            // checBoxTitleX
            // 
            this.checBoxTitleX.AutoSize = true;
            this.checBoxTitleX.Location = new System.Drawing.Point(19, 22);
            this.checBoxTitleX.Name = "checBoxTitleX";
            this.checBoxTitleX.Size = new System.Drawing.Size(56, 17);
            this.checBoxTitleX.TabIndex = 19;
            this.checBoxTitleX.Text = "Title X";
            this.checBoxTitleX.UseVisualStyleBackColor = true;
            this.checBoxTitleX.CheckedChanged += new System.EventHandler(this.checBoxTitleX_CheckedChanged);
            // 
            // textBoxTitleY
            // 
            this.textBoxTitleY.Enabled = false;
            this.textBoxTitleY.Location = new System.Drawing.Point(90, 46);
            this.textBoxTitleY.Name = "textBoxTitleY";
            this.textBoxTitleY.Size = new System.Drawing.Size(126, 20);
            this.textBoxTitleY.TabIndex = 39;
            this.textBoxTitleY.TextChanged += new System.EventHandler(this.checkBoxMedian_CheckedChanged);
            // 
            // textBoxTitleX
            // 
            this.textBoxTitleX.Enabled = false;
            this.textBoxTitleX.Location = new System.Drawing.Point(90, 20);
            this.textBoxTitleX.Name = "textBoxTitleX";
            this.textBoxTitleX.Size = new System.Drawing.Size(126, 20);
            this.textBoxTitleX.TabIndex = 37;
            this.textBoxTitleX.TextChanged += new System.EventHandler(this.textBoxTitleX_TextChanged);
            // 
            // numericUpDownAverage
            // 
            this.numericUpDownAverage.Enabled = false;
            this.numericUpDownAverage.Location = new System.Drawing.Point(315, 98);
            this.numericUpDownAverage.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownAverage.Name = "numericUpDownAverage";
            this.numericUpDownAverage.Size = new System.Drawing.Size(44, 20);
            this.numericUpDownAverage.TabIndex = 35;
            this.numericUpDownAverage.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownAverage.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // numericUpDownMedian
            // 
            this.numericUpDownMedian.Enabled = false;
            this.numericUpDownMedian.Location = new System.Drawing.Point(315, 72);
            this.numericUpDownMedian.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownMedian.Name = "numericUpDownMedian";
            this.numericUpDownMedian.Size = new System.Drawing.Size(44, 20);
            this.numericUpDownMedian.TabIndex = 33;
            this.numericUpDownMedian.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownMedian.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // numericUpDownNumberPoints
            // 
            this.numericUpDownNumberPoints.Location = new System.Drawing.Point(315, 20);
            this.numericUpDownNumberPoints.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNumberPoints.Name = "numericUpDownNumberPoints";
            this.numericUpDownNumberPoints.Size = new System.Drawing.Size(44, 20);
            this.numericUpDownNumberPoints.TabIndex = 31;
            this.numericUpDownNumberPoints.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownNumberPoints.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // labelchartPointsNumber
            // 
            this.labelchartPointsNumber.AutoSize = true;
            this.labelchartPointsNumber.Location = new System.Drawing.Point(222, 23);
            this.labelchartPointsNumber.Name = "labelchartPointsNumber";
            this.labelchartPointsNumber.Size = new System.Drawing.Size(87, 13);
            this.labelchartPointsNumber.TabIndex = 30;
            this.labelchartPointsNumber.Text = "Number of points";
            // 
            // numericUpDownLineWidth
            // 
            this.numericUpDownLineWidth.Location = new System.Drawing.Point(315, 46);
            this.numericUpDownLineWidth.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownLineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLineWidth.Name = "numericUpDownLineWidth";
            this.numericUpDownLineWidth.Size = new System.Drawing.Size(44, 20);
            this.numericUpDownLineWidth.TabIndex = 29;
            this.numericUpDownLineWidth.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownLineWidth.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // labelchartLineWidth
            // 
            this.labelchartLineWidth.AutoSize = true;
            this.labelchartLineWidth.Location = new System.Drawing.Point(222, 49);
            this.labelchartLineWidth.Name = "labelchartLineWidth";
            this.labelchartLineWidth.Size = new System.Drawing.Size(55, 13);
            this.labelchartLineWidth.TabIndex = 28;
            this.labelchartLineWidth.Text = "Line width";
            // 
            // buttonLineColor
            // 
            this.buttonLineColor.Location = new System.Drawing.Point(90, 98);
            this.buttonLineColor.Name = "buttonLineColor";
            this.buttonLineColor.Size = new System.Drawing.Size(23, 23);
            this.buttonLineColor.TabIndex = 27;
            this.buttonLineColor.UseVisualStyleBackColor = true;
            this.buttonLineColor.Click += new System.EventHandler(this.buttonLineColor_Click);
            // 
            // labelchartLineColor
            // 
            this.labelchartLineColor.AutoSize = true;
            this.labelchartLineColor.Location = new System.Drawing.Point(16, 103);
            this.labelchartLineColor.Name = "labelchartLineColor";
            this.labelchartLineColor.Size = new System.Drawing.Size(53, 13);
            this.labelchartLineColor.TabIndex = 0;
            this.labelchartLineColor.Text = "Line color";
            // 
            // checkBoxChartVisable
            // 
            this.checkBoxChartVisable.AutoSize = true;
            this.checkBoxChartVisable.Location = new System.Drawing.Point(22, 494);
            this.checkBoxChartVisable.Name = "checkBoxChartVisable";
            this.checkBoxChartVisable.Size = new System.Drawing.Size(51, 17);
            this.checkBoxChartVisable.TabIndex = 19;
            this.checkBoxChartVisable.Text = "Chart";
            this.checkBoxChartVisable.UseVisualStyleBackColor = true;
            this.checkBoxChartVisable.CheckedChanged += new System.EventHandler(this.checkBoxChartVisable_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 659);
            this.Controls.Add(this.checkBoxChartVisable);
            this.Controls.Add(this.groupBoxConnections);
            this.Controls.Add(this.groupBoxChart);
            this.Controls.Add(this.chartUC);
            this.Controls.Add(this.widgetUC);
            this.Controls.Add(this.buttonExpand);
            this.Controls.Add(this.buttonRemoveWidget);
            this.Controls.Add(this.groupBoxProperties);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_LoadAsync);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRefreshTime)).EndInit();
            this.groupBoxConnections.ResumeLayout(false);
            this.groupBoxConnections.PerformLayout();
            this.groupBoxProperties.ResumeLayout(false);
            this.groupBoxProperties.PerformLayout();
            this.groupBoxChannelName.ResumeLayout(false);
            this.groupBoxChannelName.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDateSize)).EndInit();
            this.groupBoxDeegrees.ResumeLayout(false);
            this.groupBoxDeegrees.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTemperatureSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTransparency)).EndInit();
            this.groupBoxChart.ResumeLayout(false);
            this.groupBoxChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMedian)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineWidth)).EndInit();
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
        private System.Windows.Forms.ComboBox comboBoxFields;
        private System.Windows.Forms.ComboBox comboBoxRefreshTimeUnit;
        private System.Windows.Forms.Label labelField;
        private System.Windows.Forms.GroupBox groupBoxConnections;
        private System.Windows.Forms.GroupBox groupBoxProperties;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonBackColor;
        private System.Windows.Forms.TextBox textBoxTransparency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarTransparency;
        private System.Windows.Forms.ColorDialog colorDialogBackground;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownTemperatureSize;
        private System.Windows.Forms.Label labelTempratureSize;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDownDateSize;
        private System.Windows.Forms.Label labelDateSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonTextColor;
        private System.Windows.Forms.ColorDialog colorDialogText;
        private System.Windows.Forms.GroupBox groupBoxDeegrees;
        private System.Windows.Forms.RadioButton radioButtonFahrentheitUnit;
        private System.Windows.Forms.RadioButton radioButtonCelsiusUnit;
        private System.Windows.Forms.CheckBox checkBoxShowName;
        private System.Windows.Forms.GroupBox groupBoxChannelName;
        private System.Windows.Forms.CheckBox checkBoxFieldName;
        private System.Windows.Forms.CheckBox checkBoxChannelName;
        private System.Windows.Forms.CheckBox checkBoxRunWithWindows;
        private System.Windows.Forms.Button buttonRemoveWidget;
        private System.Windows.Forms.ComboBox comboBoxTimezone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButtonUserUnit;
        private System.Windows.Forms.TextBox textBoxUserUnits;
        private System.Windows.Forms.CheckBox checkBoxPublicChannel;
        private System.Windows.Forms.CheckBox checkBoxCheckForUpdate;
        private System.Windows.Forms.Button buttonExpand;
        private forms.WidgetUC widgetUC;
        private forms.ChartUc chartUC;
        private System.Windows.Forms.GroupBox groupBoxChart;
        private System.Windows.Forms.NumericUpDown numericUpDownLineWidth;
        private System.Windows.Forms.Label labelchartLineWidth;
        private System.Windows.Forms.Button buttonLineColor;
        private System.Windows.Forms.Label labelchartLineColor;
        private System.Windows.Forms.CheckBox checkBoxChartVisable;
        private System.Windows.Forms.CheckBox checkBoxTitleY;
        private System.Windows.Forms.CheckBox checBoxTitleX;
        private System.Windows.Forms.TextBox textBoxTitleY;
        private System.Windows.Forms.TextBox textBoxTitleX;
        private System.Windows.Forms.NumericUpDown numericUpDownAverage;
        private System.Windows.Forms.NumericUpDown numericUpDownMedian;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberPoints;
        private System.Windows.Forms.Label labelchartPointsNumber;
        private System.Windows.Forms.ColorDialog colorDialogChartLine;
        private System.Windows.Forms.CheckBox checkBoxAverage;
        private System.Windows.Forms.CheckBox checkBoxMedian;
        private System.Windows.Forms.Label labelDateFormat;
        private System.Windows.Forms.TextBox textBoxDateFormat;
    }
}