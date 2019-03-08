using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Json;
using TempetarureWidget.DTO;
using TempetarureWidget.SettingsApp;

namespace TempetarureWidget
{
    public partial class WidgetForm : Form, IWidgetForm
    {
        public event Action<string> UpdateToolStripMenuItemText;
        public event Action RemoveToolStripMenuItem;

        private Point _mouseDownPoint;
        private IManager _manager;
        private Settings _settings;
        private string Name { get; set; }

        private WidgetForm()
        {
            InitializeComponent();
            BackColor = Color.Gray;

            _manager = new Manager();
            _manager.SetTemperatureLabel += UpdateTemperatureLabel;
            _manager.SetUpdataDataLabel += UpdataDateTimeLabel;
            _manager.SetNameLabel += UpdateNameLabel;
        }

        public WidgetForm(Settings settings) : this()
        {
            loadSettings(settings);
        }


        private void UpdateNameLabel(string channel, string field)
        {
            Name = channel + field;

            UpdateToolStripMenuItemText?.Invoke(channel + " " + field);

            if (labelName.IsHandleCreated)
            {

                if (_settings.channelNameVisable && _settings.fieldNameVisable)
                    labelName.Invoke(new Action(() => labelName.Text = channel + " " + field));
                else if (_settings.channelNameVisable)
                    labelName.Invoke(new Action(() => labelName.Text = channel));
                else if (_settings.fieldNameVisable)
                    labelName.Invoke(new Action(() => labelName.Text = field));
                else
                    labelName.Invoke(new Action(() => labelName.Text = ""));

                Invoke(new Action(() => ResizeWidget()));
            }
        }

        private void UpdataDateTimeLabel(string date, string time, string timeZone)
        {
            if (labelUpdateDate.InvokeRequired)
            {
                labelUpdateDate.Invoke(new Action(() => labelUpdateDate.Text = date + " " + time));
                Invoke(new Action(() => ResizeWidget()));
            }
        }

        private void UpdateTemperatureLabel(string value)
        {
            if (labelTemp.InvokeRequired)
            {
                labelTemp.Invoke(new Action(() => labelTemp.Text = value + " "  + (_settings.deegree != Deegree.User ? "\u00B0" + _settings.deegree.ToString() : _settings.unit)));// " \u00B0" + _settings.deegree.ToString()));
            }
        }

        

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _mouseDownPoint = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left = e.X + this.Left - _mouseDownPoint.X;
                this.Top = e.Y + this.Top - _mouseDownPoint.Y;
            }
        }
        private void WidgetForm_MouseUp(object sender, MouseEventArgs e)
        {
            _settings.location = new Point(Left, Top);
            if(!_settings.IsEmpty)
                _settings.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (_settings.IsEmpty)
            {
                labelTemp.Text = "Go to Settings ↗";
            }
            else
            {
                labelTemp.Text = "Loading...";
                labelName.Text = "";
                labelUpdateDate.Text = "";
            }
            ResizeWidget();
            if (!_settings.location.IsEmpty)
                Location = _settings.location;
            _manager.Start();
            
        }

        private void buttonOpenSettingsForm_Click(object sender, EventArgs e)
        {
            if (!_manager.InternetConnection)
                return;
            SettingsForm settings = new SettingsForm(ref _settings);
            var v = settings.ShowDialog(this);

            if (v == DialogResult.OK)
                loadSettings(_settings);
            else if (v == DialogResult.Abort)
                ExitWidget();

        }

        private void loadSettings(Settings settings)
        {
            if (!settings.IsEmpty)
            {
                _manager.ChangeSetting(settings);
                BackColor = settings.backColor;
                labelTemp.ForeColor = settings.textColor;
                labelUpdateDate.ForeColor = settings.textColor;
                labelName.ForeColor = settings.textColor;
                Opacity = settings.opacity;
                labelUpdateDate.Visible = settings.dateVisable;
                labelName.Visible = settings.nameVisable;
                labelName.Font = new Font(labelName.Font.FontFamily, settings.dateSize, labelName.Font.Style);
                labelUpdateDate.Font = new Font(labelUpdateDate.Font.FontFamily, settings.dateSize, labelUpdateDate.Font.Style);
                labelTemp.Font = new Font(labelTemp.Font.FontFamily, settings.temperatureSize, labelTemp.Font.Style);

                ResizeWidget();
            }
            else
            {
                settings.backColor = BackColor;
                settings.textColor = labelTemp.ForeColor;
                settings.opacity = (float)Opacity;
                settings.dateVisable = labelUpdateDate.Visible;
                settings.nameVisable = labelName.Visible;
                settings.dateSize = labelUpdateDate.Font.Size;
                settings.temperatureSize = labelTemp.Font.Size;
                settings.channelNameVisable = true;
                settings.fieldNameVisable = true;
            }
            _settings = settings;
        }

        public void ExitWidget()
        {
            _manager.Stop();
            RemoveToolStripMenuItem();
            this.Close();
            Dispose();
        }

        public void ShowSettings()
        {
            buttonOpenSettingsForm_Click(null, null);
        }

        private void ResizeWidget()
        {
            int pom = Math.Max(labelName.Visible ? labelName.Width + button2.Width : 0, labelUpdateDate.Visible ? labelUpdateDate.Width : 0);
            Width = Math.Max(labelTemp.Width, pom == 0 ? labelTemp.Width + button2.Width : pom );
            Height = labelTemp.Height + (labelName.Visible ? labelName.Height : 0) + (labelUpdateDate.Visible ? labelUpdateDate.Height : 0);

            labelName.Width = Width - button2.Width;
            labelUpdateDate.Width = Width;

            button2.Location = new Point(Width - button2.Width, button2.Location.Y);
            labelUpdateDate.Location = new Point((Width - labelUpdateDate.Width)/2, Height - labelUpdateDate.Height);
            labelTemp.Location = new Point((Width - labelTemp.Width)/2, (labelName.Visible ? labelName.Height : 0));
            labelName.Location = new Point((Width - button2.Width - labelName.Width) / 2, 0);
        }
    }
}
