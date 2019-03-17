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

        public SettingsForm(ref Settings settings)
        {
            _settings = settings;
            InitializeComponent();
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
            textBoxApi.Text = _settings.api_key;
            textBoxChannel.Text = _settings.channel;

            labelTempratureSize.Font = new Font(labelTempratureSize.Font.FontFamily, (_settings.temperatureSize > 80 ? 80 : _settings.temperatureSize), labelTempratureSize.Font.Style);
                numericUpDownTemperatureSize.Value = (decimal)_settings.temperatureSize;
            labelDateSize.Font = new Font(labelDateSize.Font.FontFamily, (_settings.dateSize > 80 ? 80 : _settings.dateSize), labelDateSize.Font.Style);
            numericUpDownDateSize.Value = (decimal)_settings.dateSize;
                              
                
            checkBoxDateLabel.Checked = _settings.dateVisable;
            checkBoxShowName.Checked = _settings.nameVisable;
            groupBoxChannelName.Visible = _settings.nameVisable;

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
            checkBoxRunWithWindows.Checked = _settings.runWithWindows;

            if (!string.IsNullOrWhiteSpace(_settings.timezone))
                comboBoxTimezone.SelectedItem = _settings.timezone;

            if (!_settings.IsEmpty)
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

        }

        private void trackBarRefreshTime_ValueChanged(object sender, EventArgs e)
        {
            textBoxRefreshTime.Text = trackBarRefreshTime.Value.ToString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBoxApi.Text) || string.IsNullOrWhiteSpace(textBoxChannel.Text))
            {
                MessageBox.Show("Cannot save with empty Api key or Channel id", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _settings.api_key = textBoxApi.Text;
            _settings.channel = textBoxChannel.Text;
            try
            {
                Fields field  = ((KeyValuePair<Fields, string>)comboBoxFields.SelectedItem).Key;
                if(field == Fields.unknown)
                {
                    MessageBox.Show("Cannot save with incorrect or unknown field name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _settings.field = field;
            }
            catch(InvalidCastException ex)
            {
                MessageBox.Show("Cannot save with incorrect field name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch(NullReferenceException ex)
            {
                MessageBox.Show("Cannot save with empty field name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _settings.backColor = colorDialogBackground.Color;
            _settings.textColor = colorDialogText.Color;
            _settings.dateVisable = checkBoxDateLabel.Checked;
            _settings.nameVisable = checkBoxShowName.Checked;
            _settings.opacity = (float)trackBarTransparency.Value / 100;
            _settings.dateSize = (float)numericUpDownDateSize.Value;
            _settings.temperatureSize = (float)numericUpDownTemperatureSize.Value;
            _settings.fieldNameVisable = checkBoxFieldName.Checked;
            _settings.channelNameVisable = checkBoxChannelName.Checked;
            _settings.runWithWindows = checkBoxRunWithWindows.Checked;
            _settings.timezone = comboBoxTimezone.SelectedItem.ToString();

            runWithWindows();

            if (radioButtonCelsiusUnit.Checked)
                _settings.deegree = Deegree.C;
            else if (radioButtonFahrentheitUnit.Checked)
                _settings.deegree = Deegree.F;
            else if (radioButtonUserUnit.Checked)
            {
                _settings.deegree = Deegree.User;
                _settings.unit = textBoxUserUnits.Text;
            }

            if (comboBoxRefreshTimeUnit.SelectedItem.Equals("s"))
            {
                _settings.refreshTime = trackBarRefreshTime.Value * 1000;
            }
            else if (comboBoxRefreshTimeUnit.SelectedItem.Equals("m"))
            {
                _settings.refreshTime = trackBarRefreshTime.Value * 60000;
            }
            else if (comboBoxRefreshTimeUnit.SelectedItem.Equals("h"))
            {
                _settings.refreshTime = trackBarRefreshTime.Value * 3600000;
            }

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
        }

        private void trackBarTransparency_ValueChanged(object sender, EventArgs e)
        {
            textBoxTransparency.Text = trackBarTransparency.Value.ToString();
        }

        private void textBoxChannel_TextChanged(object sender, EventArgs e)
        {
            using (Manager manager = new Manager(textBoxApi.Text, textBoxChannel.Text))
            {
                fillComboBoxField(manager);
            }
        }

        private void numericUpDownTemperatureSize_ValueChanged(object sender, EventArgs e)
        {
            labelTempratureSize.Font = new Font(labelTempratureSize.Font.FontFamily, ((float)numericUpDownTemperatureSize.Value > 80 ? 80 : (float)numericUpDownTemperatureSize.Value), labelTempratureSize.Font.Style);
        }

        private void numericUpDownDateSize_ValueChanged(object sender, EventArgs e)
        {
            labelDateSize.Font = new Font(labelDateSize.Font.FontFamily, ((float)numericUpDownDateSize.Value > 80 ? 80 : (float)numericUpDownDateSize.Value), labelDateSize.Font.Style);
        }

        private void buttonTextColor_Click(object sender, EventArgs e)
        {
            if (colorDialogText.ShowDialog() == DialogResult.OK)
            {
                buttonTextColor.BackColor = colorDialogText.Color;
            }
        }

        private void checkBoxShowChannelName_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxShowName.Checked)
                groupBoxChannelName.Visible = true;
            else
                groupBoxChannelName.Visible = false;
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
        }
    }
}
