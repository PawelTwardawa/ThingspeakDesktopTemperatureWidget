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
            this.comboBoxTimezone = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxProperties = new System.Windows.Forms.GroupBox();
            this.checkBoxRunWithWindows = new System.Windows.Forms.CheckBox();
            this.groupBoxChannelName = new System.Windows.Forms.GroupBox();
            this.checkBoxFieldName = new System.Windows.Forms.CheckBox();
            this.checkBoxChannelName = new System.Windows.Forms.CheckBox();
            this.checkBoxShowName = new System.Windows.Forms.CheckBox();
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
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(302, 502);
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
            // 
            // textBoxApi
            // 
            this.textBoxApi.Location = new System.Drawing.Point(88, 45);
            this.textBoxApi.Name = "textBoxApi";
            this.textBoxApi.Size = new System.Drawing.Size(259, 20);
            this.textBoxApi.TabIndex = 5;
            // 
            // trackBarRefreshTime
            // 
            this.trackBarRefreshTime.Location = new System.Drawing.Point(88, 125);
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
            this.labelRefresh.Location = new System.Drawing.Point(16, 129);
            this.labelRefresh.Name = "labelRefresh";
            this.labelRefresh.Size = new System.Drawing.Size(66, 13);
            this.labelRefresh.TabIndex = 7;
            this.labelRefresh.Text = "Refresh time";
            // 
            // textBoxRefreshTime
            // 
            this.textBoxRefreshTime.Location = new System.Drawing.Point(239, 126);
            this.textBoxRefreshTime.Name = "textBoxRefreshTime";
            this.textBoxRefreshTime.Size = new System.Drawing.Size(59, 20);
            this.textBoxRefreshTime.TabIndex = 8;
            this.textBoxRefreshTime.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxRefreshTime_Validating);
            // 
            // comboBoxFields
            // 
            this.comboBoxFields.Location = new System.Drawing.Point(88, 71);
            this.comboBoxFields.Name = "comboBoxFields";
            this.comboBoxFields.Size = new System.Drawing.Size(196, 21);
            this.comboBoxFields.TabIndex = 9;
            this.comboBoxFields.TextUpdate += new System.EventHandler(this.comboBoxFields_TextUpdate);
            // 
            // comboBoxRefreshTimeUnit
            // 
            this.comboBoxRefreshTimeUnit.FormattingEnabled = true;
            this.comboBoxRefreshTimeUnit.Items.AddRange(new object[] {
            "s",
            "m",
            "h"});
            this.comboBoxRefreshTimeUnit.Location = new System.Drawing.Point(304, 125);
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
            this.groupBoxConnections.Controls.Add(this.comboBoxTimezone);
            this.groupBoxConnections.Controls.Add(this.label4);
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
            this.groupBoxConnections.Size = new System.Drawing.Size(365, 163);
            this.groupBoxConnections.TabIndex = 12;
            this.groupBoxConnections.TabStop = false;
            this.groupBoxConnections.Text = "Connection";
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
            this.comboBoxTimezone.Location = new System.Drawing.Point(88, 98);
            this.comboBoxTimezone.Name = "comboBoxTimezone";
            this.comboBoxTimezone.Size = new System.Drawing.Size(196, 21);
            this.comboBoxTimezone.Sorted = true;
            this.comboBoxTimezone.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Timezone";
            // 
            // groupBoxProperties
            // 
            this.groupBoxProperties.Controls.Add(this.checkBoxRunWithWindows);
            this.groupBoxProperties.Controls.Add(this.groupBoxChannelName);
            this.groupBoxProperties.Controls.Add(this.checkBoxShowName);
            this.groupBoxProperties.Controls.Add(this.groupBox2);
            this.groupBoxProperties.Controls.Add(this.groupBoxDeegrees);
            this.groupBoxProperties.Controls.Add(this.label3);
            this.groupBoxProperties.Controls.Add(this.buttonTextColor);
            this.groupBoxProperties.Controls.Add(this.groupBox1);
            this.groupBoxProperties.Controls.Add(this.label2);
            this.groupBoxProperties.Controls.Add(this.buttonBackColor);
            this.groupBoxProperties.Controls.Add(this.textBoxTransparency);
            this.groupBoxProperties.Controls.Add(this.checkBoxDateLabel);
            this.groupBoxProperties.Controls.Add(this.label1);
            this.groupBoxProperties.Controls.Add(this.trackBarTransparency);
            this.groupBoxProperties.Location = new System.Drawing.Point(12, 181);
            this.groupBoxProperties.Name = "groupBoxProperties";
            this.groupBoxProperties.Size = new System.Drawing.Size(365, 315);
            this.groupBoxProperties.TabIndex = 13;
            this.groupBoxProperties.TabStop = false;
            this.groupBoxProperties.Text = "Widget Properties";
            // 
            // checkBoxRunWithWindows
            // 
            this.checkBoxRunWithWindows.AutoSize = true;
            this.checkBoxRunWithWindows.Location = new System.Drawing.Point(19, 210);
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
            this.groupBoxChannelName.Location = new System.Drawing.Point(19, 233);
            this.groupBoxChannelName.Name = "groupBoxChannelName";
            this.groupBoxChannelName.Size = new System.Drawing.Size(130, 65);
            this.groupBoxChannelName.TabIndex = 14;
            this.groupBoxChannelName.TabStop = false;
            this.groupBoxChannelName.Text = "Channel name";
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
            // 
            // checkBoxShowName
            // 
            this.checkBoxShowName.AutoSize = true;
            this.checkBoxShowName.Location = new System.Drawing.Point(19, 187);
            this.checkBoxShowName.Name = "checkBoxShowName";
            this.checkBoxShowName.Size = new System.Drawing.Size(148, 17);
            this.checkBoxShowName.TabIndex = 24;
            this.checkBoxShowName.Text = "Show channel name label";
            this.checkBoxShowName.UseVisualStyleBackColor = true;
            this.checkBoxShowName.CheckStateChanged += new System.EventHandler(this.checkBoxShowChannelName_CheckStateChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDownDateSize);
            this.groupBox2.Controls.Add(this.labelDateSize);
            this.groupBox2.Location = new System.Drawing.Point(173, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(186, 124);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date and name size";
            // 
            // numericUpDownDateSize
            // 
            this.numericUpDownDateSize.Location = new System.Drawing.Point(125, 16);
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
            this.labelDateSize.Location = new System.Drawing.Point(3, 16);
            this.labelDateSize.Margin = new System.Windows.Forms.Padding(0);
            this.labelDateSize.Name = "labelDateSize";
            this.labelDateSize.Size = new System.Drawing.Size(181, 105);
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
            this.groupBoxDeegrees.Location = new System.Drawing.Point(19, 106);
            this.groupBoxDeegrees.Name = "groupBoxDeegrees";
            this.groupBoxDeegrees.Size = new System.Drawing.Size(148, 50);
            this.groupBoxDeegrees.TabIndex = 23;
            this.groupBoxDeegrees.TabStop = false;
            this.groupBoxDeegrees.Text = "Units";
            // 
            // textBoxUserUnits
            // 
            this.textBoxUserUnits.Enabled = false;
            this.textBoxUserUnits.Location = new System.Drawing.Point(106, 18);
            this.textBoxUserUnits.Name = "textBoxUserUnits";
            this.textBoxUserUnits.Size = new System.Drawing.Size(36, 20);
            this.textBoxUserUnits.TabIndex = 3;
            this.textBoxUserUnits.Text = "%";
            // 
            // radioButtonUserUnit
            // 
            this.radioButtonUserUnit.AutoSize = true;
            this.radioButtonUserUnit.Location = new System.Drawing.Point(89, 21);
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
            this.radioButtonCelsiusUnit.Location = new System.Drawing.Point(47, 19);
            this.radioButtonCelsiusUnit.Name = "radioButtonCelsiusUnit";
            this.radioButtonCelsiusUnit.Size = new System.Drawing.Size(36, 17);
            this.radioButtonCelsiusUnit.TabIndex = 1;
            this.radioButtonCelsiusUnit.TabStop = true;
            this.radioButtonCelsiusUnit.Text = "°C";
            this.radioButtonCelsiusUnit.UseVisualStyleBackColor = true;
            // 
            // radioButtonFahrentheitUnit
            // 
            this.radioButtonFahrentheitUnit.AutoSize = true;
            this.radioButtonFahrentheitUnit.Location = new System.Drawing.Point(6, 19);
            this.radioButtonFahrentheitUnit.Name = "radioButtonFahrentheitUnit";
            this.radioButtonFahrentheitUnit.Size = new System.Drawing.Size(35, 17);
            this.radioButtonFahrentheitUnit.TabIndex = 0;
            this.radioButtonFahrentheitUnit.Text = "°F";
            this.radioButtonFahrentheitUnit.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Text color";
            // 
            // buttonTextColor
            // 
            this.buttonTextColor.Location = new System.Drawing.Point(113, 77);
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
            this.groupBox1.Location = new System.Drawing.Point(173, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 124);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Temperature size";
            // 
            // numericUpDownTemperatureSize
            // 
            this.numericUpDownTemperatureSize.Location = new System.Drawing.Point(125, 16);
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
            this.labelTempratureSize.Location = new System.Drawing.Point(3, 16);
            this.labelTempratureSize.Margin = new System.Windows.Forms.Padding(0);
            this.labelTempratureSize.Name = "labelTempratureSize";
            this.labelTempratureSize.Size = new System.Drawing.Size(181, 105);
            this.labelTempratureSize.TabIndex = 0;
            this.labelTempratureSize.Text = "Aa";
            this.labelTempratureSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Background color";
            // 
            // buttonBackColor
            // 
            this.buttonBackColor.Location = new System.Drawing.Point(113, 48);
            this.buttonBackColor.Name = "buttonBackColor";
            this.buttonBackColor.Size = new System.Drawing.Size(23, 23);
            this.buttonBackColor.TabIndex = 15;
            this.buttonBackColor.UseVisualStyleBackColor = true;
            this.buttonBackColor.Click += new System.EventHandler(this.buttonBackColor_Click);
            // 
            // textBoxTransparency
            // 
            this.textBoxTransparency.Location = new System.Drawing.Point(239, 19);
            this.textBoxTransparency.Name = "textBoxTransparency";
            this.textBoxTransparency.Size = new System.Drawing.Size(59, 20);
            this.textBoxTransparency.TabIndex = 14;
            this.textBoxTransparency.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxTransparency_Validating);
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
            this.trackBarTransparency.Minimum = 10;
            this.trackBarTransparency.Name = "trackBarTransparency";
            this.trackBarTransparency.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBarTransparency.Size = new System.Drawing.Size(145, 45);
            this.trackBarTransparency.TabIndex = 12;
            this.trackBarTransparency.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarTransparency.Value = 10;
            this.trackBarTransparency.ValueChanged += new System.EventHandler(this.trackBarTransparency_ValueChanged);
            // 
            // buttonRemoveWidget
            // 
            this.buttonRemoveWidget.Location = new System.Drawing.Point(199, 502);
            this.buttonRemoveWidget.Name = "buttonRemoveWidget";
            this.buttonRemoveWidget.Size = new System.Drawing.Size(97, 23);
            this.buttonRemoveWidget.TabIndex = 14;
            this.buttonRemoveWidget.Text = "Remove Widget";
            this.buttonRemoveWidget.UseVisualStyleBackColor = true;
            this.buttonRemoveWidget.Click += new System.EventHandler(this.buttonRemoveWidget_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 537);
            this.Controls.Add(this.buttonRemoveWidget);
            this.Controls.Add(this.groupBoxProperties);
            this.Controls.Add(this.groupBoxConnections);
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
    }
}