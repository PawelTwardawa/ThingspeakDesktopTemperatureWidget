using System;
using System.Drawing;
using System.Windows.Forms;
using TempetarureWidget.SettingsApp;

namespace TempetarureWidget.forms
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
        private ChartUc chartUc;

        private WidgetForm()
        {
            InitializeComponent();


            BackColor = Color.Gray;

            _manager = new Manager();
            //_manager.SetTemperatureLabel += UpdateTemperatureLabel;
            //_manager.SetUpdateDataLabel += UpdataDateTimeLabel;
            //_manager.SetNameLabel += UpdateNameLabel;
            _manager.ShowNoConnIcon += ShowNoConnIcon;
        }

        public WidgetForm(Settings settings) : this()
        {
            widgetUC = new WidgetUC(settings);
            widgetUC.Location = new Point(0, 0);
            widgetUC.ResizeWidgetEvent += ResizeWidget;
            widgetUC.UpdateToolStripMenuItemText += s => UpdateToolStripMenuItemText?.Invoke(s);
            widgetUC.Widget_MouseUp += WidgetForm_MouseUp;
            widgetUC.Widget_MouseMove += Form1_MouseMove;
            widgetUC.Widget_MouseDown += Form1_MouseDown;

            Controls.Add(widgetUC);

            chartUc = new ChartUc();
            chartUc.Location = new Point(widgetUC.Location.X, widgetUC.Location.Y + widgetUC.Height);
            chartUc.Chart_MouseDown += WidgetForm_MouseUp;
            chartUc.Chart_MouseMove += Form1_MouseMove;
            chartUc.Chart_MouseDown += Form1_MouseDown;
            chartUc.LoadSetting(settings);
            chartUc.Visible = false;
            
            if(settings.ChartSettings != null)
                if (settings.ChartSettings.Visable)
                    chartUc.Visible = true;
                else
                    chartUc.Visible = false;
            _manager.SetData += chartUc.UpdateData;

            Controls.Add(chartUc);

            _manager.SetTemperatureLabel += widgetUC.UpdateTemperatureLabel;
            //_manager.SetUpdateDataLabel += widgetUC.UpdataDateTimeLabel;
            _manager.SetUpdateDataLabel += widgetUC.UpdataDateTimeLabel;
            _manager.SetNameLabel += widgetUC.UpdateNameLabel;
            

            widgetUC.Visible = true;
            widgetUC.Show();

            LoadSettings(settings);
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
                Left = e.X + Left - _mouseDownPoint.X;
                Top = e.Y + Top - _mouseDownPoint.Y;
            }
        }
        private void WidgetForm_MouseUp(object sender, MouseEventArgs e)
        {
            _settings.Location = new Point(Left, Top);
            //if(!_settings.IsEmpty)
            if(!_settings.IsEmptyChannel)
                _settings.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!_settings.Location.IsEmpty)
                Location = _settings.Location;
            _manager.Start();
            
        }

        private void buttonOpenSettingsForm_Click(object sender, EventArgs e)
        {
  
            //SettingsForm settings = new SettingsForm(ref _settings);
            SettingsForm settings = new SettingsForm(ref _appSettings, ref _settings);
            var v = settings.ShowDialog(this);

            if (v == DialogResult.OK)
                LoadSettings(_settings);
            else if (v == DialogResult.Abort)
                ExitWidget();

        }

        private void LoadSettings(Settings settings)
        {
            widgetUC.loadSettings(settings);
            chartUc.LoadSetting(settings);

            if (settings.ChartSettings != null)
            {
                if (settings.ChartSettings.Visable)
                {
                    chartUc.Visible = true;
                }
                else
                {
                    chartUc.Visible = false;
                }
            }

            //if (!settings.IsEmpty)
            if (!settings.IsEmptyChannel)
            {
                _manager.ChangeSetting(settings);
                Opacity = settings.Opacity;
            }
            else
            {
                settings.Opacity = (float)Opacity;
            }
            _settings = settings;
        }

        public void ExitWidget()
        {
            _manager.Stop();
            RemoveToolStripMenuItem?.Invoke();
            Close();
            Dispose();
        }

        public void ShowSettings()
        {
            buttonOpenSettingsForm_Click(null, null);
        }

        private void ResizeWidget()
        {
            chartUc.Width = widgetUC.Width;
            chartUc.Height = chartUc.Width / 2;
            chartUc.Location = new Point(widgetUC.Location.X, widgetUC.Height);

            Width = widgetUC.Width;
            Height = !chartUc.Visible ? widgetUC.Height : widgetUC.Height + chartUc.Height;

            buttonSettings.Location = new Point(Width - buttonSettings.Width, buttonSettings.Location.Y);
            pictureBoxNoConn.Location = new Point(Width - pictureBoxNoConn.Width, buttonSettings.Height);
        }
    }
}
