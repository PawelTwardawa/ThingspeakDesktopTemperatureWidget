using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TempetarureWidget.SettingsApp;
using TempetarureWidget.DTO;

namespace TempetarureWidget.forms
{
    

    public partial class ChartUc : UserControl
    {
        private Settings _settings;

        public ChartUc()
        {
            InitializeComponent();
        }

        private void ChartUC_Load(object sender, EventArgs e)
        {
            Series lineSeria = chart.Series.Add("Data");
            //chart.ChartAreas[0].BackColor = Color.Blue;

            //chart.BackColor = Color.Blue;



            //lineSeria.Color = Color.Red;
            //lineSeria.BorderWidth = 5;

            List<Data<dynamic>> list = new List<Data<dynamic>>();
            list.Add(new Data<dynamic>() { value = "1", date = new DateTime(2019, 5, 5, 21, 20, 00) });
            list.Add(new Data<dynamic>() { value = "2.4", date = new DateTime(2019, 5, 5, 21, 30, 00) });
            list.Add(new Data<dynamic>() { value = "3.8", date = new DateTime(2019, 5, 5, 21, 40, 00) });
            list.Add(new Data<dynamic>() { value = "2", date = new DateTime(2019, 5, 5, 21, 50, 00) });
            list.Add(new Data<dynamic>() { value = "4,2", date = new DateTime(2019, 5, 5, 22, 00, 00) });

            //UpdateData(list);

            //lineSeria.ChartType = SeriesChartType.Line;
        }

        public void LoadSetting(Settings settings)
        {
            _settings = settings;
            if (settings.chartSettings != null)
            {
                chart.Series[0].ChartType = settings.chartSettings.ChartType;
                chart.Series[0].Color = settings.chartSettings.LineColor;
                chart.Series[0].BorderWidth = settings.chartSettings.LineWidth;
                chart.ChartAreas[0].AxisX.LabelStyle.Format = settings.chartSettings.DataLabelFormat;
                if (settings.chartSettings.TitleXVisable)
                    chart.ChartAreas[0].AxisX.Title = settings.chartSettings.TitleX;
                else
                    chart.ChartAreas[0].AxisX.Title = string.Empty;

                if (settings.chartSettings.TitleYVisable)
                    chart.ChartAreas[0].AxisY.Title = settings.chartSettings.TitleY;
                else
                    chart.ChartAreas[0].AxisY.Title = string.Empty;

            }
            else
            {
                chart.Series[0].ChartType = SeriesChartType.Line;
                chart.Series[0].Color = Color.Red;
                chart.Series[0].BorderWidth = 5;
            }

            chart.ChartAreas[0].BackColor = settings.backColor;
            
            chart.BackColor = settings.backColor;
        }

        public void UpdateData(List<Data<dynamic>> data)
        {
            //if (chart.InvokeRequired)
            //{
                chart.Invoke(new Action(() =>
                {
                    chart.Series[0].Points.Clear();

                    
                        switch (_settings.chartSettings.GroupType)
                        {
                            case ChartGroupType.None:
                            {
                                foreach (var i in data)
                                {
                                    chart.Series[0].Points
                                        .AddXY(i.date.ToString(chart.ChartAreas[0].AxisX.LabelStyle.Format), i.value);
                                }

                                break;
                            }

                            case ChartGroupType.Median:
                            {
                                for (int i = 0, j; i < data.Count; i += _settings.chartSettings.Median)
                                {
                                    List<double> list = new List<double>();

                                    for (j = 0; j < _settings.chartSettings.Median && i + j < data.Count; j++)
                                    {
                                        list.Add(double.Parse(((string)data[i + j].value).Replace('.', ',')));
                                    }
                                    list.Sort();
                                    chart.Series[0].Points
                                        .AddXY(
                                            data[i + (int)(j / 2)].date
                                                .ToString(chart.ChartAreas[0].AxisX.LabelStyle.Format), list[(int)list.Count/2]);
                                }
                                break;
                            }

                            case ChartGroupType.Average:
                            {
                                for (int i = 0, j ; i < data.Count; i += _settings.chartSettings.Average)
                                {
                                    double avg = 0;

                                    for (j = 0; j < _settings.chartSettings.Average && i+j < data.Count; j++)
                                    {
                                        avg += double.Parse(((string) data[i + j].value).Replace('.', ','));
                                    }
                                    
                                    avg /= _settings.chartSettings.Average;
                                    chart.Series[0].Points
                                        .AddXY(
                                            data[i + (int) (j / 2)].date
                                                .ToString(chart.ChartAreas[0].AxisX.LabelStyle.Format), avg);
                                }

                                break;
                            }

                        
                        
                    }
                }));

            //}
            //else
            //{
            //    chart.Series[0].Points.Clear();

            //    foreach (var i in data)
            //    {
            //        chart.Series[0].Points.AddXY(i.date.ToString(chart.ChartAreas[0].AxisX.LabelStyle.Format), i.value);
            //    }
            //}
            
        }
    }
}
