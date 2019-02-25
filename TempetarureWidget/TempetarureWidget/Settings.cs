using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private async void findField()
        {
            Manager manager = new Manager();
            manager.ApiKey = textBoxApi.Text;
            manager.Channel = textBoxChannel.Text;

            try
            {
                var data = await manager.AvailableFieldsAsync();
                comboBoxFields.DataSource = new BindingSource(data, null);
            }
            catch(System.Net.Http.HttpRequestException ex) when (ex.Message.Contains("404"))
            {
                comboBoxFields.DataSource = new List<string> { "not found" };
            }
            catch (System.Net.Http.HttpRequestException ex) when (ex.Message.Contains("400"))
            {
                comboBoxFields.DataSource = new List<string> { "not found" };
            }

        }

        private void Settings_LoadAsync(object sender, EventArgs e)
        {
            trackBarRefreshTime.Value = 60;

            textBoxApi.Text = _manager.ApiKey;
            textBoxChannel.Text = _manager.Channel;

            findField();

            checkBoxDateLabel.Checked = _parent.labelUpdateDate.Visible;

            //comboBoxFields.SelectedItem = 
                var c = comboBoxFields.FindString(_manager.Field.ToString());

            //settings.field = ((KeyValuePair<Fields, string>)comboBoxFields.SelectedItem).Key;



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

            colorDialog.Color = _parent.BackColor;
            buttonColor.BackColor = _parent.BackColor;
            trackBarTransparency.Value = (int)(_parent.Opacity * 100);

            

        }

        private void trackBarRefreshTime_ValueChanged(object sender, EventArgs e)
        {
            textBoxRefreshTime.Text = trackBarRefreshTime.Value.ToString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            AppSettings settings = new AppSettings();

            settings.api_key = textBoxApi.Text;
            settings.channel = textBoxChannel.Text;
            settings.field = ((KeyValuePair<Fields, string> )comboBoxFields.SelectedItem).Key;
            settings.color = colorDialog.Color;
            settings.dataVisable = checkBoxDateLabel.Checked;
            settings.opacity = (float)trackBarTransparency.Value / 100;

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

        private void buttonColor_Click(object sender, EventArgs e)
        {
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonColor.BackColor = colorDialog.Color;
            }
        }

        private void trackBarTransparency_ValueChanged(object sender, EventArgs e)
        {
            textBoxTransparency.Text = trackBarTransparency.Value.ToString();
        }

        private void textBoxChannel_TextChanged(object sender, EventArgs e)
        {
            findField();
        }
    }
}
