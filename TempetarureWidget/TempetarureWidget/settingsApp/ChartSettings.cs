using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace TempetarureWidget.SettingsApp
{
    public enum ChartGroupType
    {
        None, 
        Median,
        Average
    }

    public class ChartSettings
    {
        public bool Visable { get; set; }
        public Color LineColor { get; set; }
        public int NumberOfData { get; set; }
        public int NumberOfPoints { get; set; }
        public int LineWidth { get; set; }
        public SeriesChartType ChartType { get; set; } 
        public string TitleX { get; set; }
        public bool TitleXVisable { get; set; }
        public string TitleY { get; set; }
        public bool TitleYVisable { get; set; }
        public int Median { get; set; }
        public int Average { get; set; }
        public ChartGroupType GroupType { get; set; }
        public string DataLabelFormat { get; set; }

    }
}
