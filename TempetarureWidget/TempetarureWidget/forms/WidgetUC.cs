using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TempetarureWidget.SettingsApp;

namespace TempetarureWidget.forms
{
    public partial class WidgetUC : UserControl
    {
        private Settings _settings;
        private string Name { get; set; }

        public event Action ResizeWidgetEvent;
        public event Action<string> UpdateToolStripMenuItemText;

        public event Action<object, MouseEventArgs> Widget_MouseUp;
        public event Action<object, MouseEventArgs> Widget_MouseDown;
        public event Action<object, MouseEventArgs> Widget_MouseMove;

        public WidgetUC()
        {
            InitializeComponent();
        }

        public WidgetUC(Settings settings) : this()
        {
            loadSettings(settings);          
        }

        public void UpdateNameLabel(string channel, string field)
        {
            Name = channel + field;

            UpdateToolStripMenuItemText?.Invoke(channel + " " + field);

            if (labelName.IsHandleCreated)
            {

                if (_settings.ChannelNameVisable && _settings.FieldNameVisable)
                    labelName.Invoke(new Action(() => labelName.Text = channel + " " + field));
                else if (_settings.ChannelNameVisable)
                    labelName.Invoke(new Action(() => labelName.Text = channel));
                else if (_settings.FieldNameVisable)
                    labelName.Invoke(new Action(() => labelName.Text = field));
                else
                    labelName.Invoke(new Action(() => labelName.Text = ""));

                Invoke(new Action(() => ResizeWidget()));
            }
        }

        public void UpdataDateTimeLabel(DateTime date)
        {
            if (labelUpdateDate.InvokeRequired)
            {
                labelUpdateDate.Invoke(new Action(() => labelUpdateDate.Text = date.ToString()));
                Invoke(new Action(() => ResizeWidget()));
            }
        }

        public void UpdataDateTimeLabel(string date, string time, string timeZone)
        {
            if (labelUpdateDate.InvokeRequired)
            {
                labelUpdateDate.Invoke(new Action(() => labelUpdateDate.Text = date + " " + time));
                Invoke(new Action(() => ResizeWidget()));
            }
        }

        public void UpdateTemperatureLabel(string value)
        {
            if (labelTemp.InvokeRequired)
            {
                labelTemp.Invoke(new Action(() => labelTemp.Text = value + " " + (_settings.Deegree != Deegree.User ? "\u00B0" + _settings.Deegree.ToString() : _settings.Unit)));// " \u00B0" + _settings.deegree.ToString()));
                Invoke(new Action(() => ResizeWidget()));
            }
            else
            {
                labelTemp.Text = value + " " + (_settings.Deegree != Deegree.User ? "\u00B0" + _settings.Deegree.ToString() : _settings.Unit);
            }
        }

        public void loadSettings(Settings settings)
        {
            if (!settings.IsEmptyChannel)
            {
                BackColor = settings.BackColor;
                labelTemp.ForeColor = settings.TextColor;
                labelUpdateDate.ForeColor = settings.TextColor;
                labelName.ForeColor = settings.TextColor;
                labelUpdateDate.Visible = settings.DateVisable;
                labelName.Visible = settings.NameVisable;
                labelName.Font = new Font(labelName.Font.FontFamily, settings.DateSize, labelName.Font.Style);
                labelUpdateDate.Font = new Font(labelUpdateDate.Font.FontFamily, settings.DateSize, labelUpdateDate.Font.Style);
                labelTemp.Font = new Font(labelTemp.Font.FontFamily, settings.TemperatureSize, labelTemp.Font.Style);

                ResizeWidget();
            }
            else
            {
                settings.BackColor = BackColor;
                settings.TextColor = labelTemp.ForeColor;
                settings.DateVisable = labelUpdateDate.Visible;
                settings.NameVisable = labelName.Visible;
                settings.DateSize = labelUpdateDate.Font.Size;
                settings.TemperatureSize = labelTemp.Font.Size;
                settings.ChannelNameVisable = true;
                settings.FieldNameVisable = true;
            }
            _settings = settings;
        }

        private void ResizeWidget()
        {
            int pom = Math.Max(labelName.Visible ? labelName.Width + 20 : 0, labelUpdateDate.Visible ? labelUpdateDate.Width : 0);
            Width = Math.Max(labelTemp.Width, pom == 0 ? labelTemp.Width + 20 : pom);
            Height = labelTemp.Height + (labelName.Visible ? labelName.Height : 0) + (labelUpdateDate.Visible ? labelUpdateDate.Height : 0);

            labelName.Width = Width - 20;
            labelUpdateDate.Width = Width;

            labelUpdateDate.Location = new Point((Width - labelUpdateDate.Width) / 2, Height - labelUpdateDate.Height);
            labelTemp.Location = new Point((Width - labelTemp.Width) / 2, (labelName.Visible ? labelName.Height : 0));
            labelName.Location = new Point((Width - 20 - labelName.Width) / 2, 0);

            ResizeWidgetEvent?.Invoke();
        }

        private void WidgetUC_Load(object sender, EventArgs e)
        {
            if (_settings == null)
                return;

            if (_settings.IsEmptyChannel)
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
        }

        private void WidgetUC_MouseDown(object sender, MouseEventArgs e)
        {
            Widget_MouseDown?.Invoke(sender, e);
        }

        private void WidgetUC_MouseMove(object sender, MouseEventArgs e)
        {
            Widget_MouseMove?.Invoke(sender, e);
        }

        private void WidgetUC_MouseUp(object sender, MouseEventArgs e)
        {
            Widget_MouseUp?.Invoke(sender, e);
        }
    }
}
