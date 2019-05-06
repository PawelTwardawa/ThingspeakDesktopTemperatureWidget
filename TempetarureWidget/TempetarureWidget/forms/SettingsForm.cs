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
using TempetarureWidget.SettingsApp;

namespace TempetarureWidget
{
    public partial class SettingsForm : Form
    {
        private Settings _settings;
        private AppSettings _appSettings;
        private bool _expand = false;
        private int _normalSize = 435;

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

        private void button1_Click(object sender, EventArgs e)
        {
            if(!_expand)
            {
                Width = _normalSize + widgetUC.Width + 20; 
                _expand = true;
                buttonExpand.Text = "<<";
                updatePreviewWidget();
            }
            else
            {
                Width = _normalSize;
                _expand = false;
                buttonExpand.Text = ">>";
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
    }
}
