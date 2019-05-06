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
using System.IO;
using TempetarureWidget.forms;

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

        private AppSettings _appSettings;

        private  WidgetUC widgetUC;

        private WidgetForm()
        {
            InitializeComponent();


            BackColor = Color.Gray;

            _manager = new Manager();
            //_manager.SetTemperatureLabel += UpdateTemperatureLabel;
            //_manager.SetUpdataDataLabel += UpdataDateTimeLabel;
            //_manager.SetNameLabel += UpdateNameLabel;
            _manager.ShowNoConnIcon += ShowNoConnIcon;
        }

        public WidgetForm(Settings settings) : this()
        {
            widgetUC = new WidgetUC(settings);
            widgetUC.Location = new Point(0, 0);
            widgetUC.Widget_MouseUp += WidgetForm_MouseUp;
            widgetUC.Widget_MouseMove += Form1_MouseMove;
            widgetUC.Widget_MouseDown += Form1_MouseDown;

            this.Controls.Add(widgetUC);

            _manager.SetTemperatureLabel += widgetUC.UpdateTemperatureLabel;
            _manager.SetUpdataDataLabel += widgetUC.UpdataDateTimeLabel;
            _manager.SetNameLabel += widgetUC.UpdateNameLabel;
            widgetUC.ResizeWidgetEvent += ResizeWidget;

            widgetUC.Visible = true;
            widgetUC.Show();

            loadSettings(settings);
        }

        public WidgetForm(ref AppSettings appSettings, Settings settings) : this(settings)
        {
            _appSettings = appSettings;
        }

        private void ShowNoConnIcon(bool value)
        {
            pictureBoxNoConn.Invoke(new Action(() => pictureBoxNoConn.Visible = value));
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
            //if(!_settings.IsEmpty)
            if(!_settings.IsEmptyChannel)
                _settings.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!_settings.location.IsEmpty)
                Location = _settings.location;
            _manager.Start();
            
        }

        private void buttonOpenSettingsForm_Click(object sender, EventArgs e)
        {
  
            //SettingsForm settings = new SettingsForm(ref _settings);
            SettingsForm settings = new SettingsForm(ref _appSettings, ref _settings);
            var v = settings.ShowDialog(this);

            if (v == DialogResult.OK)
                loadSettings(_settings);
            else if (v == DialogResult.Abort)
                ExitWidget();

        }

        private void loadSettings(Settings settings)
        {
            widgetUC.loadSettings(settings);

            //if (!settings.IsEmpty)
            if (!settings.IsEmptyChannel)
            {
                _manager.ChangeSetting(settings);
                Opacity = settings.opacity;
            }
            else
            {
                settings.opacity = (float)Opacity;
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
            Width = widgetUC.Width;
            Height = widgetUC.Height;

            buttonSettings.Location = new Point(Width - buttonSettings.Width, buttonSettings.Location.Y);
            pictureBoxNoConn.Location = new Point(Width - pictureBoxNoConn.Width, buttonSettings.Height);
        }
    }
}
