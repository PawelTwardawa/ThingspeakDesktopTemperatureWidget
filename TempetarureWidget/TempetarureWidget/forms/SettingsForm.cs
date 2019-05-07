using IWshRuntimeLibrary;
using Microsoft.Win32;
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
using System.Windows.Forms.DataVisualization.Charting;
using TempetarureWidget.DTO;
using TempetarureWidget.forms;
using TempetarureWidget.SettingsApp;

namespace TempetarureWidget
{
    public partial class SettingsForm : Form
    {
        private Settings _settings;
        private AppSettings _appSettings;
        private bool _expand = false;
        private int _normalSize = 405;

        public SettingsForm()
        {
            InitializeComponent();
            Width = _normalSize;
        }

        public SettingsForm(ref Settings settings) : this()
        {
            _settings = settings;         
        }

        public SettingsForm(ref AppSettings appSettings, ref Settings settings) : this(ref settings)
        {
            _appSettings = appSettings;
        }

        private  async Task<Dictionary<Fields, string>> fillComboBoxField(Manager manager)
        {
                var data = await manager.AvailableFieldsAsync();
                comboBoxFields.DataSource = new BindingSource(data, null);
                return data;
        }

        private async void Settings_LoadAsync(object sender, EventArgs e)
        {
            trackBarRefreshTime.Value = 60;
            comboBoxRefreshTimeUnit.SelectedIndex = comboBoxRefreshTimeUnit.Items.IndexOf("s");
            trackBarTransparency.Value = 100;
            numericUpDownDateSize.Value = numericUpDownDateSize.Maximum;
            numericUpDownTemperatureSize.Value = numericUpDownTemperatureSize.Maximum;
            comboBoxTimezone.SelectedIndex = 1;
            buttonLineColor.BackColor = colorDialogChartLine.Color;

            
            switch (_settings.deegree)
            {
                case Deegree.C:
                    {
                        radioButtonCelsiusUnit.Checked = true;
                        break;
                    }
                case Deegree.F:
                    {
                        radioButtonFahrentheitUnit.Checked = true;
                        break;
                    }
                case Deegree.User:
                    {
                        radioButtonUserUnit.Checked = true;
                        break;
                    }
            }

            textBoxUserUnits.Text = _settings.unit;
            textBoxChannel.Text = _settings.channel;

            if (_settings.publicChannel)
            {
                checkBoxPublicChannel.Checked = true;
            }
            else
            {
                textBoxApi.Text = _settings.api_key;
            }

            labelTempratureSize.Font = new Font(labelTempratureSize.Font.FontFamily, (_settings.temperatureSize > 80 ? 80 : _settings.temperatureSize), labelTempratureSize.Font.Style);
                numericUpDownTemperatureSize.Value = (decimal)_settings.temperatureSize;
            labelDateSize.Font = new Font(labelDateSize.Font.FontFamily, (_settings.dateSize > 80 ? 80 : _settings.dateSize), labelDateSize.Font.Style);
            numericUpDownDateSize.Value = (decimal)_settings.dateSize;
                              
                
            checkBoxDateLabel.Checked = _settings.dateVisable;
            checkBoxShowName.Checked = _settings.nameVisable;
            groupBoxChannelName.Enabled = _settings.nameVisable;

            if (_settings.refreshTime >= 1000 && _settings.refreshTime < 60000)
            {
                trackBarRefreshTime.Value = _settings.refreshTime / 1000;
                comboBoxRefreshTimeUnit.SelectedItem = "s";
            }
            else if (_settings.refreshTime >= 60000 && _settings.refreshTime < 3600000)
            {
                trackBarRefreshTime.Value = _settings.refreshTime / 60000;
                comboBoxRefreshTimeUnit.SelectedItem = "m";
            }
            else if (_settings.refreshTime >= 3600000 && _settings.refreshTime < 216000000)
            {
                trackBarRefreshTime.Value = _settings.refreshTime / 3600000;
                comboBoxRefreshTimeUnit.SelectedItem = "h";
            }


            colorDialogBackground.Color = _settings.backColor;
            buttonBackColor.BackColor = _settings.backColor;
            colorDialogText.Color = _settings.textColor;
            buttonTextColor.BackColor = _settings.textColor;

            trackBarTransparency.Value = (int)(_settings.opacity * 100);

            checkBoxChannelName.Checked = _settings.channelNameVisable;
            checkBoxFieldName.Checked = _settings.fieldNameVisable;
            checkBoxCheckForUpdate.Checked = _appSettings.checkForUpdate;

            //checkBoxRunWithWindows.Checked = _settings.runWithWindows;
            checkBoxRunWithWindows.Checked = _appSettings.runWithWindows;

            if (!string.IsNullOrWhiteSpace(_settings.timezone))
                comboBoxTimezone.SelectedItem = _settings.timezone;


            ////////////////////////////////////////////////////////////////////////////////
            /// CHART
            /// ///////////////////////////////////////////////////////////////////////////////////////////////////

            if (_settings.chartSettings != null)
            {
                colorDialogChartLine.Color = _settings.chartSettings.LineColor;
                numericUpDownLineWidth.Value = _settings.chartSettings.LineWidth;
                numericUpDownAverage.Value = _settings.chartSettings.Average;
                numericUpDownMedian.Value = _settings.chartSettings.Median;
                switch (_settings.chartSettings.GroupType)
                {
                    case ChartGroupType.None:
                        checkBoxAverage.Checked = false;
                        checkBoxMedian.Checked = false;
                        break;

                    case ChartGroupType.Median:
                        checkBoxMedian.Checked = true;
                        break;

                    case ChartGroupType.Average:
                        checkBoxAverage.Checked = true;
                        break;
                }

                numericUpDownNumberPoints.Value = _settings.chartSettings.NumberOfPoints;
                textBoxTitleX.Text = _settings.chartSettings.TitleX;
                textBoxTitleY.Text = _settings.chartSettings.TitleY;
                checBoxTitleX.Checked = _settings.chartSettings.TitleXVisable;
                checkBoxTitleY.Checked = _settings.chartSettings.TitleYVisable;
                checkBoxChartVisable.Checked = _settings.chartSettings.Visable;
                buttonLineColor.BackColor = _settings.chartSettings.LineColor;
                textBoxDateFormat.Text = _settings.chartSettings.DataLabelFormat;
            }
            /// //////////////////////////////////////////////////////////////////////////////////////////////////////



            //if (!_settings.IsEmpty)
            if ((!_settings.IsEmpty && !_settings.publicChannel) || (!_settings.IsEmptyChannel && _settings.publicChannel))
            {
                using (Manager manager = new Manager(_settings.api_key, _settings.channel))
                {
                    Dictionary<Fields, string> data = await fillComboBoxField(manager);
                    int index = data.Keys.ToList().IndexOf(_settings.field);
                    if (index == -1)
                        index = 0;
                    comboBoxFields.SelectedIndex = index;
                }
            }
            else
            {
                comboBoxFields.DataSource = new BindingSource( new Dictionary<Fields, string>() { { Fields.unknown, "enter channel id" } }, null);
            }

            textBoxApi.TextChanged += textBoxChannel_TextChanged;
            textBoxChannel.TextChanged += textBoxChannel_TextChanged;

            updatePreviewWidget();
        }

        private void trackBarRefreshTime_ValueChanged(object sender, EventArgs e)
        {
            textBoxRefreshTime.Text = trackBarRefreshTime.Value.ToString();
        }

        private void LoadToSettings(ref Settings settings)
        {
            if (string.IsNullOrWhiteSpace(textBoxChannel.Text) && checkBoxPublicChannel.Checked)
            {
                MessageBox.Show("Cannot save with empty channel id", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((string.IsNullOrWhiteSpace(textBoxApi.Text) || string.IsNullOrWhiteSpace(textBoxChannel.Text)) && !checkBoxPublicChannel.Checked)
            {
                MessageBox.Show("Cannot save with empty Api key or Channel id", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            settings.channel = textBoxChannel.Text;

            if (checkBoxPublicChannel.Checked)
            {
                settings.api_key = "";
                settings.publicChannel = true;
            }
            else
            {
                settings.publicChannel = false;
                settings.api_key = textBoxApi.Text;
            }
            try
            {
                Fields field = ((KeyValuePair<Fields, string>)comboBoxFields.SelectedItem).Key;
                if (field == Fields.unknown)
                {
                    MessageBox.Show("Cannot save with incorrect or unknown field name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                settings.field = field;
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("Cannot save with incorrect field name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Cannot save with empty field name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            settings.backColor = colorDialogBackground.Color;
            settings.textColor = colorDialogText.Color;
            settings.dateVisable = checkBoxDateLabel.Checked;
            settings.nameVisable = checkBoxShowName.Checked;
            settings.opacity = (float)trackBarTransparency.Value / 100;
            settings.dateSize = (float)numericUpDownDateSize.Value;
            settings.temperatureSize = (float)numericUpDownTemperatureSize.Value;
            settings.fieldNameVisable = checkBoxFieldName.Checked;
            settings.channelNameVisable = checkBoxChannelName.Checked;

            

            settings.timezone = comboBoxTimezone.SelectedItem.ToString();

            runWithWindows();

            if (radioButtonCelsiusUnit.Checked)
                settings.deegree = Deegree.C;
            else if (radioButtonFahrentheitUnit.Checked)
                settings.deegree = Deegree.F;
            else if (radioButtonUserUnit.Checked)
            {
                settings.deegree = Deegree.User;
                settings.unit = textBoxUserUnits.Text;
            }

            if (comboBoxRefreshTimeUnit.SelectedItem.Equals("s"))
            {
                settings.refreshTime = trackBarRefreshTime.Value * 1000;
            }
            else if (comboBoxRefreshTimeUnit.SelectedItem.Equals("m"))
            {
                settings.refreshTime = trackBarRefreshTime.Value * 60000;
            }
            else if (comboBoxRefreshTimeUnit.SelectedItem.Equals("h"))
            {
                settings.refreshTime = trackBarRefreshTime.Value * 3600000;
            }

            /////////////////////////////////////////////////////////////////////////
            /// CHART
            /////////////////////////////////////////////////////////////////////////

            if(settings.chartSettings == null)
                settings.chartSettings = new ChartSettings();

            

            settings.chartSettings.LineColor = colorDialogChartLine.Color;
            settings.chartSettings.ChartType = SeriesChartType.Line;
            settings.chartSettings.LineWidth = (int)numericUpDownLineWidth.Value;
            settings.chartSettings.Average = (int) numericUpDownAverage.Value;
            settings.chartSettings.Median = (int) numericUpDownMedian.Value;
            if (checkBoxAverage.Checked)
            {
                settings.chartSettings.GroupType = ChartGroupType.Average;
                settings.chartSettings.NumberOfData =
                    (int) (numericUpDownNumberPoints.Value * numericUpDownAverage.Value);
            }
            else if (checkBoxMedian.Checked)
            {
                settings.chartSettings.GroupType = ChartGroupType.Median;
                settings.chartSettings.NumberOfData =
                    (int) (numericUpDownNumberPoints.Value * numericUpDownMedian.Value);
            }
            else
            {
                settings.chartSettings.GroupType = ChartGroupType.None;
                settings.chartSettings.NumberOfData = (int) numericUpDownNumberPoints.Value;
            }

            if (!checkBoxChartVisable.Checked)
                settings.chartSettings.NumberOfData = 1;

            settings.chartSettings.NumberOfPoints = (int) numericUpDownNumberPoints.Value;
            settings.chartSettings.TitleX = textBoxTitleX.Text;
            settings.chartSettings.TitleY = textBoxTitleY.Text;
            settings.chartSettings.TitleXVisable = checBoxTitleX.Checked;
            settings.chartSettings.TitleYVisable = checkBoxTitleY.Checked;
            settings.chartSettings.Visable = checkBoxChartVisable.Checked;
            settings.chartSettings.DataLabelFormat = textBoxDateFormat.Text;

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            LoadToSettings(ref _settings);

            _appSettings.runWithWindows = checkBoxRunWithWindows.Checked;
            _appSettings.checkForUpdate = checkBoxCheckForUpdate.Checked;

            _settings.Save();

            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void buttonBackColor_Click(object sender, EventArgs e)
        {
            if(colorDialogBackground.ShowDialog() == DialogResult.OK)
            {
                buttonBackColor.BackColor = colorDialogBackground.Color;
            }

            updatePreviewWidget();
        }

        private void buttonTextColor_Click(object sender, EventArgs e)
        {
            if (colorDialogText.ShowDialog() == DialogResult.OK)
            {
                buttonTextColor.BackColor = colorDialogText.Color;
            }

            updatePreviewWidget();
        }

        private void trackBarTransparency_ValueChanged(object sender, EventArgs e)
        {
            textBoxTransparency.Text = trackBarTransparency.Value.ToString();
        }

        private void textBoxChannel_TextChanged(object sender, EventArgs e)
        {
            using (Manager manager = new Manager(checkBoxPublicChannel.Checked? "" : textBoxApi.Text, textBoxChannel.Text))
            {
                fillComboBoxField(manager);
            }
        }

        private void numericUpDownTemperatureSize_ValueChanged(object sender, EventArgs e)
        {
            labelTempratureSize.Font = new Font(labelTempratureSize.Font.FontFamily, ((float)numericUpDownTemperatureSize.Value > 80 ? 80 : (float)numericUpDownTemperatureSize.Value), labelTempratureSize.Font.Style);
            updatePreviewWidget();
        }

        private void numericUpDownDateSize_ValueChanged(object sender, EventArgs e)
        {
            labelDateSize.Font = new Font(labelDateSize.Font.FontFamily, ((float)numericUpDownDateSize.Value > 80 ? 80 : (float)numericUpDownDateSize.Value), labelDateSize.Font.Style);
            updatePreviewWidget();
        }

        

        private void checkBoxShowChannelName_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxShowName.Checked)
                groupBoxChannelName.Enabled = true;
            else
                groupBoxChannelName.Enabled = false;

            updatePreviewWidget();
        }

        private void runWithWindows()
        {
            string shortcutPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), Application.ProductName + ".lnk");

            if (checkBoxRunWithWindows.Checked && !System.IO.File.Exists(shortcutPath))
            {
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), Application.ProductName + ".lnk"));
                shortcut.WorkingDirectory = Application.StartupPath;
                shortcut.TargetPath = Application.ExecutablePath;
                shortcut.Save();
            }
            else if(!checkBoxRunWithWindows.Checked && System.IO.File.Exists(shortcutPath))
            {
                System.IO.File.Delete(shortcutPath);
            }
        }

        private void buttonRemoveWidget_Click(object sender, EventArgs e)
        {
            SettingsManager.RemoveSettings(_settings);
            DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void textBoxTransparency_Validating(object sender, CancelEventArgs e)
        {
            int value;
            try
            {
                value = int.Parse(textBoxTransparency.Text);

                if (value < trackBarTransparency.Minimum)
                {
                    value = trackBarTransparency.Minimum;
                    textBoxTransparency.Text = trackBarTransparency.Minimum.ToString();
                }
                if (value > trackBarTransparency.Maximum)
                {
                    value = trackBarTransparency.Maximum;
                    textBoxTransparency.Text = trackBarTransparency.Maximum.ToString();
                }

                trackBarTransparency.Value = value;
            }
            catch (FormatException ex)
            {
                MessageBox.Show("You can enter only integer numbers!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBoxRefreshTime_Validating(object sender, CancelEventArgs e)
        {
            int value;
            try
            {
                value = int.Parse(textBoxRefreshTime.Text);

                if (value < trackBarRefreshTime.Minimum)
                {
                    value = trackBarRefreshTime.Minimum;
                    textBoxRefreshTime.Text = trackBarRefreshTime.Minimum.ToString();
                }
                if (value > trackBarRefreshTime.Maximum)
                {
                    value = trackBarRefreshTime.Maximum;
                    textBoxRefreshTime.Text = trackBarRefreshTime.Maximum.ToString();
                }

                trackBarRefreshTime.Value = value;
            }
            catch (FormatException ex)
            {
                MessageBox.Show("You can enter only integer numbers!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboBoxFields_Validated(object sender, EventArgs e)
        {
            int index = comboBoxFields.FindString(comboBoxFields.Text);
            if (index < 0)
            {
                MessageBox.Show("Invalid field name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxFields.Focus();
            }
        }

        private void radioButtonUserUnit_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUserUnit.Checked)
                textBoxUserUnits.Enabled = true;
            else
                textBoxUserUnits.Enabled = false;

            updatePreviewWidget();
        }

        private void checkBoxPublicChannel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPublicChannel.Checked)
                textBoxApi.Enabled = false;
            else
                textBoxApi.Enabled = true;

            textBoxChannel_TextChanged(null, null);

        }

        private void buttonExpand_Click(object sender, EventArgs e)
        {
            if(!_expand)
            {
                Width = _normalSize + widgetUC.Width + 20; 
                _expand = true;
                buttonExpand.Text = "Preview <<";
                updatePreviewWidget();
            }
            else
            {
                Width = _normalSize;
                _expand = false;
                buttonExpand.Text = "Preview >>";
            }
        }

        private void updatePreviewWidget()
        {
            if (_expand)
            {
                Settings settings = new Settings();

                LoadToSettings(ref settings);

                widgetUC.loadSettings(settings);
                widgetUC.UpdateNameLabel("channel name", "field name");
                widgetUC.UpdateTemperatureLabel("-00.00");

                if (settings.chartSettings.Visable)
                {
                    chartUC.Visible = true;
                    chartUC.Location = new Point(chartUC.Location.X, widgetUC.Location.Y + widgetUC.Height);
                    chartUC.Width = widgetUC.Width;
                    chartUC.Height = chartUC.Width / 2;

                    List<Data<dynamic>> dataList = new List<Data<dynamic>>();
                    for (int i = 0; i < numericUpDownNumberPoints.Value; i++)
                    {
                        dataList.Add(new Data<dynamic>()
                            {value = i % 3 + "", date = new DateTime(2000 + i, 1, 1, 00, 00, 00)});
                    }

                    
                    chartUC.LoadSetting(settings);
                    chartUC.UpdateData(dataList);
                }
                else
                {
                    chartUC.Visible = false;
                }

                Width = _normalSize + widgetUC.Width + 20;
            }
        }

        private void radioButtonFahrentheitUnit_CheckedChanged(object sender, EventArgs e)
        {
            updatePreviewWidget();
        }

        private void radioButtonCelsiusUnit_CheckedChanged(object sender, EventArgs e)
        {
            updatePreviewWidget();
        }

        private void textBoxUserUnits_TextChanged(object sender, EventArgs e)
        {
            updatePreviewWidget();
        }

        private void checkBoxDateLabel_CheckedChanged(object sender, EventArgs e)
        {
            updatePreviewWidget();
        }

        private void checkBoxChannelName_CheckedChanged(object sender, EventArgs e)
        {
            updatePreviewWidget();
        }

        private void checkBoxFieldName_CheckedChanged(object sender, EventArgs e)
        {
            updatePreviewWidget();
        }

        private void checkBoxChartVisable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxChartVisable.Checked)
            {
                groupBoxChart.Enabled = true;
            }
            else
            {
                groupBoxChart.Enabled = false;
            }
            updatePreviewWidget();
        }

        private void checBoxTitleX_CheckedChanged(object sender, EventArgs e)
        {
            if (checBoxTitleX.Checked)
            {
                textBoxTitleX.Enabled = true;
            }
            else
            {
                textBoxTitleX.Enabled = false;
            }
            updatePreviewWidget();
        }

        private void checkBoxTitleY_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTitleY.Checked)
            {
                textBoxTitleY.Enabled = true;
            }
            else
            {
                textBoxTitleY.Enabled = false;
            }
            updatePreviewWidget();
        }

        private void buttonLineColor_Click(object sender, EventArgs e)
        {
            if (colorDialogChartLine.ShowDialog() == DialogResult.OK)
            {
                buttonLineColor.BackColor = colorDialogChartLine.Color;
            }

            updatePreviewWidget();
        }

        private void textBoxTitleX_TextChanged(object sender, EventArgs e)
        {
            updatePreviewWidget();
        }

        private void textBoxTitleY_TextChanged(object sender, EventArgs e)
        {
            updatePreviewWidget();
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            updatePreviewWidget();
        }

        private void checkBoxMedian_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMedian.Checked)
            {
                numericUpDownMedian.Enabled = true;
                if (checkBoxAverage.Checked)
                    checkBoxAverage.Checked = false;
            }
            else
            {
                numericUpDownMedian.Enabled = false;
            }
            updatePreviewWidget();
        }

        private void checkBoxAverage_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAverage.Checked)
            {
                numericUpDownAverage.Enabled = true;
                if (checkBoxMedian.Checked)
                    checkBoxMedian.Checked = false;
            }
            else
            {
                numericUpDownAverage.Enabled = false;
            }
            updatePreviewWidget();
        }

        private void textBoxDateFormat_TextChanged(object sender, EventArgs e)
        {
            updatePreviewWidget();
        }

        private void textBoxDateFormat_Validating(object sender, CancelEventArgs e)
        {
            updatePreviewWidget();
        }
    }
}
