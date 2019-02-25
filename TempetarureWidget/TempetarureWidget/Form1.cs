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
    public partial class Form1 : Form
    {
        private Point MouseDownPoint;
        private Manager manager;
        int i = 0;
        
        public Form1()
        {
            InitializeComponent();

            manager = new Manager();
            manager.SetTemperatureLabel += UpdateTemperatureLabel;
            manager.setUpdataDataLabel += UpdataDateTimeLabel;
            manager.ApiKey = "2W9E39YOZ0I2L5PL";
            manager.Channel = "685438";
        }

        private void UpdataDateTimeLabel(string value)
        {
            labelUpdateDate.Invoke(new Action(() => labelUpdateDate.Text = value));
        }

        private void UpdateTemperatureLabel(string value)
        {
            //labelTemp.Text = value;

            labelTemp.Invoke(new Action(() => labelTemp.Text = value + i++));
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                MouseDownPoint = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left = e.X + this.Left - MouseDownPoint.X;
                this.Top = e.Y + this.Top - MouseDownPoint.Y;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadSettings(AppSettings.Load());
            manager.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(this, manager);
            settings.ShowDialog(this);
        }

        public void loadSettings(AppSettings settings)
        {
            //TODO: poprawic to

            if (!string.IsNullOrEmpty(settings.api_key))
            {
                manager.ApiKey = settings.api_key;
                manager.Channel = settings.channel;
                manager.Field = settings.field;
                manager.RefreshTime = settings.refreshTime;
                this.BackColor = settings.color;
                this.Opacity = settings.opacity;
                labelUpdateDate.Visible = settings.dataVisable;
            }
        }
    }
}
