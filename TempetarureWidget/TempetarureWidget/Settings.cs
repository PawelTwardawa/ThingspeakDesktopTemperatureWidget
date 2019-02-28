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
    public partial class Settings : Form
    {
        private Form1 _parent;
        private Manager _manager;

        public Settings(Form1 parent, Manager manager)
        {
            _manager = manager;
            this._parent = parent;
            InitializeComponent();


        }

        private  async Task<Dictionary<Fields, string>> fillComboBoxField(Manager manager)
        {
            try
            {
                var data = await manager.AvailableFieldsAsync();
                comboBoxFields.DataSource = new BindingSource(data, null);
                return data;
            }
            catch(System.Net.Http.HttpRequestException ex) when (ex.Message.Contains("404") || ex.Message.Contains("400"))
            {
                comboBoxFields.DataSource = new List<string> { "not found" };
            }

            return null;

        }

        private async void Settings_LoadAsync(object sender, EventArgs e)
        {
            trackBarRefreshTime.Value = 60;
            comboBoxRefreshTimeUnit.SelectedText = "s";
            trackBarTransparency.Value = 100;
            numericUpDownDateSize.Value = numericUpDownDateSize.Maximum;
            numericUpDownTemperatureSize.Value = numericUpDownTemperatureSize.Maximum;

            
            switch (_parent.deegree)
                {
                    case Deegree.C:
                        {
                            radioButtonCelsius.Checked = true;
                            break;
                        }
                    case Deegree.F:
                        {
                            radioButtonFahrentheit.Checked = true;
                            break;
                        }
                }


                textBoxApi.Text = _manager.ApiKey;
                textBoxChannel.Text = _manager.Channel;
                labelTempratureSize.Font = new Font(labelTempratureSize.Font.FontFamily, (_parent.labelTemp.Font.Size > 80 ? 80 : _parent.labelTemp.Font.Size), labelTempratureSize.Font.Style);
                numericUpDownTemperatureSize.Value = (decimal)_parent.labelTemp.Font.Size;
                labelDateSize.Font = new Font(labelDateSize.Font.FontFamily, (_parent.labelUpdateDate.Font.Size > 80 ? 80 : _parent.labelUpdateDate.Font.Size), labelDateSize.Font.Style);
                numericUpDownDateSize.Value = (decimal)_parent.labelUpdateDate.Font.Size;

                
                checkBoxRunWithWindows.CheckedChanged += checkBoxRunWithWindows_CheckedChanged;
                
                checkBoxDateLabel.Checked = _parent.labelUpdateDate.Visible;
                checkBoxShowName.Checked = _parent.labelName.Visible;
                groupBoxChannelName.Visible = _parent.labelName.Visible;

                if (_manager.RefreshTime >= 1000 && _manager.RefreshTime < 60000)
                {
                    trackBarRefreshTime.Value = _manager.RefreshTime / 1000;
                    comboBoxRefreshTimeUnit.SelectedItem = "s";
                }
                else if (_manager.RefreshTime >= 60000 && _manager.RefreshTime < 3600000)
                {
                    trackBarRefreshTime.Value = _manager.RefreshTime / 60000;
                    comboBoxRefreshTimeUnit.SelectedItem = "m";
                }
                else if (_manager.RefreshTime >= 3600000 && _manager.RefreshTime < 216000000)
                {
                    trackBarRefreshTime.Value = _manager.RefreshTime / 3600000;
                    comboBoxRefreshTimeUnit.SelectedItem = "h";
                }


            colorDialogBackground.Color = _parent.BackColor;
            buttonBackColor.BackColor = _parent.BackColor;
            colorDialogText.Color = _parent.labelTemp.ForeColor;
            buttonTextColor.BackColor = _parent.labelTemp.ForeColor;

            trackBarTransparency.Value = (int)(_parent.Opacity * 100);

            if (_parent.appSettings != null)
            {
                checkBoxChannelName.Checked = _parent.appSettings.channelNameVisable;
                checkBoxFieldName.Checked = _parent.appSettings.fieldNameVisable;
                checkBoxRunWithWindows.Checked = _parent.appSettings.runWithWindows;
                Dictionary<Fields, string> data = await fillComboBoxField(_manager);
                comboBoxFields.SelectedIndex = data.Keys.ToList().IndexOf(_manager.Field);
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
            AppSettings settings = new AppSettings();

            settings.api_key = textBoxApi.Text;
            settings.channel = textBoxChannel.Text;
            try
            {
                settings.field = ((KeyValuePair<Fields, string>)comboBoxFields.SelectedItem).Key;
            }
            catch(InvalidCastException ex)
            {
                MessageBox.Show("Cannot save with incorrect field name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            settings.runWithWindows = checkBoxRunWithWindows.Checked;

            if (radioButtonCelsius.Checked)
                settings.deegree = Deegree.C;
            else if (radioButtonFahrentheit.Checked)
                settings.deegree = Deegree.F;

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

            settings.Save();

            _parent.loadSettings(settings);

            this.Close();
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
          fillComboBoxField(new Manager { ApiKey = textBoxApi.Text, Channel = textBoxChannel.Text });
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

        private void checkBoxRunWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            var path = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(path, true);
            if (checkBoxRunWithWindows.Checked)
            {
                key.SetValue(Path.GetFileName(Application.ExecutablePath), Application.ExecutablePath.ToString());
            }
            else
            {
                key.DeleteValue(Path.GetFileName(Application.ExecutablePath), false);
            }
        }
    }
}
