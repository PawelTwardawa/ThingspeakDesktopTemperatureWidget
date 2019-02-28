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
        //int i = 0;
        internal Deegree deegree;
        internal AppSettings appSettings;
        
        public Form1()
        {
            InitializeComponent();

            manager = new Manager();
            manager.SetTemperatureLabel += UpdateTemperatureLabel;
            manager.setUpdataDataLabel += UpdataDateTimeLabel;
        }

        private void UpdataDateTimeLabel(string value)
        {
            if (labelUpdateDate.InvokeRequired)
            {
                labelUpdateDate.Invoke(new Action(() => labelUpdateDate.Text = value));
                Invoke(new Action(() => updateName()));
                Invoke(new Action(() => ResizeWidget()));
            }
        }

        private void UpdateTemperatureLabel(string value)
        {
            //labelTemp.Text = value;
            if (labelTemp.InvokeRequired)
            {
                labelTemp.Invoke(new Action(() => labelTemp.Text = value /*+ i++*/ + " \u00B0" + deegree.ToString()));
            }
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
            //updateName();
        }

        private void buttonOpenSettingsForm_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(this, manager);
            settings.ShowDialog(this);
        }

        public void loadSettings(AppSettings settings)
        {
            //TODO: poprawic to

            if (!string.IsNullOrEmpty(settings.api_key))
            {
                appSettings = settings;
                deegree = settings.deegree;
                manager.ApiKey = settings.api_key;
                manager.Channel = settings.channel;
                manager.Field = settings.field;
                manager.RefreshTime = settings.refreshTime;
                this.BackColor = settings.backColor;
                labelTemp.ForeColor = settings.textColor;
                labelUpdateDate.ForeColor = settings.textColor;
                labelName.ForeColor = settings.textColor;
                this.Opacity = settings.opacity;
                labelUpdateDate.Visible = settings.dateVisable;
                labelName.Visible = settings.nameVisable;
                labelName.Font = new Font(labelName.Font.FontFamily, settings.dateSize, labelName.Font.Style);
                labelUpdateDate.Font = new Font(labelUpdateDate.Font.FontFamily, settings.dateSize, labelUpdateDate.Font.Style);
                labelTemp.Font = new Font(labelTemp.Font.FontFamily, settings.temperatureSize, labelTemp.Font.Style);

                updateName();
                ResizeWidget();
            }
        }

        private void updateName()
        {
            if (appSettings.channelNameVisable && appSettings.fieldNameVisable)
                labelName.Text = manager.channelName() + " " + manager.fieldName();
            else if (appSettings.channelNameVisable)
                labelName.Text = manager.channelName();
            else if (appSettings.fieldNameVisable)
                labelName.Text = manager.fieldName();
            //else
                //labelName.Text = "";
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
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

            
            //}
            //else
            //{
            //    //labelTemp.AutoSize = false;
            //}
        }
    }
}
