using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TempetarureWidget.SettingsApp;
using TempetarureWidget.DTO;
using TempetarureWidget.DTOs;

namespace TempetarureWidget.forms
{
    

    public partial class ChartUc : UserControl
    {
        private Settings _settings;

        public event Action<object, MouseEventArgs> Chart_MouseUp;
        public event Action<object, MouseEventArgs> Chart_MouseDown;
        public event Action<object, MouseEventArgs> Chart_MouseMove;

        public ChartUc()
        {
            InitializeComponent();
        }

        private void ChartUC_Load(object sender, EventArgs e)
        {
            chart.Series.Add("Data");
            chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Solid;
            chart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 1;
            chart.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart.ChartAreas[0].AxisX.MinorGrid.LineWidth = 1;


        }

        public void LoadSetting(Settings settings)
        {
            _settings = settings;
            if (settings.ChartSettings != null)
            {
                chart.Series[0].ChartType = settings.ChartSettings.ChartType;
                chart.Series[0].Color = settings.ChartSettings.LineColor;
                chart.Series[0].BorderWidth = settings.ChartSettings.LineWidth;
                chart.ChartAreas[0].AxisX.LabelStyle.Format = settings.ChartSettings.DataLabelFormat;
                if (settings.ChartSettings.TitleXVisable)
                    chart.ChartAreas[0].AxisX.Title = settings.ChartSettings.TitleX;
                else
                    chart.ChartAreas[0].AxisX.Title = string.Empty;

                if (settings.ChartSettings.TitleYVisable)
                    chart.ChartAreas[0].AxisY.Title = settings.ChartSettings.TitleY;
                else
                    chart.ChartAreas[0].AxisY.Title = string.Empty;

            }
            else
            {
                chart.Series[0].ChartType = SeriesChartType.Line;
                chart.Series[0].Color = Color.Red;
                chart.Series[0].BorderWidth = 5;
            }

            chart.ChartAreas[0].BackColor = settings.BackColor;
            
            chart.BackColor = settings.BackColor;
        }

        public void UpdateData(List<Data<dynamic>> data)
        {
            //if (chart.InvokeRequired)
            //{
                chart.Invoke(new Action(() =>
                {
                    chart.Series[0].Points.Clear();

                    
                        switch (_settings.ChartSettings.GroupType)
                        {
                            case ChartGroupType.None:
                            {
                                chart.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep45;


                                foreach (var i in data)
                                {
                                    chart.Series[0].Points
                                        .AddXY(i.date.ToString(chart.ChartAreas[0].AxisX.LabelStyle.Format), i.value);
                                }

                                

                                break;
                            }

                            case ChartGroupType.Median:
                            {
                                for (int i = 0, j; i < data.Count; i += _settings.ChartSettings.Median)
                                {
                                    List<double> list = new List<double>();

                                    for (j = 0; j < _settings.ChartSettings.Median && i + j < data.Count; j++)
                                    {
                                        list.Add(double.Parse(((string)data[i + j].value).Replace('.', ',')));
                                    }
                                    list.Sort();
                                    chart.Series[0].Points
                                        .AddXY(
                                            data[i + j / 2].date
                                                .ToString(chart.ChartAreas[0].AxisX.LabelStyle.Format), list[list.Count/2]);
                                }
                                break;
                            }

                            case ChartGroupType.Average:
                            {
                                for (int i = 0, j ; i < data.Count; i += _settings.ChartSettings.Average)
                                {
                                    double avg = 0;

                                    for (j = 0; j < _settings.ChartSettings.Average && i+j < data.Count; j++)
                                    {
                                        avg += double.Parse(((string) data[i + j].value).Replace('.', ','));
                                    }
                                    
                                    avg /= _settings.ChartSettings.Average;
                                    chart.Series[0].Points
                                        .AddXY(
                                            data[i + j / 2].date
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

        private void ChartUc_MouseDown(object sender, MouseEventArgs e)
        {
            Chart_MouseDown?.Invoke(sender, e);
        }

        private void ChartUc_MouseMove(object sender, MouseEventArgs e)
        {
            Chart_MouseMove?.Invoke(sender, e);
        }

        private void ChartUc_MouseUp(object sender, MouseEventArgs e)
        {
            Chart_MouseUp?.Invoke(sender, e);
        }
    }
}
