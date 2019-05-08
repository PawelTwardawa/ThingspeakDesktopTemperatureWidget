using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using IWshRuntimeLibrary;
using TempetarureWidget.DTOs;
using TempetarureWidget.SettingsApp;

namespace TempetarureWidget.forms
{
    public partial class SettingsForm : Form
    {
        private Settings _settings;
        private AppSettings _appSettings;
        private bool _expand;
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

        private  async Task<Dictionary<Fields, string>> FillComboBoxField(Manager manager)
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

            
            switch (_settings.Deegree)
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

            textBoxUserUnits.Text = _settings.Unit;
            textBoxChannel.Text = _settings.Channel;

            if (_settings.PublicChannel)
            {
                checkBoxPublicChannel.Checked = true;
            }
            else
            {
                textBoxApi.Text = _settings.Api_Key;
            }

            labelTempratureSize.Font = new Font(labelTempratureSize.Font.FontFamily, (_settings.TemperatureSize > 80 ? 80 : _settings.TemperatureSize), labelTempratureSize.Font.Style);
                numericUpDownTemperatureSize.Value = (decimal)_settings.TemperatureSize;
            labelDateSize.Font = new Font(labelDateSize.Font.FontFamily, (_settings.DateSize > 80 ? 80 : _settings.DateSize), labelDateSize.Font.Style);
            numericUpDownDateSize.Value = (decimal)_settings.DateSize;
                              
                
            checkBoxDateLabel.Checked = _settings.DateVisable;
            checkBoxShowName.Checked = _settings.NameVisable;
            groupBoxChannelName.Enabled = _settings.NameVisable;

            if (_settings.RefreshTime >= 1000 && _settings.RefreshTime < 60000)
            {
                trackBarRefreshTime.Value = _settings.RefreshTime / 1000;
                comboBoxRefreshTimeUnit.SelectedItem = "s";
            }
            else if (_settings.RefreshTime >= 60000 && _settings.RefreshTime < 3600000)
            {
                trackBarRefreshTime.Value = _settings.RefreshTime / 60000;
                comboBoxRefreshTimeUnit.SelectedItem = "m";
            }
            else if (_settings.RefreshTime >= 3600000 && _settings.RefreshTime < 216000000)
            {
                trackBarRefreshTime.Value = _settings.RefreshTime / 3600000;
                comboBoxRefreshTimeUnit.SelectedItem = "h";
            }


            colorDialogBackground.Color = _settings.BackColor;
            buttonBackColor.BackColor = _settings.BackColor;
            colorDialogText.Color = _settings.TextColor;
            buttonTextColor.BackColor = _settings.TextColor;

            trackBarTransparency.Value = (int)(_settings.Opacity * 100);

            checkBoxChannelName.Checked = _settings.ChannelNameVisable;
            checkBoxFieldName.Checked = _settings.FieldNameVisable;
            checkBoxCheckForUpdate.Checked = _appSettings.checkForUpdate;

            //checkBoxRunWithWindows.Checked = _settings.runWithWindows;
            checkBoxRunWithWindows.Checked = _appSettings.runWithWindows;

            if (!string.IsNullOrWhiteSpace(_settings.Timezone))
                comboBoxTimezone.SelectedItem = _settings.Timezone;


            ////////////////////////////////////////////////////////////////////////////////
            /// CHART
            /// ///////////////////////////////////////////////////////////////////////////////////////////////////

            if (_settings.ChartSettings != null)
            {
                colorDialogChartLine.Color = _settings.ChartSettings.LineColor;
                numericUpDownLineWidth.Value = _settings.ChartSettings.LineWidth;
                numericUpDownAverage.Value = _settings.ChartSettings.Average;
                numericUpDownMedian.Value = _settings.ChartSettings.Median;
                switch (_settings.ChartSettings.GroupType)
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

                numericUpDownNumberPoints.Value = _settings.ChartSettings.NumberOfPoints;
                textBoxTitleX.Text = _settings.ChartSettings.TitleX;
                textBoxTitleY.Text = _settings.ChartSettings.TitleY;
                checBoxTitleX.Checked = _settings.ChartSettings.TitleXVisable;
                checkBoxTitleY.Checked = _settings.ChartSettings.TitleYVisable;
                checkBoxChartVisable.Checked = _settings.ChartSettings.Visable;
                buttonLineColor.BackColor = _settings.ChartSettings.LineColor;
                textBoxDateFormat.Text = _settings.ChartSettings.DataLabelFormat;
            }
            /// //////////////////////////////////////////////////////////////////////////////////////////////////////



            //if (!_settings.IsEmpty)
            if ((!_settings.IsEmpty && !_settings.PublicChannel) || (!_settings.IsEmptyChannel && _settings.PublicChannel))
            {
                using (Manager manager = new Manager(_settings.Api_Key, _settings.Channel))
                {
                    Dictionary<Fields, string> data = await FillComboBoxField(manager);
                    int index = data.Keys.ToList().IndexOf(_settings.Field);
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

            UpdatePreviewWidget();
        }

        private void trackBarRefreshTime_ValueChanged(object sender, EventArgs e)
        {
            textBoxRefreshTime.Text = trackBarRefreshTime.Value.ToString();
        }

        private void LoadToSettings(ref Settings settings)
        {
            if (string.IsNullOrWhiteSpace(textBoxChannel.Text) && checkBoxPublicChannel.Checked)
            {
                MessageBox.Show(@"Cannot save with empty channel id", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((string.IsNullOrWhiteSpace(textBoxApi.Text) || string.IsNullOrWhiteSpace(textBoxChannel.Text)) && !checkBoxPublicChannel.Checked)
            {
                MessageBox.Show(@"Cannot save with empty Api key or Channel id", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            settings.Channel = textBoxChannel.Text;

            if (checkBoxPublicChannel.Checked)
            {
                settings.Api_Key = "";
                settings.PublicChannel = true;
            }
            else
            {
                settings.PublicChannel = false;
                settings.Api_Key = textBoxApi.Text;
            }
            try
            {
                Fields field = ((KeyValuePair<Fields, string>)comboBoxFields.SelectedItem).Key;
                if (field == Fields.unknown)
                {
                    MessageBox.Show(@"Cannot save with incorrect or unknown field name", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                settings.Field = field;
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(@"Cannot save with incorrect field name", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(@"Cannot save with empty field name", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            settings.BackColor = colorDialogBackground.Color;
            settings.TextColor = colorDialogText.Color;
            settings.DateVisable = checkBoxDateLabel.Checked;
            settings.NameVisable = checkBoxShowName.Checked;
            settings.Opacity = (float)trackBarTransparency.Value / 100;
            settings.DateSize = (float)numericUpDownDateSize.Value;
            settings.TemperatureSize = (float)numericUpDownTemperatureSize.Value;
            settings.FieldNameVisable = checkBoxFieldName.Checked;
            settings.ChannelNameVisable = checkBoxChannelName.Checked;

            

            settings.Timezone = comboBoxTimezone.SelectedItem.ToString();

            RunWithWindows();

            if (radioButtonCelsiusUnit.Checked)
                settings.Deegree = Deegree.C;
            else if (radioButtonFahrentheitUnit.Checked)
                settings.Deegree = Deegree.F;
            else if (radioButtonUserUnit.Checked)
            {
                settings.Deegree = Deegree.User;
                settings.Unit = textBoxUserUnits.Text;
            }

            if (comboBoxRefreshTimeUnit.SelectedItem.Equals("s"))
            {
                settings.RefreshTime = trackBarRefreshTime.Value * 1000;
            }
            else if (comboBoxRefreshTimeUnit.SelectedItem.Equals("m"))
            {
                settings.RefreshTime = trackBarRefreshTime.Value * 60000;
            }
            else if (comboBoxRefreshTimeUnit.SelectedItem.Equals("h"))
            {
                settings.RefreshTime = trackBarRefreshTime.Value * 3600000;
            }

            /////////////////////////////////////////////////////////////////////////
            /// CHART
            /////////////////////////////////////////////////////////////////////////

            if(settings.ChartSettings == null)
                settings.ChartSettings = new ChartSettings();

            

            settings.ChartSettings.LineColor = colorDialogChartLine.Color;
            settings.ChartSettings.ChartType = SeriesChartType.Line;
            settings.ChartSettings.LineWidth = (int)numericUpDownLineWidth.Value;
            settings.ChartSettings.Average = (int) numericUpDownAverage.Value;
            settings.ChartSettings.Median = (int) numericUpDownMedian.Value;
            if (checkBoxAverage.Checked)
            {
                settings.ChartSettings.GroupType = ChartGroupType.Average;
                settings.ChartSettings.NumberOfData =
                    (int) (numericUpDownNumberPoints.Value * numericUpDownAverage.Value);
            }
            else if (checkBoxMedian.Checked)
            {
                settings.ChartSettings.GroupType = ChartGroupType.Median;
                settings.ChartSettings.NumberOfData =
                    (int) (numericUpDownNumberPoints.Value * numericUpDownMedian.Value);
            }
            else
            {
                settings.ChartSettings.GroupType = ChartGroupType.None;
                settings.ChartSettings.NumberOfData = (int) numericUpDownNumberPoints.Value;
            }

            if (!checkBoxChartVisable.Checked)
                settings.ChartSettings.NumberOfData = 1;

            settings.ChartSettings.NumberOfPoints = (int) numericUpDownNumberPoints.Value;
            settings.ChartSettings.TitleX = textBoxTitleX.Text;
            settings.ChartSettings.TitleY = textBoxTitleY.Text;
            settings.ChartSettings.TitleXVisable = checBoxTitleX.Checked;
            settings.ChartSettings.TitleYVisable = checkBoxTitleY.Checked;
            settings.ChartSettings.Visable = checkBoxChartVisable.Checked;
            settings.ChartSettings.DataLabelFormat = textBoxDateFormat.Text;

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            LoadToSettings(ref _settings);

            _appSettings.runWithWindows = checkBoxRunWithWindows.Checked;
            _appSettings.checkForUpdate = checkBoxCheckForUpdate.Checked;

            _settings.Save();

            Close();
            DialogResult = DialogResult.OK;
        }

        private void buttonBackColor_Click(object sender, EventArgs e)
        {
            if(colorDialogBackground.ShowDialog() == DialogResult.OK)
            {
                buttonBackColor.BackColor = colorDialogBackground.Color;
            }

            UpdatePreviewWidget();
        }

        private void buttonTextColor_Click(object sender, EventArgs e)
        {
            if (colorDialogText.ShowDialog() == DialogResult.OK)
            {
                buttonTextColor.BackColor = colorDialogText.Color;
            }

            UpdatePreviewWidget();
        }

        private void trackBarTransparency_ValueChanged(object sender, EventArgs e)
        {
            textBoxTransparency.Text = trackBarTransparency.Value.ToString();
        }

        private void textBoxChannel_TextChanged(object sender, EventArgs e)
        {
            using (Manager manager = new Manager(checkBoxPublicChannel.Checked? "" : textBoxApi.Text, textBoxChannel.Text))
            {
                FillComboBoxField(manager);
            }
        }

        private void numericUpDownTemperatureSize_ValueChanged(object sender, EventArgs e)
        {
            labelTempratureSize.Font = new Font(labelTempratureSize.Font.FontFamily, ((float)numericUpDownTemperatureSize.Value > 80 ? 80 : (float)numericUpDownTemperatureSize.Value), labelTempratureSize.Font.Style);
            UpdatePreviewWidget();
        }

        private void numericUpDownDateSize_ValueChanged(object sender, EventArgs e)
        {
            labelDateSize.Font = new Font(labelDateSize.Font.FontFamily, ((float)numericUpDownDateSize.Value > 80 ? 80 : (float)numericUpDownDateSize.Value), labelDateSize.Font.Style);
            UpdatePreviewWidget();
        }

        

        private void checkBoxShowChannelName_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxShowName.Checked)
                groupBoxChannelName.Enabled = true;
            else
                groupBoxChannelName.Enabled = false;

            UpdatePreviewWidget();
        }

        private void RunWithWindows()
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
            Close();
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
                MessageBox.Show(@"You can enter only integer numbers!", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show(@"You can enter only integer numbers!", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboBoxFields_Validated(object sender, EventArgs e)
        {
            int index = comboBoxFields.FindString(comboBoxFields.Text);
            if (index < 0)
            {
                MessageBox.Show(@"Invalid field name", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxFields.Focus();
            }
        }

        private void radioButtonUserUnit_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUserUnit.Checked)
                textBoxUserUnits.Enabled = true;
            else
                textBoxUserUnits.Enabled = false;

            UpdatePreviewWidget();
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
                buttonExpand.Text = @"Preview <<";
                UpdatePreviewWidget();
            }
            else
            {
                Width = _normalSize;
                _expand = false;
                buttonExpand.Text = @"Preview >>";
            }
        }

        private void UpdatePreviewWidget()
        {
            if (_expand)
            {
                Settings settings = new Settings();

                LoadToSettings(ref settings);

                widgetUC.loadSettings(settings);
                widgetUC.UpdateNameLabel("channel name", "field name");
                widgetUC.UpdateTemperatureLabel("-00.00");

                if (settings.ChartSettings.Visable)
                {
                    chartUC.Visible = true;
                    chartUC.Location = new Point(chartUC.Location.X, widgetUC.Location.Y + widgetUC.Height);
                    chartUC.Width = widgetUC.Width;
                    chartUC.Height = chartUC.Width / 2;

                    List<Data<dynamic>> dataList = new List<Data<dynamic>>();
                    for (int i = 0; i < numericUpDownNumberPoints.Value; i++)
                    {
                        if(i%5 != 0)
                            dataList.Add(new Data<dynamic>()
                                {value = i % 3 + "", date = new DateTime(2000 + i, 1, 1, 00, 00, 00)});
                        else
                            dataList.Add(new Data<dynamic>()
                                {value = -i % 3 + "", date = new DateTime(2000 + i, 1, 1, 00, 00, 00)});
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
            UpdatePreviewWidget();
        }

        private void radioButtonCelsiusUnit_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePreviewWidget();
        }

        private void textBoxUserUnits_TextChanged(object sender, EventArgs e)
        {
            UpdatePreviewWidget();
        }

        private void checkBoxDateLabel_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePreviewWidget();
        }

        private void checkBoxChannelName_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePreviewWidget();
        }

        private void checkBoxFieldName_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePreviewWidget();
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
            UpdatePreviewWidget();
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
            UpdatePreviewWidget();
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
            UpdatePreviewWidget();
        }

        private void buttonLineColor_Click(object sender, EventArgs e)
        {
            if (colorDialogChartLine.ShowDialog() == DialogResult.OK)
            {
                buttonLineColor.BackColor = colorDialogChartLine.Color;
            }

            UpdatePreviewWidget();
        }

        private void textBoxTitleX_TextChanged(object sender, EventArgs e)
        {
            UpdatePreviewWidget();
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdatePreviewWidget();
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
            UpdatePreviewWidget();
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
            UpdatePreviewWidget();
        }

        private void textBoxDateFormat_Validating(object sender, CancelEventArgs e)
        {
            UpdatePreviewWidget();
        }
    }
}
